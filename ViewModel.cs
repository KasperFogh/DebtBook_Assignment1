using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Data;
using Prism.Mvvm;
using Prism.Commands;
using System.IO;
using System.Xml.Serialization;
using DebtBook.Extra_Windows;
using DebtBook.Model;


namespace DebtBook
{
    public class ViewModel:BindableBase
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public ViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _dateTime.Update();
        }

        #region Property
        Date_Time _dateTime = new Date_Time();
        public Date_Time dateTime { get => _dateTime; set => _dateTime = value; }
        #endregion

        #region Commands
        ICommand _exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new DelegateCommand(() =>
                 {
                     App.Current.MainWindow.Close();
                 }));
            }
        }
        ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand((AddNewPerson)));
            }
           
        }
        
        private void AddNewPerson()
        {
            AddPerson addPerson = new AddPerson();
            addPerson.Show();
        }
        #endregion
    }

}
