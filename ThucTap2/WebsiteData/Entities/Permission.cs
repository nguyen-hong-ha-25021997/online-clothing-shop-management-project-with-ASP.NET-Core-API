using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebsiteData.Interfaces;

namespace WebsiteData.Entities
{
    public class Permission : IHasSoftDelete
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("AccountId")]
        public int AccountId { get; set; }
        public Account User { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("FunctionId")]
        public int FunctionId { get; set; }
        public Function Function { get; set; }



        [Required]
        public bool IsDeleted { get; set; }
    }
}
