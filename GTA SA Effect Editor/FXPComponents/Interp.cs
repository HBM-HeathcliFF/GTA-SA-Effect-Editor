using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Interp
    {
        public string Name { get; set; }
        public string LOOPED { get; set; }
        public string NUM_KEYS { get; set; }
        public List<KeyFloat> KeyFloats { get; set; } = new List<KeyFloat>();

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            lines.Add($"{Name}:");
            lines.Add("FX_INTERP_DATA:");
            lines.Add(LOOPED);
            lines.Add(NUM_KEYS);

            foreach (var keyFloat in KeyFloats)
            {
                foreach (var line in keyFloat.GetLines())
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}