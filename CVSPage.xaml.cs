using CommunityToolkit.Mvvm.Collections;
using Microsoft.UI.Xaml.Controls;


namespace CVSBinding
{
    public sealed partial class CVSPage : Page
    {
        private readonly ObservableGroupedCollection<object, MyItem> _mailItemSource = [];

        public ReadOnlyObservableGroupedCollection<object, MyItem> MailItems { get; }

        private int index = 0;

        public CVSPage()
        {
            InitializeComponent();
            MailItems = new ReadOnlyObservableGroupedCollection<object, MyItem>(_mailItemSource);
        }

        private void AddClicked(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var item = new MyItem { Title = $"New Item {index}" };
            _mailItemSource.AddGroup(index, [item]);

            index++;
        }
    }
}
