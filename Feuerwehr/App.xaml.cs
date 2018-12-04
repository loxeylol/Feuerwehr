using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Feuerwehr.Data;
using Xamarin.Forms.Maps;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Feuerwehr
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public App()
        {
            InitializeComponent();
           
            MainPage = new NavigationPage( new MainPage());
        }
        public App(string DB_Path)
        {
            DB_PATH = DB_Path;
            //move to on start?
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DB_PATH))
            {
                //drop data
                conn.DropTable<Woerterbuch>();
                conn.DropTable<Einstellungen>();

                conn.CreateTable<Feuerwache>();
                conn.CreateTable<Einstellungen>();
                conn.CreateTable<Woerterbuch>();
                //create some basedata
                Einstellungen settings = new Einstellungen()
                {
                    Language = "deutsch",
                    FontSize = 10,
                    Help = "erwarte keine Hilfe"
                };

                Woerterbuch word1 = new Woerterbuch()
                {
                    SituationGer = "Alltagssprache",
                    SituationDk = "Hverdagssprog",
                    WordGer = "gesund",
                    WordDk = "sund og rask",
                    FormulierungGer ="Fühlen Sie sich gesund?",
                    FormulierungDk = "Føler du dig sund og rask ?"
                };
                Woerterbuch word2 = new Woerterbuch()
                {
                    SituationGer = "Arbeit und Freizeit",
                    SituationDk = "Arbejde og fritid",
                    WordGer = "Ausbildung",
                    WordDk = "uddannelse",
                    FormulierungGer = "Die Ausbildung in der Krankenpflege findet Anerkennung",
                    FormulierungDk = "Sygeplejerskeuddannelsen er velanset"
                };
                Woerterbuch word3 = new Woerterbuch()
                {
                    SituationGer = "Atmen",
                    SituationDk = "Ånde",
                    WordGer = "Husten",
                    WordDk = "Hoste",
                    FormulierungGer = "Der trockene Husten quält mich nachts",
                    FormulierungDk = "Den toerre hoste generer mig om natten"
                };
                Woerterbuch word4 = new Woerterbuch()
                {
                    SituationGer = "Aufnahme und Einweisung",
                    SituationDk = "Modtagelse og indlæggelse",
                    WordGer = "Arzt",
                    WordDk = "læge",
                    FormulierungGer = "Der Arzt untersucht Sie gleich",
                    FormulierungDk = "Lægen vil snart undersøge dig"
                };

                Feuerwache wache = new Feuerwache()
                {
                    Name = "Berufsfeuerwehr Flensburg",
                    Adresse = "Munketoft 16 24937 Flensburg",
                    Trivia ="",
                    Strength = 25,
                    TelNr = "0461 - 85 1111",
                    latidude = 54.7779131,
                    longitude = 9.4363213



                };
                wache.pos = wache.SetPosition();

                //insert data
                conn.Insert(wache);
                conn.Insert(settings);
                conn.Insert(word1);
                conn.Insert(word2);
                conn.Insert(word3);
                conn.Insert(word4);


            }
                //load mainpage
                MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
