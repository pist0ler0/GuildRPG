using GuildRPG.Models;

namespace GuildRPG.ViewModels
{
    public class MercQuestViewModel
    {
        public string MercName { get; set; }
        public string QuestName {  get; set; }
        public List<Mercenary> Mercenaries { get; set; }
        public List<Quest> Quests { get; set; }
    }
}
