using System.ComponentModel.DataAnnotations;

namespace GestionEleves.Models
{
    public class Etablissement
    {
        [Key]
        public int EtablissementId { get; set; }
        public string? EtablissementName { get; set; }
    }
}
