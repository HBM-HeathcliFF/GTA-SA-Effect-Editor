using System.Collections.Generic;

namespace GTA_SA_Effect_Editor
{
    public static class FxsTemplates
    {
        public static string[] Effect { get; } = new string[]
        {
            "FX_SYSTEM_DATA:",
            "109",
            "",
            @"FILENAME: X:\SA\FxTools\Data\effects\gta_pc\systems/code/name.fxs",
            "NAME: name",
            "LENGTH: 0.000",
            "LOOPINTERVALMIN: 0.000",
            "LENGTH: 0.000",
            "PLAYMODE: 0",
            "CULLDIST: 1000000.000",
            "BOUNDINGSPHERE: 0.000 0.000 0.000 0.000",
            "NUM_PRIMS: 0",
            "OMITTEXTURES: 0",
            "TXDNAME: NOTXDSET"
        };

        public static string[] Prim { get; } = new string[]
        {
            "FX_PRIM_EMITTER_DATA:",
            "",
            "FX_PRIM_BASE_DATA:",
            "NAME: prim_name",
            "MATRIX: 0.000 0.000 0.000 0.000 0.000 0.000 0.000 0.000 0.000 0.000 0.000 0.000 ",
            "TEXTURE: NULL",
            "TEXTURE2: NULL",
            "TEXTURE3: NULL",
            "TEXTURE4: NULL",
            "ALPHAON: 1",
            "SRCBLENDID: 4",
            "DSTBLENDID: 5",
            "",
            "NUM_INFOS: 0",
            "",
            "LODSTART: 0.000",
            "LODEND: 0.000"
        };

        public static string[] KeyFloat { get; } = new string[]
        {
            "FX_KEYFLOAT_DATA:",
            "TIME: 0.000",
            "VAL: 0.000"
        };

        public static class Infos
        {
            public static string SelectedInfo { get; set; }

