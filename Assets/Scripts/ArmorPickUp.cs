using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    [SerializeField]
    private int value = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
            if (stats.CanTakeArmor())
            {
                stats.TakeArmor(value);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
