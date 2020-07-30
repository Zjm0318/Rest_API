using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            string sql = $"select o.*,m.* from tb_order o JOIN tb_orderdetail d on o.Order_Id=d.Order_Id join tb_menu m on m.M_Id=d.Menu_Id where o.User_Id='{uid}'";
            
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
            string sql = $"select * from tb_order od JOIN tb_orderdetail o ON od.Order_Id=o.Order_Id join tb_menu m on o.Menu_Id=m.M_Id where o.Order_Id={oid}";
            
            DataTable tb = db.ExcuteSql(sql);
            string json = JsonConvert.SerializeObject(tb);
            return JsonConvert.DeserializeObject<List<tb_OrderDetail>>(json);
        }

        //添加订单
        public int AddOrder(tb_Order orders, List<tb_Menu> m)
        {
            string Number = "";
            Number = "DH " + DateTime.Now.ToString("yyyyMMddHHmmss");
            orders.Order_Dan = DateTime.Now;
            string sql = $"insert into tb_order(Order_Num,User_Id,Desk_Id,Order_YingFu,Order_Price,Order_State,Order_YouHuiId,Order_YouHui,Order_fs,Order_Dan) VALUES('{Number}','{orders.User_Id}','1',{orders.Order_YingFu},'{orders.Order_Price}','0',{orders.Order_YouHuiId},{orders.Order_YouHui},'微信','{orders.Order_Dan}')";
            int c = db.ExcuteNonQuery(sql);
            int oid = 0;
            int s1 = 0;
            if (c > 0)
            {
                string sql1 = "select * from tb_order";
                DataTable tb = db.ExcuteSql(sql1);
                List<tb_Order> list = JsonConvert.DeserializeObject<List<tb_Order>>(JsonConvert.SerializeObject(tb)).ToList();

                oid = (from s in list orderby s.Order_Dan descending select s).FirstOrDefault().Order_Id;

                foreach (var item in m)
                {
                    string sql2 = $"insert into tb_orderdetail(Order_Id,Menu_Id,MenuNum) values('{oid}','{item.M_Id}','{item.CarNum}')";
                    s1 += db.ExcuteNonQuery(sql2);
                }

            }
            if (s1 == m.Count)
            {
                return oid;
            }
            else if (s1 == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }


        }

        //显示优惠券

        public List<tb_Coupon> GetCoupon(string ids)
        {
            string procname = "prcCoupontss";
            MySqlParameter[] mySqlParameters = new MySqlParameter[] {
             new MySqlParameter{ ParameterName="Ids",Value=ids,DbType=DbType.String,Direction=ParameterDirection.Input },

            };
            DataTable tb = db.ExecuteSql_Proc(procname, mySqlParameters);
            //转成字符串类型
            return JsonConvert.DeserializeObject<List<tb_Coupon>>(JsonConvert.SerializeObject(tb)).ToList();
        }

        //优惠券状态修改
        public int UpdateQuan(string openid, int quanId)
        {

            string proc = "UpdateQuan";
            MySqlParameter[] mySqlParameters = new MySqlParameter[] {
            new MySqlParameter{ParameterName="openid",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=openid },
            new MySqlParameter{ParameterName="youhuiId",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=quanId }

            };
            return db.ExecuteNonQuery_Proc(proc, mySqlParameters);
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
