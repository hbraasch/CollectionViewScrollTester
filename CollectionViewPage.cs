using Microsoft.Maui.Layouts;

namespace TabbedListViewTester.Pages
{
    public class CollectionViewPage : ContentPage
    {
        CollectionViewPageModel viewModel;
        public CollectionViewPage(CollectionViewPageModel viewModel)
        {
            this.viewModel = viewModel;
            BindingContext = viewModel;

            #region *// List
            var collectionView = new CollectionView()
            {
                SelectionMode = SelectionMode.Single,
            };

            collectionView.ItemTemplate = new DataTemplate(() =>
            {
                var nameLabel = new Label { VerticalTextAlignment = TextAlignment.Center, TextColor = Colors.Black, HeightRequest = 40 };
                nameLabel.SetBinding(Label.TextProperty, new Binding(nameof(CollectionViewPageModel.DisplayData.Name), BindingMode.TwoWay));

                var seperator = new BoxView { HeightRequest = 1, BackgroundColor = Colors.Black };

                return nameLabel;
            });
            collectionView.SetBinding(CollectionView.ItemsSourceProperty, new Binding(nameof(CollectionViewPageModel.List1DisplayItems), BindingMode.OneWay));
            collectionView.RemainingItemsThreshold = 10;
            #endregion


            Title = "CollectView";
            Content = collectionView;

            ToolbarItems.Add(new ToolbarItem("Direct", "", () => { Content = collectionView; }, ToolbarItemOrder.Primary));
            ToolbarItems.Add(new ToolbarItem("Stack", "", () => { Content = new VerticalStackLayout { Children = { collectionView } }; }, ToolbarItemOrder.Primary));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ViewIsAppearing.Execute(null);
        }
    }
}
