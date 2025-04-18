using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Platformer397
{
    public class Inventory
    {
        public bool HasSword = false;
        public bool HasKey = false;

        public List<ItemBase> items;


        public Inventory()
        {
            items = new List<ItemBase>();
            Debug.Log("Create inventory");
        }

        public void Add(ItemBase item)
        {
            items.Add(item);
        }


        public void Remove(ItemBase item)
        {
            items.Remove(item);
        }

    }
}
