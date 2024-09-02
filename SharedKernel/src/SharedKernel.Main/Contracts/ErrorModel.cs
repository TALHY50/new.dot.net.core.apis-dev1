namespace SharedKernel.Main.Contracts;


    public class ErrorModel
    {
        public StatusEntityModel Status { get; set; }

        public List<StatusEntityModel> Errors { get; set; }
        
        public object Data { get; set; }
    }
