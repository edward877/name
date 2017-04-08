﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ConnectDB
    {
        //@"Data Source=DESKTOP-3U6D185\SQLEXPRESS;Initial Catalog=curs;Integrated Security=True;Pooling=False"
        // string connectionString = @"Data Source=\SQLEXPRESS;Initial Catalog=curs;Integrated Security=True";

        //string connectionString = @"Data Source =.\SQLEXPRESS;" + 
        //    @"AttachDbFilename = |DataDirectory|\curs.mdf; Integrated Security = True";
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=curs;Integrated Security=True;Pooling=False";

        //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
        //             @"AttachDbFilename = |DataDirectory|\curs.mdf;" +
        //             @"Integrated Security = True; Connect Timeout = 30";
        public DBDataContext DB { get { return new DBDataContext(connectionString); }  }
        
    }
}
