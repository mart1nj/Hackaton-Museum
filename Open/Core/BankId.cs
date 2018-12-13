using Open.Aids;

namespace Open.Core {
    public static class BankId {
        private const string _prefix = "EE";
        private const decimal _min = 000000000000000000;
        private const decimal _max = 999999999999999999;

        private static decimal getDecimal() {
            return GetRandom.Decimal(_min, _max);
        }

        public static string NewBankId() {
            return _prefix + getDecimal();
        }
    }
}
