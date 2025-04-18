using UnityEngine;

namespace Platformer397
{
    
    public abstract class ItemBase : ScriptableObject
    {
        public enum ItemType
        {
            Coin,
        }

        public ItemType itemType;
        public string itemName = "";
    }
}
