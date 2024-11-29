using BestGuide.Modules.Domain.Models;

namespace BestGuide.Modules.Domain.Args.HotelArgs
{
    public partial class CreateHotelArgs
    {
        public string AuthorizedName { get; set; }
        public string AuthorizedSurname { get; set; }
        public string Title { get; set; }
        public HashSet<ContactArgsOfHotel>? Contacts { get; set; }

        internal Hotel New()
        {
            var entity = new Hotel
            {
                Title = Title,
                AuthorizedName = AuthorizedName,
                AuthorizedSurname = AuthorizedSurname,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "principal.Email",
                Contacts = []
            };
            if (Contacts != null)
            {
                AddContacts(entity);
            }
            return entity;
        }

        private void AddContacts(Hotel parent)
        {
            foreach (var args in Contacts)
            {
                var item = args.New(parent);
                parent.Contacts.Add(item);
            }
        }
    }
}
