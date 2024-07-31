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

        public Plant(string type, float timeToRipe)
        {
            Type = type;
            TimeToRipe = timeToRipe;
            Status = WORLD.PLANT_NOT_RIPE;
        }
    }
}
