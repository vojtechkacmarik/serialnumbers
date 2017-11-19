namespace SerialNumbers
{
    public interface ISerialNumberSchemaDefinition
    {
        int Increment { get; }

        string Mask { get; }

        int Seed { get; }
    }
}