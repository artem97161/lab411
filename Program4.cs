using System;

public abstract class BicycleComponent
{
    public string Name { get; set; }

    protected BicycleComponent(string name)
    {
        Name = name;
        Console.WriteLine($"{Name} створено.");
    }

    public override string ToString()
    {
        return $"Компонент велосипеда: {Name}";
    }
}

public class Wheel : BicycleComponent
{
    public Wheel(string name) : base(name) { }

    public void ReplaceWheel()
    {
        Console.WriteLine("Колесо замінено.");
    }
}

public class Frame : BicycleComponent
{
    public Frame(string name) : base(name) { }
}

public class Handlebar : BicycleComponent
{
    public Handlebar(string name) : base(name) { }

    public void TurnHandlebar()
    {
        Console.WriteLine("Руль повернуто.");
    }
}

public class Pedal : BicycleComponent
{
    public Pedal(string name) : base(name) { }

    public void IncreaseSpeed()
    {
        Console.WriteLine("Швидкість збільшено.");
    }
}

public class Bicycle
{
    public Wheel FrontWheel { get; set; }
    public Wheel BackWheel { get; set; }
    public Frame BicycleFrame { get; set; }
    public Handlebar BicycleHandlebar { get; set; }
    public Pedal BicyclePedal { get; set; }

    public Bicycle(Wheel frontWheel, Wheel backWheel, Frame frame, Handlebar handlebar, Pedal pedal)
    {
        FrontWheel = frontWheel;
        BackWheel = backWheel;
        BicycleFrame = frame;
        BicycleHandlebar = handlebar;
        BicyclePedal = pedal;
        Console.WriteLine("Велосипед створено.");
    }

    public void Ride()
    {
        Console.WriteLine("Велосипед їде.");
    }

    public void Paint(string color)
    {
        Console.WriteLine($"Велосипед перефарбовано у {color} колір.");
    }
}

class Program
{
    static void Main()
    {
        Wheel frontWheel = new Wheel("Переднє колесо");
        Wheel backWheel = new Wheel("Заднє колесо");
        Frame frame = new Frame("Рама");
        Handlebar handlebar = new Handlebar("Кермо");
        Pedal pedal = new Pedal("Педалі");

        Bicycle bicycle = new Bicycle(frontWheel, backWheel, frame, handlebar, pedal);

        handlebar.TurnHandlebar();
        pedal.IncreaseSpeed();
        bicycle.Ride();
        frontWheel.ReplaceWheel();
        bicycle.Paint("червоний");
    }
}
