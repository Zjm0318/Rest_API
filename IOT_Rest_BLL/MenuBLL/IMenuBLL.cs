using IOT_Rest_Model.DBModels;
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



    }
}
