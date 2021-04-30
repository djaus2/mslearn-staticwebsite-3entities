using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Activity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Task")]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string Description
        {
            set { }
            get
            {
                string HelperName =" ";
                string RoundNo = " ";
                if (Helper != null)
                    HelperName = $"{Helper.Name}";
                if (Round != null)
                    RoundNo = $"{Round.No}";
                return $"Helper:{HelperName}   -   Round:{RoundNo}"; }
        }
		[Column("Quantity")]
        public int Quantity { get; set; }

        //This can be null, its an Unassigned Task:
        [Column("Helper")]
        public Helper Helper { get; set; }

        [Column("Round")]
        [Required]
        public Round Round { get; set; }
    }
    public class Helper
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }
		[Column("Decsription")]
        public string Description { get; set; } = "";
    }

    public class Round
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("No")]
        [Required]
        public int  No { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string Name { get { return $"{No}"; } 
            set {
                int no;
                if (int.TryParse(value, out no))
                {
                    No = no;
                }
            } }

        [Column("Decsription")]
        public string Description { get; set; } = "";
    }
}
