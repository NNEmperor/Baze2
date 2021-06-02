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

namespace UI.ChangeViews
{
    /// <summary>
    /// Interaction logic for UpdateNastupaView.xaml
    /// </summary>
    public partial class UpdateNastupaView : Window
    {
        int idIgrac;
        int idKoncert;
        NastupaContext db = new NastupaContext();
        IgracContext dbI = new IgracContext();
        KoncertContext dbK = new KoncertContext();
        List<Igrac> igraci = new List<Igrac>();
        List<Koncert> koncerti = new List<Koncert>();
        public UpdateNastupaView(int igrac, int koncert)
        {
            InitializeComponent();
            idIgrac = igrac;
            idKoncert = koncert;
            comboBoxIgraci.ItemsSource = dbI.GetIgraci();
            comboBoxKoncerti.ItemsSource = dbK.GetKoncerti();
            for (int i = 0; i < dbI.GetIgraci().Count; i++)
            {
                for (int j = 0; j < dbK.GetKoncerti().Count; j++)
                {
                    if (igrac == igraci[i].ID_IG && koncert == koncerti[j].ID_KC)
                    {
                        comboBoxIgraci.SelectedIndex = i;
                        comboBoxKoncerti.SelectedIndex = j;
                        break;
                    }
                }
            }
        }
        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxIgraci.SelectedItem == null)
            {
                comboBoxIgraci.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxIgraci.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxKoncerti.SelectedItem == null)
            {
                comboBoxKoncerti.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxKoncerti.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Nastupa trenutno = new Nastupa()
                {
                    IgracID_IG = int.Parse(comboBoxIgraci.SelectedItem as string),
                    KoncertID_KC = int.Parse(comboBoxKoncerti.SelectedItem as string)
                };
                db.UpdateNastupa(trenutno, idIgrac, idKoncert);

                MainWindow.nastupanje.ItemsSource = db.GetNastupai();
                this.Close();
            }
        }
    }
}
