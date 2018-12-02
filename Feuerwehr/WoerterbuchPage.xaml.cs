using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Feuerwehr.Data;
using Feuerwehr.Layout;

namespace Feuerwehr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WoerterbuchPage : ContentPage
	{
		public WoerterbuchPage (string title)
		{
			InitializeComponent ();
            Title = title+" Wörterbuch";
            dictionaryList.BindingContext = dictionaryList;
            dictionaryList.ItemTemplate = new DataTemplate(typeof(LayoutWoerterBuchList));
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
               var items = conn.Table<Woerterbuch>().ToList();
               dictionaryList.ItemsSource = items;

            }
            dictionaryList.ItemSelected += (o, e) =>
            {
                if(e.SelectedItem != null)
                {
                    Navigation.PushAsync(new WortPage(e.SelectedItem as Woerterbuch));
                    dictionaryList.SelectedItem = null;
                }
            };
            
		}
	}
}