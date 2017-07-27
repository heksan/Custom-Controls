using CustomControls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomControls.ViewModels
{
    public class SwipeToDeleteViewModel : CommonMethods
    {
        private List<string> _items;

        public SwipeToDeleteViewModel()
        {
            Items = new List<string>()
            {
                "aaa","BBB","ccc","ddd"
            };

            MessagingCenter.Subscribe<string,string>(this, "remove", RemoveElement);
        }

        private void RemoveElement(string arg1, string toDelete)
        {
            Items.Remove(toDelete);
            Items = new List<string>(Items);
        }

        public List<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
    }
}
