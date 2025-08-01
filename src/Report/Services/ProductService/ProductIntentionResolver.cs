using Report.Services.Authentication;

namespace Report.Services.ProductService
{
    public class ProductIntentionResolver : IIntentionResolver<ProductIntention>
    {
        public bool IsAllowed(IIdentity idnetity, ProductIntention intention) =>

        intention switch
        {
            ProductIntention.Create => idnetity.IsAuthenticated(),
            _=> false
        };
    }
}
