
using Server.DB;
using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ServerKurasach.DB.Content;

namespace ServerMail.DB.Method
{
    public class SetData
    {
        public string SetDatas(string[] data)
        {
            using (TransportContext db = new TransportContext())
            {
                string get=null;
                switch (data[0])
                {
                    case "SaveDataCountry":
                        db.Countries.Add(JsonSerializer.Deserialize<Country>(data[1]));
                        
                        break;
                    case "SaveDataCargo":
                        db.Cargos.Add(JsonSerializer.Deserialize<Cargo>(data[1]));
                        get = "ОК";
                        break;
                    default:
                        get = "НЕТ";
                        break;
                }
                db.SaveChanges();
                return get;
            }
                
          


            
        }
    }
}
