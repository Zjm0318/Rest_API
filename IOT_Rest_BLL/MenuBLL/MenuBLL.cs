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

        public int AddMenu(tb_Menu model)
        {
            string procName = "AddMenu";
            MySqlParameter[] mySqlParameters = new MySqlParameter[] {
                new MySqlParameter{ParameterName="M_Name",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=model.M_Name },
                new MySqlParameter{ParameterName="M_Img",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=model.M_Img },
                new MySqlParameter{ParameterName="M_Price",MySqlDbType= MySqlDbType.Decimal,Direction= ParameterDirection.Input,Value=model.M_Price },
                new MySqlParameter{ParameterName="M_Msale",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=model.M_Msale },
                new MySqlParameter{ParameterName="M_Description",MySqlDbType= MySqlDbType.String,Direction= ParameterDirection.Input,Value=model.M_Description },
                new MySqlParameter{ParameterName="M_Type",MySqlDbType= MySqlDbType.Int32,Direction= ParameterDirection.Input,Value=model.M_Type }
            };
            return _dbHelper.ExecuteNonQuery_Proc(procName,mySqlParameters);
        }
    }
}
