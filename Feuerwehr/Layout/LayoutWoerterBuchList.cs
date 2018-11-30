using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace Feuerwehr.Layout
{
    class LayoutWoerterBuchList : ViewCell
    {

        public LayoutWoerterBuchList()
        {
            var nameLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center
                
            };
            nameLabel.SetBinding(Label.TextProperty, new Binding("WordGer"));

            var contextLabel = new Label
            {

                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.FillAndExpand
                
            };
            contextLabel.SetBinding(Label.TextProperty, new Binding("SituationGer"));

            View = new StackLayout
            {
                Children = { nameLabel, contextLabel },
                Orientation = StackOrientation.Horizontal

            };
        }



        
        
    }
}
