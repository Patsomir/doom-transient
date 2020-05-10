using static AmmoType;
public class Weapon
{
    public AmmoType Type { get; set; }
    public int Cost { get; set; }
    public float ReloadTime { get; set; }
    public Weapon(AmmoType type, int cost, float reloadTime)
    {
        Type = type;
        Cost = cost;
        ReloadTime = reloadTime;
    }
}
