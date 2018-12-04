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
        public SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH);

        public WoerterbuchPage (string title)
		{
			InitializeComponent ();
            Title = title+" Wörterbuch";
            
            wortSearch.BindingContext = wortSearch;

            wortSearch.Placeholder = "Suche nach Begriff";
            wortSearch.SearchCommand = new Command(() =>
            {
                searchItem(wortSearch.Text);
            });
           
            dictionaryList.BindingContext = dictionaryList;
            dictionaryList.ItemTemplate = new DataTemplate(typeof(LayoutWoerterBuchList));
         
                
                
                    var items = conn.Table<Woerterbuch>().ToList();
                    dictionaryList.ItemsSource = items;

                
           
            
            dictionaryList.ItemSelected += (o, e) =>
            {
                if(e.SelectedItem != null)
                {
                    Navigation.PushAsync(new WortPage(e.SelectedItem as Woerterbuch));
                    dictionaryList.SelectedItem = null;
                }
            };
            
		}



        public void searchItem(string searchTerm)
        {
           
          
                var searchItems = conn.Table<Woerterbuch>().Where(k => k.WordGer.Contains(searchTerm)).ToList();


                dictionaryList.ItemsSource = searchItems;
            
           
        }
        
	}
}