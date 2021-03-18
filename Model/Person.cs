using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DebtBook.Model
{
    public class Person
    {
        string name;
        DateTime timestamp;
        string number;
        
        public Person()
        {

        }

        public Person(string Name, string TimeStamp, string Number)
        {
            Name = name;
            TimeStamp = timestamp.ToString();
            Number = number;
        }

        public string Name { get { return name; } set { name = value; } }
        public DateTime Timestamp { get { return timestamp; } set { timestamp = value; } }
        public string Number { get { return number; } set { number = value; } }
    }
}
