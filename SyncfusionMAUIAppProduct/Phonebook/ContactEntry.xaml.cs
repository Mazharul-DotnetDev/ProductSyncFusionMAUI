namespace SyncfusionMAUIAppProduct.Phonebook;

public partial class ContactEntry : ContentPage
{
    public Contact Contact { get; set; }
    private ContactGridViewModel cvm;
    public ContactEntry()
    {
        InitializeComponent();
        HandlerChanged += OnHandlerChanged;
    }

    void OnHandlerChanged(object sender, EventArgs e)
    {
        cvm = Handler.MauiContext.Services.GetService<ContactGridViewModel>();
    }

    private async void sfButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            ContactFormViewModel ContactFormViewModel = (ContactFormViewModel)this.BindingContext;


            if (ContactFormViewModel.Contact != null)
            {
                cvm.AddContact(ContactFormViewModel.Contact);
                //Navigation.
                await Shell.Current.GoToAsync("//ContactListPage");
            }
        }
        catch (Exception ex)
        {

            await Shell.Current.DisplayAlert("ERROR", ex.Message, "X");
        }





    }
}