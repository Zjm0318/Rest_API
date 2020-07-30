using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_API.Controllers.OrderController
{
    public class OrderDetailViewModel
    {
        public int Order_Id { get; set; }
        public List<Menus> Menus { get; set; }
        public string Order_Num { get; set; }
        public decimal Order_Price { get; set; }
        public decimal Order_YingFu { get; set; }
        public int Order_YouHuiId { get; set; }
        public int Order_YouHui { get; set; }
        public DateTime Order_Sate { get; set; }  
        public DateTime Order_Dan { get; set; }
        public int Order_State { get; set; }
    }

    public class Menus
    {
        public int M_Id { get; set; }
        public string M_Name { get; set; }
        public string M_Img { get; set; }
        public decimal M_Price { get; set; }
        public int MenuNum { get; set; }
    }
}
