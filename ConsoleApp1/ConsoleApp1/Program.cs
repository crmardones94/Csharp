using System;
using System.Linq;

class DniValidator
{
    static bool IsValidDni(string dni)
    {
        // Comprobar si el formato del DNI es válido
        if (!IsValidDniFormat(dni))
            return false;

        // Comprobar si la letra del DNI es válida
        return IsValidDniLetter(dni);
    }

    static bool IsValidDniFormat(string dni)
    {
        // El formato válido es 8 dígitos seguidos de una letra
        var dniRegex = new System.Text.RegularExpressions.Regex(@"^\d{8}[A-Z]$");
        return dniRegex.IsMatch(dni);
    }

    static bool IsValidDniLetter(string dni)
    {
        // Calcular la letra del DNI a partir de los 8 dígitos
        var dniNumber = int.Parse(dni.Substring(0, 8));
        var expectedLetter = GetDniLetter(dniNumber);

        // Comparar la letra calculada con la letra del DNI
        return dni[8] == expectedLetter;
    }

    static char GetDniLetter(int dni)
    {
        // Tabla de letras para DNI
        var letters = "TRWAGMYFPDXBNJZSQVHLCKE";

        // Calcular el índice de la letra en la tabla
        var index = dni % 23;

        // Devolver la letra correspondiente
        return letters[index];
    }
    public static void Main()
    {
        Console.WriteLine("Introduce Dni:");
        var dni = Console.ReadLine();
        var isValid = IsValidDni(dni);
        Console.WriteLine(isValid ? "El DNI es válido" : "El DNI no es válido");
    }
}