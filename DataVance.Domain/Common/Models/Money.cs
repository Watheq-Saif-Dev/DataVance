using System;
using System.Collections.Generic;

namespace DataVance.Domain.Common.Models
{
    public class Money : ValueObject
    {
        public decimal Amount { get; private set; }
        public Guid CurrencyId { get; private set; }

        private Money() { } // لـ EF Core

        public Money(decimal amount, Guid currencyId)
        {
            // تطبيق المنطق الذهبي: التقريب لـ 4 خانات عشرية عند الإنشاء
            Amount = Math.Round(amount, 4, MidpointRounding.AwayFromZero);
            CurrencyId = currencyId;
        }

        public static Money Zero(Guid currencyId) => new Money(0, currencyId);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return CurrencyId;
        }

        // العمليات الحسابية
        public static Money operator +(Money left, Money right)
        {
            if (left.CurrencyId != right.CurrencyId)
                throw new InvalidOperationException("Cannot add money with different currencies.");

            return new Money(left.Amount + right.Amount, left.CurrencyId);
        }

        public static Money operator -(Money left, Money right)
        {
            if (left.CurrencyId != right.CurrencyId)
                throw new InvalidOperationException("Cannot subtract money with different currencies.");

            return new Money(left.Amount - right.Amount, left.CurrencyId);
        }

        public static Money operator *(Money left, decimal multiplier)
        {
            return new Money(left.Amount * multiplier, left.CurrencyId);
        }

        public override string ToString() => $"{Amount:F4}";
    }
}
