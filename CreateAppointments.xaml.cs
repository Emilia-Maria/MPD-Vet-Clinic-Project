using Vet_Clinic.Models;

namespace Vet_Clinic;

public partial class CreateAppointments : ContentPage
{
	public CreateAppointments()
	{
		InitializeComponent();
        LoadAppointmentsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var appointment = (Appointment)BindingContext;

        var pets = await App.Database.GetPetsAsync();
        PetPicker.ItemsSource = (System.Collections.IList)pets;
        PetPicker.ItemDisplayBinding = new Binding("Name");
        var selectedPet = pets.FirstOrDefault(p => p.ID == appointment.PetID);
        PetPicker.SelectedItem = selectedPet;

        var doctors = await App.Database.GetDoctorsAsync();
        DoctorPicker.ItemsSource = (System.Collections.IList)doctors;
        DoctorPicker.ItemDisplayBinding = new Binding("FullName");
        var selectedDoctor = doctors.FirstOrDefault(d => d.ID == appointment.DoctorID);
        DoctorPicker.SelectedItem = selectedDoctor;
    }
    private async void LoadAppointmentsAsync()
    {
        var pets = await App.Database.GetPetsAsync();
        PetPicker.ItemsSource = (System.Collections.IList)pets;
        PetPicker.ItemDisplayBinding = new Binding("Name"); 

        var doctors = await App.Database.GetDoctorsAsync();
        DoctorPicker.ItemsSource = (System.Collections.IList)doctors;
        DoctorPicker.ItemDisplayBinding = new Binding("FullName");
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;

        Pet selectedPet = (PetPicker.SelectedItem as Pet);
        appointment.PetID = selectedPet.ID;
        Doctor selectedDoctor = (DoctorPicker.SelectedItem as Doctor);
        appointment.DoctorID = selectedDoctor.ID;

        DateTime selectedDate = datePicker.Date;
        TimeSpan selectedTime = timePicker.Time;
        appointment.DateTime = selectedDate.Date + selectedTime;

        await App.Database.SaveAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;
        await App.Database.DeleteAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }
    async void OnTreatmentButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Appointment appointment)
        {
            await Navigation.PushAsync(new CreateTreatments(appointment.ID));
        }
    }
    async void OnInvoiceButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is Appointment appointment)
        {
            await Navigation.PushAsync(new CreateInvoice(appointment.ID));
        }
    }
}   