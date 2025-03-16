using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

public class ProductViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product> FilteredProducts { get; set; }

    private string _searchText;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterProducts();
            }
        }
    }

    public ProductViewModel()
    {
        // Initialize with some sample products
        Products = new ObservableCollection<Product>
        {
            new Product { Name = "Apple" },
            new Product { Name = "Banana" },
            new Product { Name = "Orange" },
            new Product { Name = "Grapes" },
            new Product { Name = "Pear" },
            new Product { Name = "Pineapple" },
            new Product { Name = "Melon" },
            new Product { Name = "Pumpkin" }
        };

        FilteredProducts = new ObservableCollection<Product>(Products);
    }

    private void FilterProducts()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            FilteredProducts = new ObservableCollection<Product>(Products);
        }
        else
        {
            var filtered = Products
                .Where(p => p.Name.ToLower().Contains(SearchText.ToLower()))
                .ToList();

            FilteredProducts.Clear();
            foreach (var item in filtered)
                FilteredProducts.Add(item);
        }

        OnPropertyChanged(nameof(FilteredProducts));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
