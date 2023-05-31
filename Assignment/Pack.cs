namespace Assignment;

public class Pack
{
    const float EPSILON = 0.0001f;

    private readonly List<InventoryItem> _items; // You can use another data structure here if you prefer.
    // You may need another private member variable if you use an array data structure.

    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;

    private float _currentVolume;
    private float _currentWeight;

    // Default constructor sets the maxCount to 10 
    // maxVolume to 20 
    // maxWeight to 30
    public Pack() : this(10, 20, 30) { }

    // This constructor is not complete, but it is a good start.
    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        if (maxCount < 0 || maxVolume < EPSILON || maxWeight < EPSILON)
        {
            throw new ArgumentOutOfRangeException($"An item can't have {maxCount} max count,  {maxVolume} maxvolume or {maxWeight} max weight");
        }
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
        _items = new List<InventoryItem>();
        _currentVolume = 0f;
        _currentWeight = 0f;
    }

    // This is called a getter
    public int GetMaxCount()
    {
        return _maxCount;
    }

    //add item to the list
    public bool Add(InventoryItem item)
    {
        //check the count will over or not
        if (GetCurrentItemsCount() >= _maxCount)
        {
            Console.WriteLine("Cannot more items now because the array already put the maximum count of items into it.");
            return false;
        }

        float weight = item.GetWeight();
        float volume = item.GetVolume();
        _currentWeight += weight;
        _currentVolume += volume;

        // check the weight or volume will over or not.
        if (_currentWeight > _maxWeight || _currentVolume > _maxVolume)
        {
            Console.WriteLine($"Cannot add this item:{item.GetName} because it will over max weight or max volume.");
            return false;
        }
        _items.Add(item);
        return true;
    }

    // Implement this class
    public override string ToString()
    {
        return ($"Pack is currently at {GetCurrentItemsCount()}/{_maxCount} items, {_currentWeight}/{_maxWeight} weight, and {_currentVolume}/{_maxVolume} volume");
    }

    //return the amount the items
    private int GetCurrentItemsCount()
    {
        return _items.Count;
    }
}

// Come back to this once we learn about abstract classes.
public class InventoryItem
{
    private readonly string _name;
    private readonly float _volume;
    private readonly float _weight;

    public InventoryItem(string name, float volume, float weight)
    {
        if (volume <= 0f || weight <= 0f)
        {
            throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException($"An item can't have empty name.");
        }
        _name = name;
        _volume = volume;
        _weight = weight;
    }

    // Getters
    public float GetVolume()
    {
        return _volume;
    }

    // return weight
    public float GetWeight()
    {
        return _weight;
    }

    // return name
    public string GetName()
    {
        return _name;
    }
}

// Implement these classes - each inherits from InventoryItem
// 1 line of code each - call base class constructor with appropriate arguments
public class Arrow : InventoryItem
{
    public Arrow() : base("Arrow", 0.05f, 0.1f) { }

    //add contructor to test 
    public Arrow(float volume, float weight) : base("Arrow", volume, weight) { }
}

public class Bow : InventoryItem
{
    public Bow() : base("Bow", 1f, 4f) { }
}

public class Rope : InventoryItem
{
    public Rope() : base("Rope", 1f, 1.5f) { }
}

public class Water : InventoryItem
{
    public Water() : base("Water", 2f, 3f) { }
}

public class Food : InventoryItem
{
    public Food() : base("Food", 1f, 0.5f) { }
}

public class Sword : InventoryItem
{
    public Sword() : base("Sword", 5f, 3f) { }
}
