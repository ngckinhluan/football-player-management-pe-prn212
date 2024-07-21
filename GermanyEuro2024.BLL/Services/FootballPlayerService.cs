using GermanyEuro2024.DAL.Entities;
using GermanyEuro2024.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024.BLL.Services
{
    public class FootballPlayerService
    {
        private FootballPlayerRepository _repo = new();

        public List<FootballPlayer> GetAll()
        {
            return _repo.GetAll();
        }

        public void Add(FootballPlayer footballPlayer)
        {
            _repo.Add(footballPlayer);
        }

        public void Delete(FootballPlayer footballPlayer)
        {
            _repo.Delete(footballPlayer);
        }

        public void Update(FootballPlayer footballPlayer)
        {
            _repo.Update(footballPlayer);
        }

        public List<FootballPlayer> Search(string achivements, string name)
        {
            return _repo.GetAll().Where(f => f.Achievements.ToLower().Contains(achivements.ToLower()) && f.PlayerName.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
