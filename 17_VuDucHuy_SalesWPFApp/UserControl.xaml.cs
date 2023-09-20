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
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class UserControl : Window
    {
        public UserControl()
        {
            InitializeComponent();
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditMember addOrEditMember = new AddOrEditMember(new MemberRepository());
            addOrEditMember.ShowDialog();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderManagement orderManagement = new OrderManagement(new OrderRepository()); // Thay OrderRepository() bằng đối tượng Repository của bạn.
            orderManagement.Show();
        }
    }
}
