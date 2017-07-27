using CustomControls.Common;
using CustomControls.Model;
using CustomControls.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomControls.ViewModels
{
    public class TilesViewModel : CommonMethods
    {
        public TilesViewModel()
        {
            Items = new List<TileModel>
            {
                new TileModel()
                {
                    TileCommand= new Command(()=>
                    {
                        Application.Current.MainPage.DisplayAlert("Alert1","This is an alert","OK, I guess...");
                    }),
                    Title="Tile 1",
                    Status="Status 1"
                },

                new TileModel()
                {
                    TileCommand= new Command(()=>
                    {
                        this.Items[1].Status="Changed";
                    }),
                    Title="Tile 2",
                    Status="Change me"
                },

                new TileModel()
                {
                    TileCommand= new Command(()=>
                    {
                        Application.Current.MainPage.Navigation.PushAsync(new Main());
                    }),
                    Title="Back to Main",
                    Status="Status 3"
                },
            };
        }

        public List<TileModel> Items { get; set; }
        // public float Spacing { get; set; } <-- not set but usefull
        //public float Height { get; set; } <-- not set, ideal squares would need screen size recognition 
        //public int Columns { get; set; } <-- not set, if scrollview is not ideal set it to 3
    }
}
