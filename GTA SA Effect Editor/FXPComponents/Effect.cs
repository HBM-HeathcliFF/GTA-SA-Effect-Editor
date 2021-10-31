using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Effect
    {
        
        public string Name { get; set; }
        public List<string> StartSettings { get; set; } = new List<string>();
        public List<Prim> Prims { get; set; } = new List<Prim>();
        public List<string> EndSettings { get; set; } = new List<string>();
        public string NUM_PRIMS { get; set; }
        public int ID { get; }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            foreach (var line in StartSettings)
            {
                lines.Add(line);
            }

            lines.Add(NUM_PRIMS);

            foreach (var prim in Prims)
            {
                foreach (var line in prim.GetLines())
                {
                    lines.Add(line);
                }
            }

            foreach (var line in EndSettings)
            {
                lines.Add(line);
            }

            return lines;
        }

        private static int s_id = 0;
    }
}