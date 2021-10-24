﻿using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Effect
    {
        private string _name;
        private List<string> _startSettings = new List<string>();
        private List<Prim> _prims = new List<Prim>();
        private List<string> _endSettings = new List<string>();
        
        public string Name { get => _name; }
        public List<string> StartSettings { get => _startSettings; }
        public List<Prim> Prims { get => _prims; }
        public List<string> EndSettings { get => _endSettings; }
        public int ID { get; }

        public Effect()
        {

        }

        public Effect(string name, List<Prim> prims, 
                      List<string> startSettings, List<string> endSettings)
        {
            _name = name;

            foreach (var prim in prims)
            {
                _prims.Add(prim);
            }

            foreach (var setting in startSettings)
            {
                _startSettings.Add(setting);
            }

            foreach (var setting in endSettings)
            {
                _endSettings.Add(setting);
            }

            ID = s_id;
            s_id++;
        }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            foreach (var line in StartSettings)
            {
                lines.Add(line);
            }

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