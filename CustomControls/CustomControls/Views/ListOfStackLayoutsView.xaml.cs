﻿using CustomControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListOfStackLayoutsView : ContentPage
    {
        public ListOfStackLayoutsView()
        {
            this.BindingContext = new ListOfStackLayoutsViewModel();
            InitializeComponent();
        }
    }
}
