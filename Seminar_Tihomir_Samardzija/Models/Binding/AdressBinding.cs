using Seminar_Tihomir_Samardzija.Models.Dbo.Base;
using Seminar_Tihomir_Samardzija.Validation;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class AdressBinding:AdressBase
    {
        [UserIdValidation]
        public string UserId { get; set; }
    }
}
