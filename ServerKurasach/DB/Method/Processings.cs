using Server.DB;
using Server.DB.Content;
using ServerKurasach.DB.Content;
using ServerKurasach.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerKurasach.DB.Method
{
    internal class Processings
    {
        public string Process(string data)
        {
            string returndata;
            IDGET iDGET = new IDGET();
            iDGET=JsonSerializer.Deserialize<IDGET>(data);
            using (TransportContext db = new TransportContext())
            {
                Country countryFrom = db.Countries.Where(c=>c.City==iDGET.IDFrom).First();
                Country countryTo = db.Countries.Where(c => c.City == iDGET.IDTo).First();
                Cargo cargo = db.Cargos.Where(c => c.Name == iDGET.Cargo).First();
                Doc document = new Doc();
                document.CityFrom = countryFrom.City;
                document.CityTo = countryTo.City;
                document.Price =cargo.Price;
                document.km = countryFrom.Distance + countryTo.Distance;
                document.SumToplivo = Math.Round(((document.km) / 10) * (2.8), 2);
                document.ZP = Math.Round(((document.km)) * (0.2), 2);
                document.ProcentFirm = Math.Round((document.SumToplivo + document.ZP)*0.3,2);
                document.Sum = document.SumToplivo + document.ZP + document.ProcentFirm+document.Price;
                returndata = JsonSerializer.Serialize(document);
                return returndata;
            }
        }
    }
}
