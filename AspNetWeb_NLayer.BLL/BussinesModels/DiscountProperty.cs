
namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public static class DiscountProperty
    {
        public static int invitedPerson { get; }
        public static Dictionary<string, float> payMethod { get; } = null!;
        public static Dictionary<string, float> payPeriod { get; } = null!;

        static DiscountProperty()
        {
            invitedPerson = 500;
            payMethod = new Dictionary<string, float>() { { "cash", 5 / 100f }, { "credit", 0 }, { "bitcoin", 10 / 100f } };
            payPeriod = new Dictionary<string, float>() { { "yearly", 3 / 100f }, { "monthly", 0 } };
        }
    }
}
