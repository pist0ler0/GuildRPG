using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildRPG.Data;
using GuildRPG.Exceptions;
using GuildRPG.Models;
using Microsoft.EntityFrameworkCore;

namespace GuildRPG.Services
{
    public class GuildService
    {
        private readonly IServiceScopeFactory _scopeFactory;
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
        public GuildService(IServiceScopeFactory scopeFactory)
        {
            mercenaries = new List<Mercenary>();
            quests = new List<Quest>();
            _scopeFactory = scopeFactory;
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
            
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GuildRPGContext>();
                var m = _context.Mercenary.FirstOrDefault(x => x.Name.Equals(mercenaryName));
                var q = _context.Quest
                    .Include(q => q.Enemy)
                    .FirstOrDefault(q => q.Name == questName);
                var eMaxHealth = q.Enemy.Health;
                if (m != null && q != null)
                {
                    OnQuestCompleting?.Invoke(m, q);
                    while (m.CurrentHealth > 0 && q.Enemy.Health > 0)
                    {
                        q.Enemy.Health -= m.Damage;
                        if (q.Enemy.Health > 0) m.CurrentHealth -= q.Enemy.Damage;
                        Console.WriteLine("Nowe HP: " + m.CurrentHealth);
                    }
                    OnQuestCompleted?.Invoke(m, q);
                    Console.WriteLine($"Zmiany do zapisu {_context.ChangeTracker.HasChanges()}");
                    _context.Entry(m).State = EntityState.Modified;
                    q.Enemy.Health = eMaxHealth;
                    _context.SaveChanges();
                    var updated = _context.Mercenary.FirstOrDefault(x => x.Name == m.Name);
                    var idx = mercenaries.FindIndex(x => x.Id == updated.Id);
                    if (idx != -1)
                    {
                        mercenaries[idx] = updated;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
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
