using TabbedListViewTester;
using TabbedListViewTester.Pages;

namespace CollectionViewScrollTester;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new CollectionViewPage(new CollectionViewPageModel())) { BarBackgroundColor = Colors.LightGray, BarTextColor = Colors.Black };
    }
}
