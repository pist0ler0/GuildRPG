using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildRPG.Models
{
    public class Monster
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private double health;

		public double Health
		{
			get { return health; }
			set { health = value; }
		}
		
		private byte[] imageData;
        
        public byte[]? ImageData
		{
			get { return imageData; }
			set { imageData = value; }
		}

		private string imageType;
        
        public string? ImageType
		{
			get { return imageType; }
			set { imageType = value; }
		}



		private double damage;

		public double Damage
		{
			get { return damage; }
			set { damage = value; }
		}

        public Monster(string name, double health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public Monster()
        {
        }

        public override string ToString()
        {
			return $"Potwór {name}, zdrowie: {health}, obrażenia: {damage}";
        }
    }
}
