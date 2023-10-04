using Locadora.Domain.ValueObjects;

namespace Locadora.Domain.Entities;

public class Car : Entity
{
    public Car(Color _color, Plate _plate, Model _model)
    {
        color = _color;
        plate = _plate;
        model = _model;
    }

    public Color color { get; private set; }
    public Plate plate { get; private set; }
    public Model model { get; private set; }
    public DateTime Year { get; private set; }
}