namespace BroadcasterMicroservice.Domain.Entity.Exceptions
{
    public class DoubleAddresseeException(DiaryAddressee addressee, AddressGroup group) : InvalidOperationException($"{addressee.Name} has been enrolled yo group {group.GroupName} yet")
    {
        public DiaryAddressee Addressee => addressee;
        public AddressGroup Group => group;
    }
}
