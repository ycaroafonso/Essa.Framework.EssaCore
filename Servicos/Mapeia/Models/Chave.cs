using System.ComponentModel.DataAnnotations;

namespace Mapeia.Models
{
    public class Chave
    {
        [Key]
        public string table_schema { get; set; }
        [Key]
        public string table_name { get; set; }
        [Key]
        public string column_name { get; set; }
    }
}
