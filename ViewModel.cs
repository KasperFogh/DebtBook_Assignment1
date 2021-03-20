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
using System.Windows;
using System.ComponentModel.Design;
using Microsoft.Xaml.Behaviors.Core;
using System.Reflection;
using Microsoft.Win32;

namespace DebtBook
{
    public class ViewModel:BindableBase
    {
        ObservableCollection<Person> personlist = new ObservableCollection<Person>();
        private string _filename = "DebtBook";



        private DispatcherTimer timer = new DispatcherTimer();
        public ViewModel()
        {
            
            
            var tempPersons = new ObservableCollection<Person>();
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            TextReader reader = new StreamReader(_filename);
            tempPersons = (ObservableCollection<Person>)serializer.Deserialize(reader);
            reader.Close();
            personlist = tempPersons;
            
            //foreach(var person in personlist)
            //{
            //    if(person.Name == person.Name)
            //    {
            //        int total;
            //        int number = Convert.ToInt32(person.Number);
            //        foreach(int value in person.Number)
            //        {
            //            total = number + value;
            //        }
                    
            //    }
            //}
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            
        }
        
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            _dateTime.Update();
        }

        #region Property
        
        int currentPersonIndex = -1;
        public int CurrentPersonIndex
        {
            get { return currentPersonIndex; }
            set
            {
                SetProperty(ref currentPersonIndex, value);
            }
        }

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

        Person currentPerson = null;
        public Person CurrentPerson
        {
            get { return currentPerson; }
            set
            {
                SetProperty(ref currentPerson, value);
            }
        }
        string newDebtPerson = null;
        public string NewDebtPerson
        {
            get
            {
                return newDebtPerson;
            }
            set
            {
                SetProperty(ref newDebtPerson, value);
            }
        }
        string debtValue = null;
        public string DebtValue
        {
            get
            {
                return debtValue;
            }
            set
            {
                SetProperty(ref debtValue, value);
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

        ICommand _savePersonCommand;
        public ICommand SavePersonCommand
        {
            get
            {
                return _savePersonCommand ?? (_savePersonCommand = new DelegateCommand(SaveCommandExecute).ObservesProperty(()=>Persons.Count));
            }
        }
        private void SaveCommandExecute()
        {
            personlist.Add(new Person(NewDebtPerson,DateTime.Now.ToString(), DebtValue));
            XmlSerializer serializerwriter  = new XmlSerializer(typeof(ObservableCollection<Person>));
            TextWriter writer = new StreamWriter(_filename);

            serializerwriter.Serialize(writer, personlist);
            writer.Close();
            
            //var tempPersons = new ObservableCollection<Person>();
            //XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Person>));
            //TextReader reader = new StreamReader(_filename);
            //tempPersons = (ObservableCollection<Person>)serializer.Deserialize(reader);
            //reader.Close();
            //personlist = tempPersons;
           
        }
       

        #endregion
    }

}
