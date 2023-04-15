﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class TraderFactory
    {
        private static readonly List<Trader> _traders = new List<Trader>();
        static TraderFactory()
        {
            Trader susan = new Trader("Susan");
            susan.AddItemToInventory(ItemFactory.CreateGameItem(1101));
            Trader farmerTed = new Trader("Farmer Ted");
            farmerTed.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            Trader peteTheHearbalist = new Trader("Pete the Herbalist");
            peteTheHearbalist.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            AddTraderToList(susan);
            AddTraderToList(farmerTed);
            AddTraderToList(peteTheHearbalist);
        }

        public static Trader GetTraderByName(string name)
        {
            return _traders.FirstOrDefault(t => t.Name == name);
        }
        public static void AddTraderToList(Trader trader)
        {
            if(_traders.Any(t => t.Name == trader.Name))
            {
                throw new ArgumentException($"There is already a trader name '{trader.Name}'.");
            }
            _traders.Add(trader);
        }
    }
}