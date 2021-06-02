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
    /// Interaction logic for PripadaView.xaml
    /// </summary>
    public partial class PripadaView : Window
    {
        PripadaContext db = new PripadaContext();
        IgracContext dbK = new IgracContext();
        SastavContext dbS = new SastavContext();
        public PripadaView()
        {
            InitializeComponent();
            List<string> idIgraci = new List<string>();
            foreach(Igrac i in dbK.GetIgraci())
            {
                idIgraci.Add(i.ID_IG.ToString());
            }
            List<string> idSastavi = new List<string>();
            foreach (Sastav i in dbS.GetSastavi())
            {
                idSastavi.Add(i.ID_SS.ToString());
            }
            comboBoxIgraci.ItemsSource = idIgraci;
            comboBoxSastavi.ItemsSource = idSastavi;
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
                db.AddPripada(new Pripada
                {
                    IgracID_IG = int.Parse(comboBoxIgraci.SelectedItem as string),
                    SastavID_SS = int.Parse(comboBoxSastavi.SelectedItem as string)
                });
                MainWindow.pripadanja.ItemsSource = db.GetPripadai();
                this.Close();
            }
        }
    }
}
