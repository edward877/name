using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBank
{
    public class Bank
    {
        string[] massiveOfString;
        List<Doc1C> listCB;
        string path;
        public static string OURAdress = "40702810900700601072";
       

        public Bank(string path)
        {
            this.path = path;
            listCB = new List<Doc1C>();
        }

        public List<Doc1C> Parser()
        {
            massiveOfString = File.ReadAllLines(path, Encoding.UTF8);
            Doc1C cb = null;
            foreach (string str in massiveOfString)
            {
                string[] result = str.Trim().Split('=');

                if (result.Length == 2)
                {
                    if (result[0].Equals("СекцияДокумент"))
                    {
                        cb = new Doc1C();
                        cb.Doctype = result[1];
                    }
                    if (cb != null)
                    {
                        if (result[0].Equals("СекцияДокумент"))
                        {
                            cb.Doctype = result[1];
                        }
                        else if (result[0].Equals("Номер"))
                        {
                            cb.Inbankid = result[1];
                        }
                        else if (result[0].Equals("Дата"))
                        {
                            cb.Docdate = result[1];
                        }
                        else if (result[0].Equals("Сумма"))
                        {
                            cb.Summ = result[1];
                        }
                        else if (result[0].Equals("ПлательщикСчет"))
                        {
                            cb.Payeraccount = result[1];
                        }
                        else if (result[0].Equals("Плательщик"))
                        {
                            cb.Payerinfo = result[1];
                        }
                        else if (result[0].Equals("ПолучательСчет"))
                        {
                            cb.Recieveraccount = result[1];
                        }
                        else if (result[0].Equals("Получатель"))
                        {
                            cb.Recieverinfo = result[1];
                        }
                        else if (result[0].Equals("НазначениеПлатежа"))
                        {
                            cb.Paydirection = result[1];
                        }
                    }
                }
                if (result[0].Equals("КонецДокумента"))
                {
                    listCB.Add(cb);
                    cb = null;
                }
            }
            return listCB;
        }


        //public void WritePaid(Client client, double paid)
        //{
        //    string[] massiveOfString = new string[14];
        //    massiveOfString[0] = "1CClientBankExchange";
        //    massiveOfString[1] = "ВерсияФормата=1";
        //    massiveOfString[2] = "Кодировка=Windows";
        //    massiveOfString[3] = "СекцияДокумент=Платежное поручение";
        //    massiveOfString[4] = "Номер=" + (new Random()).Next(100);
        //    massiveOfString[5] = "Дата=" + DateTime.Today;
        //    massiveOfString[6] = "Сумма=" + paid;
        //    massiveOfString[7] = "ПлательщикСчет=" + client.id_client;
        //    massiveOfString[8] = "Плательщик=" + client.full_name;
        //    massiveOfString[9] = "ПолучательСчет=" + OURAdress;
        //    massiveOfString[10] = "Получатель=THE Garagh";
        //    massiveOfString[11] = "НазначениеПлатежа=оплата за грузоперевозку";
        //    massiveOfString[12] = "КонецДокумента";
        //    massiveOfString[13] = "КонецФайла";
        //    File.WriteAllLines(path, massiveOfString, Encoding.UTF8);
            
        //}
    }
}
