using _17_VuDucHuy_BussinessObject.Models;
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
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        public static bool isAddOrder = false;
        public static Order order = null;
        private IOrderRepository _OrderRepository;
        public OrderManagement(IOrderRepository OrderRepository)
        {
            InitializeComponent();
            _OrderRepository = OrderRepository;
        }

        private void btnOrderRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = (Order)lvOrder.SelectedItem;
                _OrderRepository.DeleteOrder(order);
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            isAddOrder = false;
            order = (Order)lvOrder.SelectedItem;
            AddOrEditOrder addOrEditOrder = new AddOrEditOrder(_OrderRepository);
            addOrEditOrder.ShowDialog();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            isAddOrder = true;
            AddOrEditOrder addOrEditOrder = new AddOrEditOrder(_OrderRepository);
            addOrEditOrder.ShowDialog();
        }

        private void btnLoadOrder_Click(object sender, RoutedEventArgs e)
        {
            LoadOrderList();
        }

        public void LoadOrderList()
        {
            lvOrder.ItemsSource = _OrderRepository.GetOrders();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOrder.SelectedItem != null)
            {
                btnOrderEdit.IsEnabled = true;
                btnOrderDelete.IsEnabled = true;
            }
            else
            {
                btnOrderEdit.IsEnabled = false;
                btnOrderDelete.IsEnabled = false;
            }
        }
    }
}
