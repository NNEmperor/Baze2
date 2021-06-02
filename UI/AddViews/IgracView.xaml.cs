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
    /// Interaction logic for IgracView.xaml
    /// </summary>
    public partial class IgracView : Window
    {
        IgracContext db = new IgracContext();


        public IgracView()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            int vis;
            if (textBoxIme.Text == "" || textBoxIme.Text == null)
            {
                textBoxIme.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxIme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (textBoxPrezime.Text == "" || textBoxPrezime.Text == null)
            {
                textBoxPrezime.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxPrezime.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxPol.SelectedItem == null)
            {
                comboBoxPol.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxPol.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (textBoxVisina.Text == "" || textBoxVisina.Text == null || !int.TryParse(textBoxVisina.Text, out vis))
            {
                textBoxVisina.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxVisina.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {

                string polDuze = comboBoxPol.SelectedItem.ToString();
                string pol;
                if (polDuze.Contains("Zensko"))
                    pol = "Zensko";
                else
                    pol = "Musko";
                db.AddIgrac(new Igrac
                {
                    IME_IG = textBoxIme.Text,
                    PR_IG = textBoxPrezime.Text,
                    POL_IG = pol,
                    VIS_IG = vis
                });
                MainWindow.igraci.ItemsSource = db.GetIgraci();
                this.Close();
            }

        }
    }
}
