using UnityEngine;

public class cameraChange : MonoBehaviour
{
    public Camera cameraToDisable;
    public Camera cameraToEnable;

    // Variable para almacenar el estado actual de la c�mara
    private bool cameraEnabled = false;

    void Start()
    {
        // Aseg�rate de que las c�maras inicialmente est�n configuradas correctamente
        if (cameraToDisable != null)
            cameraToDisable.enabled = true; // Si ya est� deshabilitada, aseg�rate de que est� activada
        if (cameraToEnable != null)
            cameraToEnable.enabled = false; // Si ya est� habilitada, aseg�rate de que est� desactivada

    }

    public void SwitchCameras()
    {
        // Si la c�mara est� activada, desact�vala y activa la otra c�mara
        if (cameraEnabled)
        {
            if (cameraToDisable != null)
                cameraToDisable.enabled = true;

            if (cameraToEnable != null)
                cameraToEnable.enabled = false;

            // Actualiza el estado de la c�mara
            cameraEnabled = false;
        }
        else // Si la c�mara est� desactivada, activa esta c�mara y desactiva la otra c�mara
        {
            if (cameraToDisable != null)
                cameraToDisable.enabled = false;

            if (cameraToEnable != null)
                cameraToEnable.enabled = true;

            // Actualiza el estado de la c�mara
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
