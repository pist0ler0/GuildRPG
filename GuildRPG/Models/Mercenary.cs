namespace GuildRPG.Models
{
    public class Mercenary
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int level;

		public int Level
		{
			get { return level; }
			set { level = value; }
		}

		private double experiencePoints;

		public double ExperiencePoints
		{
			get { return experiencePoints; }
			set { experiencePoints = value; }
		}
		private double maxHealth;

		public double MaxHealth
		{
			get { return maxHealth; }
			set { maxHealth = value; }
		}

		private double currentHealth;

		public double CurrentHealth
		{
			get { return currentHealth; }
			set { currentHealth = value; }
		}
		private double damage;

		public double Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		private double gold;

		public double Gold
		{
			get { return gold; }
			set { gold = value; }
		}

        public Mercenary(string name, int level, double experiencePoints, double maxHealth, double currentHealth, double damage, double gold)
        {
            this.name = name;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
            this.damage = damage;
            this.gold = gold;
        }

        public Mercenary()
        {
        }

        public override string ToString()
        {
			return $"Najemnik {name}, Poziom: {level}, Punkty doświadczenia: {experiencePoints}, Maksymalne zdrowie; {MaxHealth}, Obecne zdrowie: {currentHealth}, Pieniążki: {gold}";
        }
    }
}
