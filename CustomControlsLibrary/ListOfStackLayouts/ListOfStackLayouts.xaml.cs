using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControlsLibrary.ListOfStackLayouts
{
    public partial class ListOfStackLayouts : StackLayout
    {
        private static IEnumerable<StackLayout> empty;
        public ListOfStackLayouts()
        {
            empty = new ObservableCollection<StackLayout>();
            InitializeComponent();
        }

        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: "ItemsSource",
            returnType: typeof(IEnumerable<StackLayout>),
            declaringType: typeof(ListOfStackLayouts),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: PropChangedEvent);

        private static void PropChangedEvent(BindableObject bindable, object oldValue, object newValue)
        {
            BuildLayouts(newValue as IEnumerable<StackLayout>, bindable as ListOfStackLayouts);
        }

        public IEnumerable<StackLayout> ItemsSource
        {
            get { return (IEnumerable<StackLayout>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void BuildLayouts(IEnumerable<StackLayout> list,StackLayout host)
        {
            host.Children.Clear();
            foreach (var layout in list)
            {
                layout.VerticalOptions = LayoutOptions.Fill;
                host.Children.Add(layout);
            }
        }
    }
}
