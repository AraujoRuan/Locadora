using System.ComponentModel.DataAnnotations.Schema;
using Locadora.Domain.ValueObjects;

namespace Locadora.Domain.Entities;

[Table("Car")]
public class Car : Entity
{
    public Car(Brand _brand, Color _color, Plate _plate, Model _model)
    {
        brand = _brand;
        color = _color;
        plate = _plate;
        model = _model;
        
    }

    public Car()
    {
    }

    public Guid Id { get; private set; }
    public Brand brand { get; private set; }
    public Color color { get; private set; }
    public Plate plate { get; private set; }
    public Model model { get; private set; }
    public DateTime Year { get; private set; }

}