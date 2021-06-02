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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.AddChangeViews;
using UI.AddViews;
using UI.ChangeViews;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IgracContext dbIgrac = new IgracContext();
        KoreografContext dbKoreograf = new KoreografContext();
        SastavContext dbSastav = new SastavContext();
        VodiContext dbVodi = new VodiContext();
        PripadaContext dbPripada = new PripadaContext();
        ProbaContext dbProba = new ProbaContext();
        KoncertContext dbKoncert = new KoncertContext();
        IgrackiKoncertContext dbIgrackiKoncert = new IgrackiKoncertContext();
        PevackiKoncertContext dbPevackiKoncert = new PevackiKoncertContext();
        MuzikaContext dbMuzika = new MuzikaContext();
        NastupaContext dbNastup = new NastupaContext();
        NosnjaContext dbNosnja = new NosnjaContext();

        public static DataGrid igraci;
        public static DataGrid koreografi;
        public static DataGrid muzike;
        public static DataGrid nosnje;
        public static DataGrid probe;
        public static DataGrid sastavi;
        public static DataGrid vodjenje;
        public static DataGrid pripadanja;
        public static DataGrid koncerti;
        public static DataGrid koncertiIgracki;
        public static DataGrid koncertiPevacki;
        public static DataGrid nastupanje;
        

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            myDataGridIgraci.ItemsSource = dbIgrac.GetIgraci();
            myDataGridKoreografi.ItemsSource = dbKoreograf.GetKoreografi();
            myDataGridMuzika.ItemsSource = dbMuzika.GetMuzikai();
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
            myDataGridProba.ItemsSource = dbProba.GetProbai();
            myDataGridSastav.ItemsSource = dbSastav.GetSastavi();
            myDataGridVodjenje.ItemsSource = dbVodi.GetVodii();
            myDataGridPripadanje.ItemsSource = dbPripada.GetPripadai();
            myDataGridKoncerti.ItemsSource = dbKoncert.GetKoncerti();
            myDataGridIgrackiKoncerti.ItemsSource = dbIgrackiKoncert.GetIgrackiKoncerti();
            myDataGridPevackiKoncerti.ItemsSource = dbPevackiKoncert.GetPevackiKoncerti();
            myDataGridNastupi.ItemsSource = dbNastup.GetNastupai();

            igraci = myDataGridIgraci;
            koreografi = myDataGridKoreografi;
            muzike = myDataGridMuzika;
            nosnje = myDataGridNosnja;
            probe = myDataGridProba;
            sastavi = myDataGridSastav;
            vodjenje = myDataGridVodjenje;
            pripadanja = myDataGridPripadanje;
            koncerti = myDataGridKoncerti;
            koncertiIgracki = myDataGridIgrackiKoncerti;
            koncertiPevacki = myDataGridPevackiKoncerti;
            nastupanje = myDataGridNastupi;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem trenutni = Tabs.SelectedItem as TabItem;
            switch (trenutni.Header)
            {
                case "Igraci":
                    IgracView igracView = new IgracView();
                    igracView.Show();
                    break;
                case "Koreografi":
                    KoreografView koreografView = new KoreografView();
                    koreografView.Show();
                    break;
                case "Muzike":
                    MuzikaView muzikaView = new MuzikaView();
                    muzikaView.Show();
                    break;
                case "Nosnje":
                    NosnjaView nosnjaView = new NosnjaView();
                    nosnjaView.Show();
                    break;
                case "Probe":
                    ProbaView probaView = new ProbaView();
                    probaView.Show();
                    break;
                case "Sastavi":
                    SastavView sastavView = new SastavView();
                    sastavView.Show();
                    break;
                case "Pripadanje":
                    PripadaView pripadaView = new PripadaView();
                    pripadaView.Show();
                    break;
                case "Vodjenje":
                    VodiView vodiView = new VodiView();
                    vodiView.Show();
                    break;
                case "Koncerti":
                    KoncertView koncertView = new KoncertView();
                    koncertView.Show();
                    break;
                case "IgrackiKoncerti":
                    KoncertView igrackiKoncertView = new KoncertView("Igracki");
                    igrackiKoncertView.Show();
                    break;
                case "PevackiKoncerti":
                    KoncertView pevackiKoncertView = new KoncertView("Pevacki");
                    pevackiKoncertView.Show();
                    break;
                case "KombinovaniKoncerti":
                    KoncertView kombinovaniKoncertView = new KoncertView("Kombinovani");
                    kombinovaniKoncertView.Show();
                    break;
                case "Nastupi":
                    NastupaView nastupaView = new NastupaView();
                    nastupaView.Show();
                    break;
            }
        }

        #region ChangeDelete
        private void buttonChangeIgrac_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridIgraci.SelectedItem as Igrac).ID_IG;
            UpdateIgracView view = new UpdateIgracView(id);
            view.Show();
        }

        private void buttonDeleteIgrac_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridIgraci.SelectedItem as Igrac).ID_IG;
            dbIgrac.DeleteIgrac(id);
            myDataGridIgraci.ItemsSource = dbIgrac.GetIgraci();
            myDataGridNastupi.ItemsSource = dbNastup.GetNastupai();
            myDataGridPripadanje.ItemsSource = dbPripada.GetPripadai();
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
        }

        private void buttonChangeKoreograf_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridKoreografi.SelectedItem as Koreograf).ID_KOR;
            UpdateKoreografView view = new UpdateKoreografView(id);
            view.Show();
        }

        private void buttonDeleteKoreograf_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridKoreografi.SelectedItem as Koreograf).ID_KOR;
            dbKoreograf.DeleteKoreograf(id);
            myDataGridKoreografi.ItemsSource = dbKoreograf.GetKoreografi();
            myDataGridVodjenje.ItemsSource = dbVodi.GetVodii();
        }

        private void buttonChangeMuzika_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridMuzika.SelectedItem as Muzika).ID_MUZ;
            UpdateMuzikaView view = new UpdateMuzikaView(id);
            view.Show();
        }

        private void buttonDeleteMuzika_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridMuzika.SelectedItem as Muzika).ID_MUZ;
            dbMuzika.DeleteMuzika(id);
            myDataGridMuzika.ItemsSource = dbMuzika.GetMuzikai();
            myDataGridIgrackiKoncerti.ItemsSource = dbIgrackiKoncert.GetIgrackiKoncerti();
            myDataGridKoncerti.ItemsSource = dbKoncert.GetKoncerti();
        }

        private void buttonChangeNosnja_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridNosnja.SelectedItem as Nosnja).ID_NOS;
            UpdateNosnjaView view = new UpdateNosnjaView(id);
            view.Show();
        }

        private void buttonDeleteNosnja_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridNosnja.SelectedItem as Nosnja).ID_NOS;
            dbNosnja.DeleteNosnja(id);
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
        }

        private void buttonChangeProba_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridProba.SelectedItem as Proba).ID_PROB;
            int idSastav = (myDataGridProba.SelectedItem as Proba).SastavID_SS;
            UpdateProbaView view = new UpdateProbaView(id, idSastav);
            view.Show();
        }

        private void buttonDeleteProba_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridProba.SelectedItem as Proba).ID_PROB;
            int idSastav = (myDataGridProba.SelectedItem as Proba).SastavID_SS;

            dbProba.DeleteProba(id, idSastav);
            myDataGridProba.ItemsSource = dbProba.GetProbai();
        }

        private void buttonChangeSastav_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridSastav.SelectedItem as Sastav).ID_SS;
            UpdateSastavView view = new UpdateSastavView(id);
            view.Show();
        }

        private void buttonDeleteSastav_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridSastav.SelectedItem as Sastav).ID_SS;
            dbSastav.DeleteSastav(id);
            myDataGridSastav.ItemsSource = dbSastav.GetSastavi();
            myDataGridVodjenje.ItemsSource = dbVodi.GetVodii();
            myDataGridPripadanje.ItemsSource = dbPripada.GetPripadai();
            myDataGridProba.ItemsSource = dbProba.GetProbai();
        }


        private void buttonChangeVodjenje_Click(object sender, RoutedEventArgs e)
        {
            int idKoreografa = (myDataGridVodjenje.SelectedItem as Vodi).KoreografID_KOR;
            int idSastava = (myDataGridVodjenje.SelectedItem as Vodi).SastavID_SS;
            UpdateVodiView view = new UpdateVodiView(idKoreografa, idSastava);
            view.Show();
        }

        private void buttonDeleteVodjenje_Click(object sender, RoutedEventArgs e)
        {
            int idKoreografa = (myDataGridVodjenje.SelectedItem as Vodi).KoreografID_KOR;
            int idSastava = (myDataGridVodjenje.SelectedItem as Vodi).SastavID_SS;
            dbVodi.DeleteVodi(idKoreografa, idSastava);
            myDataGridVodjenje.ItemsSource = dbVodi.GetVodii();
        }

        private void buttonChangePripadanje_Click(object sender, RoutedEventArgs e)
        {
            int idIgraca = (myDataGridPripadanje.SelectedItem as Pripada).IgracID_IG;
            int idSastava = (myDataGridPripadanje.SelectedItem as Pripada).SastavID_SS;
            UpdateVodiView view = new UpdateVodiView(idIgraca, idSastava);
            view.Show();
        }

        private void buttonDeletePripadanje_Click(object sender, RoutedEventArgs e)
        {
            int idIgraca = (myDataGridPripadanje.SelectedItem as Pripada).IgracID_IG;
            int idSastava = (myDataGridPripadanje.SelectedItem as Pripada).SastavID_SS;
            dbPripada.DeletePripada(idIgraca, idSastava);
            myDataGridVodjenje.ItemsSource = dbPripada.GetPripadai();
        }

        private void buttonChangeKoncerti_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridKoncerti.SelectedItem as Koncert).ID_KC;
            UpdateKoncertView view = new UpdateKoncertView(id);
            view.Show();
        }

        private void buttonDeleteKoncerti_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridKoncerti.SelectedItem as Koncert).ID_KC;
            dbKoncert.DeleteKoncert(id);
            myDataGridKoncerti.ItemsSource = dbKoncert.GetKoncerti();
            myDataGridIgrackiKoncerti.ItemsSource = dbIgrackiKoncert.GetIgrackiKoncerti();
            myDataGridPevackiKoncerti.ItemsSource = dbPevackiKoncert.GetPevackiKoncerti();
            myDataGridNastupi.ItemsSource = dbNastup.GetNastupai();
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
        }

        private void buttonChangeIgrackiKoncert_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridIgrackiKoncerti.SelectedItem as IgrackiKoncert).ID_KC;
            UpdateIgrackiKoncertView view = new UpdateIgrackiKoncertView(id);
            view.Show();

        }

        private void buttonDeleteIgrackiKoncert_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridIgrackiKoncerti.SelectedItem as IgrackiKoncert).ID_KC;
            dbKoncert.DeleteKoncert(id);
            myDataGridKoncerti.ItemsSource = dbKoncert.GetKoncerti();
            myDataGridIgrackiKoncerti.ItemsSource = dbIgrackiKoncert.GetIgrackiKoncerti();
            myDataGridNastupi.ItemsSource = dbNastup.GetNastupai();
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
        }

        private void buttonChangePevackiKoncert_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridPevackiKoncerti.SelectedItem as PevackiKoncert).ID_KC;
            UpdatePevackiKoncertView view = new UpdatePevackiKoncertView(id);
            view.Show();
        }

        private void buttonDeletePevackiKoncert_Click(object sender, RoutedEventArgs e)
        {
            int id = (myDataGridPevackiKoncerti.SelectedItem as PevackiKoncert).ID_KC;
            dbKoncert.DeleteKoncert(id);
            myDataGridKoncerti.ItemsSource = dbKoncert.GetKoncerti();
            myDataGridPevackiKoncerti.ItemsSource = dbPevackiKoncert.GetPevackiKoncerti();
            myDataGridNastupi.ItemsSource = dbNastup.GetNastupai();
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
        }

        private void buttonChangeNastupi_Click(object sender, RoutedEventArgs e)
        {
            int idIgraca = (myDataGridNastupi.SelectedItem as Nastupa).IgracID_IG;
            int idKoncerta = (myDataGridNastupi.SelectedItem as Nastupa).KoncertID_KC;
            UpdateNastupaView view = new UpdateNastupaView(idIgraca, idKoncerta);
            view.Show();
        }

        private void buttonDeleteNastupi_Click(object sender, RoutedEventArgs e)
        {
            int idIgraca = (myDataGridNastupi.SelectedItem as Nastupa).IgracID_IG;
            int idKoncerta = (myDataGridNastupi.SelectedItem as Nastupa).KoncertID_KC;
            dbNastup.DeleteNastupa(idIgraca, idKoncerta);
            myDataGridNastupi.ItemsSource = dbNastup.GetNastupai();
            myDataGridNosnja.ItemsSource = dbNosnja.GetNosnjai();
        }
        #endregion
    }
}
