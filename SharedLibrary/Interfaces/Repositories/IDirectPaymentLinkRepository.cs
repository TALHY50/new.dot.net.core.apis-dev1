using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interfaces.Repositories
{
    public interface IDirectPaymentLinkRepository : IGenericRepository<DirectPaymentLink>
    {
        public DirectPaymentLink? FindById(int id);
        public DirectPaymentLink? FindActiveDplByToken(string token);
    }
}
