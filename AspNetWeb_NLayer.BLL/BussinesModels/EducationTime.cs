using AspNetWeb_NLayer.BLL.Infrastructure;
using Microsoft.Extensions.Logging;

namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class EducationTime : Dictionary<string, int>
    {
        public ClientTimeProperty cltTimeProps { get; } = null!;
        private ILogger logger;

        public EducationTime(ClientTimeProperty cltTimeProps, ILogger logger ) : base(new Dictionary<string, int>(){ { "front-end", 2 }, { "back-end", 4 } })
        {
            this.cltTimeProps = cltTimeProps;
            this.logger = logger;
        }

        public int getTimeEducation(int timeDurationMonth)
        {
            if (cltTimeProps.EducationForm != "daily" && cltTimeProps.EducationForm != "holiday")
            {
                logger.LogError(3005, "BLL: EducationTime failed getTimeEducation({TimeDuration})", cltTimeProps.EducationForm);
                throw new ProductItemException(3005, "absent form education", cltTimeProps.EducationForm);
            }

            if (cltTimeProps.EducationForm == "daily") return timeDurationMonth;

            if (this.ContainsKey(cltTimeProps.EngineerType)) { 
                return timeDurationMonth + this[cltTimeProps.EngineerType]; 
            }
            else
            {
                logger.LogError(3006, "BLL: EducationTime failed getTimeEducation({TimeDuration})", cltTimeProps.EngineerType);
                throw new ProductItemException(3006, "absent engineer type", cltTimeProps.EngineerType);
            }
        }
    }
}
