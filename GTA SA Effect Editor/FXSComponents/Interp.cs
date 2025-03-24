using GTA_SA_Effect_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GTA_SA_Effect_Editor
{
    public class Interp : IFxsComponent, IDisposable
    {
        public string Name { get; set; }
        public string LOOPED { get; set; }
        public FxsComponentType Type { get; } = FxsComponentType.INTERP;
        public ICollection<IFxsComponent> Nodes { get; set; } = new List<IFxsComponent>();

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            lines.Add($"{Name}:");
            lines.Add("FX_INTERP_DATA:");
            lines.Add(LOOPED);
            lines.Add($"NUM_KEYS: {Nodes.Count}");

            foreach (var keyFloat in Nodes)
            {
                foreach (var line in keyFloat.GetLines())
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        public void Copy(IFxsComponent source)
        {
            Dispose();

            Name = source.Name;
            LOOPED = (source as Interp).LOOPED;

            foreach (var node in source.Nodes)
            {
                Nodes.Add(node);
            }
        }

        public void Dispose()
        {
            var nodes = Nodes.ToList();
            for (int i = 0; i < Nodes.Count; i++)
            {
                nodes[i].Dispose();
                nodes[i] = null;
            }
            Nodes.Clear();
        }
    }
}