using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{

    public class Piece
    {
        public int pieceId { get; set; }
        public string NamePart { get; set; }
        public double PricePart { get; set; }
        public String Photo { get; set; }
    }

    public class Machine
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public string Categorie { get; set; }
        public String[] ListParts { get; set; }
    }

    public class Demande
    {
        public int DemandeId { get; set; }
        public int EmployeeId { get; set; }
        public int PartId { get; set; }
        public DateTime DemandeDate { get; set; }
        public string Demandestatus { get; set; }
        public int MachineId { get; set; }
        public int QtyPiece { get; set; }
    }
}