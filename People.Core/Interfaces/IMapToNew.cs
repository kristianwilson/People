namespace People.Core.Interfaces
{
    public interface IMapToNew<in TSource, out TTarget>
    {
        TTarget Map(TSource source);
    }
}
