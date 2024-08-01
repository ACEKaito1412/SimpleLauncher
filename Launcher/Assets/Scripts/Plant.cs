using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Plant
    {
        public string Type { get; set; }
        public int Status { get; set; }
        public float TimeToRipe { get; set; }

        public Item ItemToGet { get; set; }

        public int ItemQuantity { get; set; }

        public Plant(string type, float timeToRipe, Item itemToGet, int quantity = 1)
        {
            Type = type;
            TimeToRipe = timeToRipe;
            Status = WORLD.PLANT_NOT_RIPE;
            ItemToGet = itemToGet;
            ItemQuantity = quantity;
        }
    }
}
