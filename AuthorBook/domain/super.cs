using System;
using System.Text.Json.Serialization;

namespace AuthorBook.domain
{
    public class super
    {
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime DeletedAt { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
}
