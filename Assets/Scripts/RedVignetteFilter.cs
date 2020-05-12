using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedVignetteFilter : MonoBehaviour
{
    [SerializeField]
    private Material mat = null;

    [SerializeField]
    private float minIntensity = 0.1f;

    [SerializeField]
    private float maxIntensity = 0.7f;

    [SerializeField]
    private float pulsePerSecond = 1.5f;

    [SerializeField]
    private PlayerStats healthSource = null;

    [SerializeField]
    private int healthThreshold = 21;

    private void Start()
    {
        if(healthSource == null)
        {
            healthSource = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        }
    }
    private void Update()
    {
        if (mat != null)
        {
            float intensity = maxIntensity - 
                              (pulsePerSecond * Time.time * (maxIntensity - minIntensity)) %
                              (maxIntensity - minIntensity);

            mat.SetFloat("_Intensity", intensity);
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (mat != null && healthSource.Health < healthThreshold)
        {
            Graphics.Blit(source, destination, mat);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
