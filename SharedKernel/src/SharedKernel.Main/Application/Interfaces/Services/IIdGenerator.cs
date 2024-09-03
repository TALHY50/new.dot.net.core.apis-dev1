using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Application.Interfaces.Services
{
    public interface IIdGenerator 
    {
        public uint GenerateRandomId(uint length);
    }
}
