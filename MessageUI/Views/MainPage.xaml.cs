using MessageUI.ViewModels;
using Microsoft.Practices.Prism.Events;

namespace MessageUI.Views
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.DataContext = new MainPageViewModel(new EventAggregator());
		}
	}
}