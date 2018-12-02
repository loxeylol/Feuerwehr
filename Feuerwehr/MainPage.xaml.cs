using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Feuerwehr
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //set binding Context of UI
            
            deploymentButton.BindingContext = deploymentButton;
            buildingButton.BindingContext = buildingButton;
            equipmentButton.BindingContext = equipmentButton;
            vehicleButton.BindingContext = vehicleButton;
            //main menu button listener
            deploymentButton.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new EinsatzPage());
            };

            buildingButton.Clicked += (o, e) =>
            {

            };

            equipmentButton.Clicked += (o, e) =>
            {

            };

            vehicleButton.Clicked += (o, e) =>
            {

            };
            settingsButton.BindingContext = settingsButton;

            settingsButton.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new EinstellungenPage());
            };


        }
    }
}
