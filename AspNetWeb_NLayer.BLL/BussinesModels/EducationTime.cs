using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class EducationForm
    {
        private Dictionary<string, int> educationTypes { get; set;  } = null!;
        public Dictionary<string, int> EducationTypes
        {
            get => educationTypes = new Dictionary<string, int>() { { "frontend", 2 }, { "backend", 4 } };
        }

        private string educationTime = string.Empty;
        public string EducationTime
        {
            get { if (educationTime.ToLower() != "daily" && educationTime.ToLower() != "holiday")
                    return "no data";
            return educationTime;
            }
        }

        public string educationType { get; protected set; } = null!;
        public EducationForm(string educationTime, string educationType) {

            this.educationTime = educationTime.ToLower();
            this.educationType = educationType.ToLower();
        }

        public int getTimeEducation(int timeDurationMonth)
        {
            if (educationTime == "daily")
            {
                return timeDurationMonth;
            }

            if(educationTypes.Contains(educationType)) { 
                return timeDurationMonth; 
            }
        }
    }
}
