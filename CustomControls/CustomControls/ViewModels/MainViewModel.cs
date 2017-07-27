using CustomControls.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomControls.ViewModels
{
    public class MainViewModel
    {
        public Command MoveToListOfStackLayouts
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new ListOfStackLayoutsView()); });
            }
        }

        public Command MoveToTiles
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new TilesView()); });
            }
        }

        public Command MoveToSwipeToDelete
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new SwipeToDeleteView()); });
            }
        }
        
    }
}
