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
        public List<OrderViewModel> GetOrder()
        {
            //实例化
            List<OrderViewModel> order = new List<OrderViewModel>();

            //获取数据
            List<tb_OrderDetail> list = bll.OrderList();
            //循环
            for (int i = 1; i <= list.Count; i++)
            {
                //判断获取数据
                var lis = list.Where(s => s.Order_Id == i).ToList();
                if(lis.Count>0)
                {
                    int a = 1;
                    var nm = "";
                    //实例化
                    OrderViewModel om = new OrderViewModel();
                    om.O_Img = new List<MenuImg>();
                    //循环
                    foreach (var item in lis)
                    {
                        //判断
                        if (a <= 3)
                        {
                            nm += item.M_Name + "、";
                            MenuImg mi = new MenuImg
                            {
                                photo = item.M_Img,
                            };
                            om.O_Img.Add(mi);
                        }
                        om.O_Id = item.Order_Id;
                        om.O_Price = item.Order_Price;
                        om.O_State = item.Order_State;
                        a++;
                    }
                    om.Num = lis.Count;
                    om.O_Name = nm.TrimEnd('、').ToString();
                    order.Add(om);
                }
            }
            return order;
        }

        //修改订单状态
        [HttpPost]
        public int UpdOrder(int oid,int sta)
        {
            return bll.UpdOrder(oid,sta);
        }

        //显示订单详情
        [HttpGet]
        public List<OrderDetailViewModel> GetOrderDetail(int oid)
        {
            //实例化
            List<OrderDetailViewModel> order = new List<OrderDetailViewModel>();

            //获取数据
            List<tb_OrderDetail> list= bll.ShowOrderDetail(oid);

            //实例化
            OrderDetailViewModel om = new OrderDetailViewModel();
            om.Menus = new List<Menus>();
            //循环
            foreach (var item in list)
            {
                Menus mi = new Menus
                {
                    M_Name=item.M_Name,
                    M_Img=item.M_Img,
                    M_Price=item.M_Price,
                    MenuNum=item.MenuNum
                };
                om.Menus.Add(mi);
                om.Order_Id = item.Order_Id;
                om.Order_Price = item.Order_Price;
                om.Orde_Num = item.Order_Num;
                om.Order_Dan = item.Order_Dan;
                om.Order_Sate = item.Order_Sate;
                om.Order_State = item.Order_State;
            }
            order.Add(om);
            return order;
        }
    }
}