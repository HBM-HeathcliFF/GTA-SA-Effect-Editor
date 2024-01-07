using GTA_SA_Effect_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA_SA_Effect_Editor
{
    class Info : IFxsComponent, IDisposable
    {
        public string Name { get; set; }
        public CodeBlockType Type { get; } = CodeBlockType.INFO;
        public ICollection<IFxsComponent> Nodes { get; set; } = new List<IFxsComponent>();
        public string TIMEMODEPRT { get; set; } = "";

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            lines.Add($"{Name}:");

            if (TIMEMODEPRT != "")
                lines.Add(TIMEMODEPRT);

            foreach (var interp in Nodes)
            {
                foreach (var line in interp.GetLines())
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
            TIMEMODEPRT = (source as Info).TIMEMODEPRT;
            
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