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

namespace Homework_10_Example_MVVM_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MyViewModel();
            // The DataContext serves as the starting point of Binding Paths
            DataContext = _viewModel;
        }
    }
}
