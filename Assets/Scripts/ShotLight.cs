using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLight : MonoBehaviour
{
    public float lightDuration = 0.1f;

    private void OnEnable()
    {
        Invoke("DisableLight", lightDuration);
    }

    private void DisableLight()
    {
        gameObject.SetActive(false);
    }
}
