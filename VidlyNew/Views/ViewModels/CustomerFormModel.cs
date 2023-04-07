using Vidli.Models;

namespace Vidli.ViewModels
{
    public class CustomerFormModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
