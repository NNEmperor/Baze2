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
    /// Interaction logic for ProbaView.xaml
    /// </summary>
    public partial class ProbaView : Window
    {

        ProbaContext db = new ProbaContext();
        SastavContext dbS = new SastavContext();

        public ProbaView()
        {
            InitializeComponent();
            comboBoxSastavi.ItemsSource = dbS.GetSastavi();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxTip.Text == "" || textBoxTip.Text == null)
            {
                textBoxTip.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxTip.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (comboBoxSastavi.SelectedItem == null)
            {
                comboBoxSastavi.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxSastavi.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                db.AddProba(new Proba
                {
                    TIP_PROB = textBoxTip.Text,
                    VR_PROB = datePickerVreme.SelectedDate.Value,
                    SastavID_SS = int.Parse(comboBoxSastavi.SelectedItem as string)
                });
                MainWindow.probe.ItemsSource = db.GetProbai();
                this.Close();
            }
        }
    }
}
