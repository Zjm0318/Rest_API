using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_API.Controllers.OrderController
{
    public class OrderViewModel
    {
        public int O_Id { get; set; }
        public string O_Name { get; set; }
        public List<MenuImg> O_Img { get; set; }
        public decimal O_Price { get; set; }
        public int O_State { get; set; }
        public int Num { get; set; }
    }

    public class MenuImg
    {
        public string photo { get; set; }
    }


}