            public static string[] SIZE { get; } = new string[]
            {
                "FX_INFO_SIZE_DATA:",
                "TIMEMODEPRT: 1",
                "SIZEX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEXBIAS:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEYBIAS:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
            };
            public static string[] EMLIFE { get; } = new string[]
            {
                "FX_INFO_EMLIFE_DATA:",
                "LIFE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BIAS:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMRATE { get; } = new string[]
            {
                "FX_INFO_EMRATE_DATA:",
                "RATE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMSPEED { get; } = new string[]
            {
                "FX_INFO_EMSPEED_DATA:",
                "SPEED:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BIAS:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMANGLE { get; } = new string[]
            {
                "FX_INFO_EMANGLE_DATA:",
                "MIN:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "MAX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] FORCE { get; } = new string[]
            {
                "FX_INFO_FORCE_DATA:",
                "TIMEMODEPRT: 1",
                "FORCEX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "FORCEY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "FORCEZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] ROTSPEED { get; } = new string[]
            {
                "FX_INFO_ROTSPEED_DATA:",
                "TIMEMODEPRT: 1",
                "MINCW:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "MAXCW:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "MINCCW:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "MAXCCW:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] COLOURBRIGHT { get; } = new string[]
            {
                "FX_INFO_COLOURBRIGHT_DATA:",
                "TIMEMODEPRT: 1",
                "RED:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "GREEN:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BLUE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "ALPHA:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BIAS:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMROTATION { get; } = new string[]
            {
                "FX_INFO_EMROTATION_DATA:",
                "ANGLEMIN:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "ANGLEMAX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMDIR { get; } = new string[]
            {
                "FX_INFO_EMDIR_DATA:",
                "DIRX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "DIRY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "DIRZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMSIZE { get; } = new string[]
            {
                "FX_INFO_EMSIZE_DATA:",
                "RADIUS:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEMINX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEMAXX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEMINY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEMAXY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEMINZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SIZEMAXZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] COLOUR { get; } = new string[]
            {
                "FX_INFO_COLOUR_DATA:",
                "TIMEMODEPRT: 1",
                "RED:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "GREEN:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BLUE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "ALPHA:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] FRICTION { get; } = new string[]
            {
                "FX_INFO_FRICTION_DATA:",
                "TIMEMODEPRT: 1",
                "FRICTION:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] WIND { get; } = new string[]
            {
                "FX_INFO_WIND_DATA:",
                "TIMEMODEPRT: 1",
                "WINDFACTOR:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] SELFLIT { get; } = new string[]
            {
                "FX_INFO_SELFLIT_DATA:",
                "TIMEMODEPRT: 1"
            };
            public static string[] DIR { get; } = new string[]
            {
                "FX_INFO_DIR_DATA:",
                "TIMEMODEPRT: 1",
                "X:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "Y:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "Z:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] HEATHAZE { get; } = new string[]
            {
                "FX_INFO_HEATHAZE_DATA:",
                "TIMEMODEPRT: 1"
            };
            public static string[] SPRITERECT { get; } = new string[]
            {
                "FX_INFO_SPRITERECT_DATA:",
                "TIMEMODEPRT: 1",
                "TOP:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BOTTOM:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "LEFT:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "RIGHT:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] JITTER { get; } = new string[]
            {
                "FX_INFO_JITTER_DATA:",
                "TIMEMODEPRT: 1",
                "JITTERFACTOR:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] FLAT { get; } = new string[]
            {
                "FX_INFO_FLAT_DATA:",
                "TIMEMODEPRT: 1",
                "RX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "RY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "RZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "UX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "UY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "UZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "AX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "AY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "AZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMPOS { get; } = new string[]
            {
                "FX_INFO_EMPOS_DATA:",
                "X:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "Y:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "Z:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] FLOAT { get; } = new string[]
            {
                "FX_INFO_FLOAT_DATA:",
                "TIMEMODEPRT: 1"
            };
            public static string[] NOISE { get; } = new string[]
            {
                "FX_INFO_NOISE_DATA:",
                "TIMEMODEPRT: 1",
                "NOISE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] UNDERWATER { get; } = new string[]
            {
                "FX_INFO_UNDERWATER_DATA:",
                "TIMEMODEPRT: 1"
            };
            public static string[] TRAIL { get; } = new string[]
            {
                "FX_INFO_TRAIL_DATA:",
                "TIMEMODEPRT: 1",
                "TRAILTIME:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SCREENSPACE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] GROUNDCOLLIDE { get; } = new string[]
            {
                "FX_INFO_GROUNDCOLLIDE_DATA:",
                "TIMEMODEPRT: 1",
                "BOUNCE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "SPEEDMULT:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "BOUNCEERROR:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] ANIMTEX { get; } = new string[]
            {
                "FX_INFO_ANIMTEX_DATA:",
                "TIMEMODEPRT: 1",
                "TEXID:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] EMWEATHER { get; } = new string[]
            {
                "FX_INFO_EMWEATHER_DATA:",
                "WINDMIN:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "WINDMAX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "RAINMIN:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "RAINMAX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
            public static string[] ATTRACTPT { get; } = new string[]
            {
                "FX_INFO_ATTRACTPT_DATA:",
                "TIMEMODEPRT: 1",
                "POSX:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "POSY:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "POSZ:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0",
                "FORCE:",
                "FX_INTERP_DATA:",
                "LOOPED: 0",
                "NUM_KEYS: 0"
            };
        }

        private static Dictionary<string, string[]> s_dictionaryInfo = new Dictionary<string, string[]>()
        {
            ["ANIMTEX"] = Infos.ANIMTEX,
            ["ATTRACTPT"] = Infos.ATTRACTPT,
            ["COLOUR"] = Infos.COLOUR,
            ["COLOURBRIGHT"] = Infos.COLOURBRIGHT,
            ["DIR"] = Infos.DIR,
            ["EMANGLE"] = Infos.EMANGLE,
            ["EMDIR"] = Infos.EMDIR,
            ["EMLIFE"] = Infos.EMLIFE,
            ["EMPOS"] = Infos.EMPOS,
            ["EMRATE"] = Infos.EMRATE,
            ["EMROTATION"] = Infos.EMROTATION,
            ["EMSIZE"] = Infos.EMSIZE,
            ["EMSPEED"] = Infos.EMSPEED,
            ["EMWEATHER"] = Infos.EMWEATHER,
            ["FLAT"] = Infos.FLAT,
            ["FLOAT"] = Infos.FLOAT,
            ["FORCE"] = Infos.FORCE,
            ["FRICTION"] = Infos.FRICTION,
            ["GROUNDCOLLIDE"] = Infos.GROUNDCOLLIDE,
            ["HEATHAZE"] = Infos.HEATHAZE,
            ["JITTER"] = Infos.JITTER,
            ["NOISE"] = Infos.NOISE,
            ["ROTSPEED"] = Infos.ROTSPEED,
            ["SELFLIT"] = Infos.SELFLIT,
            ["SIZE"] = Infos.SIZE,
            ["SPRITERECT"] = Infos.SPRITERECT,
            ["TRAIL"] = Infos.TRAIL,
            ["UNDERWATER"] = Infos.UNDERWATER,
            ["WIND"] = Infos.WIND
        };

        public static string[] CreateAccordingToTemplate(this string key)
        {
            if (s_dictionaryInfo.ContainsKey(key))
                return s_dictionaryInfo[key];
            else
                return null;
        }
    }
}