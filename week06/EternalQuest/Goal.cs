public class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"Goal|{_name}|{_description}|{_points}";
    }
}