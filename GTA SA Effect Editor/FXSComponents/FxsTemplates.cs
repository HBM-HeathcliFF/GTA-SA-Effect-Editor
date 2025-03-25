using GTA_SA_Effect_Editor.Interfaces;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GTA_SA_Effect_Editor
{
    public static class FxsTemplates
    {
        public static Effect Effect { get; } = new Effect()
        {
            Path = @" X:\SA\FxTools\Data\effects\gta_pc\systems/code/",
            Name = "name",
            StartSettings = new List<string>()
            {
                "NAME: name",
                "LENGTH: 0.000",
                "LOOPINTERVALMIN: 0.000",
                "LENGTH: 0.000",
                "PLAYMODE: 0",
                "CULLDIST: 1000000.000",
                "BOUNDINGSPHERE: 0.000 0.000 0.000 0.000"
            },
            EndSettings = new List<string>()
            {
                "OMITTEXTURES: 0",
                "TXDNAME: NOTXDSET"
            }
        };

        public static Prim Prim { get; } = new Prim()
        {
            StartSettings = new List<string>()
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
                ""
            },
            EndSettings = new List<string>()
            {
                "",
                "LODSTART: 0.000",
                "LODEND: 0.000"
            },
            Textures = new List<string>()
            {
                "NULL",
                "NULL",
                "NULL",
                "NULL"
            }
        };

        public static KeyFloat KeyFloat { get; } = new KeyFloat()
        {
            TIME = "TIME: 0.000",
            VAL = "VAL: 0.000"
        };

        public static class Infos
        {
            public static string SelectedInfo { get; set; }

            public static Info SIZE { get; } = new Info()
            {
                Name = "FX_INFO_SIZE_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "SIZEX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEXBIAS",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEYBIAS",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMLIFE { get; } = new Info()
            {
                Name = "FX_INFO_EMLIFE_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "LIFE",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BIAS",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMRATE { get; } = new Info()
            {
                Name = "FX_INFO_EMRATE_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "RATE",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMSPEED { get; } = new Info()
            {
                Name = "FX_INFO_EMSPEED_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "SPEED",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BIAS",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMANGLE { get; } = new Info()
            {
                Name = "FX_INFO_EMANGLE_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "MIN",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "MAX",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info FORCE { get; } = new Info()
            {
                Name = "FX_INFO_FORCE_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "FORCEX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "FORCEY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "FORCEZ",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info ROTSPEED { get; } = new Info()
            {
                Name = "FX_INFO_ROTSPEED_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "MINCW",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "MAXCW",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "MINCCW",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "MAXCCW",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info COLOURBRIGHT { get; } = new Info()
            {
                Name = "FX_INFO_COLOURBRIGHT_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "RED",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "GREEN",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BLUE",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "ALPHA",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BIAS",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMROTATION { get; } = new Info()
            {
                Name = "FX_INFO_EMROTATION_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "ANGLEMIN",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "ANGLEMAX",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMDIR { get; } = new Info()
            {
                Name = "FX_INFO_EMDIR_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "DIRX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "DIRY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "DIRZ",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMSIZE { get; } = new Info()
            {
                Name = "FX_INFO_EMSIZE_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "RADIUS",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEMINX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEMAXX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEMINY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEMAXY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEMINZ",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SIZEMAXZ",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info COLOUR { get; } = new Info()
            {
                Name = "FX_INFO_COLOUR_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "RED",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "GREEN",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BLUE",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "ALPHA",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info FRICTION { get; } = new Info()
            {
                Name = "FX_INFO_FRICTION_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "FRICTION",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info WIND { get; } = new Info()
            {
                Name = "FX_INFO_WIND_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "WINDFACTOR",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info SELFLIT { get; } = new Info()
            {
                Name = "FX_INFO_SELFLIT_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1"
            };

            public static Info DIR { get; } = new Info()
            {
                Name = "FX_INFO_DIR_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "X",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "Y",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "Z",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info HEATHAZE { get; } = new Info()
            {
                Name = "FX_INFO_HEATHAZE_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1"
            };

            public static Info SPRITERECT { get; } = new Info()
            {
                Name = "FX_INFO_SPRITERECT_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "TOP",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BOTTOM",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "LEFT",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "RIGHT",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info JITTER { get; } = new Info()
            {
                Name = "FX_INFO_JITTER_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "JITTERFACTOR",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info FLAT { get; } = new Info()
            {
                Name = "FX_INFO_FLAT_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "RX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "RY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "RZ",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "UX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "UY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "UZ",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "AX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "AY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "Az",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMPOS { get; } = new Info()
            {
                Name = "FX_INFO_EMPOS_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "X",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "Y",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "Z",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info FLOAT { get; } = new Info()
            {
                Name = "FX_INFO_FLOAT_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
            };

            public static Info NOISE { get; } = new Info()
            {
                Name = "FX_INFO_NOISE_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "NOISE",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info UNDERWATER { get; } = new Info()
            {
                Name = "FX_INFO_UNDERWATER_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1"
            };

            public static Info TRAIL { get; } = new Info()
            {
                Name = "FX_INFO_TRAIL_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "TRAILTIME",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SCREENSPACE",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info GROUNDCOLLIDE { get; } = new Info()
            {
                Name = "FX_INFO_GROUNDCOLLIDE_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "BOUNCE",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "SPEEDMULT",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "BOUNCEERROR",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info ANIMTEX { get; } = new Info()
            {
                Name = "FX_INFO_ANIMTEX_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "TEXID",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info EMWEATHER { get; } = new Info()
            {
                Name = "FX_INFO_EMWEATHER_DATA",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "WINDMIN",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "WINDMAX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "RAINMIN",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "RAINMAX",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };

            public static Info ATTRACTPT { get; } = new Info()
            {
                Name = "FX_INFO_ATTRACTPT_DATA",
                TIMEMODEPRT = "TIMEMODEPRT: 1",
                Nodes = new List<IFxsComponent>()
                {
                    new Interp()
                    {
                        Name = "POSX",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "POSY",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "POSZ",
                        LOOPED = "LOOPED: 0"
                    },
                    new Interp()
                    {
                        Name = "FORCE",
                        LOOPED = "LOOPED: 0"
                    }
                }
            };
        }

        private static Dictionary<string, IFxsComponent> s_dictionaryInfo = new Dictionary<string, IFxsComponent>()
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

        public static IFxsComponent CreateAccordingToTemplate(this string key)
        {
            if (s_dictionaryInfo.ContainsKey(key))
                return s_dictionaryInfo[key];
            else
                return null;
        }
    }
}