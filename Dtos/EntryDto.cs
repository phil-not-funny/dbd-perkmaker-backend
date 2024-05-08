using perkmaker_backend.Models;

namespace perkmaker_backend.Dtos
{
    public record EntryDto(string Header, Guid Guid, UserDto User);
}
