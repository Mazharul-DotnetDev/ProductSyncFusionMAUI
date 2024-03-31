namespace SyncfusionMAUIAppProduct;
///<summary>
///DataFormFeatures class
///</summary>
public partial class DataFormFeatures : ContentPage
{
    public DataFormFeatures()
    {
        InitializeComponent();
    }
}
///<summary>
///DataFormFeatures Model class
///</summary>
public class ContactsInfo
{
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public string ContactNumber { get; set; }
	public string Email { get; set; }
	public string Address { get; set; }
	public DateTime? BirthDate { get; set; }
	public string GroupName { get; set; }
}
///<summary>
///DataFormFeatures ViewModel class
///</summary>
public class DataFormViewModel
{
	public ContactsInfo ContactsInfo { get; set; }
	///<summary>
    ///DataFormFeatures ViewModel class constructor
    ///</summary>
	public DataFormViewModel()
	{
		this.ContactsInfo = new ContactsInfo();
	}
}
