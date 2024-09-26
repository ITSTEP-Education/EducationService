
namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class ClientPayProperty
    {
        bool isInvitedPerson;
        public bool IsInvitedPerson 
        {
            get { return isInvitedPerson; }
            set { isInvitedPerson = value; }
        }

        string payMethod = null!;
        public string PayMethod
        {
            get { return payMethod; }
            set { payMethod = value.ToLower(); }
        }

        string payPeriod = null!;
        public string PayPeriod
        {
            get { return payPeriod; }
            set { payPeriod = value.ToLower(); }
        }

        public ClientPayProperty() { }
    }
}
