using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Group_3
{
    public partial class CartPage : Window
    {
        public ecomerceEntities ecomerceEntities = new ecomerceEntities();

        public CartPage()
        {
            InitializeComponent();
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            using (ecomerceEntities context = new ecomerceEntities())
            {
                int userId = 1; 

                var cartItems = context.shopping_carts
                    .Where(c => c.user_id == userId)
                    .Select(c => new
                    {
                        Product = context.products.FirstOrDefault(p => p.p_id == c.product_id),
                        c.quantity,
                        c.cart_id
                    })
                    .ToList();

                CartListBox.Items.Clear();

                foreach (var item in cartItems)
                {
                    if (item.Product != null)
                    {
                        StackPanel itemPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

                        Label itemLabel = new Label
                        {
                            Content = $"{item.Product.p_name} - {item.quantity} x ${item.Product.p_price} = ${item.quantity * item.Product.p_price}",
                            Width = 300
                        };

                        Button selectButton = new Button
                        {
                            Content = "Select",
                            Tag = item.cart_id,
                            Width = 100
                        };
                        selectButton.Click += SelectButton_Click;

                        Button deleteButton = new Button
                        {
                            Content = "Delete",
                            Tag = item.cart_id,
                            Width = 100
                        };
                        deleteButton.Click += DeleteButton_Click;

                        itemPanel.Children.Add(itemLabel);
                        itemPanel.Children.Add(selectButton);
                        itemPanel.Children.Add(deleteButton);
                        CartListBox.Items.Add(itemPanel);
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = sender as Button;
            int cartId = (int)deleteButton.Tag; 

            using (ecomerceEntities context = new ecomerceEntities())
            {
                var cartItem = context.shopping_carts.FirstOrDefault(c => c.cart_id == cartId);
                if (cartItem != null)
                {
                    context.shopping_carts.Remove(cartItem);
                    context.SaveChanges();
                    MessageBox.Show("Item removed from cart.");
                    LoadCartItems();
                }
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Button selectButton = sender as Button;
            int cartId = (int)selectButton.Tag;

            
            MessageBox.Show($"Selected item with Cart ID: {cartId}");
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage paymentPage = new PaymentPage();
            paymentPage.Show();
            this.Close();
            
        }

        private void back_Click(object sender, object e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
            this.Close();
        }
    }
}