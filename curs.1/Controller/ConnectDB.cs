using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ConnectDB
    {
        string connectionString = @"Server=tcp:name-curs.database.windows.net,1433;Initial Catalog=curs;Persist Security Info=False;User ID=curs;Password=1234Adda;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
        //             @"AttachDbFilename = |DataDirectory|\curs.mdf;" +
        //             @"Integrated Security = True; Connect Timeout = 30";


        public DBDataContext DB { get { return new DBDataContext(connectionString); }  }
        
    }
}
