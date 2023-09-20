using _17_VuDucHuy_BussinessObject.Models;
using DataAccess;
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
    /// Interaction logic for AddOrEditOrder.xaml
    /// </summary>
    public partial class AddOrEditOrder : Window
    {
        private IOrderRepository orderRepository;

        public AddOrEditOrder(IOrderRepository repository)
        {
            try
            {
                InitializeComponent();
                if (OrderManagement.isAddOrder == true)
                {
                    this.Title = "Add Order";
                }
                else
                {
                    this.Title = "Edit Order";
                    Order mb = OrderManagement.order;
                    clear();
                    txtAddOrEditOrderID.Text = mb.OrderId.ToString();
                    txtAddOrEditMemberId.Text = mb.MemberId.ToString();
                    dpAddOrEditOrderOrderDate.Text = mb.OrderDate.ToString();
                    dpAddOrEditOrderRequiredDate.Text = mb.RequiredDate.ToString();
                    dpAddOrEditOrderShippedDate.Text = mb.ShippedDate.ToString();
                    txtAddOrEditOrderFreight.Text = mb.Freight.ToString();
                }

                orderRepository = repository;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear()
        {
            txtAddOrEditOrderID.Text = "";
            txtAddOrEditMemberId.Text = "";
            dpAddOrEditOrderOrderDate.Text = "";
            dpAddOrEditOrderRequiredDate.Text = "";
            dpAddOrEditOrderShippedDate.Text = "";
            txtAddOrEditOrderFreight.Text = "";
        }
        private Order GetOrderObject()
        {
            return new Order
            {
                MemberId = int.Parse(txtAddOrEditMemberId.Text),
                OrderDate = dpAddOrEditOrderOrderDate.SelectedDate.Value,
                RequiredDate = dpAddOrEditOrderRequiredDate.SelectedDate.Value,
                ShippedDate = dpAddOrEditOrderShippedDate.SelectedDate.Value,
                Freight = decimal.Parse(txtAddOrEditOrderFreight.Text)
            };
        }

        private void btnAddOrEditSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderManagement.isAddOrder)
                {
                    Order mb = GetOrderObject();
                    orderRepository.InsertOrder(mb);
                    this.Close();
                }
                else
                {
                    Order mb = OrderManagement.order;
                    mb.MemberId = int.Parse(txtAddOrEditMemberId.Text);
                    mb.OrderDate = dpAddOrEditOrderOrderDate.SelectedDate.Value;
                    mb.RequiredDate = dpAddOrEditOrderRequiredDate.SelectedDate.Value;
                    mb.ShippedDate = dpAddOrEditOrderShippedDate.SelectedDate.Value;
                    mb.Freight = decimal.Parse(txtAddOrEditOrderFreight.Text);
                    orderRepository.UpdateOrder(mb);
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddOrEditCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
