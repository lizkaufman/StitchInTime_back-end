using System;

namespace Stitch_BackEnd
{
    public class Project
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public int CurrentRowsDone { get; set; }
        public int CurrentStitchesDone { get; set; }
        public int RowTarget { get; set; }
        public int StitchTarget { get; set; }
        public string ProjectImageUrl { get; set; }
        public string PatternUrl { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
    }

}
