
namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class ClientTimeProperty
    {
        string educationForm = null!;
        public string EducationForm
        {
            get { return educationForm; }
            set { educationForm = value.ToLower(); }
        }

        string engineerType = null!;
        public string EngineerType
        {
            get { return engineerType; }
            set { engineerType = value.ToLower(); }
        }
    }
}
