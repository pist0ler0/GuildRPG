using GuildRPG.Models;

namespace GuildRPG.ViewModels
{
    public class MercPageViewModel
    {
        
        public List<Mercenary> Mercenaries { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public string? CurrentSort { get; set; }
    }
}
