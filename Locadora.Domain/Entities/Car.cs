namespace Locadora.Domain.Entities;

public class Car : Entity
{
 
    public Car( string color, string plate, string model)
    {
       
        Color = color;
        Plate = plate;
        Model = model;
    }

    public string Color { get; private set; }
    public string Plate { get; private set; }
    public string Model { get; private set; }
    public DateTime Year { get; private set; }
}

