namespace CQRSandMediatR.Model
{
    public class DetailModel
    {
        public DetailModel(string jsonContext)
        {
            Id = Guid.NewGuid();
            Status = true;
            JsonContext = jsonContext;
        }

        public Guid Id { get; set; }
        public bool Status { get; set; }
        public string JsonContext { get; set; }
    }
}
