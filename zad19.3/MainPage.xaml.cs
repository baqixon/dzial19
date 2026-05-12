namespace zad19._3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ObliczCene();
        }

        private void OnOptionChanged(object sender, CheckedChangedEventArgs e)
        {
            ObliczCene();
        }

        private void OnStepperChanged(object sender, ValueChangedEventArgs e)
        {
            iloscLabel.Text = $"Ilość: {(int)iloscStepper.Value}";

            ObliczCene();
        }

        private void ObliczCene()
        {
            int cenaRozmiaru = 0;
            int dodatekCiasta = 0;
            if (((RadioButton)((VerticalStackLayout)((Frame)((VerticalStackLayout)((ScrollView)Content)
                .Content).Children[1]).Content).Children[1]).IsChecked)
            {
                cenaRozmiaru = 20;
            }
            else if (((RadioButton)((VerticalStackLayout)((Frame)((VerticalStackLayout)((ScrollView)Content)
                .Content).Children[1]).Content).Children[2]).IsChecked)
            {
                cenaRozmiaru = 28;
            }
            else
            {
                cenaRozmiaru = 38;
            }

            // Rodzaj ciasta
            if (((RadioButton)((VerticalStackLayout)((Frame)((VerticalStackLayout)((ScrollView)Content)
                .Content).Children[2]).Content).Children[3]).IsChecked)
            {
                dodatekCiasta = 5;
            }

            int ilosc = (int)iloscStepper.Value;

            int cenaCalkowita = (cenaRozmiaru + dodatekCiasta) * ilosc;

            cenaLabel.Text = $"Cena całkowita: {cenaCalkowita} zł";
        }
    }
}
