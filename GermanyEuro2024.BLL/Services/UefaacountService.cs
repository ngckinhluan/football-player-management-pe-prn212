using GermanyEuro2024.DAL.Entities;
using GermanyEuro2024.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024.BLL.Services
{
    public class UefaacountService
    {
        private UefaacountRepository _repo = new();

        public Uefaaccount GetOne(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
    }
}
