using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Rest_BLL;
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
        /// <summary>
        /// 根据菜品Id 获取一条数据
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        [HttpGet]
        public tb_Menu GetOneMenu(int MenuId)
        {
            List<tb_Menu> list = GetAllMenu();
            tb_Menu model = list.Where(s => s.M_Id == MenuId).FirstOrDefault();
            return model;
        }
        List<tb_Menu> menuList = new List<tb_Menu>();
        /// <summary>
        /// 添加菜品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMenu([FromForm]tb_Menu model)
        {
            return _menuBLL.AddMenu(model);
        }
        /// <summary>
        /// 获取菜品信息
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<tb_Menu> GetMenuList(int TypeId)
        {
            return _menuBLL.GetMenuList(TypeId);
        }/// <summary>
         /// 获取菜品类型
         /// </summary>
         /// <returns></returns>
         [HttpGet]
        public List<tb_MenuType> GetMenuTypeList()
        {
            return _menuBLL.GetMenuTypeList();
        }
        /// <summary>
        /// 获取所有菜品
        /// </summary>
        /// <returns></returns>
        public List<tb_Menu> GetAllMenu()
        {
            menuList = _menuBLL.GetAllMenu();
            return menuList;
        }
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="OpenId">用户主键</param>
        /// <param name="Menu_Id"></param>
        /// <returns></returns>
        public int AddCar(string OpenId, int Menu_Id)
        {
            tb_Menu model = menuList.Where(s => s.M_Id == Menu_Id).FirstOrDefault();
            //获取该用户的购物车缓存
            List<tb_Menu> _menuList = _client.Get<List<tb_Menu>>(OpenId);
            if(_menuList!=null)
            {
                tb_Menu m = _menuList.Where(s => s.M_Id == Menu_Id).FirstOrDefault();
                if(m!=null)
                {
                    model.CarNum += 1;
                }
                else
                {
                    model.CarNum = 1;
                    _menuList.Add(model);
                }
            }
            else
            {
                _menuList = new List<tb_Menu>();
                model.CarNum = 1;
                _menuList.Add(model);
            }
            _client.Set(OpenId,_menuList);
            return _menuList.Count;
        }
        /// <summary>
        /// 获取购物车中的信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public List<tb_Menu> GetCarList(string openId)
        {
            List<tb_Menu> list = _client.Get<List<tb_Menu>>(openId);
            return list;
        }
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public void ClearCar(string openId)
        {
            _client.Del(openId);
            GetCarList(openId);
        }

    }
}