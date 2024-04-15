﻿using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public class DplAgreementRepository : GenericRepository<DplAgreement>, IDplAgreementRepository
    {
        public DplAgreementRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}