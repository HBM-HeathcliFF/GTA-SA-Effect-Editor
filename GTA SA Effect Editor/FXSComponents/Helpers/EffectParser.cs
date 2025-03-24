using GTA_SA_Effect_Editor.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace GTA_SA_Effect_Editor
{
    public static class EffectParser
    {
        public static BindingList<Effect> Parse(List<string> effectsFile)
        {
            BindingList<Effect> effects = new BindingList<Effect>();
            if (effectsFile != null)
            {
                int i = 0;
                while (FindLine("FX_SYSTEM_DATA", i, effectsFile) != -1)
                {
                    i = FindLine("FX_SYSTEM_DATA", i, effectsFile);
                    effects.Add(ParseEffect(effectsFile, i) as Effect);
                    i++;
                }
            }
            return effects;
        }

        public static IFxsComponent Parse(List<string> effectsFile, int currentPositon, FxsComponentType type)
        {
            switch (type)
            {
                case FxsComponentType.EFFECT:
                    return ParseEffect(effectsFile, currentPositon);
                case FxsComponentType.PRIM:
                    return ParsePrim(effectsFile, currentPositon);
                case FxsComponentType.INFO:
                    return ParseInfo(effectsFile, currentPositon);
                case FxsComponentType.INTERP:
                    return ParseInterp(effectsFile, currentPositon);
                case FxsComponentType.KEYFLOAT:
                    return ParseKeyFloat(effectsFile, currentPositon);
                default:
                    return null;
            }
        }

        public static IFxsComponent ParseEffect(List<string> effectsFile, int currentPositon)
        {
            int i = currentPositon, numberSettings = 0;
            Effect effect = new Effect();
            for (; !effectsFile[i].Contains("TXDNAME: NOTXDSET"); i++)
            {
                if (effectsFile[i].Contains("FX_SYSTEM_DATA:") || effectsFile[i].Contains("109") || effectsFile[i] == "")
                {
                    continue;
                }
                if (effectsFile[i].Contains("FILENAME"))
                {
                    int startIndex = effectsFile[i].LastIndexOf('/') + 1;
                    int endIndex = effectsFile[i].IndexOf('.');
                    effect.Name = effectsFile[i].Substring(startIndex, endIndex - startIndex);
                    effect.Path = effectsFile[i].Replace("FILENAME:", "").Replace($"{effect.Name}.fxs", "");
                    continue;
                }
                if (effectsFile[i].Contains("NUM_PRIMS"))
                {
                    while (FindLine("FX_PRIM_EMITTER_DATA", "FX_SYSTEM_DATA", i, effectsFile) != -1)
                    {
                        i = FindLine("FX_PRIM_EMITTER_DATA", i, effectsFile);
                        ((List<IFxsComponent>)(effect.Nodes)).Add(ParsePrim(effectsFile, i) as Prim);
                        i++;
                    }

                    numberSettings = 1;
                    i = FindLine("OMITTEXTURES", i, effectsFile);
                }
                if (numberSettings == 0)
                {
                    effect.StartSettings.Add(effectsFile[i]);
                }
                if (numberSettings == 1)
                {
                    effect.EndSettings.Add(effectsFile[i]);
                }
            }
            effect.EndSettings.Add(effectsFile[i]);

            return effect;
        }
        public static IFxsComponent ParsePrim(List<string> effectsFile, int currentPositon)
        {
            int numberSettings = 0;
            Prim prim = new Prim();
            for (int i = currentPositon; !effectsFile[i].Contains("LODEND"); i++)
            {
                if (effectsFile[i].Contains("NUM_INFOS"))
                {
                    while (FindLine("FX_INFO_", "LODSTART", i, effectsFile) != -1)
                    {
                        i = FindLine("FX_INFO_", i, effectsFile);
                        ((List<IFxsComponent>)(prim.Nodes)).Add(ParseInfo(effectsFile, i) as Info);
                        i++;
                    }

                    numberSettings = 1;
                    i = FindLine("LODSTART", i, effectsFile);
                }

                if (numberSettings == 0)
                {
                    prim.StartSettings.Add(effectsFile[i]);
                }
                if (effectsFile[i].StartsWith("TEXTURE"))
                {
                    prim.Textures.Add(effectsFile[i]);
                }

                if (numberSettings == 1)
                {
                    prim.EndSettings.Add(effectsFile[i]);
                    currentPositon = i;
                }
            }
            prim.EndSettings.Add(effectsFile[currentPositon + 1]);

            return prim;
        }
        public static IFxsComponent ParseInfo(List<string> effectsFile, int currentPositon)
        {
            int i = currentPositon;
            Info info = new Info();

            info.Name = effectsFile[i].Split(':')[0];
            i = FindLine("TIMEMODEPRT", "FX_INTERP_DATA", i, effectsFile);
            if (i != -1)
            {
                info.TIMEMODEPRT = effectsFile[i];
            }

            currentPositon++;

            while (FindLine("FX_INTERP_DATA", "FX_INFO_", currentPositon, effectsFile) != -1)
            {
                currentPositon = FindLine("FX_INTERP_DATA", currentPositon, effectsFile);
                ((List<IFxsComponent>)(info.Nodes)).Add(ParseInterp(effectsFile, currentPositon) as Interp);
                currentPositon++;
            }

            return info;
        }
        public static IFxsComponent ParseInterp(List<string> effectsFile, int currentPositon)
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
            {
                interp.Name = effectsFile[currentPositon].Split(':')[0];
            }

            currentPositon = FindLine("LOOPED", currentPositon, effectsFile);
            interp.LOOPED = effectsFile[currentPositon];

            currentPositon = FindLine("NUM_KEYS", currentPositon, effectsFile);
            while (FindLine("FX_KEYFLOAT_DATA", "FX_INTERP_DATA", currentPositon, effectsFile) != -1)
            {
                currentPositon = FindLine("FX_KEYFLOAT_DATA", currentPositon, effectsFile);
                var keyFloat = ParseKeyFloat(effectsFile, currentPositon);
                ((List<IFxsComponent>)(interp.Nodes)).Add(keyFloat as KeyFloat);
                currentPositon++;
            }

            return interp;
        }
        public static IFxsComponent ParseKeyFloat(List<string> effectsFile, int currentPositon)
        {
            KeyFloat keyFloat = new KeyFloat();
            currentPositon = FindLine("TIME", currentPositon, effectsFile);
            keyFloat.TIME = effectsFile[currentPositon];
            currentPositon = FindLine("VAL", currentPositon, effectsFile);
            keyFloat.VAL = effectsFile[currentPositon];

            return keyFloat;
        }

        private static int FindLine(string targetLine, int currentPosition, List<string> lines)
        {
            for (int i = currentPosition; i < lines.Count; i++)
            {
                if (lines[i].Contains(targetLine))
                {
                    return i;
                }
            }
            return -1;
        }
        private static int FindLine(string targetLine, string secondLine, int currentPosition, List<string> lines)
        {
            for (int i = currentPosition; i < lines.Count; i++)
            {
                if (lines[i].Contains(targetLine))
                {
                    return i;
                }
                if (lines[i].Contains(secondLine))
                {
                    return -1;
                }
            }
            return -1;
        }
    }
}