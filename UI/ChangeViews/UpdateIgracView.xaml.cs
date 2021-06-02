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
    /// Interaction logic for UpdateIgracView.xaml
    /// </summary>
    public partial class UpdateIgracView : Window
    {
        int id;
        IgracContext db = new IgracContext();
        public UpdateIgracView(int id)
        {
            InitializeComponent();
            Igrac trenutno = db.GetIgrac(id);
            textBoxIme.Text = trenutno.IME_IG;
            textBoxPrezime.Text = trenutno.PR_IG;
            textBoxVisina.Text = trenutno.VIS_IG.ToString();
            if (trenutno.POL_IG == "Musko")
                comboBoxPol.SelectedIndex = 0;
            else
                comboBoxPol.SelectedIndex = 1;
            this.id = id;
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
                Igrac trenutno = new Igrac();
                trenutno.IME_IG = textBoxIme.Text;
                string polDuze = comboBoxPol.SelectedItem.ToString();
                string pol;
                if (polDuze.Contains("Zensko"))
                    pol = "Zensko";
                else
                    pol = "Musko";
                trenutno.POL_IG = pol;
                trenutno.PR_IG = textBoxPrezime.Text;
                trenutno.VIS_IG = vis;
                db.UpdateIgrac(trenutno, id);
                MainWindow.igraci.ItemsSource = db.GetIgraci();
                this.Close();
            }
        }
    }
}
