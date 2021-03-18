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
        string timestamp = DateTime.Now.ToString();
        string number;
        
        public Person()
        {

        }

        public Person(string aName, string aTimeStamp, string aNumber)
        {
            name = aName;
            timestamp  = aTimeStamp;
            number = aNumber;
        }

        public string Name { get { return name; } set { name = value; } }
        public string Timestamp { get { return timestamp; } set { timestamp = value; } }
        public string Number { get { return number; } set { number = value; } }
    }
}
