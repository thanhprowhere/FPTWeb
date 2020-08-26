using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteFPT
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Course { get; set; }
    }
}