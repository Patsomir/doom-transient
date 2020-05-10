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
        transform.LookAt(toLookAt, Vector3.up);

        float yRotation = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(new Vector3(0, yRotation, 0));
    }
}
