using DataVance.Domain.Common;

namespace DataVance.Domain.Entities.TaxSystem
{

    public class TaxCode : BaseEntity
    {

        //public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public bool IsRecoverable { get; private set; }

        public Guid TaxAuthorityId { get; private set; }
        public Guid TaxTypeId { get; private set; }

        private readonly List<TaxRate> _taxRates = new();
        public IReadOnlyCollection<TaxRate> TaxRates => _taxRates.AsReadOnly();

        private readonly List<BranchTaxSetting> _branchSettings = new();
        public IReadOnlyCollection<BranchTaxSetting> BranchSettings => _branchSettings.AsReadOnly();


        protected TaxCode() { }

        public TaxCode(string code, string name, bool isRecoverable, Guid taxAuthorityId, Guid taxTypeId)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IsRecoverable = isRecoverable;
            TaxAuthorityId = taxAuthorityId;
            TaxTypeId = taxTypeId;
        }

        public void UpdateDetails(string name, bool isRecoverable)
        {
            Name = name;
            IsRecoverable = isRecoverable;
        }

        //public void AddRate(TaxRate rate)
        //{

        //    _taxRates.Add(rate);
        //}

        public void SetBranchConfiguration(Guid branchId, string? taxNumber = null)
        {
            var existing = _branchSettings.FirstOrDefault(x => x.BranchId == branchId);
            if (existing != null)
            {
                _branchSettings.Remove(existing);
            }

            _branchSettings.Add(new BranchTaxSetting(branchId, Id, taxNumber));

        }
        public void AddNewRate(decimal percentage, DateTime validFrom)
        {
            // 1. البحث عن النسبة الحالية التي ليس لها تاريخ انتهاء
            var currentRate = _taxRates.FirstOrDefault(r => r.ValidTo == null);

            if (currentRate != null)
            {
                // 2. إنهاء النسبة القديمة (تنتهي قبل ثانية واحدة من بدء الجديدة)
                currentRate.Expire(validFrom.AddSeconds(-1));
            }

            // 3. إضافة النسبة الجديدة
            _taxRates.Add(new TaxRate(percentage, validFrom));
        }
        public decimal GetRateForDate(DateTime date)
        {
            var rate = _taxRates.FirstOrDefault(r => r.IsActiveAt(date));
            return rate?.Percentage ?? 0m;
        }
    }
}
