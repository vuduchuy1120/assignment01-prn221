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
    /// Interaction logic for MemberManagement.xaml
    /// </summary>
    public partial class MemberManagement : Window
    {
        public static bool isAddMember = false;
        public static Member member = null;
        IMemberRepository _memberRepository;
        public MemberManagement(IMemberRepository memberRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
        }

        private void btnMemberRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = (Member)lvMember.SelectedItem;
                _memberRepository.DeleteMember(member);
                LoadMemberList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditMember_Click(object sender, RoutedEventArgs e)
        {
            isAddMember = false;
            member = (Member)lvMember.SelectedItem;
            AddOrEditMember addOrEditMember = new AddOrEditMember(_memberRepository);
            addOrEditMember.ShowDialog();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvMember.SelectedItem != null)
            {
                btnMemberEdit.IsEnabled = true;
                btnMemberRemove.IsEnabled = true;
            }
            else
            {
                btnMemberEdit.IsEnabled = false;
                btnMemberRemove.IsEnabled = false;
            }
        }

        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            isAddMember = true;
            AddOrEditMember addOrEditMember = new AddOrEditMember(_memberRepository);
            addOrEditMember.ShowDialog();
        }

        private void btnLoadMember_Click(object sender, RoutedEventArgs e)
        {
            LoadMemberList();
        }
        public void LoadMemberList()
        {
            lvMember.ItemsSource = _memberRepository.GetMembers();
        }
    }
}
