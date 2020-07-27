using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IOT_Rest_DAL.DBHelp;
using IOT_Rest_Model.DBModels;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace IOT_Rest_BLL
{
    public class OrderBLL
    {
        DBHelper db = new DBHelper();

        //显示订单
        public List<tb_OrderDetail> OrderList(string uid)
        {
            string sql = $"select o.*,m.* from tb_order o JOIN tb_orderdetail d on o.Order_Id=d.Order_Id join tb_menu m on m.M_Id=d.Menu_Id where o.User_Id="+uid;
            
            DataTable tb = db.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<tb_OrderDetail>>(json);
        }
        
        //修改状态
        public int UpdOrder(int oid, int sta)
        {
            string sql = $"update tb_order set Order_State={sta} where Order_Id={oid}";
            return db.ExcuteNonQuery(sql);
        }

        //显示订单详情
        public List<tb_OrderDetail> ShowOrderDetail(int oid)
        {
            string sql = $"select * from tb_order od JOIN tb_orderdetail o ON od.Order_Id=o.Order_Id join tb_menu m on o.Menu_Id=m.M_Id where o.Order_Id="+oid;
            
            DataTable tb = db.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<tb_OrderDetail>>(json);
        }

        //删除订单
        public int DelOrder(int oid)
        {
            string proc = "Del_Order";
            MySqlParameter[] mySqlParameters = new MySqlParameter[] {
                new MySqlParameter{ParameterName="oid",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=oid }
            };
            return db.ExecuteNonQuery_Proc(proc, mySqlParameters);
        }

    }
}
