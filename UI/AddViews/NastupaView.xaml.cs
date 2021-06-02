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
    /// Interaction logic for NastupaView.xaml
    /// </summary>
    public partial class NastupaView : Window
    {
        NastupaContext db = new NastupaContext();
        IgracContext dbK = new IgracContext();
        KoncertContext dbS = new KoncertContext();
        public NastupaView()
        {
            InitializeComponent();
            comboBoxIgraci.ItemsSource = dbK.GetIgraci();
            comboBoxKoncerti.ItemsSource = dbS.GetKoncerti();
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
                db.AddNastupa(new Nastupa
                {
                    IgracID_IG = int.Parse(comboBoxIgraci.SelectedItem as string),
                    KoncertID_KC = int.Parse(comboBoxKoncerti.SelectedItem as string)

                });
                MainWindow.nastupanje.ItemsSource = db.GetNastupai();
                this.Close();
            }
        }
    }
}
