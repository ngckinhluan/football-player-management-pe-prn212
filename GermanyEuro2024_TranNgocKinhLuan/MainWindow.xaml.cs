using GermanyEuro2024.BLL.Services;
using GermanyEuro2024.DAL.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GermanyEuro2024_TranNgocKinhLuan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Uefaaccount CurrentUser { get; set; } = null;
        private FootballPlayerService _service = new();
        public MainWindow(Uefaaccount uefaaccount)
        {
            CurrentUser = uefaaccount;
            InitializeComponent();
        }

        private bool IsManager()
        {
            return CurrentUser?.Role == 3;
        }

        private void FootballPlayerDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            var result = _service.GetAll(); 
            FootballPlayerDataGrid.ItemsSource = null;
            FootballPlayerDataGrid.ItemsSource = result;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsManager())
            {
                var selected = (dynamic)FootballPlayerDataGrid.SelectedItem;
                if (selected == null)
                {
                    MessageBox.Show("Please choose a football player to delete!", "Deleted!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult result = MessageBox.Show("Do you really want to delete this football player?", "Delete!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No) return;
                _service.Delete(selected);
                LoadList();
                MessageBox.Show("Delete a football player successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("You have no permission to acess this function!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string achivementText = AchivementsTextBox.Text;
            string playerNameText = PlayerNameTextBox.Text;
            var result = _service.Search(achivementText, playerNameText);
            FootballPlayerDataGrid.ItemsSource = null;
            FootballPlayerDataGrid.ItemsSource = result;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsManager())
            {
                DetailWindow d = new DetailWindow();
                d.ShowDialog();
                LoadList();
            }
            else
            {
                MessageBox.Show("You have no permission to acess this function!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsManager())
            {
                var selected = (dynamic)FootballPlayerDataGrid.SelectedItem;
                if (selected == null)
                {
                    MessageBox.Show("Please choose a footbal player to update!", "Update!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                DetailWindow d = new DetailWindow();
                d.SelectedFooballPlayer = selected;
                d.ShowDialog();
                LoadList();
            }
            else
            {
                MessageBox.Show("You have no permission to acess this function!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}