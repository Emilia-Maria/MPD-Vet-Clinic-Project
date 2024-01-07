namespace Vet_Clinic.Models;

public partial class CreateInvoice : ContentPage
{
    public int appointmentID { get; set; }
    private Invoice invoice;
    public CreateInvoice(int appointmentID)
    {
        InitializeComponent();
        this.appointmentID = appointmentID;
        LoadTreatment();
    }
    private async void LoadTreatment()
    {
        invoice = await FetchInvoiceForAppointment(appointmentID);

        if (invoice == null)
        {
            invoice = new Invoice();
            invoice.AppointmentID = appointmentID;
        }

        BindingContext = invoice;
    }
    private Task<Invoice> FetchInvoiceForAppointment(int appointmentID)
    {
        return App.Database.GetInvoiceForAppointment(appointmentID);
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var invoice = (Invoice)BindingContext;

        if (invoice != null)
        {
            invoice.AppointmentID = appointmentID;

            await App.Database.SaveInvoiceAsync(invoice);
            await Navigation.PopAsync();
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var invoice = (Invoice)BindingContext;
        await App.Database.DeleteInvoiceAsync(invoice);
        await Navigation.PopAsync();
    }
}