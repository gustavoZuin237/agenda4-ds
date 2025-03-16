namespace Agenda4_DS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel();
        }
    }

}
