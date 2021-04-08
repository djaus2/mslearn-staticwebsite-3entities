using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
        public int Quantity { get; set; }

         //This can be null, its an Unassigned Task:
        public Helper Helper { get; set; }
        [Required]
        public Round Round { get; set; }
    }
    public class Helper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "";
    }

    public class Round
    {
        public int Id { get; set; }
        public int  No { get; set; }

        public string Name { get { return $"{No}"; } 
            set {
                int no;
                if (int.TryParse(value, out no))
                {
                    No = no;
                }
            } }

        public string Description { get; set; } = "";
    }
}
