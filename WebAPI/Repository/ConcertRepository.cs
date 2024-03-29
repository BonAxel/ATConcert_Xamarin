﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly DataContext _context;

        public ConcertRepository(DataContext context)
        {
            _context = context;
        }

        public bool ConcertExists(int id)
        {
            return _context.Concerts.Any(e => e.ConcertId == id);
        }

        public Concert GetConcert(int id)
        {
            return _context.Concerts.Where(e => e.ConcertId == id).FirstOrDefault();
        }

        public ICollection<Concert> GetConcerts()
        {
            return _context.Concerts.ToList();
        }
    }
}
