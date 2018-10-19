using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiecesDeRechange.Models
{
    public class Employe
    {
        public int ID { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string  Rue { get; set; }
        public string NoApp { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string CodePostal { get; set; }
        public TypeEmploye Type { get; set; }
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public string Courriel { get; set; }
    }
}