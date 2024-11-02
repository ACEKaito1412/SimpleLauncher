using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class InventoryItem
    {
        public Item_Scriptable Details;

        public int Quantity { get; set; }

        public InventoryItem(Item_Scriptable details, int quantity) {
            Details = details;
            Quantity = quantity;

        }

    }
}
