namespace SyncfusionMAUIAppProduct;
///<summary>
///NavigationDrawer class
///</summary>
public partial class NavigationDrawerFeatures : ContentPage 
{
    ///<summary>
    ///NavigationDrawer constructor
    ///</summary>
    public NavigationDrawerFeatures()
    {
        InitializeComponent();
        List<string> list = new List<string>();
        list.Add("Home");
        list.Add("Profile");
        list.Add("Inbox");
        list.Add("Outbox");
        list.Add("Sent");
        list.Add("Draft");
        listView.ItemsSource = list;
    }
    private void hamburgerButton_Clicked(object sender, EventArgs e)
    {
        navigationDrawer.ToggleDrawer();
    }
}
