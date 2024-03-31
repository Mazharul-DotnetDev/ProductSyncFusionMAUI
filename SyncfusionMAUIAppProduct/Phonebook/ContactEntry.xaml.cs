namespace SyncfusionMAUIAppProduct.Phonebook;

public partial class ContactEntry : ContentPage
{
	public Contact Contact { get; set; } 
	public ContactEntry()
	{
		InitializeComponent();
	}

	private async  void sfButton_Clicked(object sender, EventArgs e)
	{
		Contact = (Contact)this.BindingContext;


		if(Contact != null )
		{
			//Navigation.
			await Shell.Current.GoToAsync("//ContactListPage");
		}




    }
}