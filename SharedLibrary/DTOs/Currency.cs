using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SharedLibrary.DTOs
{
    

    public class Currency
    {
        public string NAME { get; set; } = String.Empty;
        public string SYMBOL { get; set; } = String.Empty;
        public string CODE { get; set; } = String.Empty;
        public int ISO_CODE { get; set; }
    }
}
