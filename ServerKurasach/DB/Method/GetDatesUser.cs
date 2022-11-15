
using Server.DB;
using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerMail.DB.Method
{
    public class GetDatesUser
    {
        public string Data(string check)
        {
            string perm;
           
            using (TransportContext db = new TransportContext())
            {
                if (check == "GetData")
                {
                    perm = JsonSerializer.Serialize(db.Countries);
                }
                else
                {
                    perm = JsonSerializer.Serialize(db.Cargos);
                }
               
            }
            return perm;
        }
    }
}

