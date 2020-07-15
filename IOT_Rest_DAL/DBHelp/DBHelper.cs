using IOT_Rest_DAL.IDBHelp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IOT_Rest_DAL.DBHelp
{
    public class DBHelper : IDBHelper
    {
        private string Connection = "server=192.168.0.139;User Id=root;password=123456;Database=restaurant";
        /// <summary>
        /// 执行sql语句，返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExcuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 执行sql，返回结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExcuteSql(string sql)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 执行存储过程，返回受影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="mySqlParameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery_Proc(string procName, MySqlParameter[] mySqlParameters)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable ExecuteSql_Proc(string procName, MySqlParameter[] sqlParameters)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="parame"></param>
        /// <param name="RowsCount"></param>
        /// <returns></returns>
        public DataTable ExecuteSql_Proc(string ProcName, MySqlParameter[] parame, ref int RowsCount)
        {
            throw new NotImplementedException();
        }
    }
}
