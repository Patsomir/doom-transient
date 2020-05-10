using UnityEditor;
using UnityEngine;
using static AmmoType;
public class PlayerStats : MonoBehaviour
{
    private Transform player = null;
    private Vector3 previousPosition;
    private float speed;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private int armor = 0;

    [SerializeField]
    private int[] ammo = { 40, 0, 0, 0 };
    public float Speed
    {
        get { return speed; }
        private set { speed = value; }
    }

    public int Bullets
    {
        get { return ammo[0]; }
        private set { ammo[0] = value; }
    }

    public int Shells
    {
        get { return ammo[1]; }
        private set { ammo[1] = value; }
    }

    public int Rockets
    {
        get { return ammo[2]; }
        private set { ammo[2] = value; }
    }

    public int Cells
    {
        get { return ammo[3]; }
        private set { ammo[3] = value; }
    }

    void Start()
    {
        player = GetComponent<Transform>();
        previousPosition = player.position;
        Speed = 0;
    }

    void Update()
    {
        Speed = (player.position - previousPosition).magnitude / Time.deltaTime;
        previousPosition = player.position;
    }

    public void useAmmo(AmmoType type, int count, out bool isSuccessful)
    {
        if (ammo[(int)type] < count)
        {
            isSuccessful = false;
            return;
        }
        ammo[(int)type] -= count;
        isSuccessful = true;
    }
}
