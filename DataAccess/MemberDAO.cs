using _17_VuDucHuy_BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        //using singleton pattern
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetMembers()
        {
            List<Member> members;
            try
            {
                var myContext = new ShoppingContext();
                members = myContext.Members.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return members;
        }

        public Member GetMemberByID(int memberID)
        {
            Member member =null;
            try
            {
                var myContext = new ShoppingContext();
                member = myContext.Members.SingleOrDefault(m => m.MemberId == memberID);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return member;
        }
        
        public void InsertMember(Member member)
        {
            try
            {
                var myContext = new ShoppingContext();
                myContext.Members.Add(member);
                myContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMember(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if(_member != null)
                {
                    var myContext = new ShoppingContext();
                    myContext.Members.Remove(_member);
                    myContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Member not exists!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var myContext = new ShoppingContext();
                    myContext.Entry<Member>(member).State = EntityState.Modified;
                    myContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Member not exists!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
