using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaCar.Api.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Nome { get; set; }
    }
}
