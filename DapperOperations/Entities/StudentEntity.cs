namespace DapperOperations.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? FamilyName { get; set; }

        public string? Address { get; set; }

        public long ContactNumber { get; set; }

        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
