﻿using perkmaker_backend.Models;

namespace perkmaker_backend.Dtos
{
    public record PerkCreateDto (string Header, List<Perk> Perks);
}
