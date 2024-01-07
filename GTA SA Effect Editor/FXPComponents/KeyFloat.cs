using GTA_SA_Effect_Editor.Interfaces;
using System;
using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class KeyFloat : IFxsComponent, IDisposable
    {
        public string Name { get; } = "KEYFLOAT";
        public string TIME { get; set; }
        public string VAL { get; set; }
        public CodeBlockType Type { get; } = CodeBlockType.KEYFLOAT;
        public ICollection<IFxsComponent> Nodes { get; } = new List<IFxsComponent>();

        public List<string> GetLines()
        {
            List<string> lines = new List<string>
            {
                "FX_KEYFLOAT_DATA:",
                TIME,
                VAL
            };

            return lines;
        }

        public void Copy(IFxsComponent source)
        {
            TIME = (source as KeyFloat).TIME;
            VAL = (source as KeyFloat).VAL;
        }

        public void Dispose()
        {
            Nodes.Clear();
        }
    }
}