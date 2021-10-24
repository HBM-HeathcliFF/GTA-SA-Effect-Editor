using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Prim
    {
        private List<string> _startSettings = new List<string>();
        private List<Info> _infos = new List<Info>();
        private List<string> _endSettings = new List<string>();
        private List<string> _textures = new List<string>();

        public List<string> StartSettings { get => _startSettings; }
        public List<Info> Infos { get => _infos; }
        public List<string> EndSettings { get => _endSettings; }
        public List<string> Textures { get => _textures; }

        public Prim()
        {

        }

        public Prim(List<string> startSettings, List<string> endSettings, 
                    List<Info> infos, List<string> textures)
        {
            foreach (var setting in startSettings)
            {
                _startSettings.Add(setting);
            }

            foreach (var setting in endSettings)
            {
                _endSettings.Add(setting);
            }

            foreach (var info in infos)
            {
                _infos.Add(info);
            }

            foreach (var texture in textures)
            {
                _textures.Add(texture);
            }
        }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();

            foreach (var line in StartSettings)
            {
                lines.Add(line);
            }

            foreach (var info in Infos)
            {
                foreach (var line in info.Lines)
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