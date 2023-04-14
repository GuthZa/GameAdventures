using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();
        public List<MonsterEncounter> MonsterHere { get; set; } = new List<MonsterEncounter>();
        public Trader TraderHere { get; set; }

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if (MonsterHere.Exists(m => m.MonsterID == monsterID))
            {
                //The monster has already been added to the location
                //So we overwrite the ChanceOfEncountering with a new number
                MonsterHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                //This monster is not already at this location
                MonsterHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }
        public Monster GetMonster()
        {
            if(!MonsterHere.Any())
            {
                return null;
            }
            //Total the percentages of all monsters at this location
            int totalChance = MonsterHere.Sum(m => m.ChanceOfEncountering);
            //Select a random number between 1 and the total
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChance);
            //Loop through the monster List
            //Adding the monster's percentage chance of appearing to the runningTotal variable
            //When the random number is lower than the runningTotal
            int runningTotal = 0;
            foreach(MonsterEncounter monsterEncounter in MonsterHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;
                if(randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }
            //if there was a problem, return the last monster in the list
            return MonsterFactory.GetMonster(MonsterHere.Last().MonsterID);
        }
    }
}
