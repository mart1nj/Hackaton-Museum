namespace Open.Facade.Common
{
    public class EntityView: PeriodView
    {
        protected string id;
        public string ID {
            get => getString(ref id);
            set => id = value;
        }
    }
}

