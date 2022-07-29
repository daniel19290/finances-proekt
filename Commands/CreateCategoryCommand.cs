using System.ComponentModel.DataAnnotations;

namespace TransactionAPI.Commands
{
    public class CreateCategoryCommand
    {
        [Required]
        public string Code { get; set; }
        
        public string parentCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}