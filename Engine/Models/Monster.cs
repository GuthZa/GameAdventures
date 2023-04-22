using Engine.Factories;
using System.Collections.Generic;

namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        private readonly List<ItemPercentage> _lootTable = new List<ItemPercentage>();
        public int ID { get; }
        public string ImageName { get; }
        public int RewardExperiencePoints { get; }
        public Monster(int id, string name, string imageName,
            int maximumHitPoints,
            GameItem currentWeapon,
            int rewardExperiencePoints, int gold)
            : base(name, maximumHitPoints, maximumHitPoints, gold)
        {
            ID = id;
            ImageName = imageName;
            CurrentWeapon = currentWeapon;
            RewardExperiencePoints = rewardExperiencePoints;
        }
        public void AddItemToLootTable(int id, int percentage)
        {
            //Removes the entry if already exists
            _lootTable.RemoveAll(ip => ip.ID == id);
            _lootTable.Add(new ItemPercentage(id, percentage));
        }
        public Monster GetNewInstance()
        {
            //Clones this monster to a new Monster object
            Monster newMonster = new Monster(ID, Name, ImageName, MaximumHitPoints, CurrentWeapon, RewardExperiencePoints, Gold);
            foreach(ItemPercentage itemPercentage in _lootTable)
            {
                //Clone the loot table
                newMonster.AddItemToLootTable(itemPercentage.ID, itemPercentage.Percentage);
                //Populate the inventory
                if(RandomNumberGenerator.NumberBetween(1,100) <= itemPercentage.Percentage)
                {
                    newMonster.AddItemToInventory(ItemFactory.CreateGameItem(itemPercentage.ID));
                }
            }
            return newMonster;
        }
    }
}
