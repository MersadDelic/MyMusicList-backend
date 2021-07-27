using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyMusicList.Models
{
    public class Category: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Song> Songs { get; set;}
    }
}


