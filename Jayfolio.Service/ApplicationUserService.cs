using Jayfolio.Data;
using Jayfolio.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jayfolio.Service
{
    class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext m_context;

        public ApplicationUserService(ApplicationDbContext _context)
        {
            m_context = _context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return m_context.ApplicationUsers;
        }

        public ApplicationUser GetById(string id)
        {
            return GetAll().FirstOrDefault(
                user => user.Id == id);
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            m_context.Update(user);
            await m_context.SaveChangesAsync();
        }
    }
}
