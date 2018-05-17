using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AproData
    {
        /// <summary>
        /// 員工工號
        /// </summary>
        public string emp { get; set; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public string attd_date { get; set; }
        /// <summary>
        /// 出勤時間
        /// </summary>
        public string attd_time { get; set; } 
        /// <summary>
        /// 是否同意(Y/N)
        /// </summary>
        public string apro_yn { get; set; }
    }
}
