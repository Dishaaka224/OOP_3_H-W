using System;
using System.Reflection.Metadata;
namespace OOP_HomeTask3.OOP_3;

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

