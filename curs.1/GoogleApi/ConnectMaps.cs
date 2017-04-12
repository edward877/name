using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace GoogleApi
{
    public class ConnectMaps
    {

        WebClient Client = new WebClient();
        //string from = "ульяновск, кузоватовская 21";
        //string to = "Москва";
        
        public ConnectMaps(string from,string to)
        {
            string adress = "http://maps.googleapis.com/maps/api/directions/xml?origin=" + from
                + "&destination=" + to + "&sensor=false";

            using (Stream strm =
                Client.OpenRead(@adress))
                {
                    StreamReader sr = new StreamReader(strm);
                    FileStream f = new FileStream("temp.xml", FileMode.Create);
                    StreamWriter sw = new StreamWriter(f);
                    sw.WriteLine(sr.ReadToEnd());
                    sw.Close();
                    f.Close();
            }

        }

    }
}
