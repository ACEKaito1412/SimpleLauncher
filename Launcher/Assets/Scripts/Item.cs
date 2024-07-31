using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(int id, string name, string description = "") {
            ID = id;
            Name = name;
            Description = description;
        }

    }
}
