﻿namespace WebAPI.Models
{
    public partial class Todo
    {
        public Guid TodoId { get; set; }
        public string? Name { get; set; }
        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool Enable { get; set; }
        public int? Orders { get; set; }
        public string? InsertEmployeeName { get; set; }
        public string? UpdateEmployeeName { get; set; }
        public string? UploadFiles { get; set; }
    }
}
