using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class CreatePets : ContentPage
{
	public CreatePets()
	{
		InitializeComponent();
        LoadOwnersAsync();
    }
    protected override async void OnAppearing()
    {   
        base.OnAppearing();
        var pet = (Pet)BindingContext;

        var owners = await App.Database.GetOwnersAsync();
        OwnerPicker.ItemsSource = (System.Collections.IList)owners;
        OwnerPicker.ItemDisplayBinding = new Binding("FullName");
        var selectedOwner = owners.FirstOrDefault(o => o.ID == pet.OwnerID);
        OwnerPicker.SelectedItem = selectedOwner;
    }
    private async void LoadOwnersAsync()    
    {
        var owner = await App.Database.GetOwnersAsync();
        OwnerPicker.ItemsSource = (System.Collections.IList)owner;
        OwnerPicker.ItemDisplayBinding = new Binding("FullName");
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var pet = (Pet)BindingContext;
        Owner selectedOwner = (OwnerPicker.SelectedItem as Owner);
        pet.OwnerID = selectedOwner.ID;
        await App.Database.SavePetAsync(pet);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var pet = (Pet)BindingContext;
        await App.Database.DeletePetAsync(pet);
        await Navigation.PopAsync();
    }

}