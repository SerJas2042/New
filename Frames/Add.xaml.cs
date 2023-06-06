using Session_1.Classes;
using Session_1.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Session_1.Frames
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Books _books = new Books();  //таблица Книг

        public Add( Books selectedBook) //аргумент для редактирования книги
        {
            InitializeComponent();

            if(selectedBook != null)    //установка контекста
            {
                _books = selectedBook;
            }

            DataContext = _books;   
        }

        private void ADDSave_Click(object sender, RoutedEventArgs e)    //кнопка добавить запись
        {
            StringBuilder errors = new StringBuilder();     //ошибки
            if (string.IsNullOrWhiteSpace(_books.Name))
                errors.AppendLine("Укажите название книги");
            if (_books.DateOfWrite == null)
                errors.AppendLine("Укажите дату написания");

            if(errors.Length > 0)           //ошибки
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_books.ID == 0)     //добавить новый
            {
                OpenConnectionDB dB = new OpenConnectionDB();
                SqlCommand sqlCommand = new SqlCommand("SELECT MAX(ID) from Books", dB.GetConnection());

                dB.GetConnection().Open();

                int ID = Convert.ToInt32(sqlCommand.ExecuteScalar().ToString());
                _books.ID = ID + 1;

                dB.GetConnection().Close();

                GlazkiSaveEntities.GetContext().Books.Add(_books);
            }
            else        //редактировать
            {
                GlazkiSaveEntities.GetContext().Books.Add(_books);
            }

            try //сохранение контекста 
            {
                GlazkiSaveEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                FrameManager.MainFrame.GoBack();
                FrameManager.MainFrame.NavigationService.RemoveBackEntry();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CloseSave_Click(object sender, RoutedEventArgs e)  //кнопка закрыть добавление
        {
            FrameManager.MainFrame.GoBack();
        }
    }
}
