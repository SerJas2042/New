using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using Session_1.Classes;
using Session_1.Frames;

namespace Session_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.MainFrame = MainFrame;
            FrameManager.MainFrame.Navigate(new Avtorisation());            //Навигация фрэйма
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)     //кнопка назад
        {
            try
            {
                MainFrame.NavigationService.GoBack();
                MainFrame.NavigationService.RemoveBackEntry();
            }
            catch
            {
                BackButton.Visibility = Visibility.Hidden;
                CloseButton.Visibility = Visibility.Visible;
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)          //если поменялся фрэйм
        {
            if (MainFrame.NavigationService.CanGoBack == false)
            {
                CloseButton.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                CloseButton.Visibility = Visibility.Hidden;
                BackButton.Visibility = Visibility.Visible;

                if(time == 0)
                {
                    ConvertTime(0, 0, 15);
                    TimeStart();
                }
                
            }
        }

        readonly DispatcherTimer timer = new DispatcherTimer();     //ТАЙМЕР
        public int time = 0;

        public DispatcherTimer Timer => timer;

        public int ConvertTime(int h, int m, int s)
        {
            return time = h * 3600 + m * 60 + s;
        }

        public void TimeStart()
        {
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += TimeLess;
            Timer.Start();
            
        }

        private void TimeLess(object sender, EventArgs e)           //Событие в тик
        {
            if(time >= 0)
            {
                time -= 1;
                TimerShow.Text = Convert.ToString(TimeSpan.FromSeconds(time));
            }
            else
            {
                Timer.Stop();
                MainWindow window = new MainWindow();
                this.Close();
                window.Show();
                
            }
        }
    }
}
