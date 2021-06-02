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
    /// Interaction logic for KoreografView.xaml
    /// </summary>
    public partial class KoreografView : Window
    {

        KoreografContext db = new KoreografContext();
        public KoreografView()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text == null || textBoxIme.Text == "")
            {
                textBoxIme.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxIme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else if (textBoxPrezime.Text == null || textBoxPrezime.Text == "")
            {
                textBoxPrezime.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxPrezime.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                db.AddKoreograf(new Koreograf
                {
                    IME_KOR = textBoxIme.Text,
                    PR_KOR = textBoxPrezime.Text
                });
                MainWindow.koreografi.ItemsSource = db.GetKoreografi();
                this.Close();
            }
        }
    }
}
