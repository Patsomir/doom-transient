using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlashFilter : MonoBehaviour
{
    [SerializeField]
    private Material mat = null;

    [SerializeField]
    private float intensity = 0.8f;

    [SerializeField]
    private float duration = 0.1f;

    [SerializeField]
    private PlayerStats healthSource = null;

    private int previousHealth;
    private float turnOffTimestamp;
    private bool tookDamageThisFrame;

    private void Start()
    {
        if (healthSource == null)
        {
            healthSource = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
        previousHealth = healthSource.Health;
        turnOffTimestamp = Time.time;
    }
    private void Update()
    {
        if (mat != null)
        {
            mat.SetFloat("_Intensity", intensity);
        }
        if(healthSource.Health < previousHealth)
        {
            turnOffTimestamp = Time.time + duration;
        }
        previousHealth = healthSource.Health;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (mat != null && Time.time < turnOffTimestamp)
        {
            Graphics.Blit(source, destination, mat);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
