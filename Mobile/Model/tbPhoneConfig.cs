using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBC.Phone
{
    public class tbPhoneConfig
    {
        /// <summary>
        /// 電話ID
        /// </summary>
        [PrimaryKey]
        public string PHID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// IP ADDRESS
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// TCP PORT
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }

    }
}
