using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyMusicList.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public int IsFavourite { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        
        // FK
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
    
}




