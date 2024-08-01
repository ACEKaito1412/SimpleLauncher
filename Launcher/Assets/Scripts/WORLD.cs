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

        public static int ID_SEED_SUNFLOWER = 10;
        public static int ID_SEED_POTATO = 11;
        public static int ID_SEED_CARROT = 12;
        public static int ID_SEED_PUMPKIN = 13;
        public static int ID_SEED_BEETROOT = 14;
        public static int ID_SEED_CAULIFLOWER = 15;
        public static int ID_SEED_PARSNIP = 16;
        public static int ID_SEED_RADISH = 17;
        public static int ID_SEED_WHEAT = 18;

        public static Item item_seed_sunflower = new Item(ID_SEED_SUNFLOWER, "Sunflower Seed", "You can grow a beautiful sunflower with it.");
        public static Item item_seed_potato = new Item(ID_SEED_POTATO, "Potato Seed", "Plant it to grow potatoes.");
        public static Item item_seed_carrot = new Item(ID_SEED_CARROT, "Carrot Seed", "Plant it to grow carrots.");
        public static Item item_seed_pumpkin = new Item(ID_SEED_PUMPKIN, "Pumpkin Seed", "Plant it to grow pumpkins.");
        public static Item item_seed_beetroot = new Item(ID_SEED_BEETROOT, "Beetroot Seed", "Plant it to grow beetroots.");
        public static Item item_seed_cauliflower = new Item(ID_SEED_CAULIFLOWER, "Cauliflower Seed", "Plant it to grow cauliflowers.");
        public static Item item_seed_parsnip = new Item(ID_SEED_PARSNIP, "Parsnip Seed", "Plant it to grow parsnips.");
        public static Item item_seed_radish = new Item(ID_SEED_RADISH, "Radish Seed", "Plant it to grow radishes.");
        public static Item item_seed_wheat = new Item(ID_SEED_WHEAT, "Wheat Seed", "Plant it to grow wheat.");

        public static int ID_SUNFLOWER = 100;
        public static int ID_POTATO = 101;
        public static int ID_CARROT = 102;
        public static int ID_PUMPKIN = 103;
        public static int ID_BEETROOT = 104;
        public static int ID_CAULIFLOWER = 105;
        public static int ID_PARSNIP = 106;
        public static int ID_RADISH = 107;
        public static int ID_WHEAT = 108;


        public static Item item_sunflower = new Item(ID_SUNFLOWER, "Sunflower", "A beautiful flower, extract to get seeds.");
        public static Item item_potato = new Item(ID_POTATO, "Potato", "Bake it, this would taste good.");
        public static Item item_carrot = new Item(ID_CARROT, "Carrot", "I hear the slime like vegetables.");
        public static Item item_pumpkin = new Item(ID_PUMPKIN, "Pumpkin", "I hear the slime like vegetables.");
        public static Item item_beetroot = new Item(ID_BEETROOT, "Beetroot", "I hear the slime like vegetables.");
        public static Item item_cauliflower = new Item(ID_CAULIFLOWER, "Cauliflower", "I hear the slime like vegetables.");
        public static Item item_parsnip = new Item(ID_PARSNIP, "Parsnip", "I hear the slime like vegetables.");
        public static Item item_radish = new Item(ID_RADISH, "Radish", "I hear the slime like vegetables.");
        public static Item item_wheat = new Item(ID_WHEAT, "WHEAT", "Take's ages to grow, wonder what it is use for.");


        public static Plant Seed_Wheat = new Plant("Wheat", 15_360f, item_wheat, 1);
        public static Plant Seed_Radish = new Plant("Radish", 7_680f, item_radish, 1);
        public static Plant Seed_Parsnip = new Plant("Parsnip", 3_840f, item_parsnip, 1);
        public static Plant Seed_Cauliflower = new Plant("Cauliflower", 1_920f, item_cauliflower, 1);
        public static Plant Seed_Beetroot = new Plant("Beetroot", 960f, item_beetroot, 1);
        public static Plant Seed_Pumpkin = new Plant("Pumpkin", 480f, item_pumpkin, 1);
        public static Plant Seed_Carrot = new Plant("Carrot", 240f, item_carrot, 1);
        public static Plant Seed_Potato = new Plant("Potato", 120f, item_potato, 3);
        public static Plant Seed_SunFlower = new Plant("Sunflower", 60f, item_sunflower, 1);


        public static List<Plant> Plants = new List<Plant>()
        {
            Seed_SunFlower, Seed_Potato, Seed_Carrot, Seed_Pumpkin, Seed_Beetroot, Seed_Cauliflower, Seed_Parsnip, Seed_Radish, Seed_Wheat
        };

        public static void PreparePlants()
        {

        }
    }
}
