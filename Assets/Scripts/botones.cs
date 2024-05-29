using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void IrAEscena1()
    {
        SceneManager.LoadScene(1);
    }

    public void IrAEscena0()
    {
        SceneManager.LoadScene(0);
    }
    public void IrABotones()
    {
        SceneManager.LoadScene(4);
    }

    public void VolverAEscena1()
    {
        SceneManager.LoadScene(1);
    }
}
