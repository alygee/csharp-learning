using System.Globalization;

namespace UnitConverter;

/// <summary>
/// Единицы длины для конвертации в метры и обратно (скелет для дня 2).
/// </summary>
public enum LengthUnit
{
    Meter,
    Centimeter,
    Millimeter
}

public static class LengthConverter
{
    /// <summary>
    /// Переводит значение из указанной единицы в метры.
    /// </summary>
    public static double ToMeters(double value, LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Meter => value,
            LengthUnit.Centimeter => value / 100.0,
            LengthUnit.Millimeter => value / 1000.0,
            _ => throw new ArgumentOutOfRangeException(nameof(unit))
        };
    }

    /// <summary>
    /// Переводит метры в указанную единицу.
    /// </summary>
    public static double FromMeters(double meters, LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Meter => meters,
            LengthUnit.Centimeter => meters * 100.0,
            LengthUnit.Millimeter => meters * 1000.0,
            _ => throw new ArgumentOutOfRangeException(nameof(unit))
        };
    }

    /// <summary>
    /// Парсит число из строки (запятая или точка как разделитель).
    /// TODO: при желании добавить проверку на отрицательные значения или диапазон.
    /// </summary>
    public static bool TryParseLength(string? line, out double value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        string normalized = line.Trim().Replace(',', '.');
        return double.TryParse(
            normalized,
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out value);
    }

    /// <summary>
    /// Распознаёт единицу по короткому вводу (м, см, мм, m, cm, mm).
    /// TODO: добавить синонимы (метр, миллиметр) или ввод на английском полностью.
    /// </summary>
    public static bool TryParseUnit(string? line, out LengthUnit unit)
    {
        unit = LengthUnit.Meter;
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        string key = line.Trim().ToLowerInvariant();
        switch (key)
        {
            case "м":
            case "m":
            case "meter":
            case "метр":
            case "метры":
                unit = LengthUnit.Meter;
                return true;
            case "см":
            case "cm":
            case "centimeter":
            case "сантиметр":
            case "сантиметры":
                unit = LengthUnit.Centimeter;
                return true;
            case "мм":
            case "mm":
            case "millimeter":
            case "миллиметр":
            case "миллиметры":
                unit = LengthUnit.Millimeter;
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Краткое обозначение единицы для вывода.
    /// </summary>
    public static string GetUnitLabel(LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Meter => "м",
            LengthUnit.Centimeter => "см",
            LengthUnit.Millimeter => "мм",
            _ => "?"
        };
    }
}
