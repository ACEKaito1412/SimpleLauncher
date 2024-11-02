using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.WORLD;

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


        public enum Item_TYPE
        {
           PLANT,
           SEED,
           TOOL
        }
        public enum Item_ID {
        SEED_SUNFLOWER,
        SEED_POTATO,
        SEED_CARROT,
        SEED_PUMPKIN ,
        SEED_BEETROOT ,
        SEED_CAULIFLOWER,
        SEED_PARSNIP, 
        SEED_RADISH,
        SEED_WHEAT,
        SUNFLOWER,
        POTATO,
        CARROT,
        PUMPKIN,
        BEETROOT,
        CAULIFLOWER,
        PARSNIP,
        RADISH,
        WHEAT
        }


    }
}
