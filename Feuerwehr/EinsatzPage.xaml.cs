using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Feuerwehr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EinsatzPage : ContentPage
	{
		public EinsatzPage ()
		{
			InitializeComponent ();
            Title = "Einsatz";
            //todo: datenbankverbindung
            deploymentList.BindingContext = deploymentList;
            var items = new[]
            {
                "Wörterbuch",
                "Taschenkarten",
                "Schmerzskala"
            };
            deploymentList.ItemsSource = items;
            deploymentList.ItemSelected += (o, e) =>
            {
                if(e.SelectedItem != null)
                {
                    Navigation.PushAsync(new EinsatzPage(deploymentList.SelectedItem as string));
                    deploymentList.SelectedItem = null;
                }
            };
		}

        public EinsatzPage(string einsatzTyp)
        {
            InitializeComponent();
            Title = einsatzTyp;
            deploymentList.BindingContext = deploymentList;
            
            switch (einsatzTyp)
            {
                case "Wörterbuch":
                    var items = new[]
                    {
                        "Luftrettung",
                        "Wasserrettung",
                        "Unfall"
                    };
                    deploymentList.ItemsSource = items;
                    deploymentList.ItemSelected += (o, e) =>
                    {
                        if ( e.SelectedItem != null)
                        {
                            Navigation.PushAsync(new WoerterbuchPage(e.SelectedItem as string));
                            deploymentList.SelectedItem = null;
                        }
                    };
                    break;
                case "Taschenkarten":

                    break;
                case "Schmerzskala":

                    break;
                default:
                    Console.WriteLine("nothing here");
                    break;
            }
        }
    }
    
}