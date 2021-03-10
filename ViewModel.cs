using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.IO;
using System.Xml.Serialization;

namespace DebtBook
{
    public class ViewModel:BindableBase
    {
        public ViewModel()
        {

        }
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
                return _addCommand ?? (_addCommand=new DelegateCommand(()=>
                {
                    App.
                }
            }
        }
        private void AddPerson()
        {
            
        }
        #endregion
    }

}
