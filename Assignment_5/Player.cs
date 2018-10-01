using System;
using System.Collections.Generic;

namespace Assignment_2
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Score { get; set; }
        public bool IsBanned { get; set; }
        public int Level { get; set; }
        public DateTime CreationTime { get; set; }
        public List <Item> items { get; set; }
    }
}