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
    /// Interaction logic for UpdateNosnjaView.xaml
    /// </summary>
    public partial class UpdateNosnjaView : Window
    {
        int id;
        NosnjaContext db = new NosnjaContext();
        NastupaContext dbNastupa = new NastupaContext();
        List<string> kombinovanId = new List<string>();

        public UpdateNosnjaView(int id)
        {
            InitializeComponent();
            foreach (Nastupa nastupa in dbNastupa.GetNastupai())
            {
                kombinovanId.Add(nastupa.ToString());
            }
            comboBoxNastupi.ItemsSource = kombinovanId;
            Nosnja trenutno = db.GetNosnja(id);
            textBoxIme.Text = trenutno.IME_NOS;

            for (int i = 0; i < kombinovanId.Count; i++)
            {
                if(kombinovanId[i].Contains(trenutno.NastupaIgracID_IG.ToString()) && kombinovanId[i].Contains(trenutno.NastupaKoncertID_KC.ToString())){
                    comboBoxNastupi.SelectedIndex = i;
                }
            }

            this.id = id;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text == "" || textBoxIme.Text == null)
            {
                textBoxIme.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxIme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxNastupi.SelectedItem == null)
            {
                comboBoxNastupi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxNastupi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Nosnja trenutno = new Nosnja();
                trenutno.IME_NOS = textBoxIme.Text;
                string id1 = (comboBoxNastupi.SelectedItem as string);
                string[] ids = id1.Split('-');
                trenutno.NastupaIgracID_IG = int.Parse(ids[0]);
                trenutno.NastupaKoncertID_KC = int.Parse(ids[1]);
                db.UpdateNosnja(trenutno, id);
                MainWindow.nosnje.ItemsSource = db.GetNosnjai();
                this.Close();
            }
        }
    }
}
