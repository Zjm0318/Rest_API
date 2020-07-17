using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_Rest_BLL;
using IOT_Rest_Model.DBModels;

namespace Rest_API.Controllers.OrderController
{
    [Route("api/Order/[Action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBLL bll = new OrderBLL();

        //显示订单
        [HttpGet]
        public List<OrderViewModel> GetOrder(int sta)
        {
            //实例化
            List<OrderViewModel> order = new List<OrderViewModel>();

            //获取数据
            List<tb_OrderDetail> list = bll.OrderList(sta);
            //循环
            for (int i = 1; i <= list.Count; i++)
            {
                //判断获取数据
                var lis = list.Where(s => s.Order_Id == i).ToList();
                int a = 1;
                var nm = "";
                //实例化
                OrderViewModel om = new OrderViewModel();
                MenuImg mi = new MenuImg();
                //循环
                foreach (var item in lis)
                {
                    //判断
                    if(a<=3)
                    {
                        nm += item.M_Name + "、";

                        mi.Img = item.M_Img;
                        om.O_Img.Add(mi);
                    }
                    om.O_Id = item.Order_Id;
                    om.O_Price = item.Order_Price;
                    om.O_State = item.Order_State;
                    a++;
                }
                om.O_Name = nm.TrimEnd(',').ToString();
                order.Add(om);
            }
            return order;
        }
    }
}