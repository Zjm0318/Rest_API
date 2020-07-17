using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Rest_Model.DBModels
{
    public class tb_User
    {
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public string AvatarUrl { get; set; }
        public int Count { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
