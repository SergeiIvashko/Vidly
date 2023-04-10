using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class CustomerFormModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
