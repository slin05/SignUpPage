using System.Web;

namespace SignUpPage;

public partial class Signup : ContentPage
{
    public Signup()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;

        string username = UsernameEntry.Text?.Trim() ?? string.Empty;
        string email = EmailEntry.Text?.Trim() ?? string.Empty;
        string password = PasswordEntry.Text ?? string.Empty;
        string confirmPassword = ConfirmPasswordEntry.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            ErrorLabel.Text = "All fields are required";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (password != confirmPassword)
        {
            ErrorLabel.Text = "Passwords do not match";
            ErrorLabel.IsVisible = true;
            return;
        }

        var queryParameters = new Dictionary<string, object>
        {
            { "username", HttpUtility.UrlEncode(username) },
            { "email", HttpUtility.UrlEncode(email) }
        };

        await Shell.Current.GoToAsync("profile", queryParameters);
    }
}