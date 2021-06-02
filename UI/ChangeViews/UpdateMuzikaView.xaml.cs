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
    /// Interaction logic for UpdateMuzikaView.xaml
    /// </summary>
    public partial class UpdateMuzikaView : Window
    {
        int id;
        MuzikaContext db = new MuzikaContext();
        public UpdateMuzikaView(int id)
        {
            InitializeComponent();
            Muzika trenutno = db.GetMuzika(id);
            textBoxTip.Text = trenutno.TIP_MUZ;
            this.id = id;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxTip.Text == null || textBoxTip.Text == "")
            {
                textBoxTip.BorderBrush = new SolidColorBrush(Colors.Red);
                textBoxTip.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Muzika trenutno = new Muzika();
                trenutno.TIP_MUZ = textBoxTip.Text;
                db.UpdateMuzika(trenutno, id);
                MainWindow.muzike.ItemsSource = db.GetMuzikai();
                this.Close();
            }
        }
    }
}
