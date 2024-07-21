using GermanyEuro2024.BLL.Services;
using GermanyEuro2024.DAL.Entities;
using System.Windows;


namespace GermanyEuro2024_TranNgocKinhLuan
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public FootballPlayer SelectedFooballPlayer { get; set; } = null;
        private FootballTeamService _teamService = new();
        private FootballPlayerService _service = new();
        public DetailWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text) ||
             string.IsNullOrWhiteSpace(NameTextBox.Text) ||
            string.IsNullOrWhiteSpace(AchievementsTextBox.Text) ||
            BirthdayPicker.SelectedDate == null ||
            string.IsNullOrWhiteSpace(OriginCountryTextBox.Text) ||
            string.IsNullOrWhiteSpace(AwardTextBox.Text) ||
            TeamTitleComboBox.SelectedValue == null)
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidAward(AwardTextBox.Text))
            {
                MessageBox.Show("Invalid Award. The award must be 3-100 characters long, each word must begin with a capital letter or digit (1-9), and no special characters are allowed.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime maxBirthday = new DateTime(2004, 1, 1);
            if (BirthdayPicker.SelectedDate > maxBirthday)
            {
                MessageBox.Show("Birthday must be on or before 01/01/2004.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            FootballPlayer player = new();
            player.PlayerId = IdTextBox.Text;
            player.PlayerName = NameTextBox.Text;
            player.Achievements = AchievementsTextBox.Text;
            player.Birthday = BirthdayPicker.SelectedDate;
            player.OriginCountry = OriginCountryTextBox.Text;
            player.Award = AwardTextBox.Text;
            player.FootballTeamId = TeamTitleComboBox.SelectedValue.ToString();
            if (SelectedFooballPlayer != null)
            {
                _service.Update(player);
                MessageBox.Show("Update player sucessfully!", "Updated!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                return;
            }
            _service.Add(player);
            MessageBox.Show("Add player sucessfully!", "Added!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            return;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            if (SelectedFooballPlayer != null)
            {
                IdTextBox.Text = SelectedFooballPlayer.PlayerId.ToString();
                NameTextBox.Text = SelectedFooballPlayer.PlayerName.ToString();
                AchievementsTextBox.Text = SelectedFooballPlayer.Achievements.ToString();
                BirthdayPicker.Text = SelectedFooballPlayer.Birthday.ToString();
                OriginCountryTextBox.Text = SelectedFooballPlayer.OriginCountry.ToString();
                AwardTextBox.Text = SelectedFooballPlayer.Award.ToString();
                TeamTitleComboBox.SelectedValue = SelectedFooballPlayer.FootballTeamId.ToString();
                MessageLabel.Content = "UPDATE A FOOTBALL PLAYER";
            }
            MessageLabel.Content = "CREATE A FOOTBALL PLAYER";


        }

        private bool IsValidAward(string award)
        {
            if (string.IsNullOrWhiteSpace(award) || award.Length < 3 || award.Length > 100)
            {
                return false;
            }

            // Split the award into words
            var words = award.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Check each word
            foreach (var word in words)
            {
                // Check if the word starts with a capital letter or digit (1-9)
                if (!char.IsUpper(word[0]) && (word[0] < '1' || word[0] > '9'))
                {
                    return false;
                }

                // Check for special characters
                if (word.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    return false;
                }
            }

            return true;
        }

        private void FillComboBox()
        {
            TeamTitleComboBox.ItemsSource = _teamService.GetAll();
            TeamTitleComboBox.DisplayMemberPath = "TeamTitle";
            TeamTitleComboBox.SelectedValuePath = "FootballTeamId";
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
