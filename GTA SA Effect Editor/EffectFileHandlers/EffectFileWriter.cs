using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;

namespace GTA_SA_Effect_Editor
{
    public class EffectFileWriter
    {
        public void WriteFxp(string path, BindingList<Effect> effectsList)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding(1251)))
                {
                    streamWriter.WriteLine("FX_PROJECT_DATA:");
                    streamWriter.WriteLine();

                    foreach (var effect in effectsList)
                    {
                        WriteEffect(effect, streamWriter);
                        streamWriter.WriteLine();
                    }

                    streamWriter.WriteLine("FX_PROJECT_DATA_END:");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to overwrite effects file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void WriteFxs(string path, Effect effect)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.GetEncoding(1251)))
                {
                    WriteEffect(effect, streamWriter);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to overwrite effects file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteEffect(Effect effect, StreamWriter streamWriter)
        {
            foreach (var line in effect.GetLines())
            {
                streamWriter.WriteLine(line);
            }
        }
    }
}