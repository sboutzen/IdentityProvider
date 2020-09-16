namespace IdentityProviderCore.Entities
{
    public class Email : BaseEntity
    {
        public string EmailAddress { get; set; }
        public bool IsVerified { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
