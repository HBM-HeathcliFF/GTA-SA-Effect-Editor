using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Info
    {
        public string Name { get; set; }
        public List<Interp> Interps { get; set; } = new List<Interp>();
        public string TIMEMODEPRT { get; set; } = "";

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            lines.Add($"{Name}:");

            if (TIMEMODEPRT != "")
                lines.Add(TIMEMODEPRT);

            foreach (var interp in Interps)
            {
                foreach (var line in interp.GetLines())
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}