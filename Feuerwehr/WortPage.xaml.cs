using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Feuerwehr.Data;
using SQLite;
namespace Feuerwehr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WortPage : ContentPage
	{

        SQLiteConnection conn = new SQLiteConnection(App.DB_PATH);
		public WortPage ()
		{
			InitializeComponent ();

		}

        public WortPage(Woerterbuch wort)
        {
            InitializeComponent();
            var einstellungen = conn.Table<Einstellungen>().First();
            transLation1.BindingContext = transLation1;
            transLation2.BindingContext = transLation2;
            phrase.BindingContext = phrase;
            phrase.FontSize = Device.GetNamedSize(NamedSize.Large, phrase);


            if (einstellungen.Language == "deutsch")
            {
                Title = wort.WordGer;
                transLation1.Text = wort.WordDk;
                phrase.Text = wort.FormulierungDk;
            }
            else if(einstellungen.Language == "dansk")
            {
                Title = wort.WordDk;
                transLation1.Text = wort.WordGer;
                phrase.Text = wort.FormulierungGer;

            }
            settingsButton.BindingContext = settingsButton;

            settingsButton.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new EinstellungenPage());
            };
           

         
          


        }
	}
}