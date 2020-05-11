using System.Transactions;
using UnityEngine;
using UnityEngine.EventSystems;
using static AmmoType;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private PlayerStats ammo = null;

    private Weapon[] weapons = null;

    private int currentWeapon = 0;

    private float currentReloadTimestamp = 0;

    private Camera cam = null;
    public bool IsRealoading { get; private set; } = false;
    public bool ShotThisFrame { get; private set; } = false;

    void Start()
    {
        weapons = new Weapon[6];
        weapons[0] = new Pistol();
        cam = Camera.main;
    }
    void Update()
    {
        IsRealoading = Time.time < currentReloadTimestamp;

        if (Input.GetMouseButtonDown(0) && !IsRealoading)
        {
            bool wasSuccessful;
            ammo.useAmmo(weapons[currentWeapon].Type, weapons[currentWeapon].Cost, out wasSuccessful);
            ShotThisFrame = wasSuccessful;
            if (wasSuccessful)
            {
                Vector3 position = cam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, cam.nearClipPlane));
                Vector3 direction = cam.transform.forward;
                weapons[currentWeapon].ShootFrom(position, direction);
                currentReloadTimestamp = Time.time + weapons[currentWeapon].ReloadTime;
            }
        } else
        {
            ShotThisFrame = false;
        }
    }
}

class Pistol : Weapon
{
    public Pistol() : base(AmmoType.BULLET, 1, 10, 5, 0.5f) { }

    public override void ShootFrom(Vector3 position, Vector3 direction)
    {
        RaycastHit target;
        if(Physics.Raycast(position, direction, out target))
        {
            if (target.collider.CompareTag("Demon"))
            {
                DemonStats demon = target.collider.gameObject.GetComponent<DemonStats>();
                demon.TakeDamage(GetEffectiveDamage());
            }
        }
    }
        
}
