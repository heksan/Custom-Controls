using CustomControls.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomControls.Model
{
    public class TileModel : CommonMethods
    {
        private Command _tileCommand;
        private string _title;
        private string _status;
        public Command TileCommand
        {
            get { return _tileCommand; }
            set { _tileCommand = value; OnPropertyChanged(); }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }
    }
}
