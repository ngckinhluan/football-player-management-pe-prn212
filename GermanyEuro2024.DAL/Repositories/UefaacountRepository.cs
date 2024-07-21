using GermanyEuro2024.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024.DAL.Repositories
{
    public class UefaacountRepository
    {
        private GermanyEuro2024DbContext _context;

        public List<Uefaaccount> GetAll()
        {
            _context = new();
            return _context.Uefaaccounts.ToList();
        }

        public Uefaaccount GetOne(string email, string password)
        {
            _context = new();
            return _context.Uefaaccounts.FirstOrDefault(u => u.AccountEmail == email && u.AccountPassword == password && (u.Role == 3 || u.Role == 2));
        }
    }
}
