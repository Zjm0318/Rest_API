﻿using IOT_Rest_Model.DBModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using IOT_Rest_BLL;
using System.Collections.Generic;

namespace Rest_API.Controllers.UserController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserBLL bll = new UserBLL();

        //获取session_key
        [HttpGet]
        public string GetSession_key(string code)
        {
           
            string url = "https://api.weixin.qq.com/sns/jscode2session?appid=wx5a232bbd9decb01c&secret=45824d2383cb565686db4a4c8b8793f5&js_code=" + code+ "&grant_type=authorization_code&connect_redirect=1";
            //获取请求后的数据
            string jotext = HttpService.Get(url);

            return jotext;
            
        }

        //根据session_key iv encryptedData 解密出用户数据 ,如何将用户数据插入到表中
        [HttpGet]
        public string GetUserInfo(string session_key,string iv, string encryptedData)
        {

            //获取用户数据
            string jo = WXBizDataCrypt.AESDecrypt(encryptedData,session_key,iv);
            //转成json格式
            JObject job = (JObject)JsonConvert.DeserializeObject(jo);

            //用户类 赋值
            tb_User userinfo = new tb_User();
            userinfo.OpenId = job["openId"].ToString();
            userinfo.NickName = job["nickName"].ToString();
            userinfo.AvatarUrl = job["avatarUrl"].ToString();
            object watermark = job["watermark"].ToString();
            object timestamp = job["watermark"]["timestamp"].ToString();
            int count = 1;

            //创建连接对象
            MySqlConnection conn = new MySqlConnection("server=192.168.43.80;User Id=root;password=1234;Database=restaurant");
            //打开连接池
            conn.Open();
            //查询是否有当前用户
            string sql= "SELECT * FROM `tb_user` where OpenId='"+userinfo.OpenId+"'";
            MySqlCommand cmd1 = new MySqlCommand(sql, conn);
            object obj = cmd1.ExecuteScalar();
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                //添加当前用户的信息
                string str1 = $"insert into tb_user(OpenId,NickName,AvatarUrl,Count,TimeStamp) VALUES('{userinfo.OpenId}', '{userinfo.NickName}', '{userinfo.AvatarUrl}', {count}, '{timestamp.ToString()}')";
                MySqlCommand cmd2 = new MySqlCommand(str1,conn);
                try
                {
                    int row = cmd2.ExecuteNonQuery();
                }
                catch (Exception)
                {                
                    throw;
                }
            }
            else
            {
                //修改用户登录的次数
                string str2 = $"update tb_user set Count=Count+1 where OpenId='{userinfo.OpenId}'";
                MySqlCommand cmd3 = new MySqlCommand(str2,conn);
                int row = cmd3.ExecuteNonQuery();
            }
            //关闭连接池
            conn.Close();
            return jo;
        }
        
       
        [HttpGet]
        //获取用户优惠券信息
        public List<tb_Coupon> GetUserCoupon(int flag)
        {
            List<tb_Coupon> list = bll.GetUserCoupon(flag);
            return list;
        }

    }
}