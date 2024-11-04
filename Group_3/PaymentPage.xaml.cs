using System.Windows;

namespace Group_3
{
    public partial class PaymentPage : Window
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            string cardNumber = CardNumberTextBox.Text;
            string expirationDate = ExpirationDateTextBox.Text;
            string cvv = CvvTextBox.Text;
            MessageBox.Show("Payment Successful!");
            this.Close(); 
        }
    }
}