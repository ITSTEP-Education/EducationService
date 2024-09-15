using AspNetWeb_NLayer.BLL.Infrastructure;

namespace AspNetWeb_NLayer.BLL.BussinesModels
{
    public class EducationTime : Dictionary<string, int>
    {
        public ClientTimeProperty cltTimeProps { get; } = null!;

        public EducationTime(ClientTimeProperty cltTimeProps) : base(new Dictionary<string, int>(){ { "front-end", 2 }, { "back-end", 4 } })
        {
            this.cltTimeProps = cltTimeProps;
        }

        public int getTimeEducation(int timeDurationMonth)
        {
            if (cltTimeProps.EducationForm != "daily" && cltTimeProps.EducationForm != "holiday")
                throw new ProductItemException("absent form education", cltTimeProps.EducationForm);

            if (cltTimeProps.EducationForm == "daily"){
                return timeDurationMonth;
            }
            else if (cltTimeProps.EducationForm == "holiday") { 
                return timeDurationMonth + this[cltTimeProps.EngineerType]; 
            }
            else if (cltTimeProps.EducationForm == "remote")
            {
                return (int)((timeDurationMonth + this[cltTimeProps.EngineerType])*1.5);
            }
            else
            {
                throw new ProductItemException("absent engineer type", cltTimeProps.EngineerType);
            }
        }
    }
}
