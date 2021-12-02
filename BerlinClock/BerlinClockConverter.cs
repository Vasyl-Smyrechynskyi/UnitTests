using System;

namespace BerlinClock
{
    public class BerlinClockConverter
    {
        public BerlinClockData ConvertToBerlinClockValue(TimeSpan time)
        {
            return new BerlinClockData
            {
                Row1 = (time.Seconds % 2 == 0) ? "Y" : "O",
                Row2 = "RRRR".Substring(0, time.Hours / 5) + "OOOO"[(time.Hours / 5)..],
                Row3 = "RRRR".Substring(0, time.Hours % 5) + "OOOO"[(time.Hours % 5)..],
                Row4 = "YYRYYRYYRYY".Substring(0, time.Minutes / 5) + "OOOOOOOOOOO"[(time.Minutes / 5)..],
                Row5 = "YYYY".Substring(0, time.Minutes % 5) + "OOOO"[(time.Minutes % 5)..]
            };
        }
    }

    public class BerlinClockData
    {
        public string Row1 { get; set; }

        public object Row2 { get; set; }

        public string Row3 { get; set; }

        public string Row4 { get; set; }

        public string Row5 { get; set; }

        public override string ToString()
        {
            return Row1 + "\n" + Row2 + "\n" + Row3 + "\n" + Row4 + "\n" + Row5;
        }
    }
}