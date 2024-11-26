using System.Runtime.Serialization;

namespace Currency.UK
{
    public class TwentyPence : UKCoin
    {
        public TwentyPence()
        {
            this.MonetaryValue = .20;
            this.Name = "Twenty Pee";       
        }

        protected TwentyPence(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
