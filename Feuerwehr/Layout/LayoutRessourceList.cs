using System;
using Xamarin.Forms;
namespace Feuerwehr.Layout
{
    public class LayoutRessourceList :ViewCell
    {
        public LayoutRessourceList()
        {
            var ressource = new TableView
            {
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new ImageCell
                        {

                        }
                    }

                }

            };
            ressource.SetBinding(ImageCell.TextProperty, "Name");
            ressource.SetBinding(ImageCell.ImageSourceProperty, "imageSource");



            View = new StackLayout
            {
                Children = {ressource},
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}
