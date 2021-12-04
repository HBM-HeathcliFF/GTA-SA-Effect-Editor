using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    class EffectReader
    {
        public void Read(List<string> effectsFile, ref List<Effect> effects)
        {
            int i = 0;
            while (FindLine("FX_SYSTEM_DATA", i, effectsFile) != -1)
            {
                i = FindLine("FX_SYSTEM_DATA", i, effectsFile);
                effects.Add(ReadEffect(effectsFile, i));
                i++;
            }
        }

        public Effect ReadEffect(List<string> effectsFile, int currentPositon)
        {
            int i = currentPositon, numberSettings = 0;
            Effect effect = new Effect();
            for (; !effectsFile[i].Contains("TXDNAME: NOTXDSET"); i++)
            {
                if (effectsFile[i].Contains("FILENAME"))
                {
                    int startIndex = effectsFile[i].LastIndexOf('/') + 1;
                    int endIndex = effectsFile[i].IndexOf('.');
                    effect.Name = effectsFile[i].Substring(startIndex, endIndex - startIndex);
                }
                if (effectsFile[i].Contains("NUM_PRIMS"))
                {
                    effect.NUM_PRIMS = effectsFile[i];

                    while (FindLine("FX_PRIM_EMITTER_DATA", "FX_SYSTEM_DATA", i, effectsFile) != -1)
                    {
                        i = FindLine("FX_PRIM_EMITTER_DATA", i, effectsFile);
                        effect.Prims.Add(ReadPrim(effectsFile, i));
                        i++;
                    }

                    numberSettings = 1;
                    i = FindLine("OMITTEXTURES", i, effectsFile);
                }
                if (numberSettings == 0)
                    effect.StartSettings.Add(effectsFile[i]);
                if (numberSettings == 1)
                    effect.EndSettings.Add(effectsFile[i]);
            }
            effect.EndSettings.Add(effectsFile[i]);

            return effect;
        }
        public Prim ReadPrim(List<string> effectsFile, int currentPositon)
        {
            int numberSettings = 0;
            Prim prim = new Prim();
            for (int i = currentPositon; !effectsFile[i].Contains("LODEND"); i++)
            {
                if (effectsFile[i].Contains("NUM_INFOS"))
                {
                    prim.NUM_INFOS = effectsFile[i];

                    while (FindLine("FX_INFO_", "LODSTART", i, effectsFile) != -1)
                    {
                        i = FindLine("FX_INFO_", i, effectsFile);
                        prim.Infos.Add(ReadInfo(effectsFile, i));
                        i++;
                    }

                    numberSettings = 1;
                    i = FindLine("LODSTART", i, effectsFile);
                }

                if (numberSettings == 0)
                    prim.StartSettings.Add(effectsFile[i]);
                if (effectsFile[i].StartsWith("TEXTURE"))
                    prim.Textures.Add(effectsFile[i]);

                if (numberSettings == 1)
                {
                    prim.EndSettings.Add(effectsFile[i]);
                    currentPositon = i;
                }
            }
            prim.EndSettings.Add(effectsFile[currentPositon + 1]);

            return prim;
        }
        public Info ReadInfo(List<string> effectsFile, int currentPositon)
        {
            int i = currentPositon;
            Info info = new Info();

            info.Name = effectsFile[i].Split(':')[0];
            i = FindLine("TIMEMODEPRT", "FX_INTERP_DATA", i, effectsFile);
            if (i != -1)
                info.TIMEMODEPRT = effectsFile[i];

            currentPositon++;

            while (FindLine("FX_INTERP_DATA", "FX_INFO_", currentPositon, effectsFile) != -1)
            {
                currentPositon = FindLine("FX_INTERP_DATA", currentPositon, effectsFile);
                info.Interps.Add(ReadInterp(effectsFile, currentPositon));
                currentPositon++;
            }

            return info;
        }
        public Interp ReadInterp(List<string> effectsFile, int currentPositon)
        {
            Interp interp = new Interp();
            if (currentPositon > 0)
            {
                for (int i = currentPositon - 1; ; i--)
                {
                    if (effectsFile[i].Contains(":"))
                    {
                        interp.Name = effectsFile[i].Split(':')[0];
                        break;
                    }
                }
            }
            else
                interp.Name = effectsFile[currentPositon].Split(':')[0];

            currentPositon = FindLine("LOOPED", currentPositon, effectsFile);
            interp.LOOPED = effectsFile[currentPositon];
            currentPositon = FindLine("NUM_KEYS", currentPositon, effectsFile);
            interp.NUM_KEYS = effectsFile[currentPositon];

            while (FindLine("FX_KEYFLOAT_DATA", "FX_INTERP_DATA", currentPositon, effectsFile) != -1)
            {
                currentPositon = FindLine("FX_KEYFLOAT_DATA", currentPositon, effectsFile);
                interp.KeyFloats.Add(ReadKeyFloat(effectsFile, currentPositon));
                currentPositon++;
            }

            return interp;
        }
        public KeyFloat ReadKeyFloat(List<string> effectsFile, int currentPositon)
        {
            KeyFloat keyFloat = new KeyFloat();
            currentPositon = FindLine("TIME", currentPositon, effectsFile);
            keyFloat.TIME = effectsFile[currentPositon];
            currentPositon = FindLine("VAL", currentPositon, effectsFile);
            keyFloat.VAL = effectsFile[currentPositon];

            return keyFloat;
        }

        private int FindLine(string targetLine, int currentPosition, List<string> lines)
        {
            for (int i = currentPosition; i < lines.Count; i++)
            {
                if (lines[i].Contains(targetLine))
                    return i;
            }
            return -1;
        }
        private int FindLine(string targetLine, string secondLine, int currentPosition, List<string> lines)
        {
            for (int i = currentPosition; i < lines.Count; i++)
            {
                if (lines[i].Contains(targetLine))
                    return i;
                if (lines[i].Contains(secondLine))
                    return -1;
            }
            return -1;
        }
    }
}