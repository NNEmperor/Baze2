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
    /// Interaction logic for KombinovanKoncertView.xaml
    /// </summary>
    public partial class KombinovanKoncertView : Window
    {
        MuzikaContext dbMuzika = new MuzikaContext();
        IgrackiKoncertContext dbIgracki = new IgrackiKoncertContext();
        PevackiKoncertContext dbPevacki = new PevackiKoncertContext();
        KoncertContext dbKoncert = new KoncertContext();
        DateTime vreme;
        public KombinovanKoncertView(DateTime vreme)
        {
            InitializeComponent();
            List<string> muzike = new List<string>();
            foreach(Muzika m in dbMuzika.GetMuzikai())
            {
                muzike.Add(m.ID_MUZ.ToString());
            }

            comboBoxMuzika.ItemsSource = muzike;
            this.vreme = vreme;
        }
        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxKoreografija.Text == "" || textBoxKoreografija.Text == null)
            {
                textBoxKoreografija.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxKoreografija.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxMuzika.SelectedItem == null)
            {
                comboBoxMuzika.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxMuzika.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxTipPesme.SelectedItem == null)
            {
                comboBoxTipPesme.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxTipPesme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                string tipDuze = comboBoxTipPesme.SelectedItem.ToString();
                string tip;
                if (tipDuze.Contains("Hor"))
                    tip = "Hor";
                else
                    tip = "Solista";
                dbIgracki.AddIgrackiKoncert(new IgrackiKoncert
                {
                    MuzikaID_MUZ = int.Parse(comboBoxMuzika.SelectedItem as string),
                    IG_KOR = textBoxKoreografija.Text,
                    VR_KC = vreme,
                    TIP_KC = "Igracki"
                });
                dbPevacki.AddPevackiKoncert(new PevackiKoncert
                {
                    PEV_TIP = tip,
                    VR_KC = vreme,
                    TIP_KC = "Pevacki"
                });
                MainWindow.koncerti.ItemsSource = dbKoncert.GetKoncerti();
                MainWindow.koncertiIgracki.ItemsSource = dbIgracki.GetIgrackiKoncerti();
                MainWindow.koncertiPevacki.ItemsSource = dbPevacki.GetPevackiKoncerti();

                this.Close();
            }
        }
    }
}
