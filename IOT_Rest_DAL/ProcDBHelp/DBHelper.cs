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
        /// 执行存储过程，返回受影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="mySqlParameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery_Proc(string procName, MySqlParameter[] mySqlParameters)
        {
            int code = 0;
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(mySqlParameters);
                    code = cmd.ExecuteNonQuery();
                }
            }
            return code;
        }
        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public DataTable ExecuteSql_Proc(string procName, MySqlParameter[] sqlParameters)
        {
            DataSet set = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(procName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(sqlParameters);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(set);
                }
            }
            return set.Tables[0];
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
            DataSet set = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(ProcName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parame);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(set);
                    //获取输出参数
                    RowsCount = int.Parse(cmd.Parameters["RowsCount"].Value.ToString());
                }
            }
            return set.Tables[0];
        }
    }
}
