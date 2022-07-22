using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int workedHours)
        {
            PartName = partName;
            this.WorkedHours = workedHours;
        }

        public string PartName { get; set; }

        public int WorkedHours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} " +
                $"Hours Worked: {WorkedHours}";
        }
    }
}