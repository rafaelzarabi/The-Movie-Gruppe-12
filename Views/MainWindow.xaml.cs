using System.Windows;
using The_Movie_Gruppe_12.ViewModels;

namespace The_Movie_Gruppe_12.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MovieViewModel();
        }
    }
}