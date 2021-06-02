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
    /// Interaction logic for UpdatePevackiKoncertView.xaml
    /// </summary>
    public partial class UpdatePevackiKoncertView : Window
    {
        MuzikaContext dbMuzika = new MuzikaContext();
        KoncertContext dbKoncert = new KoncertContext();
        PevackiKoncertContext dbPevacki = new PevackiKoncertContext();
        int id;
        public UpdatePevackiKoncertView(int id)
        {
            InitializeComponent();
            PevackiKoncert pevacki = dbPevacki.GetPevackiKoncert(id);
            if (pevacki.PEV_TIP == "Solista")
                comboBoxTip.SelectedIndex = 0;
            else
                comboBoxTip.SelectedIndex = 1;
            this.id = id;
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
                PevackiKoncert trenutno = new PevackiKoncert();
                string tipDuze = comboBoxTip.SelectedItem.ToString();
                string tip;
                if (tipDuze.Contains("Hor"))
                    tip = "Hor";
                else
                    tip = "Solista";
                trenutno.PEV_TIP = tip;
                dbPevacki.UpdatePevackiKoncert(trenutno, id);
                MainWindow.koncertiPevacki.ItemsSource = dbPevacki.GetPevackiKoncerti();
                this.Close();
            }
        }
    }
}
