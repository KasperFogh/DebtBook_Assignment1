using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DebtBook.Extra_Windows
{
    /// <summary>
    /// Interaction logic for PersonDebt.xaml
    /// </summary>
    public partial class PersonDebt : Window
    {
        public PersonDebt()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
