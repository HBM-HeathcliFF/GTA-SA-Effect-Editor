using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class KeyFloat
    {
        public string TIME { get; set; }
        public string VAL { get; set; }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            lines.Add("FX_KEYFLOAT_DATA:");
            lines.Add(TIME);
            lines.Add(VAL);

            return lines;
        }
    }
}