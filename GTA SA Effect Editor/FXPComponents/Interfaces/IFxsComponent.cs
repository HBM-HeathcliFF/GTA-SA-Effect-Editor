using System.Collections.Generic;

namespace GTA_SA_Effect_Editor.Interfaces
{
    public enum CodeBlockType
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
        CodeBlockType Type { get; }
        ICollection<IFxsComponent> Nodes { get; }

        List<string> GetLines();
        void Copy(IFxsComponent source);
        void Dispose();
    }
}
