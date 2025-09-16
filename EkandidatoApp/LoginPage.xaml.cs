namespace EkandidatoApp;

public partial class LoginPage : ContentPage
{
    bool isPasswordVisible = false;
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnTogglePasswordClicked(object sender, EventArgs e)
    {
        isPasswordVisible = !isPasswordVisible;
        PasswordEntry.IsPassword = !isPasswordVisible;

        TogglePasswordButton.Source = isPasswordVisible ? "eye_slash.png" : "eye_open.png";
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string studentNum = StudentNumberEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (studentNum == "0200012345" && password == "password")
        {
            await Shell.Current.GoToAsync("CreatePassword");
        }
        else
        {
            await DisplayAlert("Login Failed", "Invalid student number or password", "OK");
        }
    }

    private async void OnforgotPasswordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPage());
    }

}