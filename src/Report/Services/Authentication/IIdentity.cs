namespace Report.Services.Authentication
{
    public interface IIdentity
    {
        Guid UserId { get; }
    }

    public static class IdentityExtentions
    {
        public static bool IsAuthenticated(this IIdentity identity) => 
            identity.UserId != Guid.Empty;
    }
}
