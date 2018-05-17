using CSBC.Phone;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PhoneDAL
    {
        private SQLiteConnection conn;
        private static object lockData = new object();
        public PhoneDAL(string path)
        {
            this.conn = new SQLiteConnection(Path.Combine(path, "Phone.db3"));
            conn.CreateTable<tbPhoneConfig>();

            if (!conn.Table<tbPhoneConfig>().Any())
            {
                tbPhoneConfig config = new tbPhoneConfig
                {
                    PHID = "1",
                    IP = "192.168.14.2",
                    Port = "80",
                    Name = "12345",
                    Password = "12345"
                };
                conn.Insert(config);
            }
        }

        public IList<tbPhoneConfig> GetConfig()
        {
            return conn.Table<tbPhoneConfig>().ToList();
        }

        public bool SetConfig(tbPhoneConfig item)
        {
            bool result = false;
            lock (lockData)
            {
                try
                {
                    var data = conn.Table<tbPhoneConfig>().Where(c => c.PHID == item.PHID).SingleOrDefault();
                    if (data == null)
                        conn.Insert(item);
                    else
                    {
                        data.PHID = item.PHID;
                        data.IP = item.IP;
                        data.Name = item.Name;
                        data.Port = item.Port;
                        data.Password = item.Password;
                        conn.Update(data);
                    }
                    result = true;
                }
                catch{}
                
            }

            return result;
        }


    }
}
