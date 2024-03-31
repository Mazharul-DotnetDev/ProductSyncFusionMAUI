namespace SyncfusionMAUIAppProduct
{
	public partial class App : Application
	{
		public App()
		{
            //Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
			InitializeComponent();

			MainPage = new AppShell();
		}
	}
}
