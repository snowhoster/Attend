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
               
                //DNS 解析的關係,不能打IP
                // HOST_IP = "172.16.1.12",//config[0].IP,
                HOST_IP = "www2.csbcnet.com.tw",
                HOST_PORT = "80",//config[0].Port,


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

        public List<MissCard> Get_MissCardsTest(string as_emp)
        {
            List<MissCard> result = new List<MissCard> {
               
                new MissCard {emp="222222",emp_name="台船一寶",attd_date="1070501",attd_time="0805"},
                new MissCard {emp="333333",emp_name="台船二寶",attd_date="1070506",attd_time="1010"},
                new MissCard {emp="444444",emp_name="台船三寶",attd_date="1070512",attd_time="0759"},
            };

            return result;
        }


        public async Task<bool> Set_MissCards(AproRequest request)
        {
            var result = await remoteAccess.Set_AproMissCard(request);
            return true;
        }

            public async Task<List<MissCard>> Get_MissCards(AproRequest request)
        {
            var result = await remoteAccess.Get_NoneAproMissCardByAproEmp(request);

            return result;
        }




    }
}
