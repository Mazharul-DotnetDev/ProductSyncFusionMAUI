using SyncfusionMAUIAppProduct.Phonebook;

namespace SyncfusionMAUIAppProduct
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();


			Routing.RegisterRoute("ContactEntryPage", typeof(ContactEntry));
		}
	}
}
