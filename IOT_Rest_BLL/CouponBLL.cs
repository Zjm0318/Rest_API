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
        private string Connection = "server=192.168.0.139;User Id=root;password=123456;Database=restaurant";

        public List<tb_Coupon> ShowCoupon()
        {
            using (MySqlConnection conn=new MySqlConnection(Connection))
            {
                return conn.Query<tb_Coupon>("select * from tb_Coupon").ToList();
            }
        }
    }
}
