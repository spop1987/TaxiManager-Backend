using TaxiManagerDomain.Errors;

namespace TaxiManagerDomain.Shared
{
    public record Currency
    {
        internal static readonly Currency None = new("");
        public static readonly Currency COP = new("COP");

        public Currency(string code) => Code = code;
        public string Code { get; init;}

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ApplicationException, "The currency code is invalid"));
        }

        public static readonly IReadOnlyCollection<Currency> All = [COP];
    }
}