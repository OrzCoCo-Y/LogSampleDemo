
// 定义状态接口
interface IState
{
    void PerformAction();
}

// 具体状态类：正常状态
class NormalState : IState
{
    public void PerformAction()
    {
        Console.WriteLine("Performing normal action.");
    }
}

// 具体状态类：受伤状态
class InjuredState : IState
{
    public void PerformAction()
    {
        Console.WriteLine("Performing injured action.");
    }
}

// 具体状态类：死亡状态
class DeadState : IState
{
    public void PerformAction()
    {
        Console.WriteLine("Performing dead action.");
    }
}

// 上下文类
class Character
{
    private IState state;

    public Character(IState initialState)
    {
        this.state = initialState;
    }

    public void ChangeState(IState newState)
    {
        this.state = newState;
    }

    public void PerformAction()
    {
        this.state.PerformAction();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 创建一个角色对象，并设定初始状态为正常状态
        Character character = new Character(new NormalState());

        // 执行不同状态下的行为
        character.PerformAction();

        // 切换到受伤状态
        character.ChangeState(new InjuredState());
        character.PerformAction();

        // 切换到死亡状态
        character.ChangeState(new DeadState());
        character.PerformAction();
    }
}
