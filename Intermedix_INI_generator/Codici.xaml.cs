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
        public Codici()
        {
            InitializeComponent();
        }

        private void btnAddCode_Click(object sender, RoutedEventArgs e)
        {
            String testoImmesso;

            testoImmesso = txtInserimento.Text;
            lsCodici.Items.Add(testoImmesso);
        }
    }

    public class Test
    {
        public string Test1 { get; set; }
    }
}
