using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildRPG.Exceptions;
using GuildRPG.Models;

namespace GuildRPG.Services
{
    public class Guild
    {
        private List<Mercenary> mercenaries;

        public List<Mercenary> Mercenaries
        {
            get { return mercenaries; }
            set { mercenaries = value; }
        }

        private List<Quest> quests;

        public List<Quest> Quests
        {
            get { return quests; }
            set { quests = value; }
        }
        public Guild()
        {
            mercenaries = new List<Mercenary>();
            quests = new List<Quest>();
        }

        public void addMercenary(Mercenary mercenary)
        {
            foreach (var item in mercenaries)
            {
                try
                {
                    if (item.Name == mercenary.Name) throw new NonUniqueNameException();
                }
                catch (NonUniqueNameException e)
                {
                    Console.WriteLine(e);
                }
               
            }
            mercenaries.Add(mercenary);
            OnMercenaryHired?.Invoke(mercenary);
        }

        public event doSomethingWithMercenary OnMercenaryHired;

        public void addQuest(Quest quest)
        {
            foreach (var item in quests)
            {
                if (item.Name == quest.Name) throw new NonUniqueNameException();
            }
            quests.Add(quest);
            OnQuestAdded?.Invoke(quest);
        }

        public event doSomethingWithQuest OnQuestAdded;

        public event doSomethingWithMercenaryAndQuest OnQuestCompleting;
        public event doSomethingWithMercenaryAndQuest OnQuestCompleted;
        public void sendMercenaryToQuest(string mercenaryName, string questName)
        {
            Mercenary m = mercenaries.Find(x => x.Name.Equals(mercenaryName));
            Quest q = quests.Find(x => x.Name.Equals(questName));
            
            if (m != null && q != null)
            {
                OnQuestCompleting?.Invoke(m, q);
                while (m.CurrentHealth > 0 && q.Enemy.Health > 0)
                {
                    q.Enemy.Health -= m.Damage;
                    if (q.Enemy.Health > 0) m.CurrentHealth -= q.Enemy.Damage;

                }
                OnQuestCompleted?.Invoke(m, q);

            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            

        }
        

        public delegate void doSomethingWithMercenary(Mercenary m);

        public delegate void doSomethingWithQuest(Quest q);

        public delegate void doSomethingWithMercenaryAndQuest(Mercenary m, Quest q);

        public void doSomethingWithAllMercenaries(doSomethingWithMercenary action)
        {
            foreach (Mercenary m in mercenaries)
            {
                action(m);
            }
        }

        public void doSomethingWithAllQuests(doSomethingWithQuest action)
        {
            foreach(Quest q in quests)
            {
                action(q);
            }
        }

        public Mercenary findMercenary(Predicate<Mercenary> predicate)
        {
            return mercenaries.Find(predicate);
        }

        public Quest findQuest(Predicate<Quest> predicate)
        {
            return quests.Find(predicate);
        }

        public List<Mercenary> findAllMercenaries(Predicate<Mercenary> predicate)
        { 
            return mercenaries.FindAll(predicate);
        }

        public List<Quest> findAllQuests(Predicate<Quest> predicate)
        {
            return quests.FindAll(predicate);
        }
    }
}
