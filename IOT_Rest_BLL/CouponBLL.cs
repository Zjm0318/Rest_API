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
        public List<tb_Coupon> ShowCoupon(int flag)
        {
            using (MySqlConnection conn=new MySqlConnection(Connection))
            {
                if (flag==0)
                {
                    return conn.Query<tb_Coupon>("select * from restaurant.tb_coupon where Coupon_EndTime>NOW()").ToList();       
                }
                else if(flag==1)
                {
                    return conn.Query<tb_Coupon>("select * from restaurant.tb_coupon where Coupon_EndTime>NOW() limit 0,2").ToList();
                }
                else
                {
                    return conn.Query<tb_Coupon>("select * from restaurant.tb_coupon where Coupon_EndTime<NOW()").ToList();
                }
            }           
        }

        /// <summary>
        /// 领取优惠券
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public int LingQu(int UId)
        {
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                var code = conn.Execute($"update restaurant.tb_coupon set Coupon_Num=Coupon_Num-1 where Coupon_Id={UId}");
                if (code>0)
                {
                    return conn.Execute($"update restaurant.tb_coupon set Coupon_State=1 where Coupon_Id={UId}");
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
