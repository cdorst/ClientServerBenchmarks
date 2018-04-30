namespace Server.Internals.Contracts
{
    public interface IPrimitive<TValue, TKey> : IEntity<TKey> where TKey : struct
    {
        TValue Value { get; set; }
    }
}
