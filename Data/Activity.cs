using System;

namespace Data
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Helper Helper { get; set; }
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
