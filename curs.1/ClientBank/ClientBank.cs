using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBank
{
    public class Doc1C
    {

        private string doctype;
        private string inbankid;
        private string docdate;
        private string summ;
        private string payeraccount;
        private string payerinfo;
        private string recieveraccount;
        private string recieverinfo;
        private string paydirection;

        public string Doctype
        {
            get
            {
                return doctype;
            }

            set
            {
                doctype = value;
            }
        }

        public string Inbankid
        {
            get
            {
                return inbankid;
            }

            set
            {
                inbankid = value;
            }
        }

        public string Docdate
        {
            get
            {
                return docdate;
            }

            set
            {
                docdate = value;
            }
        }

        public string Summ
        {
            get
            {
                return summ;
            }

            set
            {
                summ = value;
            }
        }

        public string Payeraccount
        {
            get
            {
                return payeraccount;
            }

            set
            {
                payeraccount = value;
            }
        }

        public string Payerinfo
        {
            get
            {
                return payerinfo;
            }

            set
            {
                payerinfo = value;
            }
        }

        public string Recieveraccount
        {
            get
            {
                return recieveraccount;
            }

            set
            {
                recieveraccount = value;
            }
        }

        public string Recieverinfo
        {
            get
            {
                return recieverinfo;
            }

            set
            {
                recieverinfo = value;
            }
        }

        public string Paydirection
        {
            get
            {
                return paydirection;
            }

            set
            {
                paydirection = value;
            }
        }
    }
}
