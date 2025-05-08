
namespace Composite
{
    public interface ILightNodeContainer
    {
        IReadOnlyList<LightNode> GetChildren();
        int GetChildrenCount();
        void AddChild(LightNode child);
        void RemoveChild(LightNode child);
    }
}
