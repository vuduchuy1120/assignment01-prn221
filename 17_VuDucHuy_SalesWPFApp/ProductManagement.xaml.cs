﻿using _17_VuDucHuy_BussinessObject.Models;
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
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Window
    {
        public static bool isAddProduct = false;
        public static Product product = null;
        IProductRepository _ProductRepository;
        public ProductManagement(IProductRepository productRepository)
        {
            InitializeComponent();
            _ProductRepository = productRepository;
        }

        public void LoadProductList()
        {
            lvProduct.ItemsSource = _ProductRepository.GetProducts();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            string name = "";
            string productPrice = "";
            string UnitsInStock = "";
            id = txtProductID.Text;
            name = txtProductName.Text;
            productPrice = txtUnitPrice.Text;
            UnitsInStock = txtUnitInStock.Text;
            lvProduct.ItemsSource = _ProductRepository.SearchProduct(id, name, productPrice, UnitsInStock);

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadProductList();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            isAddProduct = true;
            AddOrEditProduct addOrEditProduct = new AddOrEditProduct(_ProductRepository);
            addOrEditProduct.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            isAddProduct = false;
            product = (Product)lvProduct.SelectedItem;
            AddOrEditProduct addOrEditProduct = new AddOrEditProduct(_ProductRepository);
            addOrEditProduct.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = (Product)lvProduct.SelectedItem;
                _ProductRepository.DeleteProduct(product);
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                btnProductEdit.IsEnabled = true;
                btnProductDelete.IsEnabled = true;
            }
            else
            {
                btnProductEdit.IsEnabled = false;
                btnProductDelete.IsEnabled = false;
            }
        }
    }
}
