using DataVance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.ItemSystem.ValueObjects
{
    public class GlobalUnit : Entity
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; } = null!;   // مثال: "كيلوجرام"، "كرتون"
        public string Symbol { get; private set; } = null!; // الرمز الدولي أو المختصر: "Kg", "Ctn", "Pcs"
        public bool IsActive { get; private set; }

        internal GlobalUnit() { }

        public GlobalUnit(Guid categoryId, string name, string symbol)
        {
            Id = Guid.NewGuid();
            CategoryId = categoryId;
            Name = name;
            Symbol = symbol;
            IsActive = true;
        }
    }
}

