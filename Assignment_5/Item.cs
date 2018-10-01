using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2
{
    
    public class Item
    {
        public Guid Id { get; set; }

        public string Name {get; set;}

        [Range(1, 99)]
        public int Level {get; set;}

        [ItemTypeAlligator]
        public string Type {get; set;}

        [DateTypeAlligator]
        public DateTime CreationTime {get; set;}
    }
}