using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using intcc.Model;

namespace intcc
{
    /// <summary>
    /// Interaction logic for CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void Tb_GotFocus(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            tb?.SelectAll();
        }

        private void Tb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null || tb.IsKeyboardFocusWithin) return;
            e.Handled = true;
            tb.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
