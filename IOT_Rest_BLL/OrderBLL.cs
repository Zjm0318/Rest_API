using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IOT_Rest_DAL.DBHelp;
using IOT_Rest_Model.DBModels;
using Newtonsoft.Json;

namespace IOT_Rest_BLL
{
    public class OrderBLL
    {
        DBHelper db = new DBHelper();

        //显示订单
        public List<tb_OrderDetail> OrderList(int sta)
        {
            string sql = $"select o.Order_Id,m.M_Name,m.M_Img,o.Order_Price,o.Order_State from tb_order o JOIN tb_orderdetail d on o.Order_Id=d.Order_Id join tb_menu m on m.M_Id=d.Menu_Id";
            if(sta!=-1)
            {
                sql+=$" where Order_State="+sta;
            }
            DataTable tb = db.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<tb_OrderDetail>>(json);
        }
        
    }
}
