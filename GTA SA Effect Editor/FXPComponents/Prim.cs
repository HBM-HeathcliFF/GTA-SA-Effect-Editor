using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Prim
    {
        public List<string> StartSettings { get; set; } = new List<string>();
        public List<Info> Infos { get; set; } = new List<Info>();
        public List<string> EndSettings { get; set; } = new List<string>();
        public List<string> Textures { get; set; } = new List<string>();
        public string NUM_INFOS { get; set; }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            foreach (var line in StartSettings)
            {
                lines.Add(line);
            }

            lines.Add(NUM_INFOS);

            foreach (var info in Infos)
            {
                foreach (var line in info.GetLines())
                {
                    lines.Add(line);
                }
                lines.Add("");
            }

            foreach (var line in EndSettings)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}