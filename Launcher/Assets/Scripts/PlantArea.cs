using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlantArea
    {
        public int Status { get; set; }

        public PlantPrep Plant { get; set; }

        public GameObject PlantObjectReference { get; set; }

        public PlantArea() {
            Status = WORLD.PA_NEEDS_PREPARATION;
        }


    }
}
