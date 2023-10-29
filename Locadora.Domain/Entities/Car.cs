using Locadora.Domain.ValueObjects;

namespace Locadora.Domain.Entities;

public class Car : Entity
{
    public Car(Name _name,Color _color, Plate _plate, Model _model)
    {
        name = _name;
        color = _color;
        plate = _plate;
        model = _model;
        Isvalid = true;
    }

    public Car()
    {
    }


    public Name name { get; private set; }
    public Color color { get; private set; }
    public Plate plate { get; private set; }
    public Model model { get; private set; }
    public DateTime Year { get; private set; }
    public bool Isvalid { get; set; }
}