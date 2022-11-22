namespace BuilderExample;

#region Engines

public class Engine
{
    public override string ToString() => "Simple Engine";
}

public class SportEngine : Engine
{
    public override string ToString() => "Sport Engine";
}

#endregion


#region Product

public class Car
{
    public int Seats { get; set; }
    public string? TripComputer { get; set; }
    public string? GPS { get; set; }
    public Engine? Engine { get; set; }
}

public class CarManual :Car
{

}



#endregion


#region Builders

public interface ICarBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(Engine engine);
    void SetTripComputer();
    void SetGPS();

}


public class CarBuilder : ICarBuilder
{
    private Car car = new();

    public void Reset()
    {
        car = new();
    }

    public void SetEngine(Engine engine)
    {
        car.Engine = engine;
    }

    public void SetGPS()
    {
        car.GPS = "GPS";
    }

    public void SetSeats(int number)
    {
        car.Seats = number;
    }

    public void SetTripComputer()
    {
        car.TripComputer = "TripComputer";
    }

    public Car GetResult() => car;
}

public class CarManualBuilder : ICarBuilder
{
    private CarManual manual = new();

    public void Reset()
    {
        manual = new();
    }

    public void SetEngine(Engine engine)
    {
        manual.Engine = engine;
    }

    public void SetGPS()
    {
        manual.GPS = "GPS";
    }

    public void SetSeats(int number)
    {
        manual.Seats = number;
    }

    public void SetTripComputer()
    {
        manual.TripComputer = "TripComputer";
    }

    public CarManual GetResult() => manual;
}


#endregion


#region Directory

public class Director
{
    public CarManual MakeSUV(CarManualBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine(new Engine());
        return builder.GetResult();
    }

    public Car MakeSportCar(CarBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine(new SportEngine());
        builder.SetTripComputer();
        builder.SetGPS();
        return builder.GetResult();
    }

}


#endregion

public class Program
{
    public static void Main()
    {
        CarBuilder carBuilder = new();
        CarManualBuilder carManualBuilder = new();
        Director director = new();

        CarManual carManual = director.MakeSUV(carManualBuilder);
        Car sportCar = director.MakeSportCar(carBuilder);

        Console.WriteLine(carManual.Engine?.ToString());
        Console.WriteLine(sportCar.Engine?.ToString());
    }
}