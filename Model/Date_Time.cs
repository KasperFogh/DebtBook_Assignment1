using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace DebtBook.Model
{
    public class Date_Time : BindableBase
    {
        string _date;
        string _time;

        public void Update()
        {
            Time = DateTime.Now.ToString();
            Date = DateTime.Now.ToString();
        }
        public string Time
        {
            get
            {
                return _time;
            }
            private set
            {
                SetProperty(ref _time, value);
            }
        }
        public string Date
        {
            get { return _date; }
            private set
            {
                SetProperty(ref _date, value);
            }
        }

    }
}
