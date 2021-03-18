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
        ObservableCollection<Person> personlist;
        private string _filename = "DebtBook";
        string _textfile = Path.Combine(Environment.CurrentDirectory, @"Textfile\wave.xml");

        private DispatcherTimer timer = new DispatcherTimer();
        public ViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            personlist = new ObservableCollection<Person>
            {
                new Person("bob","digdj","50"),
                new Person("bob","digdj","50"),
                new Person("bob","digdj","50")
            };
        }
        int currentPersonIndex =  -1;
        public int CurrentPersonIndex
        {
            get { return currentPersonIndex;  }
            set
            {
                SetProperty(ref currentPersonIndex, value);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _dateTime.Update();
        }

        private void AddNewPerson()
        {
            AddPerson addPerson = new AddPerson();
            addPerson.Show();
        }

       


        #region Property

        Date_Time _dateTime = new Date_Time();
        public Date_Time dateTime { get => _dateTime; set => _dateTime = value; }

        public ObservableCollection<Person> Persons
        {
            get
            {
                return personlist;
            }
            set
            {
                SetProperty(ref personlist, value);
            }
        }

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
        ICommand _savePerson;
        public ICommand SavePerson
        {
            get
            {
                return _savePerson ?? (_savePerson = new DelegateCommand(SaveCommandExecute).ObservesProperty(()=>Persons));
            }
        }
        private void SaveCommandExecute()
        {
            XmlSerializer serializer  = new XmlSerializer(typeof(ObservableCollection<Person>));
            TextWriter writer = new StreamWriter(_filename);

            serializer.Serialize(writer, Persons);
            writer.Close();
        }
        
        
        #endregion
    }

}
