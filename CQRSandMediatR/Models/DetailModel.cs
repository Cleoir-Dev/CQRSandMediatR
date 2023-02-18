namespace CQRSandMediatR.Model
{
    public class DetailModel
    {
        public DetailModel(bool status, string jsonContext)
        {
            Id = Guid.NewGuid();
            Status = status;
            JsonContext = jsonContext;
        }

        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string JsonContext { get; set; }
    }
}
