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
	public partial class EinstellungenPage : ContentPage
	{
        SQLiteConnection conn = new SQLiteConnection(App.DB_PATH);

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

                var settings = conn.Table<Einstellungen>().First() ;
                languagePicker.Title = settings.Language;
                languagePicker.SelectedIndexChanged += (o, e) =>
                {
                    settings.Language = languagePicker.Items[languagePicker.SelectedIndex];
                    conn.BeginTransaction();
                    conn.Update(settings);
                    conn.Commit();
                    Console.WriteLine(settings.Language + "selected Language");
                };
                


        }
	}
}