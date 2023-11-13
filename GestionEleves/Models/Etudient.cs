using System.ComponentModel.DataAnnotations;

namespace GestionEleves.Models
{
    public class Etudient
    {
        [Key]
        public int EtudientID { get; set; }
        public string? EtudientFirstName { get; set; }
        public string? EtudientLastName { get; set; }
        public DateTime EtudientBirthDate { get; set; }
        public int EtablissementId {  get; set; }
        public Etablissement? Etablissement { get; set; }
    }
}
