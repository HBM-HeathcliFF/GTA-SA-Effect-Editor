using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class Effect
    {
        private string _name;
        private List<string> _textures = new List<string>();

        public List<string> Lines { get; set; } = new List<string>();
        public string Name { get => _name; }
        public List<string> Textures { get => _textures; }

        public Effect(string name, int startLine, int endLine, List<string> textures, List<string> effectsFXP)
        {
            _name = name;

            for (int i = 0; i < textures.Count; i++)
            {
                _textures.Add(textures[i]);
            }

            for (int i = startLine; i < endLine + 1; i++)
            {
                Lines.Add(effectsFXP[i]);
            }
        }
    }
}