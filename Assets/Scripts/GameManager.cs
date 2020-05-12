using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player = null;
    private PlayerStats stats = null;
    private Camera cam = null;

    private bool hasGameEnded = false;

    private float cameraHeightAfterFall;

    [SerializeField]
    private float cameraFallDistance = 0.8f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        cam = Camera.main;
    }

    void Update()
    {
        if (stats.IsDead() && !hasGameEnded)
        {
            EndGame();
        }
        if (hasGameEnded)
        {
            CameraFall();
        }
    }

    void EndGame()
    {
        GameObject.Find("WeaponUI").SetActive(false);
        cam.GetComponent<CameraFollow>().enabled = false;
        cam.GetComponent<RedVignetteFilter>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerWeapons>().enabled = false;
        cameraHeightAfterFall = cam.transform.position.y - cameraFallDistance;
        hasGameEnded = true;
    }

    void CameraFall()
    {
        float relativeHeight = cam.transform.position.y - cameraHeightAfterFall;
        relativeHeight -= relativeHeight * Time.deltaTime * 8;
        cam.transform.position = new Vector3(cam.transform.position.x,
                                             cameraHeightAfterFall + relativeHeight,
                                             cam.transform.position.z);
    }
}
