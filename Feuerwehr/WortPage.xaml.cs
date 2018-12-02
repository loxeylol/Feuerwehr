using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Feuerwehr.Data;
namespace Feuerwehr
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WortPage : ContentPage
	{
		public WortPage ()
		{
			InitializeComponent ();

		}

        public WortPage(Woerterbuch wort)
        {
            InitializeComponent();
            Title = wort.WordGer;
            transLation1.BindingContext = transLation1;
            transLation2.BindingContext = transLation2;
            phrase.BindingContext = phrase;
            transLation1.Text = wort.WordDk;
            transLation2.Text = wort.WordGer;
            phrase.FontSize = Device.GetNamedSize(NamedSize.Large, phrase);
            phrase.Text = wort.FormulierungGer;
        }
	}
}