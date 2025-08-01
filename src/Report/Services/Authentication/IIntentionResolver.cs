namespace Report.Services.Authentication
{
    public interface IIntentionResolver
    {
    }
    public interface IIntentionResolver<in TIntention>:IIntentionResolver where TIntention : struct
    {
        bool IsAllowed(IIdentity idnetity, TIntention intention);
    }
}
