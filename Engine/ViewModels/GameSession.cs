using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public Locations CurrentLocation { get; set; }
        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Dhapius";
            CurrentPlayer.CharacterClass = "Enchanter";
            CurrentPlayer.Gold = 100000;
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            CurrentLocation = new Locations();
            CurrentLocation.Name = "Home";
            CurrentLocation.XCoordinate = 0;
            CurrentLocation.YCoordinate = -1;
            CurrentLocation.Description = "This is your home";
            CurrentLocation.ImageName = "/Engine;component/Images/Locations/Home.png";
        }
    }
}
