using AspNetWeb_NLayer.DAL.Filter;
using System.ComponentModel.DataAnnotations;


namespace AspNetWeb_NLayer.DAL.Entities
{
    public class ProductOrder : IValidatableObject
    {
        [SwaggerIgnore]
        public int id {  get; set; }
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int timeStudy { get; set; }
        public float sumPay { get; set; }
        [SwaggerIgnore]
        public string guid { get; set; } = "";
        [SwaggerIgnore]
        public DateTime dateTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.name))
            {
                errors.Add(new ValidationResult("input field \"name\" in ProductOrder"));
            }
            if (string.IsNullOrWhiteSpace(this.typeEngeeniring))
            {
                errors.Add(new ValidationResult("input field \"typeEngeeniring\" in ProductOrder"));
            }
            if(this.timeStudy == 0)
            {
                errors.Add(new ValidationResult("input field \"timeStudy\" in ProductOrder"));
            }
            if(this.sumPay == 0)
            {
                errors.Add(new ValidationResult("input field \"sumPay\" in ProductOrder"));
            }

            return errors;
        }

    }
}
