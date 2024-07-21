using GermanyEuro2024.DAL.Entities;
using GermanyEuro2024.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024.BLL.Services
{
    public class FootballTeamService
    {
        private FootballTeamRepository _repo = new();
        public List<FootballTeam> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
