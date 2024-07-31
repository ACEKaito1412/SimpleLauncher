using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class WORLD
    {
        public static int PA_NEEDS_PREPARATION = 0;
        public static int PA_PLANTABLE = 1;
        public static int PA_PLANTED = 2;

        public static int PLANT_NOT_RIPE = 0;
        public static int PLANT_IS_RIPE = 1;
        public static int PLANT_GROWING = 2;

        public static Plant Seed_Wheat = new Plant("Wheat", 15_360f);
        public static Plant Seed_Radish = new Plant("Radish", 7_680f);
        public static Plant Seed_Parsnip = new Plant("Parsnip", 3_840f);
        public static Plant Seed_Cauliflower = new Plant("Cauliflower", 1_920f);
        public static Plant Seed_Beetroot = new Plant("Beetroot", 960f);
        public static Plant Seed_Pumpkin = new Plant("Pumpkin", 480f);
        public static Plant Seed_Carrot = new Plant("Carrot", 240f);
        public static Plant Seed_Potato = new Plant("Potato", 120f);
        public static Plant Seed_SunFlower = new Plant("Sunflower", 60f);

        public static List<Plant> Plants = new List<Plant>()
        {
            Seed_SunFlower, Seed_Potato, Seed_Carrot, Seed_Pumpkin, Seed_Beetroot, Seed_Cauliflower, Seed_Parsnip, Seed_Radish, Seed_Wheat
        };

        public static void PreparePlants()
        {

        }
    }
}
