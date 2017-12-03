using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Intermedix_INI_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string imgName = null;
        private Visibility visCheckOrder = Visibility.Hidden;
        List<string> myStrings = new List<string>(); // To Storage the seleted values
        List<string> myCode = new List<string>(); // To Storage the seleted values

        public MainWindow()
        {
            InitializeComponent();

        }

        public void CreteIni()
        {
            var MyIni = new IniFile("Test.ini");
            string dataInizioFormattata = datepickerDataInizio.Text.Substring(6,4) + datepickerDataInizio.Text.Substring(3,2) + datepickerDataInizio.Text.Substring(0,2);
            string dataFineFormattata = datepickerDataFine.Text.Substring(6,4) + datepickerDataFine.Text.Substring(3,2) + datepickerDataFine.Text.Substring(0,2);
            string regioni = null;

            MyIni.Write("DESCR", textCampaignDescription.Text, textCampaignName.Text);
            MyIni.Write("TIPO", (comboCampaignType.SelectedItem as ComboBoxItem).Tag.ToString(), textCampaignName.Text);
            MyIni.Write("IMG", @"dat\prodcons\" + imgName, textCampaignName.Text);
            MyIni.Write("DATA_DA", dataInizioFormattata, textCampaignName.Text);
            MyIni.Write("DATA_AL", dataFineFormattata, textCampaignName.Text);

            if (myStrings.Count > 0)
            {
                foreach (string s in myStrings)
                {
                    regioni = regioni + s + "|";
                }
            }

            MyIni.Write("REGIONE", regioni, textCampaignName.Text);
            MyIni.Write("TESTO", textTesto.Text, textCampaignName.Text);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreteIni();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string testo1 = (sender as TextBox).Text;
            //var testo = textProdottoPerGiacenza.Text;

            if (testo1 != String.Empty)
            {
                visCheckOrder = Visibility.Visible;
            }

            //chkOrderButton.Visibility = visCheckOrder;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string gettag = (comboCampaignType.SelectedItem as ComboBoxItem).Tag.ToString();
            //MessageBox.Show(gettag);
        }

        private void btnImg_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                imgName = dlg.SafeFileName;

                //Uri uriDoc = new Uri(dlg.FileName, UriKind.Relative);
                Uri uriDoc = new Uri(dlg.FileName);

                imgVis.Source = new BitmapImage(uriDoc);
                btnImg.Content = imgName;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb != null)
            {
                myStrings.Add(cb.Tag.ToString());
            }
        }
    }
}