using UnityEngine;

public class SpriteFaceHandler : MonoBehaviour
{
    [SerializeField]
    Transform toLookAt = null;

    private void Start()
    {
        if(toLookAt == null)
        {
            toLookAt = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.LookAt(toLookAt);

        float yRotation = transform.rotation.eulerAngles.y + 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, yRotation, 0));
    }
}
