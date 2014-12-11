using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OAuth2.Entities.Sina
{
    [Serializable]
    public class SinaUserInfoResult:IResource
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public long id { get; set; }

        public string idstr { get; set; }

        public string screen_name { get; set; }

        public string name { get; set; }

        public int province { get; set; }

        public int city { get; set; }

        public string location { get; set; }

        public string description { get; set; }

        public string url { get; set; }

        public string profile_image_url { get; set; }

        public string profile_url { get; set; }

        public string domain { get; set; }

        public string weihao { get; set; }

        public string gender { get; set; }

        public int followers_count { get; set; }

        public int friends_count { get; set; }

        public int statuses_count { get; set; }

        public int favourites_count { get; set; }

        public string created_at { get; set; }

        public bool following { get; set; }

        public bool allow_all_act_msg { get; set; }

        public bool geo_enabled { get; set; }

        public bool verified { get; set; }

        public int verified_type { get; set; }

        public string remark { get; set; }

        public object status { get; set; }

        public bool allow_all_comment { get; set; }

        public string avatar_large { get; set; }

        public string avatar_hd { get; set; }

        public string verified_reason { get; set; }

        public bool follow_me { get; set; }

        public int online_status { get; set; }

        public int bi_followers_count { get; set; }

        public string lang { get; set; }
    }
}
