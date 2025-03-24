using System.Collections.Generic;

namespace GTA_SA_Effect_Editor.Interfaces
{
    public enum FxsComponentType
    {
        EFFECT,
        PRIM,
        INFO,
        INTERP,
        KEYFLOAT
    }

    public interface IFxsComponent
    {
        string Name { get; }
        FxsComponentType Type { get; }
        ICollection<IFxsComponent> Nodes { get; }

        List<string> GetLines();
        void Copy(IFxsComponent source);
        void Dispose();
    }
}
