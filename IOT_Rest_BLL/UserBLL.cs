using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IOT_Rest_DAL;
using IOT_Rest_DAL.DBHelp;
using IOT_Rest_Model.DBModels;
using Newtonsoft.Json;

namespace IOT_Rest_BLL
{
   public class UserBLL
    {
        DBHelper dbhelp = new DBHelper();

        //优惠券显示 未过期的
        public List<tb_Coupon> GetUserCoupon(int flag,int flag1)
        {
            string sql = $"select cp.*,uc.Coupon_States from tb_user us join tb_userandcoupon uc  on us.OpenId = uc.User_Id join tb_coupon cp on uc.Coupon_Id = cp.Coupon_Id where us.OpenId = 'o25Ne5ZEqb2WGO3x9-z1UaQ-sYp4' and uc.Coupon_States = {flag} or uc.Coupon_States = {flag1}";

            DataTable tb= dbhelp.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            List<tb_Coupon> list = JsonConvert.DeserializeObject<List<tb_Coupon>>(json);
            return list;
        }
    }
}
