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
    /// Interaction logic for AddOrEditMember.xaml
    /// </summary>
    public partial class AddOrEditMember : Window
    {
        private IMemberRepository memberRepository;

        public AddOrEditMember(IMemberRepository repository) 
        {
            try
            {
                InitializeComponent();
                if (Login.isRegister == true)
                {
                    clear();

                }
                else
                {
                    if (MemberManagement.isAddMember == true)
                    {
                        this.Title = "Add Member";
                    }
                    else if (MemberManagement.isAddMember == false && Login.isAdmin == true)
                    {
                        this.Title = "Edit Member";
                        Member mb = MemberManagement.member;
                        clear();
                        txtAddOrEditMemberID.Text = mb.MemberId.ToString();
                        txtAddOrEditEmail.Text = mb.Email;
                        txtAddOrEditCompanyName.Text = mb.CompanyName;
                        txtAddOrEditMemberCity.Text = mb.City;
                        txtAddOrEditMemberCountry.Text = mb.Country;
                        txtAddOrEditMemberPassword.Password = mb.Password;
                    }
                    else if (MemberManagement.isAddMember == false && Login.isAdmin == false)
                    {
                        this.Title = "Edit Profile";
                        Member member = MemberDAO.Instance.GetMemberByID(Login.memberID);
                        clear();
                        txtAddOrEditMemberID.Text = member.MemberId.ToString();
                        txtAddOrEditEmail.Text = member.Email;
                        txtAddOrEditEmail.IsEnabled = false;
                        txtAddOrEditCompanyName.Text = member.CompanyName;
                        txtAddOrEditMemberCity.Text = member.City;
                        txtAddOrEditMemberCountry.Text = member.Country;
                        txtAddOrEditMemberPassword.Password = member.Password;
                    }

                }

                memberRepository = repository;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clear()
        {
            txtAddOrEditMemberID.Text = "";
            txtAddOrEditEmail.Text = "";
            txtAddOrEditCompanyName.Text = "";
            txtAddOrEditMemberCity.Text = "";
            txtAddOrEditMemberCountry.Text = "";
            txtAddOrEditMemberPassword.Password = "";

        }
        private Member GetMemberObject()
        {
            return new Member(txtAddOrEditEmail.Text, txtAddOrEditCompanyName.Text, txtAddOrEditMemberCity.Text, txtAddOrEditMemberCountry.Text, txtAddOrEditMemberPassword.Password);
        }

        private void btnAddOrEditSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.isRegister)
                {
                    Member mb = GetMemberObject();
                    memberRepository.InsertMember(mb);
                    Login.isRegister = false;
                    this.Close();
                }
                else
                {
                    if (MemberManagement.isAddMember)
                    {
                        Member mb = GetMemberObject();
                        memberRepository.InsertMember(mb);
                        this.Close();
                    }
                    else if (Login.isAdmin == true)
                    {
                        Member mb = MemberManagement.member;
                        mb.Email = txtAddOrEditEmail.Text;
                        mb.CompanyName = txtAddOrEditCompanyName.Text;
                        mb.City = txtAddOrEditMemberCity.Text;
                        mb.Country = txtAddOrEditMemberCountry.Text;
                        mb.Password = txtAddOrEditMemberPassword.Password;
                        memberRepository.UpdateMember(mb);
                        this.Close();
                    }
                    else if (Login.isAdmin == false)
                    {
                        Member mb = MemberDAO.Instance.GetMemberByID(Login.memberID);
                        mb.CompanyName = txtAddOrEditCompanyName.Text;
                        mb.City = txtAddOrEditMemberCity.Text;
                        mb.Country = txtAddOrEditMemberCountry.Text;
                        mb.Password = txtAddOrEditMemberPassword.Password;
                        memberRepository.UpdateMember(mb);
                        this.Close();
                    }

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
