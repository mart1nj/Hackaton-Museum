using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class Metric<T> : NamedEntity<T>, IMetric
        where T : MetricData, new() {
        protected Metric(T dbRecord) : base(dbRecord) { }
        public string ID => Data.ID;
        public string Name => Data.Name;
        public string Symbol => Data.Code;
        public string Definition => Data.Definition;

        public virtual string Formula(bool longFormula = false) {
            return longFormula ? Name : Symbol;
        }

        public static bool IsFormula(string s) {
            return !isNull(s) && s.Contains("^");
        }
        public virtual bool IsSameFormula(IMetric m) {
            if (isNull(m)) return false;
            var f1 = Formula(true);
            var f2 = m.Formula(true);
            return f1 == f2;
        }
        public virtual bool IsThis(string id) {
            if (isSpaces(id)) return false;
            if (ID == id) return true;
            if (Name == id) return true;
            if (Symbol == id) return true;
            if (!IsFormula(id)) return false;
            if (Formula() == id) return true;
            return Formula(true) == id;
        }
    }
}


