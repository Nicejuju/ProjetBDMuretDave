//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetBDMuretDave.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeExaman
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeExaman()
        {
            this.ExamenRealises = new HashSet<ExamenRealise>();
        }
    
        public decimal IdTypeExamen { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public decimal PrixSoumis { get; set; }
        public decimal PrixNonSoumis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamenRealise> ExamenRealises { get; set; }
    }
}