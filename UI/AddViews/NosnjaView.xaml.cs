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

namespace UI.AddChangeViews
{
    /// <summary>
    /// Interaction logic for NosnjaView.xaml
    /// </summary>
    public partial class NosnjaView : Window
    {
        NosnjaContext db = new NosnjaContext();
        NastupaContext dbNastupa = new NastupaContext();
        List<string> kombinovanId = new List<string>();
        public NosnjaView()
        {
            InitializeComponent();
            foreach(Nastupa nastupa in dbNastupa.GetNastupai())
            {
                kombinovanId.Add(nastupa.ToString());
            }
            comboBoxNastupi.ItemsSource = kombinovanId;
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
                string id = (comboBoxNastupi.SelectedItem as string);
                string[] ids = id.Split('-');
                db.AddNosnja(new Nosnja
                {
                    IME_NOS = textBoxIme.Text,
                    NastupaIgracID_IG = int.Parse(ids[0]),
                    NastupaKoncertID_KC = int.Parse(ids[1])
                });
                MainWindow.nosnje.ItemsSource = db.GetNosnjai();
                this.Close();
            }
        }
    }
}
