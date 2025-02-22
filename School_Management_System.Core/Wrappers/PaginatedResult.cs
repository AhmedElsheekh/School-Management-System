﻿namespace School_Management_System.Core.Wrappers
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(List<T> data, int count, int pageNumber, int pageSize, bool isSuccess = true,
            string? message = null)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            IsSuccess = isSuccess;
            Message = message;
        }

        public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
