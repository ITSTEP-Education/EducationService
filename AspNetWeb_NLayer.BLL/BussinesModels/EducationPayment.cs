using AspNetWeb_NLayer.BLL.Infrastructure;

namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class EducationPayment
    {
        public ClientPayProperty clientPayProperty { get; } = null!;
        private float percentage = 0f;

        public EducationPayment(ClientPayProperty clientPayProperty)
        {
            this.clientPayProperty = clientPayProperty;
        }

        public float getSumPayment(float sum)
        {
            if (clientPayProperty == null) throw new ProductItemException("absent entity", "none");

            if (clientPayProperty.IsInvitedPerson)
                sum -= DiscountProperty.invitedPerson;

            if (!DiscountProperty.payMethod.TryGetValue(clientPayProperty.PayMethod, out percentage))
                throw new ProductItemException("absent pay method", clientPayProperty.PayMethod);
            sum = sum - sum * percentage;

            if (!DiscountProperty.payPeriod.TryGetValue(clientPayProperty.PayPeriod, out percentage))
                throw new ProductItemException("absent pay pariod", clientPayProperty.PayPeriod);
            sum = sum - sum * percentage;

            return sum;
        }
    }
}
