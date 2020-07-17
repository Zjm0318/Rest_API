using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IOT_Rest_DAL.IDBHelp
{
    public interface IDBHelper
    {

        /// <summary>
        /// 执行存储过程，返回受影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="mySqlParameters"></param>
        /// <returns></returns>
        int ExecuteNonQuery_Proc(string procName, MySqlParameter[] mySqlParameters);

        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        DataTable ExecuteSql_Proc(string procName, MySqlParameter[] sqlParameters);

        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="parame"></param>
        /// <param name="RowsCount"></param>
        /// <returns></returns>
        public DataTable ExecuteSql_Proc(string ProcName, MySqlParameter[] parame, ref int RowsCount);

        /// <summary>
        /// 执行sql语句，返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExcuteNonQuery(string sql);
        /// <summary>
        /// 执行sql，返回结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExcuteSql(string sql);
    }
}
