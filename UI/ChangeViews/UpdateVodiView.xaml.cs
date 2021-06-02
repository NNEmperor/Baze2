using ProjekatBaze2.Common;
using ProjekatBaze2;
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
    /// Interaction logic for UpdateVodiView.xaml
    /// </summary>
    public partial class UpdateVodiView : Window
    {
        int idKoreograf;
        int idSastav;
        VodiContext db = new VodiContext();
        KoreografContext dbK = new KoreografContext();
        SastavContext dbS = new SastavContext();
        List<Koreograf> koregrafi = new List<Koreograf>();
        List<Sastav> sastavi = new List<Sastav>();
        public UpdateVodiView(int koreograf, int sastav)
        {
            InitializeComponent();
            idKoreograf = koreograf;
            idSastav = sastav;
            comboBoxKoreografi.ItemsSource = dbK.GetKoreografi();
            comboBoxSastavi.ItemsSource = dbS.GetSastavi();
            koregrafi = dbK.GetKoreografi();
            sastavi = dbS.GetSastavi();

            for(int i = 0; i < dbS.GetSastavi().Count; i++)
            {
                for(int j=0;j<dbK.GetKoreografi().Count; j++)
                {
                    if(koreograf == koregrafi[j].ID_KOR && sastav == sastavi[i].ID_SS)
                    {
                        comboBoxKoreografi.SelectedIndex = j;
                        comboBoxSastavi.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxKoreografi.SelectedItem == null)
            {
                comboBoxKoreografi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxKoreografi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxSastavi.SelectedItem == null)
            {
                comboBoxSastavi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxSastavi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Vodi trenutno = new Vodi()
                {
                    KoreografID_KOR = int.Parse(comboBoxKoreografi.SelectedItem as string),
                    SastavID_SS = int.Parse(comboBoxSastavi.SelectedItem as string)
                };
                db.UpdateVodi(trenutno, idKoreograf, idSastav);

                MainWindow.vodjenje.ItemsSource = db.GetVodii();
                this.Close();
            }
        }
    }
}
