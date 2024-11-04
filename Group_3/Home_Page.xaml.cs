using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Group_3
{
    public partial class Home_Page : Window
    {
        private List<product> products = new List<product>();
        private List<shopping_carts> cart = new List<shopping_carts>();

        public Home_Page()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (ecomerceEntities context = new ecomerceEntities())
            {
                
                products = context.products.ToList();

                foreach (var product in products.Take(5)) 
                {
                    StackPanel productPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(5) };

                    Label productLabel = new Label
                    {
                        Content = $"{product.p_name} - ${product.p_price}",
                        Width = 200
                    };

                    Button addButton = new Button
                    {
                        Content = "Add to Cart",
                        Tag = product,
                        Width = 100
                    };
                    addButton.Click += AddButton_Click;
                    productPanel.Children.Add(productLabel);
                    productPanel.Children.Add(addButton);
                    ProductsPanel.Children.Add(productPanel);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = sender as Button;
            product product = button.Tag as product;

            if (product != null)
            {
                using (ecomerceEntities context = new ecomerceEntities())
                {
                    shopping_carts cartItem = new shopping_carts
                    {
                        user_id = 1,
                        product_id = product.p_id,
                        quantity = 1 
                    };
                    context.shopping_carts.Add(cartItem);
                    context.SaveChanges();
                }

                MessageBox.Show($"{product.p_name} has been added to the cart.");
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            //MenuListBox.Visibility = MenuListBox.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            
            CartPage cartPage = new CartPage();
            cartPage.Show();
            this.Close();
        }
    }
}