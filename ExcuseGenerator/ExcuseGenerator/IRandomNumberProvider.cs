namespace ExcuseGenerator
{
    public interface IRandomNumberProvider
    {
        int GenerateRandom(int min, int max);
    }
}