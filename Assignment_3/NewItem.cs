using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2
{
    public class NewItem
    {
        public string Name { get; set; }

        [Range(1, 99)]
        public int Level {get; set;}

        [ItemTypeAlligator]
        public string Type {get; set;}

        [DateTypeAlligator]
        [DataType(DataType.Date)]
        public DateTime CreationDate {get; set;}
        }
    }