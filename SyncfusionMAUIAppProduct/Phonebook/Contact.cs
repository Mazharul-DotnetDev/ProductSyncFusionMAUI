using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionMAUIAppProduct.Phonebook
{
	public class Contact
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ContactNumber { get; set; }
	}
	public class ContactFormViewModel
	{
		public Contact Contact { get; set; }
		///<summary>
		///DataFormFeatures ViewModel class constructor
		///</summary>
		public ContactFormViewModel()
		{
			this.Contact = new Contact();
		}
	}
	public class ContactGridViewModel : INotifyPropertyChanged
	{
		public ContactGridViewModel()
		{
			DataGenerate();
		}

		#region ItemsSource

		private static ObservableCollection<Contact> contacts;

		public ObservableCollection<Contact> Contacts
		{
			get { return contacts; }
			set { contacts = value; }
		}

		#endregion

		#region ItemSource Generator

		public void DataGenerate()
		{
			if(contacts == null || contacts.Count==0)
			{
				Contacts = new ObservableCollection<Contact>();

				Contacts.Add(new Contact() { FirstName = "Abc", LastName = "Xyz" });
			}
			
		}

		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}


}
