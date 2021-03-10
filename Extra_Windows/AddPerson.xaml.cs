using System;
using System.Collections.Generic;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        public AddPerson()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }


        //Color control in the two textboxes....
        private void tbx_personName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbx_personName.Text == "Enter name here:")
            {
                tbx_personName.Text = "";
                tbx_personName.Foreground = Brushes.Black;
            }
        }

        private void tbx_personValue_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbx_personValue.Text == "Enter a value:")
            {
                tbx_personValue.Text = "";
                tbx_personValue.Foreground = Brushes.Black;
            }
        }

        private void tbx_personName_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbx_personName.Text == "")
            {
                tbx_personName.Text = "Enter name here:";
                tbx_personName.Foreground = Brushes.LightSlateGray;
            }
        }

        private void tbx_personValue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbx_personValue.Text == "")
            {
                tbx_personValue.Text = "Enter a value:";
                tbx_personValue.Foreground = Brushes.LightSlateGray;
            }
        }
    }
}
