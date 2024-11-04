using System;
using System.Linq;
using System.Windows;

namespace Group_3
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        ecomerceEntities ecomerceEntitiess = new ecomerceEntities();

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
            string username = Username_TextBox.Text; 
            string password = Password_TextBox.Text;
            string addresss = address.Text; 
            string phonee = phone.Text; 
            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(addresss) || string.IsNullOrWhiteSpace(phonee))
            {
                MessageTextBlock.Text = "Please fill in all fields.";
                return;
            }

          
            using (ecomerceEntities context = new ecomerceEntities())
            {
                user user = new user
                {
                    u_name = username,
                    u_pass = password,
                    u_address = addresss,
                    u_phone = phonee
                };

                context.users.Add(user);
                context.SaveChanges();
            }

            MessageTextBlock.Text = "Account Created";
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = Username_TextBox.Text; 
            string password = Password_TextBox.Text; 

            using (ecomerceEntities context = new ecomerceEntities())
            {
             
                var user = context.users.FirstOrDefault(u => u.u_name == username && u.u_pass == password);
                if (user != null)
                {
                    
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageTextBlock.Text = "Login Failed, Invalid Username or Password";
                }
            }
        }
    }
}