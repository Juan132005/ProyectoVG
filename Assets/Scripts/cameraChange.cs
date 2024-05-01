using UnityEngine;

public class cameraChange : MonoBehaviour
{
    public Camera cameraToDisable;
    public Camera cameraToEnable;

    // Variable para almacenar el estado actual de la cámara
    private bool cameraEnabled = false;

    void Start()
    {
        // Asegúrate de que las cámaras inicialmente estén configuradas correctamente
        if (cameraToDisable != null)
            cameraToDisable.enabled = true; // Si ya está deshabilitada, asegúrate de que esté activada
        if (cameraToEnable != null)
            cameraToEnable.enabled = false; // Si ya está habilitada, asegúrate de que esté desactivada

    }

    public void SwitchCameras()
    {
        // Si la cámara está activada, desactívala y activa la otra cámara
        if (cameraEnabled)
        {
            if (cameraToDisable != null)
                cameraToDisable.enabled = true;

            if (cameraToEnable != null)
                cameraToEnable.enabled = false;

            // Actualiza el estado de la cámara
            cameraEnabled = false;
        }
         // Si la cámara está desactivada, activa esta cámara y desactiva la otra cámara
        {
            if (cameraToDisable != null)
                cameraToDisable.enabled = false;

            if (cameraToEnable != null)
                cameraToEnable.enabled = true;

            // Actualiza el estado de la cámara
            cameraEnabled = true;
        }
    }
    public bool IsCameraToEnableEnabled()
    {
        if (cameraToEnable != null)
        {
            return cameraToEnable.enabled;
        }
        else
        {
            return false; // Retorna false si cameraToEnable es nula
        }
    }
}
