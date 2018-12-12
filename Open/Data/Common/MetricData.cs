
namespace Open.Data.Common {
    public abstract class MetricData : NamedData {
        private string definition;
        public string Definition
        {
            get => getString(ref definition);
            set => definition = value;
        }
    }
}

