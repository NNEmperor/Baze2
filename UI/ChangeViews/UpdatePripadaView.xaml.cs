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
    /// Interaction logic for UpdatePripadaView.xaml
    /// </summary>
    public partial class UpdatePripadaView : Window
    {
        int idIgrac;
        int idSastav;
        PripadaContext db = new PripadaContext();
        IgracContext dbK = new IgracContext();
        SastavContext dbS = new SastavContext();
        List<Igrac> koregrafi = new List<Igrac>();
        List<Sastav> sastavi = new List<Sastav>();
        public UpdatePripadaView(int igrac, int sastav)
        {
            InitializeComponent();
            idIgrac = igrac;
            idSastav = sastav;
            comboBoxIgraci.ItemsSource = dbK.GetIgraci();
            comboBoxSastavi.ItemsSource = dbS.GetSastavi();
            koregrafi = dbK.GetIgraci();
            sastavi = dbS.GetSastavi();

            for (int i = 0; i < dbS.GetSastavi().Count; i++)
            {
                for (int j = 0; j < dbK.GetIgraci().Count; j++)
                {
                    if (igrac == koregrafi[j].ID_IG && sastav == sastavi[i].ID_SS)
                    {
                        comboBoxIgraci.SelectedIndex = j;
                        comboBoxSastavi.SelectedIndex = i;
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
            else if (comboBoxSastavi.SelectedItem == null)
            {
                comboBoxSastavi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxSastavi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Pripada trenutno = new Pripada()
                {
                    IgracID_IG = int.Parse(comboBoxIgraci.SelectedItem as string),
                    SastavID_SS = int.Parse(comboBoxSastavi.SelectedItem as string)
                };
                db.UpdatePripada(trenutno, idIgrac, idSastav);

                MainWindow.pripadanja.ItemsSource = db.GetPripadai();
                this.Close();
            }
        }
    }
}
