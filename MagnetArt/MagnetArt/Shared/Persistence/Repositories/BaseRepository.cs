﻿using MagnetArt.Shared.Persistence.Contexts;

namespace MagnetArt.Shared.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
