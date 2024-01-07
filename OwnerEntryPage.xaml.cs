using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class OwnerEntryPage : ContentPage
{
    public OwnerEntryPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetOwnersAsync();
    }
    async void OnOwnerAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OwnerPage
        {
            BindingContext = new Owner()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new OwnerPage
            {
                BindingContext = e.SelectedItem as Owner
            });
        }
    }
}