using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionMAUIAppProduct
{
    public class DataGridViewModel : INotifyPropertyChanged
    {
        public DataGridViewModel()
        {
            SetRowstoGenerate();
        }

        #region Filtering

        #region Fields

        private string filtertext = "";
        private int columnselectedIndex = 0;
        private string selectedcolumn = "All Columns";
        private string selectedcondition = "Contains";

        internal delegate void FilterChanged();

        internal FilterChanged filtertextchanged;

        #endregion

        #region Property

        public string FilterText
        {
            get { return filtertext; }
            set
            {
                filtertext = value;
                OnFilterTextChanged();
                RaisePropertyChanged("FilterText");
            }

        }

        public int ColumnSelectedIndex
        {
            get { return columnselectedIndex; }
            set
            {
                columnselectedIndex = value;
                RaisePropertyChanged("ColumnSelectedIndex");
            }
        }
        public string SelectedCondition
        {
            get { return selectedcondition; }
            set { selectedcondition = value; }
        }

        public string SelectedColumn
        {
            get { return selectedcolumn; }
            set { selectedcolumn = value; }
        }

        #endregion

        #region Private Methods

        private void OnFilterTextChanged()
        {
            if (filtertextchanged != null)
                filtertextchanged();
        }

        private bool MakeStringFilter(OrderInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
            var methods = typeof(string).GetMethods();

            if (methods.Count() != 0)
            {
                if (condition == "Contains")
                {
                    var methodInfo = methods.FirstOrDefault(method => method.Name == condition);
                    bool result1 = (bool)methodInfo.Invoke(exactValue, new object[] { text });
                    return result1;
                }
                else if (exactValue.ToString() == text.ToString())
                {
                    bool result1 = String.Equals(exactValue.ToString(), text.ToString());
                    if (condition == "Equals")
                        return result1;
                    else if (condition == "NotEquals")
                        return false;
                }
                else if (condition == "NotEquals")
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private bool MakeNumericFilter(OrderInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric)
            {
                switch (condition)
                {
                    case "Equals":
                        try
                        {
                            if (exactValue.ToString() == FilterText)
                            {
                                if (Convert.ToDouble(exactValue) == (Convert.ToDouble(FilterText)))
                                    return true;
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                        break;
                    case "NotEquals":
                        try
                        {
                            if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                                return true;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        #endregion

        #region Public Methods

        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as OrderInfo;
            if (item != null && FilterText.Equals("") && !string.IsNullOrEmpty(FilterText))
            {
                return true;
            }
            else
            {
                if (item != null)
                {
                    if (checkNumeric && !SelectedColumn.Equals("All Columns") && !SelectedCondition.Equals("Contains"))
                    {
                        bool result = MakeNumericFilter(item, SelectedColumn, SelectedCondition);
                        return result;
                    }
                    else if (SelectedColumn.Equals("All Columns"))
                    {
                        if (item.CustomerID.ToLower().Contains(FilterText.ToLower()) ||
                            item.OrderID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Customer.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.ShipCountry.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.ShipCity.ToLower().Contains(FilterText.ToLower()))
                            return true;
                        return false;
                    }
                    else
                    {
                        bool result = MakeStringFilter(item, SelectedColumn, SelectedCondition);
                        return result;
                    }
                }
            }
            return false;
        }

        #endregion

        #endregion

        #region ItemsSource

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            ordersInfo = order.GenerateOrders();
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
