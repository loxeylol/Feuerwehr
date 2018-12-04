using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Feuerwehr.Data;

namespace Feuerwehr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EinstellungenPage : ContentPage
	{
        
		public EinstellungenPage ()
		{
			InitializeComponent ();
            
            languagePicker.BindingContext = languagePicker;
            var pickLanguage = new[] 
            {
                "deutsch",
                "dansk",
                "english"
            };
            languagePicker.ItemsSource = pickLanguage;
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                var settings = conn.Table<Einstellungen>().First() ;
                languagePicker.Title = settings.Language;
                languagePicker.SelectedIndexChanged += (o, e) =>
                {
                    settings.Language = languagePicker.Items[languagePicker.SelectedIndex];
                    Console.WriteLine(settings.Language + "selected Language");
                };
                

            }
        }
	}
}