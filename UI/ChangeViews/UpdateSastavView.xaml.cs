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
    /// Interaction logic for UpdateSastavView.xaml
    /// </summary>
    public partial class UpdateSastavView : Window
    {
        int id;
        SastavContext db = new SastavContext();
        public UpdateSastavView(int id)
        {
            InitializeComponent();
            Sastav trenutno = db.GetSastav(id);
            textBoxIme.Text = trenutno.IME_SS;
            this.id = id;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIme.Text == "" || textBoxIme.Text == null)
            {
                textBoxIme.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxIme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Sastav trenutno = new Sastav();
                trenutno.IME_SS = textBoxIme.Text;
                db.UpdateSastav(trenutno, id);
                MainWindow.sastavi.ItemsSource = db.GetSastavi();
                this.Close();
            }
        }
    }
}
