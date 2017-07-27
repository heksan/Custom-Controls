using CustomControls.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CustomControls.Common;

namespace CustomControls.ViewModels
{
    public class ListOfStackLayoutsViewModel : CommonMethods
    {
        private StackLayout stack1 = new StackLayout();
        private StackLayout stack2 = new StackLayout();
        private StackLayout stack3 = new StackLayout();
        private StackLayout stack4 = new StackLayout();
        private List<StackLayout> _items;

        public ListOfStackLayoutsViewModel()
        {
            stack1.Children.Add(new Button() { Text = "StackLayout" });
            stack2.Children.Add(new Entry() { Text = "Another StackLayout" });
            stack3.Children.Add(new Label() { Text = "Yet Another" });
            stack4.Children.Add(new Button() { Text = "Add New One()", Command = AddNew });
            Items = new List<StackLayout>() { stack1 , stack2 , stack3 , stack4};

        }

        public ICommand AddNew
        {
            get
            {
                return new Command(() => 
                {
                    var s=new StackLayout();
                    s.Children.Add(new Label() { Text = "SO MANY LAYOUTS!!!!!!!!11111oneone" });
                    var newItems = new List<StackLayout>(Items);
                    newItems.Add(s);
                    Items = newItems;

                    //IMPORTANT: Items=Items will trigger OnPropertyChanged but underlying bindable property will not fire on this method,
                    //this is because Bindable Property will not refresh the UI unless value being assigned is different from original value


                    //tl;dr use new list when assigning coz immutable
                });
            }
        }

        public List<StackLayout> Items
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
