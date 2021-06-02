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
    /// Interaction logic for KoncertView.xaml
    /// </summary>
    public partial class KoncertView : Window
    {
        KoncertContext db = new KoncertContext();
        public KoncertView()
        {
            InitializeComponent();
        }

        public KoncertView(string tip)
        {
            InitializeComponent();
            if(tip == "Igracki")
            {
                comboBoxTip.SelectedIndex = 0;
            }
            else if (tip == "Pevacki")
            {
                comboBoxTip.SelectedIndex = 1;
            }
            else
            {
                comboBoxTip.SelectedIndex = 2;
            }
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxTip.SelectedItem == null)
            {
                comboBoxTip.BorderBrush = new SolidColorBrush(Colors.Red);
                comboBoxTip.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (dateTimeVreme.SelectedDate == null)
            {
                dateTimeVreme.BorderBrush = new SolidColorBrush(Colors.Red);
                dateTimeVreme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                string tip = (comboBoxTip.SelectedItem.ToString());

                if (tip.Contains("Igracki"))
                {
                    IgrackiKoncertView view = new IgrackiKoncertView(dateTimeVreme.SelectedDate.Value);
                    view.Show();
                }
                else if (tip.Contains("Pevacki"))
                {
                    PevackiKoncertView view = new PevackiKoncertView(dateTimeVreme.SelectedDate.Value);
                    view.Show();
                }
                else
                {
                    KombinovanKoncertView view = new KombinovanKoncertView(dateTimeVreme.SelectedDate.Value);
                    view.Show();
                }

                this.Close();
            }
        }
    }
}
