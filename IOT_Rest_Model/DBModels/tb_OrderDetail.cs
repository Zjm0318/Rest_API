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
		 public int  Menu_Id { get; set; }
		 public int  Spec_Id { get; set; }
	 }
}
