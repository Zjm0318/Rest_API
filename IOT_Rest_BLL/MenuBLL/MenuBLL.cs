using IOT_Rest_Common;
using IOT_Rest_DAL.IDBHelp;
using IOT_Rest_Model.DBModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;

namespace IOT_Rest_BLL.MenuBLL
{
    public class MenuBLL:IMenuBLL
    {
        private IDBHelper _dbHelper;
        public MenuBLL(IDBHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        ListClass listClass = new ListClass();
        /// <summary>
        /// 添加菜品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddMenu(tb_Menu model)
        {
            string procName = "AddMenu";
            MySqlParameter[] mySqlParameters = new MySqlParameter[] {
                new MySqlParameter{ParameterName="MName",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=model.M_Name },
                new MySqlParameter{ParameterName="MImg",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=model.M_Img },
                new MySqlParameter{ParameterName="MPrice",MySqlDbType= MySqlDbType.Decimal,Direction= ParameterDirection.Input,Value=model.M_Price },
                new MySqlParameter{ParameterName="MMsale",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=model.M_Msale },
                new MySqlParameter{ParameterName="MDescription",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=model.M_Description },
                new MySqlParameter{ParameterName="MType",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=model.M_Type }
            };
            return _dbHelper.ExecuteNonQuery_Proc(procName,mySqlParameters);
        }
        /// <summary>
        ///根据类型获取菜品信息
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public List<tb_Menu> GetMenuList(int TypeId)
        {
            string procName = "proc_ShowMenu";
            MySqlParameter[] mySqlParameter = new MySqlParameter[] {
                new MySqlParameter{ParameterName="TypeId",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=TypeId }
            };
            DataTable tb= _dbHelper.ExecuteSql_Proc(procName, mySqlParameter);
            List<tb_Menu> list = listClass.GetDataList<tb_Menu>(tb);
            return list;
        }
        /// <summary>
        /// 获取菜品类型
        /// </summary>
        /// <returns></returns>
        public List<tb_MenuType> GetMenuTypeList()
        {
            string sql = "select * from tb_menutype;";
            DataTable tb = _dbHelper.ExcuteSql(sql);
            List<tb_MenuType> list = listClass.GetDataList<tb_MenuType>(tb);
            return list;
        }
        /// <summary>
        /// 获取所有菜品信息
        /// </summary>
        /// <returns></returns>
        public List<tb_Menu> GetAllMenu()
        {
            DataTable tb = _dbHelper.ExcuteSql("select * from tb_Menu");
            return listClass.GetDataList<tb_Menu>(tb);
        }
    }
}
