using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyMusicList.Models
{
    public class Song: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public int IsFavourite { get; set; }
        
        // FK
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
    
}




