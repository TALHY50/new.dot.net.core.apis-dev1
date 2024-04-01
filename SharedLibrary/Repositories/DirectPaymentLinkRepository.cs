using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public class DirectPaymentLinkRepository : GenericRepository<DirectPaymentLink>, IDirectPaymentLinkRepository
    {
        public DirectPaymentLinkRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public DirectPaymentLink? FindActiveDplByToken(string token)
        {
            return UnitOfWork.ApplicationDbContext.DirectPaymentLinks
            .Where(dpl => dpl.Token == token)
            .Where(dpl => dpl.Status == DirectPaymentLink.ACTIVE || dpl.Status == DirectPaymentLink.USED)
            .FirstOrDefault();
            
        }

        public DirectPaymentLink? FindById(int id)
        {
            return UnitOfWork.ApplicationDbContext.DirectPaymentLinks.Where(dpl => dpl.Id == id).FirstOrDefault();
        }
    }
}
