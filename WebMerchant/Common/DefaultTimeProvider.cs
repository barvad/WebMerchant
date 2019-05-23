namespace WebMerchant.Common
{
    internal class DefaultTimeProvider : TimeProvider
    {
        public override System.DateTime UtcNow => System.DateTime.UtcNow;
        public override System.DateTime Now => System.DateTime.Now;
    }
}