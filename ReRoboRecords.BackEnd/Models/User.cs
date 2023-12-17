using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Postgrest.Attributes;
using Postgrest.Models;

namespace ReRoboRecords.BackEnd.Models;

[Table("users")]
public class User : BaseModel
{
    [PrimaryKey("id", true)]
    public string Id { get; set; }

 
    [Column("name")]
    public string Username { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("bio")]
    public string Bio { get; set; }
    

}