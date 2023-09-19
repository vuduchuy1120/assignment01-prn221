using _17_VuDucHuy_BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memberID);
        void InsertMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);

    }
}
