namespace Server.Internals.Contracts
{
    public interface ILabel<TPrimitive, TValueKey, TValueType, TKey> : IPrimitive<TPrimitive, TKey>
        where TKey : struct
        where TValueKey : struct
        where TPrimitive : IPrimitive<TValueType, TValueKey>
    {
        TValueKey ValueId { get; set; }
    }
}
