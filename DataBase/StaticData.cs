using Session_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1.DataBase
{
    static class StaticData     //статичная БД
    {
        public static GlazkiSaveEntities db = new GlazkiSaveEntities();

        public static int ID { get; set; }

    }
}
