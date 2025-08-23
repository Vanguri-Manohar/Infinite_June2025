﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Assignment.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using MVC_Assignment.Repository;

namespace MVC_Assignment.Repository
{
    public class ContactRepository : IContactRepository
    {
         readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }

}