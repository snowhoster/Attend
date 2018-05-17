using CSBC.Phone;
using Model;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Service
{
    public class BLLService
    {
        private PhoneDAL phomeDAL;
        private RemoteAccess remoteAccess;

        public string LocalPath { get; set; }
        public BLLService()
        {
            string AppPath = DependencyService.Get<IFileHelper>().GetLocalPath();
            LocalPath = AppPath;
            Init_BLLService();
        }
        public void Init_BLLService()
        {
            phomeDAL = new PhoneDAL(LocalPath);
            var config = phomeDAL.GetConfig();
            remoteAccess = new RemoteAccess
            {
                HOST_IP = config[0].IP,
                HOST_PORT = config[0].Port,
                USER_ID = config[0].Name,
                PHONE_PW = config[0].Password
            };
        }

        public bool Login(string UserID, string Password)
        {
            var data = phomeDAL.GetConfig() as List<tbPhoneConfig>;
            if (data[0].Name == UserID && data[0].Password == Password)
                return true;
            else
                return false;

        }

        public tbPhoneConfig GetPhoneConfig()
        {
            return phomeDAL.GetConfig()[0];
        }

                
        public bool SetConfig(tbPhoneConfig item)
        {
            return phomeDAL.SetConfig(item);
        }

        public List<MissCard> Get_MissCards(string as_emp)
        {
            List<MissCard> result = new List<MissCard> {
                new MissCard {emp="107948",emp_name="霖霖",attd_date="1070505",attd_time="1010"},
                new MissCard {emp="107941",emp_name="一一",attd_date="1070505",attd_time="1010"},
            };

            return result;
        }

    }
}
