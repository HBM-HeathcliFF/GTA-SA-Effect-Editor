using GTA_SA_Effect_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTA_SA_Effect_Editor
{
    class Effect : IFxsComponent, IDisposable
    {
        private static int s_id = 0;

        public int ID { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public List<string> StartSettings { get; set; } = new List<string>();
        public CodeBlockType Type { get; } = CodeBlockType.EFFECT;
        public ICollection<IFxsComponent> Nodes { get; set; } = new List<IFxsComponent>();
        public List<string> EndSettings { get; set; } = new List<string>();

        public Effect()
        {
            ID = s_id;
            s_id++;
        }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            lines.Add("FX_SYSTEM_DATA:");
            lines.Add("109");
            lines.Add("");
            lines.Add($@"FILENAME:{Path}{Name}.fxs");

            foreach (var line in StartSettings)
            {
                lines.Add(line);
            }

            lines.Add($"NUM_PRIMS: {Nodes.Count}");

            foreach (var prim in Nodes)
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

        public void Copy(IFxsComponent source)
        {
            Dispose();

            Name = source.Name;
            foreach (var setting in (source as Effect).StartSettings)
            {
                StartSettings.Add(setting);
            }
            foreach (var setting in (source as Effect).EndSettings)
            {
                EndSettings.Add(setting);
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
        }
    }
}