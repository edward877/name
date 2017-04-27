using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GoogleApi
{
    public class Distantion
    {

        XmlDocument doc = new XmlDocument();

        public string ReadXml()
        {
           
                string str="";
            try
            {
                doc.Load("temp.xml");

                XmlNodeList elemList = doc.GetElementsByTagName("distance");             //считали все шаги по маршруту

                str = (elemList[elemList.Count - 1].InnerXml) + " ";
                //нашли содержимое итоговой дистанции

                str = Regex.Match(str, @"(?<=<text>)(.*)(?= km</text>)").ToString();       // убрали теги и прочее из строки  

                //  File.Delete("temp.xml");
            }
            catch { }
            return str;
        }
        

    }

}
