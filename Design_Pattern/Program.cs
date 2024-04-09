
// 策略接口
interface IStrategy
{
    void Execute();
}

// 具体策略类：正常策略
class NormalStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Performing normal action.");
    }
}

// 具体策略类：受伤策略
class InjuredStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Performing injured action.");
    }
}

// 上下文类
class Character
{
    private IStrategy strategy;

    public Character(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void PerformAction()
    {
        this.strategy.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 创建一个角色对象，并设定初始策略为正常策略
        Character character = new Character(new NormalStrategy());

        // 执行不同策略下的行为
        character.PerformAction();

        // 切换到受伤策略
        character.SetStrategy(new InjuredStrategy());
        character.PerformAction();
    }
}

