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
    /// Interaction logic for UpdateProbaView.xaml
    /// </summary>
    public partial class UpdateProbaView : Window
    {
        int id, idSastav;
        ProbaContext db = new ProbaContext();
        SastavContext dbS = new SastavContext();

        public UpdateProbaView(int id, int idSastav)
        {
            InitializeComponent();
            Proba trenutno = db.GetProba(id, idSastav);
            textBoxTip.Text = trenutno.TIP_PROB;
            datePickerVreme.SelectedDate = trenutno.VR_PROB;

            this.id = id;
            this.idSastav = idSastav;
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
                Proba trenutno = new Proba();
                trenutno.TIP_PROB = textBoxTip.Text;
                trenutno.VR_PROB = datePickerVreme.SelectedDate.Value;

                db.UpdateProba(trenutno, id, idSastav);
                MainWindow.probe.ItemsSource = db.GetProbai();
                this.Close();
            }
        }
    }
}
