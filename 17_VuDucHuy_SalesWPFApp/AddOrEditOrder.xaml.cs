using _17_VuDucHuy_BussinessObject.Models;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
            Order order = new Order();
            order.MemberId = int.Parse(txtAddOrEditMemberId.Text);
            order.OrderDate = dpAddOrEditOrderOrderDate.SelectedDate.Value;
            order.RequiredDate = dpAddOrEditOrderRequiredDate.SelectedDate == null ? null : dpAddOrEditOrderRequiredDate.SelectedDate.Value;
            order.ShippedDate = dpAddOrEditOrderShippedDate.SelectedDate == null ? null : dpAddOrEditOrderShippedDate.SelectedDate.Value;
            order.Freight = decimal.TryParse(txtAddOrEditOrderFreight.Text, out var parsedFreight) ? parsedFreight : null;
            return order;



        }

        private void btnAddOrEditSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderManagement.isAddOrder)
                {
                    Order mb = GetOrderObject();
                    try
                    {
                        if (!ValidateInput())
                        {
                            return;
                        }
                        orderRepository.InsertOrder(mb);
                        this.Close();
                    }catch(Exception ex)
                    {
                        MessageBox.Show("MemberID is not exist!");
                    }
                    
                }
                else
                {
                    Order mb = OrderManagement.order;
                    mb.MemberId = int.Parse(txtAddOrEditMemberId.Text);
                    mb.OrderDate = dpAddOrEditOrderOrderDate.SelectedDate.Value;
                    mb.RequiredDate = dpAddOrEditOrderRequiredDate.SelectedDate == null ? null: dpAddOrEditOrderRequiredDate.SelectedDate.Value;
                    mb.ShippedDate = dpAddOrEditOrderShippedDate.SelectedDate == null ? null: dpAddOrEditOrderShippedDate.SelectedDate.Value;
                    mb.Freight = decimal.TryParse(txtAddOrEditOrderFreight.Text, out var parsedFreight) ? parsedFreight : null;
                    try
                    {
                        if (!ValidateInput())
                        {
                            return;
                        }
                        orderRepository.UpdateOrder(mb);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MemberID is not exist!");
                    }
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateInput()
        {
            string msg = "";
            if (!Regex.IsMatch(txtAddOrEditMemberId.Text,IConstant.REGEX_NUMBER))
            {
                msg += "Member ID must be number\n";
            }
            if(dpAddOrEditOrderOrderDate.SelectedDate == null)
            {
                msg += "Order Date must be selected\n";
            }
            if (txtAddOrEditOrderFreight.Text !="" && !Regex.IsMatch(txtAddOrEditOrderFreight.Text,IConstant.REGEX_DECIMAL))
            {
                msg += "Freight must be number\n";
            }
            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnAddOrEditCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
