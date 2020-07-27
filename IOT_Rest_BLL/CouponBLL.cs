using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using IOT_Rest_Model.DBModels;
using System.Linq;

namespace IOT_Rest_BLL
{
    public class CouponBLL
    {
        private string Connection = "server=192.168.0.192;User Id=root;password=1234;Database=restaurant";

        /// <summary>
        /// 显示优惠券
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<tb_Coupon> ShowCoupon(int flag, string openid)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                //判断openid是否为空
                //openid==空
                if (string.IsNullOrEmpty(openid))
                {
                    //使优惠券都为可领取状态
                    conn.Execute("update restaurant.tb_coupon set Coupon_State=0");

                    //返回所有优惠券
                    return conn.Query<tb_Coupon>("select * from restaurant.tb_coupon where Coupon_EndTime>NOW()").ToList();
                }
                //openid不为空
                else
                {
                    //根据openid获取用户所拥有的优惠券编号
                    var cid = conn.Query<tb_UserAndCoupon>($"select uc.Coupon_Id from tb_userandcoupon uc join tb_coupon cp on uc.Coupon_Id = cp.Coupon_Id where uc.User_Id = '{openid}'").ToList();

                    //所有的优惠券信息
                    List<tb_Coupon> list = conn.Query<tb_Coupon>("select * from restaurant.tb_coupon where Coupon_EndTime>NOW()").ToList();

                    //遍历所有的优惠券
                    foreach (var item in list)
                    {
                        //如果用户没有领取优惠券
                        if (cid.Count == 0)
                        {
                            //所有的优惠券为可领取状态
                            conn.Execute($"update restaurant.tb_coupon set Coupon_State=0 where Coupon_Id={item.Coupon_Id}");
                        }
                        else
                        {
                            //遍历用户已有的优惠券
                            foreach (var item1 in cid)
                            {
                                //如果用户已有的优惠券==所有的优惠券中的之一
                                if (item.Coupon_Id == item1.Coupon_Id)
                                {
                                    //使该优惠券为已领取状态
                                    conn.Execute($"update restaurant.tb_coupon set Coupon_State=1 where Coupon_Id={item.Coupon_Id}");
                                }
                            }
                        }
                    }
                    //flag==0显示全部优惠券
                    if (flag == 0)
                    {
                        return list;
                    }
                    //显示前两条
                    else
                    {
                        return conn.Query<tb_Coupon>("select * from restaurant.tb_coupon where Coupon_EndTime>NOW() limit 0,2").ToList();
                    }
                }
            }
        }

        /// <summary>
        /// 领取优惠券
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public int LingQu(int UId, string openid)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                //判断Openid是否为空
                if (string.IsNullOrEmpty(openid))
                {
                    return 0;
                }
                else
                {
                    //使该优惠券的数量减1
                    var code = conn.Execute($"update restaurant.tb_coupon set Coupon_Num=Coupon_Num-1 where Coupon_Id={UId}");
                    if (code > 0)
                    {
                        //添加该用户信息和优惠券信息
                        return conn.Execute($"insert into tb_userandcoupon(User_Id,Coupon_Id) VALUES ('{openid}','{UId}')");
                    }
                    else
                    {
                        return 0;
                    }
                }               
            }

        }
    }
}
