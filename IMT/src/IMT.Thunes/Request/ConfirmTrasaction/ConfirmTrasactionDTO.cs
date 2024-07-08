using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.ConfirmTrasaction
{
    public class ConfirmTrasactionDTO
    {
        public int TrasactionId { get; set; }
        public int ProviderId { get; set; }
        public sbyte Type { get; set; }
    }
}
