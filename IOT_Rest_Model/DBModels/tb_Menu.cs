using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Rest_Model.DBModels
{
	 public class tb_Menu
	 {
		 public int  M_Id { get; set; }
		 public string  M_Name { get; set; }
		 public string  M_Img { get; set; }
		 public decimal  M_Price { get; set; }
		 public int  M_Msale { get; set; }
		 public string  M_Description { get; set; }
		 public int  M_Type { get; set; }
	 }
}
