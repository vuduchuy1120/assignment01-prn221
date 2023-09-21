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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace _17_VuDucHuy_SalesWPFApp
{
    /// <summary>
    /// Interaction logic for AddOrEditProduct.xaml
    /// </summary>
    public partial class AddOrEditProduct : Window
    {
        private IProductRepository productRepository;

        public AddOrEditProduct(IProductRepository repository)
        {
            try
            {
                InitializeComponent();
                if (ProductManagement.isAddProduct == true)
                {
                    this.Title = "Add Product";
                }
                else
                {
                    this.Title = "Edit Product";
                    Product mb = ProductManagement.product;
                    //fill
                    clear();
                    txtAddOrEditProductID.Text = mb.ProductId.ToString();
                    txtAddOrEditCategoryID.Text = mb.CategoryId.ToString();
                    txtAddOrEditProductName.Text = mb.ProductName;
                    txtAddOrEditProductWeight.Text = mb.Weight.ToString();
                    txtAddOrEditProductUnitPrice.Text = mb.UnitPrice.ToString();
                    txtAddOrEditProductUnitsInStock.Text = mb.UnitsInStock.ToString();


                }

                productRepository = repository;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear()
        {
            txtAddOrEditProductID.Text = "";
            txtAddOrEditCategoryID.Text = "";
            txtAddOrEditProductName.Text = "";
            txtAddOrEditProductWeight.Text = "";
            txtAddOrEditProductUnitPrice.Text = "";
            txtAddOrEditProductUnitsInStock.Text = "";

        }
        private Product GetProductObject()
        {
            return new Product
            {
                CategoryId = int.Parse(txtAddOrEditCategoryID.Text),
                ProductName = txtAddOrEditProductName.Text,
                Weight = txtAddOrEditProductWeight.Text,
                UnitPrice = decimal.Parse(txtAddOrEditProductUnitPrice.Text),
                UnitsInStock = int.Parse(txtAddOrEditProductUnitsInStock.Text)

            };
        }

        private void btnAddOrEditProductCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddOrEditProductSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductManagement.isAddProduct)
                {
                    try
                    {
                        if(!ValidateInput())
                        {
                            return;
                        }
                        Product mb = GetProductObject();
                        productRepository.AddProduct(mb);
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                else
                {

                    Product mb = ProductManagement.product;
                    mb.CategoryId = int.Parse(txtAddOrEditCategoryID.Text);
                    mb.ProductName = txtAddOrEditProductName.Text;
                    mb.Weight = txtAddOrEditProductWeight.Text;
                    mb.UnitPrice = decimal.Parse(txtAddOrEditProductUnitPrice.Text);
                    mb.UnitsInStock = int.Parse(txtAddOrEditProductUnitsInStock.Text);
                    try
                    {
                        if(!ValidateInput())
                        {
                            return;
                        }
                        productRepository.UpdateProduct(mb);
                        this.Close();
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
            if (string.IsNullOrEmpty(txtAddOrEditCategoryID.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtAddOrEditCategoryID.Text, IConstant.REGEX_NUMBER))
            {
                msg += "Category ID is invalid\n";
            }
            if (string.IsNullOrEmpty(txtAddOrEditProductName.Text))
            {
                msg += "Product name is invalid\n";
            }
            if (string.IsNullOrEmpty(txtAddOrEditProductWeight.Text))
            {
                msg += "Product weight is invalid\n";
            }
            if (string.IsNullOrEmpty(txtAddOrEditProductUnitPrice.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtAddOrEditProductUnitPrice.Text, IConstant.REGEX_DECIMAL))
            {
                msg += "Product unit price is invalid\n";
            }
            if (string.IsNullOrEmpty(txtAddOrEditProductUnitsInStock.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtAddOrEditProductUnitsInStock.Text, IConstant.REGEX_NUMBER))
            {
                msg += "Product units in stock is invalid\n";
            }
            if (msg != "")
            {
                MessageBox.Show(msg);
                return false;
            }
            else return true;

        }
    }
}
