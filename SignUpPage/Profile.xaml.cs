using System.Web;

namespace SignUpPage;

[QueryProperty(nameof(Username), "username")]
[QueryProperty(nameof(Email), "email")]
public partial class Profile : ContentPage
{
    private string _username;
    private string _email;

    public string Username
    {
        get => _username;
        set
        {
            _username = HttpUtility.UrlDecode(value);
            OnPropertyChanged();
            UsernameLabel.Text = _username;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = HttpUtility.UrlDecode(value);
            OnPropertyChanged();
            EmailLabel.Text = _email;
        }
    }

    public Profile()
    {
        InitializeComponent();
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///signup");
    }
}