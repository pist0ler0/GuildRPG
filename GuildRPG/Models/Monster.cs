using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5Library
{
    public class Monster
    {
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
