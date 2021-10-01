using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Effect
    {
        private string _name;
        private int _startLine, _endLine;
        private List<string> _textures = new List<string>();

        public string Name { get => _name; }
        public List<string> Textures { get => _textures; }
        public int StartLine { get => _startLine; }
        public int EndLine { get => _endLine; }

        public Effect(string name, int startLine, int endLine, List<string> textures)
        {
            _name = name;
            _startLine = startLine;
            _endLine = endLine;

            for (int i = 0; i < textures.Count; i++)
            {
                _textures.Add(textures[i]);
            }
        }
    }
}