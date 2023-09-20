using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _17_VuDucHuy_SalesWPFApp
{
    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    public partial class NavigationControl : Window
    {
        public NavigationControl()
        {
            InitializeComponent();

        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderManagement orderManagement = new  OrderManagement(new OrderRepository()); // Thay OrderRepository() bằng đối tượng Repository của bạn.
            orderManagement.Show();
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductManagement productManagement = new ProductManagement(new ProductRepository()); // Thay OrderRepository() bằng đối tượng Repository của bạn.
            productManagement.Show();
        }

        private void BtnMember_Click(object sender, RoutedEventArgs e)
        {
            MemberManagement memberManagement = new MemberManagement(new MemberRepository()); // Thay MemberRepository() bằng đối tượng Repository của bạn.

            memberManagement.Show();
        }
    }
}
