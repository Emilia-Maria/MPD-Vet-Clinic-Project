using SQLite;
using Vet_Clinic.Data;
using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class ViewPets : ContentPage
{
    public ViewPets()
	{
		InitializeComponent();
        LoadPetsAsync();
    }
    private async void LoadPetsAsync()
    {
        var database = App.Database;

        var pets = await database.GetPetsAsync();

        foreach (var pet in pets)
        {
            var owner = await database.GetOwnersAsync(pet.OwnerID);
            pet.SelectedOwner = owner;
        }

        listView.ItemsSource = pets;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetPetsAsync();
        LoadPetsAsync();
    }
    async void OnPetAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreatePets
        {
            BindingContext = new Pet()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CreatePets
            {
                BindingContext = e.SelectedItem as Pet
            });
        }
    }
}