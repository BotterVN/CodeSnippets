using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class CellVM : INotifyPropertyChanged
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Cell Model { get; set; }

        public string Content { get; set; }

        private bool _isOpened;
        public bool IsOpened 
        {
            get { return _isOpened; }
            set
            {
                _isOpened = value;
                OnPropertyChanged("IsOpened");
            }
        }

        private bool _isFlaged;
        public bool IsFlagged 
        {
            get { return _isFlaged; }
            set
            {
                _isFlaged = value;
                OnPropertyChanged("IsFlagged");
            } 
        }

        public CellVM(int row, int col, Cell model)
        {
            Model = model;
            Row = row;
            Column = col;
            Content = model.Value.ToString();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
