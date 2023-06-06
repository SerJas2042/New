using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using Session_1.Classes;
using Session_1.DataBase;

namespace Session_1.Frames
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Administator : Page
    {
        public Administator()
        {
            InitializeComponent();
            PrintUserData();
        }
        

        //Загрузка данных о пользователе
        public void PrintUserData() 
        {
            var query = from UserInfo 
                        in StaticData.db.UserInfo
                        where UserInfo.ID == StaticData.ID
                        select new {UserInfo.Name, UserInfo.Second_Name, UserInfo.Fird_Name};
            UserData.ItemsSource = query.ToList();
  
        }
        //Загрузка фотографии пользователя
        private void WorkerFace_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var path = (from UserInfo
                            in StaticData.db.UserInfo
                            where UserInfo.ID == StaticData.ID
                            select new { UserInfo.Photo }).First();

                string photo = Convert.ToString(path.Photo);

                WorkerFace.Source = new ImageSourceConverter().ConvertFromString(photo) as ImageSource;
            }
            catch
            {
                WorkerFace.Source = new ImageSourceConverter().ConvertFromString("C:/Users/serzh/source/repos/Session 1/Resources/SimpleFace.png") as ImageSource;
            }

            
        }
        //Открытие таблицы
        private void OpenData_Click(object sender, RoutedEventArgs e)
        {
            OpenTable.ItemsSource = GlazkiSaveEntities.GetContext().Books.ToList();
        }
        //Открытие страницы добавления
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Add(null));
        }

        //Кнопка редактировать
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new Add((sender as Button).DataContext as Books));

            GlazkiSaveEntities.GetContext().Books.Remove( (sender as Button).DataContext as Books);
            try
            {
                GlazkiSaveEntities.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        //кнопка удалить 
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            GlazkiSaveEntities.GetContext().Books.RemoveRange(OpenTable.SelectedItems.Cast<Books>().ToList());

            if(MessageBox.Show($"Будут удалены элемент/ы: {OpenTable.SelectedItems.Cast<Books>().Count()}" , "продолжить ?" ,
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GlazkiSaveEntities.GetContext().SaveChanges();
                    OpenTable.ItemsSource = GlazkiSaveEntities.GetContext().Books.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Отмена");
            }

            
        }
        //отображение изминений в таблице
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                GlazkiSaveEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                OpenTable.ItemsSource = GlazkiSaveEntities.GetContext().Books.ToList();
            }
        }

    }
}
