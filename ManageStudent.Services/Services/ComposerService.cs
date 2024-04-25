﻿using ManageStudent.Core.Models;
using ManageStudent.Core.Repositories;
using ManageStudent.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Services.Services
{
    public class ComposerService : IComposerService
    {
        private readonly IComposerRepository _context;
        public ComposerService(IComposerRepository context)
        {
            _context = context;
        }
        public async Task<Composer> Create(Composer composer)
        {
            return await _context.Create(composer);
        }

        public async Task<bool> Delete(string id)
        {
            return await _context.Delete(id);
        }

        public async Task<IEnumerable<Composer>> GetAllComposer()
        {
            return await _context.GetAllComposer();
        }

        public Task<Composer> GetComposerById(string id)
        {
            return _context.GetComposerById(id);
        }

        public void Update(string id, Composer composer)
        {
            _context.Update(id, composer);
        }
    }
}