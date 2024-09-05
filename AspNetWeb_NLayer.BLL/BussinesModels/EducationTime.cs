using AspNetWeb_NLayer.BLL.Infrastructure;

namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class EducationTime : Dictionary<string, int>
    {
        public string engineerType { get; protected set; } = null!;
        public string educationForm { get; protected set; } = null!;

        public EducationTime(string educationForm, string engineerType) : base(new Dictionary<string, int>(){ { "frontend", 2 }, { "backend", 4 } }) {

            this.educationForm = educationForm.ToLower();
            this.engineerType = engineerType.ToLower();
        }

        public int getTimeEducation(int timeDurationMonth)
        {
            if (educationForm != "daily" && educationForm != "holiday")
                throw new ProductItemException("absent form education", educationForm);

            if (educationForm == "daily") return timeDurationMonth;

            if (this.ContainsKey(engineerType)) { 
                return timeDurationMonth + this[engineerType]; 
            }
            else
            {
                throw new ProductItemException("absent engineer type", engineerType);
            }
        }
    }
}
