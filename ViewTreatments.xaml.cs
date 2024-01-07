using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class ViewTreatments : ContentPage
{
	public ViewTreatments()
	{
		InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTreatmentsAsync();
    }
    async void OnAppointmentAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateAppointments
        {
            BindingContext = new Appointment()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            Appointment selectedAppointment = e.SelectedItem as Appointment;
            await Navigation.PushAsync(new CreateAppointments
            {
                BindingContext = selectedAppointment // Pass the selected appointment to CreateAppointments
            });
        }
    }
}