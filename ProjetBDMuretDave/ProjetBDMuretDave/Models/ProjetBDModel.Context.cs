﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBIG3A3Entities : DbContext
    {
        public DBIG3A3Entities()
            : base("name=DBIG3A3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Emploi> Emplois { get; set; }
        public virtual DbSet<Entreprise> Entreprises { get; set; }
        public virtual DbSet<ExamenRealise> ExamenRealises { get; set; }
        public virtual DbSet<Lieu> Lieux { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<TypeExaman> TypeExamen { get; set; }
        public virtual DbSet<VisiteMedicale> VisiteMedicales { get; set; }
    }
}
