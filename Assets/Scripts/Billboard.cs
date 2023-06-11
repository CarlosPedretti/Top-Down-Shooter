using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // Obtén la transformación de la cámara principal
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Rota la barra de vida hacia la cámara
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
            mainCameraTransform.rotation * Vector3.up);
    }
}