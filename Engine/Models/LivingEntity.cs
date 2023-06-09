﻿using System;
using System.Collections.Generic;
using Engine.Services;

namespace Engine.Models
{
    public abstract class LivingEntity : BaseNotificationClass
    {
        //Region Properties
        private string _name;
        private int _currentHitPoints;
        private int _maximumHitPoints;
        private int _gold;
        private int _level;
        private GameItem _currentWeapon;
        private GameItem _currentConsumable;
        private Inventory _inventory;
        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public int Level
        {
            get { return _level; }
            protected set
            {
                _level = value;
                OnPropertyChanged();
            }
        }
        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            private set
            {
                _currentHitPoints = value;
                OnPropertyChanged();
            }
        }
        public int MaximumHitPoints
        {
            get { return _maximumHitPoints; }
            protected set
            {
                _maximumHitPoints = value;
                OnPropertyChanged();
            }
        }
        public int Gold
        {
            get { return _gold; }
            private set
            {
                _gold = value;
                OnPropertyChanged();
            }
        }
        public GameItem CurrentWeapon
        {
            get => _currentWeapon; 
            set
            {
                if(_currentWeapon != null)
                {
                    _currentWeapon.Action.OnActionPerformed -= RaiseOnActionPerformedEvent;
                }
                _currentWeapon = value;
                if(_currentWeapon != null)
                {
                    _currentWeapon.Action.OnActionPerformed += RaiseOnActionPerformedEvent;
                }
                OnPropertyChanged();
            }
        }
        public GameItem CurrentConsumable
        {
            get => _currentConsumable;
            set
            {
                if(_currentConsumable != null)
                {
                    _currentConsumable.Action.OnActionPerformed -= RaiseOnActionPerformedEvent;
                }
                _currentConsumable = value;
                if(_currentConsumable != null)
                {
                    _currentConsumable.Action.OnActionPerformed += RaiseOnActionPerformedEvent;
                }
                OnPropertyChanged();
            }
        }
        public Inventory Inventory
        {
            get => _inventory;
            private set
            {
                _inventory = value;
                OnPropertyChanged();
            }
        }
        public bool IsDead => CurrentHitPoints <= 0;
        //End region Properties

        public event EventHandler<string> OnActionPerformed;
        public event EventHandler OnKilled;
        protected LivingEntity(string name, int maximumHitPoints, int currentHitPoints, int gold, int level = 1)
        {
            Name = name;
            Level = level;
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = currentHitPoints;
            Gold = gold;
            Inventory = new Inventory();
        }

        public void UseCurrentWeaponOn(LivingEntity target)
        {
            CurrentWeapon.PerformAction(this, target);
        }
        public void UseCurrentConsumable()
        {
            //TODO not allow the player to heal above full HP
            CurrentConsumable.PerformAction(this, this);
            RemoveItemFromInventory(CurrentConsumable);
        }
        public void TakeDamage(int hitPointsOfDamage)
        {
            CurrentHitPoints -= hitPointsOfDamage;
            if(IsDead)
            {
                CurrentHitPoints = 0;
                RaiseOnKilledEvent();
            }
        }
        public void Heal(int hitPointsToHeal)
        {
            CurrentHitPoints += hitPointsToHeal;
            if (CurrentHitPoints > MaximumHitPoints)
            {
                CurrentHitPoints = MaximumHitPoints;
            }
        }
        public void CompletlyHeal()
        {
            CurrentHitPoints = MaximumHitPoints;
        }
        public void ReceiveGold(int amountOfGold)
        {
            Gold += amountOfGold;
        }
        public void SpendGold(int amountOfGold)
        {
            if(amountOfGold > Gold)
            {
                throw new ArgumentOutOfRangeException($"{Name} only has {Gold} gold, and cannot spend {amountOfGold} gold.");
            }
            Gold -= amountOfGold;
        }
        public void AddItemToInventory(GameItem item)
        {
            Inventory = Inventory.AddItem(item);
        }
        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory = Inventory.RemoveItem(item);
        }
        public void RemoveItemsFromInventory(List<ItemQuantity> itemQuantities)
        {
            Inventory = Inventory.RemoveItems(itemQuantities);
        }

        //Region Private functions
        private void RaiseOnKilledEvent()
        {
            OnKilled?.Invoke(this, new System.EventArgs());
        }
        private void RaiseOnActionPerformedEvent(object sender, string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
        //End Region private functions
    }
}
