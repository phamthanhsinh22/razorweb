using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace razorweb.models
{
    public class Article{
        
        [Key]
        public int ID{set;get;}
        [StringLength(255)]
        [Required]
        [Column(TypeName ="nvarchar")]
        public string Title{set;get;}
        [DataType(DataType.Date)]
        [Required]
        public DateTime Created{set;get;}
        [Column(TypeName ="ntext")]
        public string Content{set;get;}
    }    
}