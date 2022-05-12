using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TabbedListViewTester
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class CollectionViewPageModel
    {
        public class DisplayData
        {
            public string Name { get; set; }
        }


        public ObservableCollection<DisplayData> List1DisplayItems { get; set; }


        public CollectionViewPageModel()
        {
            List1DisplayItems = new ObservableCollection<DisplayData>();
        }



        public ICommand ViewIsAppearing => new Command(() =>
        {
            UpdateDisplay();
        });

        private void UpdateDisplay()
        {
            var list1 = new List<DisplayData>();

            for (int i = 0; i < 100; i++)
            {
                list1.Add(new DisplayData() { Name = $"List 1 item {i}" });
            }
            List1DisplayItems = new ObservableCollection<DisplayData>(list1);
        }


        public ICommand OnList1AddPressed => new Command(() =>
        {
            var list = List1DisplayItems.ToList();
            list.Add(new DisplayData { Name = "Added item" });
            list = list.OrderBy(o => o.Name).ToList();
            List1DisplayItems = new ObservableCollection<DisplayData>(list);
        });

    }
}
