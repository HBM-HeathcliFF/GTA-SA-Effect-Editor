using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GTA_SA_Effect_Editor
{
    public class EffectFileReader
    {
        private EffectParser _parser;

        public EffectFileReader(EffectParser parser) =>
            _parser = parser;

        public BindingList<Effect> Read(string path)
        {
            try
            {
                return _parser.Parse(File.ReadAllLines(path).ToList());
            }
            catch (Exception)
            {
                MessageBox.Show("File opening error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}