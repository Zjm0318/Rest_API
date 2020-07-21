using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IOT_Rest_DAL.ADO.Net
{
    public class ADONetHelper
    {
        private string Connection = "server=192.168.0.192;User Id=root;password=1234;Database=restaurant";

        /// <summary>
        /// 执行sql语句，返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExcuteNonQuery(string sql)
        {
            int code = 0;
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    code = cmd.ExecuteNonQuery();
                }
            }
            return code;
        }
        /// <summary>
        /// 执行sql，返回结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExcuteSql(string sql)
        {
            DataSet set = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(set);
                }
            }
            return set.Tables[0];
        }
    }
}
