using System.Reflection;
namespace SyncfusionMAUIAppProduct;
///<summary>
///PDFViewerFeatures class
///</summary>
public partial class PDFViewerFeatures : ContentPage
{
	///<summary>
    ///PDFViewerFeatures constructor
    ///</summary>
    public PDFViewerFeatures()
    {
        InitializeComponent();
    }
}
///<summary>
///ViewModel class for the PDFViewerFeatures 
///</summary>
class ViewModel
{
	/// <summary>
	/// The PDF document stream that is loaded into the instance of the PDF viewer. 
	/// </summary>
	public Stream PdfDocumentStream { get; set; }
	/// <summary>
	/// Constructor of the view model class
	/// </summary>
	public ViewModel()
	{
		//Accessing the PDF document that is added as embedded resource as stream.
		PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SyncfusionMAUIAppProduct.Assets.pdf_succinctly.pdf");
	}
}
