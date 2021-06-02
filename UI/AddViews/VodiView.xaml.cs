using ProjekatBaze2;
using ProjekatBaze2.Common;
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

namespace UI.AddViews
{
    /// <summary>
    /// Interaction logic for VodiView.xaml
    /// </summary>
    public partial class VodiView : Window
    {
        VodiContext db = new VodiContext();
        KoreografContext dbK = new KoreografContext();
        SastavContext dbS = new SastavContext();
        public VodiView()
        {
            InitializeComponent();
            List<string> idKoregrafi = new List<string>();
            foreach (Koreograf i in dbK.GetKoreografi())
            {
                idKoregrafi.Add(i.ID_KOR.ToString());
            }
            List<string> idSastavi = new List<string>();
            foreach (Sastav i in dbS.GetSastavi())
            {
                idSastavi.Add(i.ID_SS.ToString());
            }
            comboBoxKoreografi.ItemsSource = idKoregrafi;
            comboBoxSastavi.ItemsSource = idSastavi;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxKoreografi.SelectedItem == null)
            {
                comboBoxKoreografi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxKoreografi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxSastavi.SelectedItem == null)
            {
                comboBoxSastavi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxSastavi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                db.AddVodi(new Vodi
                {
                    KoreografID_KOR = int.Parse(comboBoxKoreografi.SelectedItem as string),
                    SastavID_SS = int.Parse(comboBoxSastavi.SelectedItem as string),
                });
                MainWindow.vodjenje.ItemsSource = db.GetVodii();
                this.Close();
            }
        }
    }
}
