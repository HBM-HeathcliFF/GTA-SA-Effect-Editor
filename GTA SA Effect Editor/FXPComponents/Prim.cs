using GTA_SA_Effect_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA_SA_Effect_Editor
{
    class Prim : IFxsComponent, IDisposable
    {
        public string Name { get; } = "PRIM";
        public List<string> StartSettings { get; set; } = new List<string>();
        public CodeBlockType Type { get; } = CodeBlockType.PRIM;
        public ICollection<IFxsComponent> Nodes { get; set; } = new List<IFxsComponent>();
        public List<string> EndSettings { get; set; } = new List<string>();
        public List<string> Textures { get; set; } = new List<string>();

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            foreach (var line in StartSettings)
            {
                lines.Add(line);
            }

            lines.Add($"NUM_INFOS: {Nodes.Count}");

            foreach (var info in Nodes)
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

        public void Copy(IFxsComponent source)
        {
            Dispose();

            foreach (var setting in (source as Prim).StartSettings)
            {
                StartSettings.Add(setting);
            }
            foreach (var setting in (source as Prim).EndSettings)
            {
                EndSettings.Add(setting);
            }
            foreach (var texture in (source as Prim).Textures)
            {
                Textures.Add(texture);
            }
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
            StartSettings.Clear();
            EndSettings.Clear();
            Textures.Clear();
        }
    }
}