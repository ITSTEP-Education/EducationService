using AspNetWeb_NLayer.BLL.Infrastructure;
using Microsoft.Extensions.Logging;

namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class EducationPayment
    {
        public ClientPayProperty? clientPayProperty { get; }
        private float percentage = 0f;
        private ILogger logger;

        public EducationPayment(ClientPayProperty clientPayProperty, ILogger logger)
        {
            this.clientPayProperty = clientPayProperty;
            this.logger = logger;
        }

        public float getSumPayment(float sum)
        {
            if (clientPayProperty == null) {
                logger.LogError(3002, "BLL: ClientPayProperty failed getSumPayment({Sum}), with PayProperty = {PayProperty}", sum, clientPayProperty is null? "null" : clientPayProperty);
                throw new ProductItemException(3002, "absent entity", "none");
            }
            

            if (clientPayProperty.IsInvitedPerson)
                sum -= DiscountProperty.invitedPerson;

            if (!DiscountProperty.payMethod.TryGetValue(clientPayProperty.PayMethod, out percentage)){
                logger.LogError(3003, "BLL: ClientPayProperty failed getSumPayment({Sum}), with PayMethod = {PayMethod}", sum, clientPayProperty.PayMethod);
                throw new ProductItemException(3003, "absent pay method", clientPayProperty.PayMethod);
            }
            sum = sum - sum * percentage;

            if (!DiscountProperty.payPeriod.TryGetValue(clientPayProperty.PayPeriod, out percentage)){
                logger.LogError(3004, "BLL: ClientPayProperty failed getSumPayment({Sum}), with PayPeriod = {PayPeriod}", sum, clientPayProperty.PayPeriod);
                throw new ProductItemException(3004, "absent pay pariod", clientPayProperty.PayPeriod);
            }
            sum = sum - sum * percentage;

            return sum;
        }
    }
}
