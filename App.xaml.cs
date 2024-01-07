using SQLite;
using Vet_Clinic.Data;

namespace Vet_Clinic;

public partial class App : Application
{
    static VetClinicDatabase database;
    public static int SelectedOwnerId { get; set; }

    public static VetClinicDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new VetClinicDatabase(Path.Combine(FileSystem.AppDataDirectory, "VetClinic.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
