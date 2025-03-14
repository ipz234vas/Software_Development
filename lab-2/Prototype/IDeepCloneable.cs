namespace Prototype
{
    public interface IDeepCloneable<T> where T : class
    {
        T DeepClone(IDictionary<T, T>? copies = null);
    }
}
