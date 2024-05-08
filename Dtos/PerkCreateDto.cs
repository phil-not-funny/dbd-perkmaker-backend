using perkmaker_backend.Models;

namespace perkamker_backend.Dtos
{
    public record PerkCreateDto (string Header, List<Perk> Perks);
}
