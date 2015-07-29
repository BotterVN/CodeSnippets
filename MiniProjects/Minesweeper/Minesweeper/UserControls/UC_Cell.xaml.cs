using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    public delegate void CellRightClicked();
    /// <summary>
    /// Interaction logic for UC_Cell.xaml
    /// </summary>
    /// 
    public partial class UC_Cell : UserControl
    {   
        private CellVM _viewModel;

        public CellRightClicked OnCellRightClicked;

        public UC_Cell(int row, int col, Cell model)
        {
            InitializeComponent();
            _viewModel = new CellVM(row, col, model);
            btnContent.Tag = string.Format("{0},{1},{2}", row, col, model.Value);
            DataContext = _viewModel;
        }

        private void btnContent_RightClick(object sender, MouseButtonEventArgs e)
        {
            if (!_viewModel.IsOpened)
                _viewModel.IsFlagged = !_viewModel.IsFlagged;

            if (OnCellRightClicked != null)
                OnCellRightClicked();
        }

        private void btnContent_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.IsOpened == false && !_viewModel.IsFlagged)
                _viewModel.IsOpened = true;
        }
    }
}
