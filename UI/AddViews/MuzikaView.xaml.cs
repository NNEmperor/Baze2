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
    /// Interaction logic for MuzikaView.xaml
    /// </summary>
    public partial class MuzikaView : Window
    {

        MuzikaContext db = new MuzikaContext();
        public MuzikaView()
        {
            InitializeComponent();
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
                db.AddMuzika(new Muzika
                {
                    TIP_MUZ = textBoxTip.Text
                });
                MainWindow.muzike.ItemsSource = db.GetMuzikai();
                this.Close();
            }
        }
    }
}
