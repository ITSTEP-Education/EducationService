﻿using AspNetWeb_NLayer.BLL.Infrastructure;

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
                throw new ProductItemException(3005, "absent form education", cltTimeProps.EducationForm);

            if (cltTimeProps.EducationForm == "daily") return timeDurationMonth;

            if (this.ContainsKey(cltTimeProps.EngineerType)) { 
                return timeDurationMonth + this[cltTimeProps.EngineerType]; 
            }
            else
            {
                throw new ProductItemException(3006, "absent engineer type", cltTimeProps.EngineerType);
            }
        }
    }
}
