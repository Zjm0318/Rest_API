using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_Rest_BLL;
using IOT_Rest_Model.DBModels;
using Newtonsoft.Json;

namespace Rest_API.Controllers.OrderController
{
    [Route("api/Order/[Action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBLL bll = new OrderBLL();

        //显示订单
        [HttpGet]
        public List<OrderViewModel> GetOrder(string uid)
        {
            //实例化
            List<OrderViewModel> order = new List<OrderViewModel>();

            //获取数据
            List<tb_OrderDetail> list = bll.OrderList(uid);

            OrderViewModel om = new OrderViewModel();
            //循环
            foreach (var q in list)
            {
                //判断获取数据
                var lis = list.Where(s => s.Order_Id == q.Order_Id).ToList();
                if(lis.Count>0)
                {
                    int a = 1;
                    var nm = "";
                    //实例化
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
                }
                order.Add(om);
            }
            
            return order.OrderBy(s => s.O_State).ToList();
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
                om.Order_YingFu = item.Order_YingFu;
                om.Order_YouHuiId = item.Order_YouHuiId;
                om.Order_YouHui = item.Order_YouHui;
                om.Order_Num = item.Order_Num;
                om.Order_Dan = item.Order_Dan;
                om.Order_Sate = item.Order_Sate;
                om.Order_State = item.Order_State;
            }
            order.Add(om);
            return order;
        }

        //添加订单
        [HttpPost]
        public int AddOrder([FromForm]tb_Order orders, [FromForm]string lists)
        {
            List<tb_Menu> list = JsonConvert.DeserializeObject<List<tb_Menu>>(lists).ToList();

            return bll.AddOrder(orders, list);

        }

        //显示优惠券
        [HttpGet]
        public List<tb_Coupon> GetCoupon(string ids)
        {
            List<tb_Coupon> list = bll.GetCoupon(ids);
            return list;
        }

        //删除订单
        [HttpPost]
        public int DelOrder(int oid)
        {
            return bll.DelOrder(oid);
        }

        //修改优惠券

        [HttpPost]
        public int UpdateQuan([FromForm]string openid, [FromForm]int quanId)
        {
            return bll.UpdateQuan(openid, quanId);
        }

        //再次购买
        //[HttpPost]
        //public int BuyMenu(int oid)
        //{
        //    List<tb_Menu> menu = new List<tb_Menu>();
        //    //获取数据
        //    List<tb_OrderDetail> list = bll.ShowOrderDetail(oid);
        //    tb_Order order = new tb_Order();
        //    //循环
        //    foreach (var item in list)
        //    {
        //        order.Order_Price = item.Order_Price;
        //        order.User_Id = item.User_Id;
        //        tb_Menu m = new tb_Menu
        //        {
        //            M_Id = item.Menu_Id,
        //            CarNum = item.MenuNum,
        //        };
        //        menu.Add(m);
        //    }
        //    return bll.AddOrder(order, menu);
        //}

    }
}