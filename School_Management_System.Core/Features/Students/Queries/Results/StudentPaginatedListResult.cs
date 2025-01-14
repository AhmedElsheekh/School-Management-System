namespace School_Management_System.Core.Features.Students.Queries.Results
{
    public class StudentPaginatedListResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public StudentPaginatedListResult(int id, string name, string address, string phone, string department)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Department = department;
        }
    }
}
