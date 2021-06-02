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
    /// Interaction logic for UpdateKoreografView.xaml
    /// </summary>
    public partial class UpdateKoreografView : Window
    {
        int id;
        KoreografContext db = new KoreografContext();
        public UpdateKoreografView(int id)
        {
            InitializeComponent();
            Koreograf trenutno = db.GetKoreograf(id);
            textBoxIme.Text = trenutno.IME_KOR;
            textBoxPrezime.Text = trenutno.PR_KOR;
            this.id = id;
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
                Koreograf trenutno = new Koreograf();
                trenutno.IME_KOR = textBoxIme.Text;
                trenutno.PR_KOR = textBoxPrezime.Text;
                db.UpdateKoreograf(trenutno, id);
                MainWindow.koreografi.ItemsSource = db.GetKoreografi();
                this.Close();
            }
        }
    }
}
