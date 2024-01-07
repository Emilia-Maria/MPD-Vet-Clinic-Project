using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class SeeOwnerPets : ContentPage
{
    private int ownerId;

    public SeeOwnerPets(int ownerId)
    {
        InitializeComponent();
        this.ownerId = ownerId;

        DisplayPets(); // Load pets for the specified owner
    }

    private async void DisplayPets()
    {
        // Fetch pets based on the ownerId
        List<Pet> petsForOwner = await App.Database.GetPetsByOwnerAsync(ownerId);
        petsListView.ItemsSource = petsForOwner;
    }
}
