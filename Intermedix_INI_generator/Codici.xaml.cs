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

namespace Intermedix_INI_generator
{
    /// <summary>
    /// Logica di interazione per Codici.xaml
    /// </summary>
    public partial class Codici : Window
    {
        private List<String> elenco = new List<string>();
        public Codici()
        {
            InitializeComponent();
        }

        public Codici(List<String> value)
        {
            elenco = value;
            InitializeComponent();
        }

        private void btnAddCode_Click(object sender, RoutedEventArgs e)
        {

            lsCodici.Items.Add(txtInserimento.Text);
            txtInserimento.Text = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in elenco)
            {
                lsCodici.Items.Add(s);
            }
            txtInserimento.Focus();
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            lsCodici.Items.RemoveAt(lsCodici.SelectedIndex);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            elenco.Clear();
            foreach (String strCol in lsCodici.Items)
            {
                elenco.Add(strCol);
            }
        }
    }
}
