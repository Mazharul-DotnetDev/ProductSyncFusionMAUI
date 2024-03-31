using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        private ICommand buttonCommand;
        public ICommand ButtonCommand
        {
            get { return buttonCommand; }
            set { buttonCommand = value; }
        }

        public ContactGridViewModel()
        {
            DataGenerate();
            this.ButtonCommand = new Command(DeleteRecord);
        }

        #region ItemsSource

        private ObservableCollection<Contact> contacts;

        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; RaisePropertyChanged("Contacts"); }
        }

        public void AddContact(Contact c)
        {

            //if (contacts == null || contacts.Count == 0)
            //{
            //    Contacts = new ObservableCollection<Contact>();
            //}
            Contacts.Add(c);
            RaisePropertyChanged("Contacts");
        }
        private void DeleteRecord(object contact )
        {
            if(contact is Contact cnt)
            {
                var c = Contacts.AsEnumerable().First(x => x.Id == cnt.Id);

                Contacts.Remove(c);
                RaisePropertyChanged("Contacts");

            }
        }

        #endregion



        #region ItemSource Generator

        public void DataGenerate()
		{
			if(contacts == null)
			{
				Contacts = new ObservableCollection<Contact>();				
			}

			//if(contacts.Count == 0)
   //             Contacts.Add(new Contact() { FirstName = "Abc", LastName = "Xyz" });
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
