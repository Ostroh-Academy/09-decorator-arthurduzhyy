public abstract class Component
{
    public abstract string Operation();
}

class ConcreteComponent : Component
{
    public override string Operation() => "ConcreteComponent";
}

abstract class Decorator : Component
{
    protected Component _component;

    public Decorator(Component component)
    {
        _component = component;
    }

    public void SetComponent(Component component)
    {
        _component = component;
    }

    public override string Operation()
    {
        if (_component != null)
            return _component.Operation();
        return string.Empty;
    }
}

class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(Component comp) : base(comp) { }

    public override string Operation() => $"ConcreteDecoratorA({base.Operation()})";
}

class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(Component comp) : base(comp) { }

    public override string Operation() => $"ConcreteDecoratorB({base.Operation()})";
}

public class Client
{
    public void ClientCode(Component component) => Console.WriteLine("RESULT: " + component.Operation());
}

class Program
{
    public static void Main(string[] args)
    {
        var client = new Client();

        var simple = new ConcreteComponent();
        Console.WriteLine("Client: I get a simple component:");
        client.ClientCode(simple);
        Console.WriteLine();

        var decorator1 = new ConcreteDecoratorA(simple);
        var decorator2 = new ConcreteDecoratorB(decorator1);
        Console.WriteLine("Client: Now I've got a decorated component:");
        client.ClientCode(decorator2);
    }
}