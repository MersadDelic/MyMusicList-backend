using System;

namespace MyMusicList.Models

{
public class BaseEntity
{
    public DateTime CreatedTime { get; set; }
    
    public DateTime ModifiedTime { get; set; }
}
}