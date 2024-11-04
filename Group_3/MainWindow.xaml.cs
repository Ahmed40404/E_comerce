using System;
using System.Linq;
using System.Windows;

namespace Group_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ecomerceEntities ecomerceEntitiess = new ecomerceEntities();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Username_TextBox.Text;
            string password = Password_TextBox.Text;

            using (ecomerceEntities context = new ecomerceEntities())
            {
                var user = context.users.FirstOrDefault(u => u.u_name == username && u.u_pass == password);

                if (user != null)
                {
                    MessageTextBlock.Text = "Login Successfully";

                   
                    Home_Page homePage = new Home_Page();
                    homePage.Show();
                    this.Close(); 
                }
                else
                {
                    MessageTextBlock.Text = "Login Failed, Invalid Username or Password";
                }
            }
        }

        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}