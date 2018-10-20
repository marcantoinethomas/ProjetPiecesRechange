using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiecesDeRechange.Models
{
    public class IngenieurViewModel
    {

  

    }

    public class Piece {

        
        public int pieceId { get; set; }

        [Display(Name = "NamePart", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                 ErrorMessageResourceName = "NamePartRequired")]
        public string NamePart { get; set; }

        [Display(Name = "PricePart", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                 ErrorMessageResourceName = "PricePartRequired")]
        public double PricePart { get; set; }
        public String Photo { get; set; }

    }
    public class Machine {

        public int MachineId { get; set; }
        public string  Categorie { get; set; }
        public String[]  ListParts{ get; set; }



    }

    public class Demande {
        public int DemandeId { get; set; }
        public int EmployeeId { get; set; }
        public int PartId { get; set; }
        public DateTime DemandeDate { get; set; }
        public string Demandestatus { get; set; }


    }
}