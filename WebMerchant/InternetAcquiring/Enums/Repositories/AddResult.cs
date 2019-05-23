using System;

namespace WebMerchant.InternetAcquiring.Enums.Repositories
{
    [Flags]
    public enum AddResult
    {
        Ok = 0,
        UnknownError = 1,
        AlreadyExists = 1 << 1,
        IncorrectObject = 1 << 2
    }
}