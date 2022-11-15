
using ServerKurasach.DB.Method;
using ServerMail.DB.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerKurasach.Processing
{
    public class Request
    {
        SetData setData;
        GetDatesUser getDatesUser;
        Processings processing;
        public byte[] GetRequest(string[] message)
        {

           
            byte[] data=null;
            switch (message[0])
            {

                case "GetData":
                    getDatesUser = new GetDatesUser();
                    data = Encoding.UTF8.GetBytes(getDatesUser.Data(message[0]));
                    break;
                case "GetDataC":
                    getDatesUser = new GetDatesUser();
                    data = Encoding.UTF8.GetBytes(getDatesUser.Data(message[0]));
                    break;
                case "Processing":
                    processing = new Processings();
                    data = Encoding.UTF8.GetBytes(processing.Process(message[1]));
                    break;
                case "SaveDataCountry":
                    setData = new SetData();
                    data = Encoding.UTF8.GetBytes(setData.SetDatas(message));
                    break;
                case "SaveDataCargo":
                    setData = new SetData();
                    data = Encoding.UTF8.GetBytes(setData.SetDatas(message));
                    break;
                default:
                    break;
            }
            Console.WriteLine(data);
            return data;
        }
    }
}
