using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;


namespace CVSBinding
{
    [INotifyPropertyChanged]
    public sealed partial class CVSPage : Page
    {
        public ViewModel VM { get; set; } = new ViewModel();

        public CVSPage()
        {
            InitializeComponent();
        }

        private void AddClicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            VM.Add();
        }
    }

    public partial class ViewModel : ObservableObject
    {
        // Community Toolkit collection.
        private readonly ObservableGroupedCollection<object, MyItem> _mailItemSource = [];

        public ReadOnlyObservableGroupedCollection<object, MyItem> MailItems { get; }

        private int index = 0;

        // IGrouping
        [ObservableProperty]
        public partial IEnumerable<IGrouping<object, MyItem>> NewItems { get; set; }

        private List<MyItem> _newItems = new List<MyItem>();

        public ViewModel()
        {
            MailItems = new ReadOnlyObservableGroupedCollection<object, MyItem>(_mailItemSource);
        }

        public void Add()
        {
            // Item to add.
            var item = new MyItem { Title = $"New Item {index}" };

            // Add to Community Toolkit collection.
            _mailItemSource.AddGroup(index, new MyItem[] { item });

            // Add to IGrouping source.
            _newItems.Add(item);

            var result =
                from t in _newItems
                group t by t.Title into g
                orderby g.Key
                select g;

            index++;

            NewItems = result;
        }
    }
}
