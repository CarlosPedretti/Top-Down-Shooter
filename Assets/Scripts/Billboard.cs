using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // Obt�n la transformaci�n de la c�mara principal
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Rota la barra de vida hacia la c�mara
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
            mainCameraTransform.rotation * Vector3.up);
    }
}