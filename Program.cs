using System;
using OOP_HomeTask3.OOP_3;
using static System.Collections.Specialized.BitVector32;
public class Watertank
{
    private readonly int _capacity;
    private int _water;

    public int Capacity => _capacity;
    public int Water => _water;

    public Watertank(int capacity, int initialWater)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be a positive number.");

        if (initialWater < 0 || initialWater > capacity)
            throw new ArgumentOutOfRangeException(nameof(initialWater), "The water amount must be between 0 and the capacity.");

        _capacity = capacity;
        _water = initialWater;
    }
    public bool Fill(int amount)
    {
        if (amount <= 0 || amount > _capacity - _water)
            return false;

        _water += amount;
        return true;
    }

    public bool Use(int amount)
    {
        if (amount <= 0 || amount > _water)
            return false;

        _water -= amount;
        return true;
    }

    public int GetFreeCapacity() => _capacity - _water;
}
public class Programm
{


    public static void Main()
    {
        var tank = new Watertank(100, 40);
        Console.WriteLine($"Fill(30): {tank.Fill(30)}, water: {tank.Water}");
        Console.WriteLine($"Use(20):  {tank.Use(20)}, water: {tank.Water}");
        Console.WriteLine($"Fill(60): {tank.Fill(60)}, water: {tank.Water}");
        Console.WriteLine($"Use(0):   {tank.Use(0)}, water: {tank.Water}");
        Console.WriteLine($"Bo'sh sig'im: {tank.GetFreeCapacity()}");

        var tank2 = new Watertank(50, 10);
        Console.WriteLine($"Ikkinchi idish: {tank2.Water}");

        Console.WriteLine();

        var session = new ClassSession("C#", 40);
        Console.WriteLine($"RecordMinutes(25): {session.RecordMinutes(25)}, sarflangan: {session.SpentMinutes}");
        Console.WriteLine($"RecordMinutes(20): {session.RecordMinutes(20)}, sarflangan: {session.SpentMinutes}");

        session.PlannedMinutes = 60;
        Console.WriteLine($"Reja: {session.PlannedMinutes}, qolgan: {session.GetRemainingMinutes()}");

        try
        {
            session.PlannedMinutes = 20;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Xato: {ex.Message}");
        }

        Console.WriteLine($"Reja hali ham: {session.PlannedMinutes}");
        Console.WriteLine($"RecordMinutes(35): {session.RecordMinutes(35)}, qolgan: {session.GetRemainingMinutes()}");
    }
}

public class ClassSession
{
    private string _topic;
    private int _plannedMinutes;
    private int _spentMinutes;

    public string Topic => _topic;
    public int SpentMinutes => _spentMinutes;

    public int PlannedMinutes
    {
        get => _plannedMinutes;
        set
        {
            ValidatePlan(value, _spentMinutes);
            _plannedMinutes = value;
        }
    }

    public ClassSession(string topic, int plannedMinutes)
    {
        if (string.IsNullOrWhiteSpace(topic))
            throw new ArgumentException("The subject must not be empty.", nameof(topic));

        ValidatePlan(plannedMinutes, 0);

        _topic = topic;
        _plannedMinutes = plannedMinutes;
        _spentMinutes = 0;
    }

    public bool RecordMinutes(int minutes)
    {
        if (minutes <= 0 || minutes > _plannedMinutes - _spentMinutes)
            return false;

        _spentMinutes += minutes;
        return true;
    }

    public int GetRemainingMinutes() => _plannedMinutes - _spentMinutes;

    private static void ValidatePlan(int plan, int spent)
    {
        if (plan < 10 || plan > 120)
            throw new ArgumentOutOfRangeException(nameof(plan), "Reja 10 dan 120 gacha bo'lishi kerak.");

        if (plan < spent)
            throw new ArgumentOutOfRangeException(nameof(plan), "Reja sarflangan vaqtdan kam bo'lmasligi kerak.");
    }
}





