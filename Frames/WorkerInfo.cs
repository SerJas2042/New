using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Session_1.Frames
{
    internal class WorkerInfo : INotifyPropertyChanged
    {
        private string name { get; set; }
        private string secondName { get; set; }
        private string thirdName { get; set; }
        private string role { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChenged();
            }
        }
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
                OnPropertyChenged();
            }
        }
        public string ThirdName
        {
            get
            {
                return thirdName;
            }
            set
            {
                thirdName = value;
                OnPropertyChenged();
            }
        }
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
                OnPropertyChenged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChenged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
