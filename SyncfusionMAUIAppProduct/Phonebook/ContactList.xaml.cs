namespace SyncfusionMAUIAppProduct.Phonebook;

public partial class ContactList : ContentPage
{
	public ContactList()
	{
		InitializeComponent();
        HandlerChanged += OnHandlerChanged;
    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        BindingContext = Handler.MauiContext.Services.GetService<ContactGridViewModel>();
    }
    private async void sfButton_Clicked(object sender, EventArgs e)
	{
		try
		{

			await Shell.Current.GoToAsync("ContactEntryPage");
		}
		catch (Exception ex)
		{

			await Shell.Current.DisplayAlert("ERROR", ex.Message, "X");
		}
	}
}