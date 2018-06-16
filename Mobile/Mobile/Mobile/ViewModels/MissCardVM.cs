using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;

namespace Mobile.ViewModels
{
    public class MissCardVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 刷卡補登資料
        /// tptm605 資料表
        /// 依照合理推論,emp + attd_date + attd_time 為主key
        /// </summary>

        /// <summary>
        /// 員工號
        /// </summary>
        public string emp { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string emp_name { get; set; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public string attd_date { get; set; }
        /// <summary>
        /// 出勤時間
        /// </summary>
        public string attd_time { get; set; }
        /// <summary>
        /// 機器唯一碼
        /// </summary>
        public string mac_no { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string gps_lati { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string gps_long { get; set; }
        /// <summary>
        /// 主管功號
        /// </summary>
        public string apro_emp { get; set; }
        /// <summary>
        /// 主管同意日期時間
        /// </summary>
        public string apro_date { get; set; }
        /// <summary>
        /// 是否同意(Y/N)
        /// </summary>
        public string apro_yn { get; set; }
        /// <summary>
        /// error code
        /// </summary>
        public string err_code { get; set; }
        /// <summary>
        /// kn date
        /// </summary>
        public string kn_date { get; set; }

        public Color testColor { get; set; }


    }
}
