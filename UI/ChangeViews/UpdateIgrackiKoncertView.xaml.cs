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
    /// Interaction logic for UpdateIgrackiKoncertView.xaml
    /// </summary>
    public partial class UpdateIgrackiKoncertView : Window
    {
        MuzikaContext dbMuzika = new MuzikaContext();
        KoncertContext dbKoncert = new KoncertContext();
        IgrackiKoncertContext dbIgracki = new IgrackiKoncertContext();
        int id;

        public UpdateIgrackiKoncertView(int id)
        {
            InitializeComponent();
            List<string> muzike = new List<string>();
            foreach (Muzika m in dbMuzika.GetMuzikai())
            {
                muzike.Add(m.ID_MUZ.ToString());
            }
            comboBoxMuzika.ItemsSource = muzike;
            List<Muzika> muzikeSve = dbMuzika.GetMuzikai();
            for(int i = 0; i < dbMuzika.GetMuzikai().Count; i++)
            {
                if (dbIgracki.GetIgrackiKoncert(id).MuzikaID_MUZ == muzikeSve[i].ID_MUZ)
                {
                    comboBoxMuzika.SelectedIndex = i;
                }
            }
            textBoxKoreografija.Text = dbIgracki.GetIgrackiKoncert(id).IG_KOR;
            this.id = id;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxMuzika.SelectedItem != null)
            {
                comboBoxMuzika.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxMuzika.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (textBoxKoreografija.Text == "" || textBoxKoreografija.Text == null)
            {
                textBoxKoreografija.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxKoreografija.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                var trenutno = new IgrackiKoncert();
                trenutno.IG_KOR = textBoxKoreografija.Text;
                trenutno.MuzikaID_MUZ = int.Parse(comboBoxMuzika.SelectedItem as string);
                dbIgracki.UpdateIgrackiKoncert(trenutno, id);
                MainWindow.koncertiIgracki.ItemsSource = dbIgracki.GetIgrackiKoncerti();
                this.Close();
            }
        }
    }
}
