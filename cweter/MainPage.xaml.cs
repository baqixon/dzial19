namespace cweter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            dataPicker.MinimumDate = DateTime.Today.AddDays(1);
            dataPicker.MaximumDate = DateTime.Today.AddDays(30);
            dataPicker.Date = DateTime.Today.AddDays(1);
        }

        private async void OnReserveClicked(object sender, EventArgs e)
        {
            if (specjalizacjaPicker.SelectedIndex == -1)
            {
                await DisplayAlertAsync("Błąd",
                    "Wybierz specjalizację.",
                    "OK");
                return;
            }
            string specjalizacja =
                specjalizacjaPicker.SelectedItem.ToString();

            DateTime data = (DateTime)dataPicker.Date;
            TimeSpan godzina = (TimeSpan)godzinaPicker.Time;

            string dataText = data.ToString("dd.MM.yyyy");
            string godzinaText = godzina.ToString(@"hh\:mm");

            await DisplayAlertAsync(
                "Rezerwacja",
                $"Wizyta u {specjalizacja} dnia {dataText} o godzinie {godzinaText}",
                "OK");
        }
    }
}
