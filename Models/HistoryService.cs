using System;
using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class SearchHistory
    {
        [Key]
        public int Id { get; set; }

        public string Query { get; set; }

        public string GifUrl { get; set; }

        public string Fact { get; set; }

        public int Length { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
