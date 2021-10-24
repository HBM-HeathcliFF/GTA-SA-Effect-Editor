using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Info
    {
        public List<string> Lines { get; set; } = new List<string>();

        public Info()
        {

        }

        public Info(List<string> lines)
        {
            foreach (var line in lines)
            {
                Lines.Add(line);
            }
        }
    }
}