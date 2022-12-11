using Entites = Domain.Entities;
using Domain.Enums;


namespace Application.Guest.DTO
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string Email { get; set; }
        public int IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Entites.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Entites.Guest
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                SubName = guestDTO.Subname,
                Email = guestDTO.Email,
                DocumentId = new Domain.ValueObjects.PersonId
                {
                    IdNumber = guestDTO.IdNumber,
                    DocumentType = (DocumentType)guestDTO.IdTypeCode
                }
            };
        }
    }
}
