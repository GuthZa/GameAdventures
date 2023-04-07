using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public Weapon(string name, int itemTypeID, int price, int minimumDamage, int maximumDamage) : base(name, itemTypeID, price)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
        public Weapon Clone()
        {
            return new Weapon(Name, ItemTypeID, Price, MinimumDamage, MaximumDamage);
        }
    }
}
