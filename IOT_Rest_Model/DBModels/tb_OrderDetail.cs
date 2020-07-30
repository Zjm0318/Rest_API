using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Rest_Model.DBModels
{
	 public class tb_OrderDetail
	 {
		 public int  Detail_Id { get; set; }
		 public int  Order_Id { get; set; }
		public string Order_Num { get; set; }
		public string User_Id { get; set; }
		public int Desk_Id { get; set; }
		public decimal Order_Price { get; set; }
		public decimal Order_YingFu { get; set; }
		public int Order_YouHuiId { get; set; }
		public int Order_YouHui { get; set; }
		public int Order_State { get; set; }
		public string Order_fs { get; set; }   //支付方式
		public DateTime Order_Sate { get; set; }  //支付时间
		public DateTime Order_Dan { get; set; }    //下单时间
		public int  Menu_Id { get; set; }
		public string M_Name { get; set; }
		public string M_Img { get; set; }
		public decimal M_Price { get; set; }
		public int  Spec_Id { get; set; }
		public string MenuSpec_Name { get; set; }
		public int MenuNum { get; set; }    //菜品数量
	}
}
