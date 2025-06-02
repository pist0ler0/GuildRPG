using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildRPG.Models
{
    public class Quest
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

		private string description;

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		private string location;

		public string Location
		{
			get { return location; }
			set { location = value; }
		}

		private Difficulty diff;

		public Difficulty Diff
		{
			get { return diff; }
			set { diff = value; }
		}

		private int enemyId;

		public int EnemyId
		{
			get { return enemyId; }
			set { enemyId = value; }
		}


		private Monster enemy;

		[ValidateNever]
		public Monster Enemy
		{
			get { return enemy; }
			set { enemy = value; }
		}

		private double rewardXP;

		public double RewardXP
		{
			get { return rewardXP; }
			set { rewardXP = value; }
		}
		private double rewardMoney;

		public double RewardMoney
		{
			get { return rewardMoney; }
			set { rewardMoney = value; }
		}



		public Quest(string name, string description, string location, Difficulty diff, Monster enemy, double xpR, double moneyR)
        {
            this.name = name;
            this.description = description;
            this.location = location;
            this.diff = diff;
            this.enemy = enemy;
			this.rewardXP = xpR;
			this.rewardMoney = moneyR;
        }

        public Quest()
        {
        }
    }
}
