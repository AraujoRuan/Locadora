﻿namespace Locadora.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    {

    }

    public static void HasError(bool HasError, string error)
    {
        if (HasError)
        {
            Console.WriteLine(error);
        }
    }
}
