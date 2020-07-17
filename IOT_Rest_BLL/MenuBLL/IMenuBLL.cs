﻿using IOT_Rest_Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Rest_BLL.MenuBLL
{
    public interface IMenuBLL
    {
        /// <summary>
        /// 添加菜品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddMenu(tb_Menu model);
        /// <summary>
        /// 根据类型获取菜品信息
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        List<tb_Menu> GetMenuList(int TypeId);
        /// <summary>
        /// 获取菜品类型
        /// </summary>
        /// <returns></returns>
        public List<tb_MenuType> GetMenuTypeList();
        /// <summary>
        /// 根据用户Id获取购物车信息
        /// </summary>
        /// <returns></returns>
        public List<tb_GoodsCar> GetCarList(int User_Id);
    }
}
