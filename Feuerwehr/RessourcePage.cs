using System;

using Xamarin.Forms;

namespace Feuerwehr
{
    public class RessourcePage : ContentPage
    {
        public RessourcePage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

