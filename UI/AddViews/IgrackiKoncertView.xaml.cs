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
    /// Interaction logic for IgrackiKoncertView.xaml
    /// </summary>
    public partial class IgrackiKoncertView : Window
    {
        MuzikaContext dbMuzika = new MuzikaContext();
        KoncertContext dbKoncert = new KoncertContext();
        IgrackiKoncertContext dbIgracki = new IgrackiKoncertContext();
        DateTime vreme;
        public IgrackiKoncertView(DateTime vreme)
        {
            InitializeComponent();
            List<string> muzike = new List<string>();
            foreach (Muzika m in dbMuzika.GetMuzikai())
            {
                muzike.Add(m.ID_MUZ.ToString());
            }

            comboBoxMuzika.ItemsSource = muzike;
            this.vreme = vreme;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxMuzika.SelectedItem != null)
            {
                comboBoxMuzika.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxMuzika.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if(textBoxKoreografija.Text == "" || textBoxKoreografija.Text == null)
            {
                textBoxKoreografija.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxKoreografija.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                dbIgracki.AddIgrackiKoncert(new IgrackiKoncert
                {
                    MuzikaID_MUZ = int.Parse(comboBoxMuzika.SelectedItem as string),
                    IG_KOR = textBoxKoreografija.Text,
                    VR_KC = vreme,
                    TIP_KC = "Igracki"
                });

                MainWindow.koncerti.ItemsSource = dbKoncert.GetKoncerti();
                MainWindow.koncertiIgracki.ItemsSource = dbIgracki.GetIgrackiKoncerti();

                this.Close();
            }


        }
    }
}
