using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControlsLibrary.Tiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tiles : Grid
    {
        private static bool _tapped=false;
        public Tiles()
        {
            InitializeComponent();
        }

        public static BindableProperty CommandParameterProperty = BindableProperty.Create(
            propertyName: "CommandParameter",
            returnType: typeof(Command),
            declaringType: typeof(Tiles),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay);


        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(
            propertyName: "ItemsSource",
            returnType: typeof(IEnumerable<object>),//can be anything essentally as far as it can be .CreateContent()
            declaringType: typeof(Tiles),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ItemsSourceChangedEvent);

        public static BindableProperty ItemTemplateProperty = BindableProperty.Create(
            propertyName: "ItemTemplate",
            returnType: typeof(DataTemplate),
            declaringType: typeof(Tiles),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnItemTemplateChanged);

        public static BindableProperty TileHeightProperty = BindableProperty.Create(
            propertyName: "TileHeight",
            returnType: typeof(float),//has to be float
            declaringType: typeof(Tiles),
            defaultValue: (float)190);

        public static BindableProperty ColumnNumberProperty = BindableProperty.Create(
            propertyName: "ColumnNumber",
            returnType: typeof(int),
            declaringType: typeof(Tiles),
            defaultValue: 2);

        private static void ItemsSourceChangedEvent(BindableObject bindable, object oldValue, object newValue)
        {
            BuildTiles(newValue as IEnumerable<object>, bindable as Tiles);
        }

        private static void OnItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Tiles).ItemTemplate = newValue as DataTemplate;
        }

        public int ColumnNumber
        {
            get { return (int)GetValue(ColumnNumberProperty); }
            set { SetValue(ColumnNumberProperty, value); }
        }

        public float TileHeight
        {
            get { return (float)GetValue(TileHeightProperty); }
            set { SetValue(TileHeightProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static void BuildTiles(IEnumerable<object> tiles, Tiles host)
        {
            if (tiles.Count() == 0)
            {
                throw new InvalidOperationException("No tiles to display");
            }

            for (var i = 0; i < host.ColumnNumber; i++)
            {
                host.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var tileList = tiles.ToList();
            var numberOfRows = Math.Ceiling(tileList.Count / (float)host.ColumnNumber);

            for (var i = 0; i < numberOfRows; i++)
                host.RowDefinitions?.Add(new RowDefinition { Height = host.TileHeight });

            for (var i = 0; i < tileList.Count; i++)
            {
                var column = i % host.ColumnNumber;
                var row = (int)Math.Floor(i / (float)host.ColumnNumber);

                var tile = host.ItemTemplate.CreateContent() as StackLayout;

                tile.GestureRecognizers.Add(GetTappedAnimation(tile));
                tile.BindingContext = tileList[i];
                host.Children.Add(tile, column, row);
            }
        }

        private static IGestureRecognizer GetTappedAnimation(StackLayout tile)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                if (!_tapped)
                {
                    _tapped = true;
                    await tile.ScaleTo(0.95, 70, Easing.Linear);
                    await tile.ScaleTo(1, 70, Easing.Linear);
                    _tapped = false;
                }
            };
            return tapGestureRecognizer;
        }

        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ItemTemplateProperty);
            }
            set
            {
                SetValue(ItemTemplateProperty, value);
                OnPropertyChanged();
            }
        }
    }
}
