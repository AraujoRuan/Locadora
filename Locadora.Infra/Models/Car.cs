﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Infra.Models;

public partial class Car
{
    [Key]
    public Guid Id { get; set; }

    public string Color { get; set; }

    public string Plate { get; set; }

    public string Model { get; set; }

    public DateTime Year { get; set; }

    public string Brand { get; set; }
}