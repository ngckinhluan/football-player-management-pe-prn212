using GermanyEuro2024.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanyEuro2024.DAL.Repositories
{
    public class FootballPlayerRepository
    {
        private GermanyEuro2024DbContext _context;
        public List<FootballPlayer> GetAll()
        {
            _context = new();
            return _context.FootballPlayers.Include(f => f.FootballTeam).ToList();
        }

        public void Add(FootballPlayer footballPlayer)
        {
            _context = new();
            _context.FootballPlayers.Add(footballPlayer);
            _context.SaveChanges();
        }

        public void Update(FootballPlayer footballPlayer)
        {
            _context = new();
            _context.FootballPlayers.Update(footballPlayer);
            _context.SaveChanges();
        }

        public void Delete(FootballPlayer footballPlayer)
        {
            _context = new();
            _context.FootballPlayers.Remove(footballPlayer);
            _context.SaveChanges();
        }
    }
}
