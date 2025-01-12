﻿namespace School_Management_System.Core.Features.Students.Queries.Results
{
    public class PaginatedStudentsListResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required string Department { get; set; }
    }
}
