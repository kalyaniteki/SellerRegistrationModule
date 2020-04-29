using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AccountService.Models;

namespace AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmartDBContext _context;
        public AccountRepository(EmartDBContext context)
        {
            _context = context;
        }

        public void SellerRegister(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller ValidateSeller(string uname, string pwd)
        {
            Seller b = _context.Seller.SingleOrDefault(e => e.Username == uname && e.Password == pwd);
            return b;
        }
    }
}
