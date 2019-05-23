using WebMerchant.InternetAcquiring.Enums;
using WebMerchant.InternetAcquiring.Objects.Settings;

namespace WebMerchant.InternetAcquiring.Contracts.Settings
{
    public interface ISettingsManager
    {
        AcquirerSettings GetAcquirerSettings(AcquiringType acquiringType);
    }
}