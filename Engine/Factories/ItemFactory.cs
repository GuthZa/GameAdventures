using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;
        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();
            _standardGameItems.Add(new Weapon("Pointy Stick", 1001, 1, 1, 2));
            _standardGameItems.Add(new Weapon("Rusty Sword", 1002, 5, 1, 3));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);
            if (standardItem == null)
            {
                return standardItem.Clone();
            }
            return null;
        }
    }
}
