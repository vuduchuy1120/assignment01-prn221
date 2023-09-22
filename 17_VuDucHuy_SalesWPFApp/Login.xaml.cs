using _17_VuDucHuy_BussinessObject.Models;
using DataAccess;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _17_VuDucHuy_SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static bool isAdmin = false;
        public static int memberID = -1;
        public static bool isRegister = false;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            if (TryLoginAsAdmin(username, password))
            {
                // Đăng nhập thành công với tài khoản admin
                isAdmin = true;
                ShowNavigationControl();
            }
            else if (TryLoginAsMember(username, password))
            {
                // Đăng nhập thành công với tài khoản thành viên
                isAdmin = false;
                ShowUserControl();
            }
            else
            {
                // Đăng nhập không thành công
                MessageBox.Show("Invalid username or password");
            }
        }

        private bool TryLoginAsAdmin(string username, string password)
        {
            return AdminCheck(username, password);
        }
        private Boolean AdminCheck(string username, string password)
        {
            var admin = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build().GetSection("Admin");

            if (!admin["username"].Equals(username) || !admin["password"].Equals(password))
            {
                return false;
            }
            return true;
        }

        private bool TryLoginAsMember(string username, string password)
        {
            var members = MemberDAO.Instance.GetMembers();
            var authenticatedMember = members.FirstOrDefault(member =>
                !string.IsNullOrEmpty(member.Email) && !string.IsNullOrEmpty(member.Password) &&
                member.Email.Trim().Equals(username) && member.Password.Equals(password));

            if (authenticatedMember != null)
            {
                memberID = authenticatedMember.MemberId;
                return true;
            }

            return false;
        }

        private void ShowNavigationControl()
        {
            NavigationControl navigationControl = new NavigationControl();
            navigationControl.Show();
            Hide();
            navigationControl.Closed += (s, args) =>
            {
                txtUsername.Clear();
                txtPassword.Clear();
                isAdmin = false;
                isRegister = false;
                memberID = -1;
                Show();
            };
        }

        private void ShowUserControl()
        {
            UserControl userControl = new UserControl();
            userControl.Show();
            Hide();
            userControl.Closed += (s, args) =>
            {
                txtUsername.Clear();
                txtPassword.Clear();
                isAdmin = false;
                isRegister = false;
                memberID = -1;
                Show();
            };
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            isRegister = true;
            AddOrEditMember addOrEditMember = new AddOrEditMember(new MemberRepository());
            addOrEditMember.ShowDialog();
            addOrEditMember.Closed += (s, args) =>
            {
                isAdmin = false;
                isRegister = false;
                memberID = -1;
            };
        }
    }

}
