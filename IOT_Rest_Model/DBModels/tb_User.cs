using System;
using System.Collections.Generic;
using System.Text;


namespace IOT_Rest_Model.DBModels
{
    /// <summary>
    /// 微信用户类
    /// </summary>
   public class tb_User
    {
        //用户OpenId
        public string OpenId { get; set; }
         //昵称
        public string NickName { get; set; }
        //头像
        public string AvatarUrl { get; set; }
        //访问次数
        public int Count { get; set; }
        public data watermark { get; set; }

    }

    public class data
    {
        public string TimeStamp { get; set; }
    }



}
