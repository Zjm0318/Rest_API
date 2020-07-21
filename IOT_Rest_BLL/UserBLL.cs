using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IOT_Rest_DAL;
using IOT_Rest_DAL.ADO.Net;
using IOT_Rest_Model.DBModels;
using Newtonsoft.Json;

namespace IOT_Rest_BLL
{
   public class UserBLL
    {
        ADONetHelper dbhelp = new ADONetHelper();

        //优惠券显示 未过期的
        public List<tb_Coupon> GetUserCoupon()
        {
            string sql = @"select cp.Coupon_Name,cp.Coupon_Money,cp.Coupon_Tj,cp.Coupon_EndTime,cp.Coupon_Num 
                                    from tb_user us join tb_userandcoupon uc  on us.OpenId = uc.User_Id join tb_coupon cp on uc.Coupon_Id = cp.Coupon_Id
                                    where us.OpenId = 'ohnLO4oq9ISJEXu1ZpXJOhYT7oWg' and uc.Coupon_State = 1";

            DataTable tb= dbhelp.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            List<tb_Coupon> list = JsonConvert.DeserializeObject<List<tb_Coupon>>(json);
            return list;
        }

        //查询已过期或已使用的优惠券
        public List<tb_Coupon> GetUserCoupon2()
        {
            string sql = @"select cp.Coupon_Name,cp.Coupon_Money,cp.Coupon_Tj,cp.Coupon_EndTime,cp.Coupon_Num 
                                    from tb_user us join tb_userandcoupon uc  on us.OpenId = uc.User_Id join tb_coupon cp on uc.Coupon_Id = cp.Coupon_Id
                                    where us.OpenId = 'ohnLO4oq9ISJEXu1ZpXJOhYT7oWg' and uc.Coupon_State =0 or uc.Coupon_State=2";

            DataTable tb = dbhelp.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            List<tb_Coupon> list = JsonConvert.DeserializeObject<List<tb_Coupon>>(json);
            return list;
        }
    }
}
