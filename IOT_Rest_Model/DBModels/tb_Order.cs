using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Rest_Model.DBModels
{
	 public class tb_Order
	 {
		 public int  Order_Id { get; set; }
		 public string  Order_Num { get; set; }
		 public string  User_Id { get; set; }
		 public int  Desk_Id { get; set; }
		 public decimal  Order_Price { get; set; }
		 public int  Order_State { get; set; }
		public string Order_fs { get; set; }   //֧����ʽ
		public DateTime Order_Sate { get; set; }  //֧��ʱ��
		public DateTime Order_Dan { get; set; }    //�µ�ʱ��
	}
}
