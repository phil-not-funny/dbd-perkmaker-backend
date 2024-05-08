using perkmaker_backend.Models;

namespace perkmaker_backend.Dtos
{
    public record SurvivorCreateDto (string Name, string Description, string Image, List<Perk> Perks, string Header);
}
