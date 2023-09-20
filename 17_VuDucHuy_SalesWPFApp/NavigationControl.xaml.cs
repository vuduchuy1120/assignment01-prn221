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
            OrderManagement orderManagement = OrderManagement.GetInstance(new OrderRepository()); // Thay OrderRepository() bằng đối tượng Repository của bạn.
            orderManagement.Show();
        }

        private void BtnMember_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMember_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
