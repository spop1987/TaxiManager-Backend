using TaxiManagerDomain.Errors;

namespace TaxiManagerDomain.Shared
{
    public record Money
    {
        public decimal Amount { get; init; }
        public Currency Currency { get; init; }

        public Money() : this(0, Currency.None) {}

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money a, Money b)
        {
            if(a.Currency != b.Currency) throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ApplicationException, "Currencies have to be equal"));

            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money Zero() => new(0, Currency.COP);
        public static Money Zero(Currency currency) => new(0, currency);
        public bool IsZero() => this == Zero(Currency);
    }
}