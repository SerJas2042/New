using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1.DataBase
{
    static public class dbBooksContext
    {
        public static int ID { get; set; }
        public static string Name { get; set; }
        public static DateTime Date { get; set; }

        public static DataSet Data { set => StaticData.db.Books.ToList();  }
    }
}
