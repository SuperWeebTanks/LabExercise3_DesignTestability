namespace ECS.Legacy
{
    public interface ISensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
}