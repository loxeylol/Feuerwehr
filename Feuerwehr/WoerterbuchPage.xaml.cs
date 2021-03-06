﻿using System;
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

            //update search while tiping
            wortSearch.TextChanged += (o, e) =>
            {
                searchItem(e.NewTextValue);
            };
            //remove this?
            wortSearch.SearchCommand = new Command(() =>
            {
                searchItem(wortSearch.Text);
            });
           
            dictionaryList.BindingContext = dictionaryList;
            dictionaryList.ItemTemplate = new DataTemplate(typeof(LayoutWoerterBuchList));
            
                
            //set default items
            //todo filter for Einsatztyp
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

            settingsButton.BindingContext = settingsButton;

            settingsButton.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new EinstellungenPage());
            };

        }



        public void searchItem(string searchTerm)
        {
           
            //todo search for ger / dk / eng word
            var searchItems = conn.Table<Woerterbuch>().Where(k => k.WordGer.ToLower().Contains(searchTerm)).ToList();


                dictionaryList.ItemsSource = searchItems;
            
           
        }
        
	}
}