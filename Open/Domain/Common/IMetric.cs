namespace Open.Domain.Common {
    public interface IMetric: IUnique {
        string Name { get; }
        string Symbol { get; }
        string Definition { get; }
        string Formula(bool longFormula = false);
    }
}