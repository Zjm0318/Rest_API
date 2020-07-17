using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Rest_BLL.MenuBLL;
using IOT_Rest_Model.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSRedis;

namespace Rest_API.Controllers.MenuController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuBLL _menuBLL;
        CSRedis.CSRedisClient _client;
        public MenuController(IMenuBLL menuBLL)
        {
            _menuBLL = menuBLL;
            _client = new CSRedis.CSRedisClient("127.0.0.1:6379");
            RedisHelper.Initialization(_client);
        }
        List<tb_GoodsCar> carList = new List<tb_GoodsCar>();
        /// <summary>
        /// 添加菜品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMenu(tb_Menu model)
        {
            return _menuBLL.AddMenu(model);
        }
        /// <summary>
        /// 获取菜品信息
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public List<tb_Menu> GetMenuList(int TypeId)
        {
            return _menuBLL.GetMenuList(TypeId);
        }/// <summary>
         /// 获取菜品类型
         /// </summary>
         /// <returns></returns>
        public List<tb_MenuType> GetMenuTypeList()
        {
            return _menuBLL.GetMenuTypeList();
        }

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="User_Id"></param>
        /// <param name="Menu_Id"></param>
        /// <returns></returns>
        public int AddCar(int User_Id,int Menu_Id)
        {
            //获取该用户的所有购物车信息
            carList = _menuBLL.GetCarList(User_Id);
            //获取Redis数据库所有购物车信息
            List<tb_GoodsCar> _carList = _client.Get<List<tb_GoodsCar>>("Cars");
            if(_carList!=null)
            {
                //获取当前用户的购物车信息
                List<tb_GoodsCar> userCar = _carList.Where(s => s.User_Id == User_Id).ToList();
                if(userCar!=null)
                {

                }
            }
            
        }

    }
}