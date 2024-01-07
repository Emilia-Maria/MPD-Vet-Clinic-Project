using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class CreateTreatments : ContentPage
{
    public int appointmentID { get; set; }
    private Treatment treatment;
    public CreateTreatments(int appointmentID)
    {
        InitializeComponent();
        this.appointmentID = appointmentID;

        LoadTreatment(); // Load the treatment asynchronously
    }
    private async void LoadTreatment()
    {
        // Retrieve treatment data associated with the appointment ID from the database
        treatment = await FetchTreatmentForAppointment(appointmentID);

        if (treatment == null)
        {
            treatment = new Treatment();
            treatment.AppointmentID = appointmentID;
        }

        BindingContext = treatment;
    }
    private Task<Treatment> FetchTreatmentForAppointment(int appointmentID)
    {
        return App.Database.GetTreatmentForAppointment(appointmentID);
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var treatment = (Treatment)BindingContext;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var savedTreatment = (Treatment)BindingContext;

        if (savedTreatment != null) // Check if the savedTreatment object is not null
        {
            savedTreatment.AppointmentID = appointmentID;

            await App.Database.SaveTreatmentAsync(savedTreatment);
            await Navigation.PopAsync();
        }
        else
        {
            // Handle the situation where savedTreatment is null
            // You might want to display an error message or take corrective action
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var treatment = (Treatment)BindingContext;
        await App.Database.DeleteTreatmentAsync(treatment);
        await Navigation.PopAsync();
    }
}