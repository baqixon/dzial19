namespace zad19._4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            conferenceDatePicker.MinimumDate = new DateTime(2026, 6, 10);
            conferenceDatePicker.MaximumDate = new DateTime(2026, 6, 12);

            conferenceDatePicker.Date = new DateTime(2026, 6, 10);

            UpdatePrice();
        }

        private void OnPackageChanged(object sender, CheckedChangedEventArgs e)
        {
            UpdatePrice();
        }
        private void OnStepperChanged(object sender, ValueChangedEventArgs e)
        {
            peopleLabel.Text = $"Liczba osób: {(int)peopleStepper.Value}";
            UpdatePrice();
        }
        private void UpdatePrice()
        {
            int packagePrice = 0;
            if (basicRadio.IsChecked)
            {
                packagePrice = 200;
            }
            else if (standardRadio.IsChecked)
            {
                packagePrice = 350;
            }
            else if (premiumRadio.IsChecked)
            {
                packagePrice = 500;
            }           int additionalPeople = (int)peopleStepper.Value;

            int totalPrice = packagePrice + (additionalPeople * 100);

            priceLabel.Text = $"Cena całkowita: {totalPrice} zł";
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await DisplayAlertAsync("Błąd",
                    "Podaj imię i nazwisko.",
                    "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(emailEntry.Text))
            {
                await DisplayAlertAsync("Błąd",
                    "Podaj adres email.",
                    "OK");
                return;
            }

            if (companyPicker.SelectedIndex == -1)
            {
                await DisplayAlertAsync("Błąd", "Wybierz firmę.", "OK");
                return;
            }

            string company = companyPicker.SelectedItem.ToString();

            string packageName = "";
            int packagePrice = 0;

            if (basicRadio.IsChecked)
            {
                packageName = "Basic";
                packagePrice = 200;
            }
            else if (standardRadio.IsChecked)
            {
                packageName = "Standard";
                packagePrice = 350;
            }
            else if (premiumRadio.IsChecked)
            {
                packageName = "Premium";
                packagePrice = 500;
            }

            int additionalPeople = (int)peopleStepper.Value;

            int totalPrice = packagePrice + (additionalPeople * 100);

            await DisplayAlertAsync(
                "Rejestracja zakończona",
                $"Uczestnik: {nameEntry.Text}\n" +
                $"Email: {emailEntry.Text}\n" +
                $"Firma: {company}\n" +
                $"Data konferencji: {conferenceDatePicker.Date.ToString()}\n" +
                $"Pakiet: {packageName}\n" +
                $"Osoby towarzyszące: {additionalPeople}\n" +
                $"Całkowity koszt: {totalPrice} zł",
                "OK");
        }
    }
}