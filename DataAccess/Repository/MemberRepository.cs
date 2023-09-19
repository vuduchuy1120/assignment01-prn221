using _17_VuDucHuy_BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member member) => MemberDAO.Instance.DeleteMember(member);
       

        public Member GetMemberByID(int memberID)=> MemberDAO.Instance.GetMemberByID(memberID);

        public IEnumerable<Member> GetMembers()=> MemberDAO.Instance.GetMembers();

        public void InsertMember(Member member) => MemberDAO.Instance.InsertMember(member);
        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}
