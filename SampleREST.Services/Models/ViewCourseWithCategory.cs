﻿namespace SampleREST.Services.Models
{
    public class ViewCourseWithCategory
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageName { get; set; }
        public double Duration { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
