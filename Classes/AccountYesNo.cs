using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Session_1.Frames;
using Session_1.DataBase;

namespace Session_1.Classes
{
    static class AccountYesNo       //класс поиск Аккаунта в БД
    {
        public static void CheckAccount(string log, string pas)
        {
            try
            {
                var query = (from USERS
                             in StaticData.db.USERS
                             where (USERS.LOGIN == log && USERS.PASSWORD == pas)
                             select USERS).First();

                Console.WriteLine($"{query.ID}", query.ROLE, query.LOGIN, query.PASSWORD);

                StaticData.ID = query.ID;
                FrameManager.MainFrame.Navigate(new Administator());
                
            }
            catch
            {
                MessageBox.Show("Ошибка - пользователь не найден");
            }

        }
    }
}
