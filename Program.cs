public abstract class GraphicComponent
{
    public abstract string Draw();
}

class SimpleGraphic : GraphicComponent
{
    public override string Draw() => "Simple Graphic";
}

abstract class GraphicDecorator : GraphicComponent
{
    protected GraphicComponent _component;

    public GraphicDecorator(GraphicComponent component)
    {
        _component = component;
    }

    public void SetComponent(GraphicComponent component)
    {
        _component = component;
    }

    public override string Draw()
    {
        if (_component != null)
            return _component.Draw();
        return string.Empty;
    }
}

class ShadowDecorator : GraphicDecorator
{
    public ShadowDecorator(GraphicComponent component) : base(component) { }

    public override string Draw() => $"Shadow({base.Draw()})";
}

class GradientDecorator : GraphicDecorator
{
    public GradientDecorator(GraphicComponent component) : base(component) { }

    public override string Draw() => $"Gradient({base.Draw()})";
}

public class Client
{
    public void ClientCode(GraphicComponent component) => Console.WriteLine("RESULT: " + component.Draw());
}

class Program
{
    public static void Main(string[] args)
    {
        var client = new Client();

        var simple = new SimpleGraphic();
        Console.WriteLine("Client: I get a simple graphic:");
        client.ClientCode(simple);
        Console.WriteLine();

        var withShadow = new ShadowDecorator(simple);
        var withGradient = new GradientDecorator(withShadow);
        Console.WriteLine("Client: Now I've got a decorated graphic:");
        client.ClientCode(withGradient);
    }
}