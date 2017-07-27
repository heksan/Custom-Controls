using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControlsLibrary.SwipeToDelete
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeableLabel : Label
    {
        public SwipeableLabel()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            MessagingCenter.Send("", "remove", Text);
        }
    }
}