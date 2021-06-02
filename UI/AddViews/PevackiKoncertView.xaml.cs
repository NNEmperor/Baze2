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
    /// Interaction logic for PevackiKoncertView.xaml
    /// </summary>
    public partial class PevackiKoncertView : Window
    {
        PevackiKoncertContext db = new PevackiKoncertContext();
        KoncertContext dbKoncert = new KoncertContext();
        DateTime vreme;
        public PevackiKoncertView(DateTime vreme)
        {
            InitializeComponent();
            this.vreme = vreme;
        }
        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxTip.SelectedItem == null)
            {
                comboBoxTip.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxTip.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                string tipDuze = comboBoxTip.SelectedItem.ToString();
                string tip;
                if (tipDuze.Contains("Hor"))
                    tip = "Hor";
                else
                    tip = "Solista";
                db.AddPevackiKoncert(new PevackiKoncert
                {
                    PEV_TIP = tip,
                    TIP_KC = "Pevacki",
                    VR_KC = vreme
                });
                MainWindow.koncerti.ItemsSource = dbKoncert.GetKoncerti();
                MainWindow.koncertiPevacki.ItemsSource = db.GetPevackiKoncerti();

                this.Close();
            }
        }
    }
}
