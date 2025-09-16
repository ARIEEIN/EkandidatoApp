namespace EkandidatoApp;

public partial class CreatePassword : ContentPage
{
    private bool fPasswordVisible = false;
    private bool sPasswordVisible = false;
    public CreatePassword()
    {
        InitializeComponent();
    }

    private void TogglePasswordClicked(object sender, EventArgs e)
    {
        if (sender == FTogglePasswordButton)
        {
            fPasswordVisible = !fPasswordVisible;
            FPasswordEntry.IsPassword = !fPasswordVisible;
            FTogglePasswordButton.Source = fPasswordVisible ? "eye_slash.png" : "eye_open.png";
        }
        else if (sender == STogglePasswordButton)
        {
            sPasswordVisible = !sPasswordVisible;
            SPasswordEntry.IsPassword = !sPasswordVisible;
            STogglePasswordButton.Source = sPasswordVisible ? "eye_slash.png" : "eye_open.png";
        }
    }

    private async void OnCreatePasswordClicked(object sender, EventArgs e)
    {
        string studentNumber = "0200012345";
        string firstPass = FPasswordEntry.Text;
        string secondPass = SPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(studentNumber))
        {
            await DisplayAlert("Error", "Please enter your Student Number.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(firstPass) || string.IsNullOrWhiteSpace(secondPass))
        {
            await DisplayAlert("Error", "Please enter and confirm your password.", "OK");
            return;
        }

        if (firstPass != secondPass)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }
        await DisplayAlert("Success", "Password created successfully!", "OK");
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        await Shell.Current.GoToAsync("//HomePage");
    }
}