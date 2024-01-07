using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class SeeOwnerPets : ContentPage
{
    private int ownerId;

    public SeeOwnerPets(int ownerId)
    {
        InitializeComponent();
        this.ownerId = ownerId;

        DisplayPets();
    }

    private async void DisplayPets()
    {
        List<Pet> petsForOwner = await App.Database.GetPetsByOwnerAsync(ownerId);
        petsListView.ItemsSource = petsForOwner;
    }
}
