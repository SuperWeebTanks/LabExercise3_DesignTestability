namespace ECS.Legacy
{
    public interface ISensorCtrl
    {
        int GetTemp();
        bool RunSelfTest();
    }
}