using System;

namespace OOP_HomeTask3.OOP_3;

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


