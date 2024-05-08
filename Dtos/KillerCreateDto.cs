using perkmaker_backend.Models;

namespace perkamker_backend.Dtos
{
    public record KillerCreateDto (string Name, string Description, string Image, KillerPower KillerPower, List<Perk> Perks, string Header);
}
