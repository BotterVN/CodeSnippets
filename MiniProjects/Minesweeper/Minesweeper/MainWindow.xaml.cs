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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] dx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        private int[] dy = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        private Board _board;
        private int _size = 30;

        public MainWindow()
        {
            InitializeComponent();
            InitBoard(8, 8, 10);
        }

        private void InitBoard(int width, int height, int numOfMines)
        {
            _board = new Board(width, height, numOfMines);
            var w = width * _size;
            var h = height * _size;

            this.Width = w + 50;
            this.Height = h + 100;
            this.ResizeMode = System.Windows.ResizeMode.CanResize;

            grdMain.Height = h + 50;

            grdGameArea.Width = w;
            grdGameArea.Height = h;

            grdGameArea.Children.Clear();
            grdGameArea.ColumnDefinitions.Clear();
            grdGameArea.RowDefinitions.Clear();

            for (int i = 0; i < width; i++)
            {
                var colDef = new ColumnDefinition();
                colDef.Width = new GridLength(_size);
                grdGameArea.ColumnDefinitions.Add(colDef);
            }

            for (int i = 0; i < height; i++)
            {
                var rowDef = new RowDefinition();
                rowDef.Height = new GridLength(_size);
                grdGameArea.RowDefinitions.Add(rowDef);
            }

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    var ucCell = new UC_Cell(row, col, _board.Cells[row, col]);
                    (ucCell.DataContext as CellVM).IsOpened = false;

                    ucCell.btnContent.Click += btnContent_Click;
                    ucCell.OnCellRightClicked += Cell_RightClicked;
                    
                    Grid.SetColumn(ucCell, col);
                    Grid.SetRow(ucCell, row);

                    grdGameArea.Children.Add(ucCell);
                }
            }

            this.ResizeMode = System.Windows.ResizeMode.NoResize;
        }

        private void Cell_RightClicked()
        {
            foreach (var item in grdGameArea.Children)
            {
                var ctrl = item as UC_Cell;
                if (ctrl != null)
                {
                    var model = (ctrl.DataContext as CellVM);
                    if (model.Model.Value == -1 && !model.IsFlagged)
                        return;
                }
            }

            MessageBox.Show("Excellent! You solve it!", "QLN@ - Minesweeper", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        void btnContent_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            
            var row = int.Parse(((string)btn.Tag).Split(',')[0]);
            var col = int.Parse(((string)btn.Tag).Split(',')[1]);
            var val = int.Parse(((string)btn.Tag).Split(',')[2]);

            if (!(btn.DataContext as CellVM).IsFlagged)
            {
                if (val == -1) 
                {
                    MessageBox.Show("You loose.", "Loose", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    foreach (var item in grdGameArea.Children)
                    {
                        if (item is UC_Cell)
                            (item as UC_Cell).IsEnabled = false; 
                    }   
                }   
                else
                {
                    if (val == 0)
                        OpenBoard(row, col);
                    else
                    {   
                        var vm = btn.DataContext as CellVM;
                        vm.IsOpened = true;
                    }
                }
            }
        }

        private void OpenBoard(int row, int col)
        {   
            for (int i = 0; i < 8; i++)
            {
                var r = row + dy[i];
                var c = col + dx[i];                
                var ctrl = GetControlByRowCol(r, c);
                if (ctrl != null)
                {
                    var vm = ctrl.DataContext as CellVM;
                    if (!vm.IsOpened && vm.Model.Value != -1)
                    {
                        (ctrl.DataContext as CellVM).IsOpened = true;
                        if (vm.Model.Value == 0)
                            OpenBoard(r, c);
                    }   
                }
            }
        }

        private UC_Cell GetControlByRowCol(int row, int col)
        {
            foreach (var item in grdGameArea.Children)
            {
                var vm = (item as UC_Cell).DataContext as CellVM;
                if (vm.Column == col && vm.Row == row)
                    return item as UC_Cell;
            }

            return null;
        }

        private void MenuNewGame_Click(object sender, RoutedEventArgs e)
        {
            var mnuItem = (sender as MenuItem);
            if ((mnuItem.Header as string) == "8x8")
                InitBoard(8, 8, 10);
            else if ((mnuItem.Header as string == "10x10"))
                InitBoard(10, 10, 20);
            else 
                InitBoard(15, 15, 45);
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        { 
            MessageBox.Show("Written by Quang N Le - WPF Test", "QLN@ - Minesweeper", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
