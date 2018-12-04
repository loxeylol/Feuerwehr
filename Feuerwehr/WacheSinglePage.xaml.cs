using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Feuerwehr.Data;
namespace Feuerwehr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WacheSinglePage : ContentPage
	{
		public WacheSinglePage ()
		{
			InitializeComponent ();
            Feuerwache wache;
            
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                 wache = conn.Table<Feuerwache>().First() as Feuerwache;


            }
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = wache.SetPosition(),
                Label = wache.Name,
                Address = wache.Adresse
            };
            myMap.Pins.Add(pin);
		}
	}
}