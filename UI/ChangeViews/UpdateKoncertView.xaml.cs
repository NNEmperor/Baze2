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
    /// Interaction logic for UpdateKoncertView.xaml
    /// </summary>
    public partial class UpdateKoncertView : Window
    {
        KoncertContext db = new KoncertContext();
        int id;
        public UpdateKoncertView(int id)
        {
            InitializeComponent();
            Koncert trenutno = db.GetKoncert(id);
            dateTimeVreme.SelectedDate = trenutno.VR_KC;
            this.id = id;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (dateTimeVreme.SelectedDate == null)
            {
                dateTimeVreme.BorderBrush = new SolidColorBrush(Colors.Red);
                dateTimeVreme.BorderThickness = new Thickness(2, 2, 2, 2);
            }
            else
            {
                Koncert trenutno = new Koncert();
                trenutno.VR_KC = dateTimeVreme.SelectedDate.Value;
                db.UpdateKoncert(trenutno, id);
                MainWindow.koncerti.ItemsSource = db.GetKoncerti();
                this.Close();
            }
        }
    }
}
