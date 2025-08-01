namespace Report.Services.Authentication
{
    public interface IIntentionManager
    {
        bool IsAllowed<TIntention>(TIntention intention) where TIntention : struct;

        bool IsAllowed<TIntention, TObject>(TIntention intention, TObject target) where TIntention : struct;
    }

    public static class IntentionManagerExtentions
    {
        public static void ThrowIfForbidder<TIntention>(this IIntentionManager intentionManager, TIntention intention)
            where TIntention:struct
        {
            if(!intentionManager.IsAllowed(intention))
            {
                throw new Exception("Intention not allowed"); 
            }
        }
    }
}
