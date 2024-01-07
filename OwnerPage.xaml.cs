using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class OwnerPage : ContentPage
{
    private Owner selectedOwner;
    public OwnerPage()
    {
        InitializeComponent();
        int selectedOwnerId = App.SelectedOwnerId;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var owner = (Owner)BindingContext;
        await App.Database.SaveOwnerAsync(owner);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var owner = (Owner)BindingContext;
        await App.Database.DeleteOwnerAsync(owner);
        await Navigation.PopAsync();
    }
    async void OnSeePetListButtonClicked(object sender, EventArgs e)
    {
        var owner = (Owner)BindingContext;
        await Navigation.PushAsync(new SeeOwnerPets(owner.ID));
    }
}