using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameItem
    {
        public string Name { get; set; }
        public int ItemTypeID { get; set; }
        public int Price { get; set; }
        public GameItem(string name, int itemTypeID, int price)
        {
            Name = name;
            ItemTypeID = itemTypeID;
            Price = price;
        }
        public GameItem Clone()
        {
            return new GameItem(Name, ItemTypeID, Price);
        }
    }
}
