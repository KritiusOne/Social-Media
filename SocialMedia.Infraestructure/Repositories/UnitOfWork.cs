﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }
        public IRepository<Post> PostRepo => _postRepository ?? new BaseRepository<Post>(_context);

        public IRepository<User> UserRepo => _userRepository ?? new BaseRepository<User>(_context);

        public IRepository<Comment> ComentRepo => _commentRepository ?? new BaseRepository<Comment>(_context);

        public void Dispose()
        {
            if(_context == null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}