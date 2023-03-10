namespace VirtualEducation.DDD.Domain.Student.ValueObjects.Account
{
    public record AccountID
    {
        //variables
        public Guid Value { get; init; }
        //constructor
        internal AccountID(Guid id)
        {
            Value = id;
        }
        //create method
        public static AccountID Create(Guid id)
        {
            return new AccountID(id);
        }
        //implicit assignment
        public static implicit operator Guid(AccountID accountID)
        {
            return accountID.Value;
        }
    }
}
