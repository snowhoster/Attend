using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AproRequest
    {
        /// <summary>
        /// 主管工號
        /// </summary>
        public string apro_emp { get; set; }
        /// <summary>
        /// 主管同意日期時間
        /// </summary>
        public string apro_date { get; set; }

        public List<AproData> misscards { get; set; } = new List<AproData>();
    }
}
