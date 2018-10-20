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

    }
    public class Machine {





    }

    public class Demande {




    }
}