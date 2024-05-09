using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class Seleccionar : MonoBehaviour
{
    public TMP_Text level;
    public Image imageIA;
    public Image imageHUM;
    public TMP_Text resultado;
    public TMP_Text resultado2;
    public Images[] playList;
    public int reset;
    private AudioSource playerMusic;
    private bool isHuman;
    private int randomNumber;
    private int randomNumber2;
    private int contador;
    private int inicio;
    private bool temporizadorActivo = false;
    public ScoreManager scoreManager;
    public cameraChange cameraChanger;
    public CanvasGroup canvasGroup;
    public int correcto;


    // Start is called before the first frame update
    void Start()
    {
       
        if (inicio == 0)
        {
            if (reset == 0)
            {
                scoreManager.ResetScore();
            }
            inicio += 1;
        }

        playerMusic = gameObject.GetComponent<AudioSource>();
        GenerateRandomNumber();
        GenerateRandomNumber2();
        playerMusic.clip = playList[randomNumber].canciones;
        playerMusic.Play();
        // Configura la transparencia inicial a 0
        canvasGroup.alpha = 0f;
        Juego();

    }


    void Juego()
    {
        if (contador == 0)
        {
            if (randomNumber2 == 0)
            {
                imageIA.sprite = playList[randomNumber].image1;
                imageHUM.sprite = playList[randomNumber].image2;
            }
            else
            {
                imageIA.sprite = playList[randomNumber].image2;
                imageHUM.sprite = playList[randomNumber].image1;
            }
            level.text = "Seleccione el Cuadro Correcto";
        }
        else if (contador == 1)
        {
            if (randomNumber2 == 0)
            {
                imageIA.sprite = playList[randomNumber].image3;
                imageHUM.sprite = playList[randomNumber].image4;
            }
            else
            {
                imageIA.sprite = playList[randomNumber].image4;
                imageHUM.sprite = playList[randomNumber].image3;
            }
            level.text = "Seleccione el Cuadro Correcto";
        }
        else if (contador == 2)
        {
            if (randomNumber2 == 0)
            {
                imageIA.sprite = playList[randomNumber].image5;
                imageHUM.sprite = playList[randomNumber].image6;
            }
            else
            {
                imageIA.sprite = playList[randomNumber].image6;
                imageHUM.sprite = playList[randomNumber].image5;
            }
            level.text = "Seleccione el Cuadro Correcto";
        }
        else if (contador == 3)
        {
            if (randomNumber2 == 0)
            {
                imageIA.sprite = playList[randomNumber].image7;
                imageHUM.sprite = playList[randomNumber].image8;
            }
            else
            {
                imageIA.sprite = playList[randomNumber].image8;
                imageHUM.sprite = playList[randomNumber].image7;
            }
            level.text = "Seleccione el Cuadro Correcto";
        }
        else if (contador == 4)
        {
            if (randomNumber2 == 0)
            {
                imageIA.sprite = playList[randomNumber].image9;
                imageHUM.sprite = playList[randomNumber].image10;
            }
            else
            {
                imageIA.sprite = playList[randomNumber].image10;
                imageHUM.sprite = playList[randomNumber].image9;
            }
            level.text = "Seleccione el Cuadro Correcto";
        }

    }



    void GenerateRandomNumber()
    {
        randomNumber = Random.Range(0, 5); // Genera un n�mero aleatorio entre 0 y 4
    }
    void GenerateRandomNumber2()
    {
        randomNumber2 = Random.Range(0, 2); // Genera un n�mero aleatorio entre 0 y 1
    }


    public void Boton1()
    { 

            if (reset == 0)
            {
                if (contador <= 4)
                {
                    if (randomNumber2 == 0)
                    {
                        resultado.text = "Correcto";
                        resultado2.text = "Correcto";
                        scoreManager.AddPoints(100);
                        // Inicia la animación para aumentar la transparencia a 1
                        StartCoroutine(FadeImageIn());

                        // Inicia la animación para disminuir la transparencia a 0 después de 1 segundo
                        StartCoroutine(FadeImageOut());
                        correcto = 1;
                        cameraChanger.SwitchCameras();
                }
                    else
                    {
                        resultado2.text = "Incorrecto";
                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-100);
                        correcto = 0;
                }
                    contador += 1;
                    Start();
                }
            }
            else
            {
                if (contador <= 4)
                {
                    if (randomNumber2 == 0)
                    {
                        resultado2.text = "Correcto";
                        resultado.text = "Correcto";
                        scoreManager.AddPoints(100);
                        // Inicia la animación para aumentar la transparencia a 1
                        StartCoroutine(FadeImageIn());

                        // Inicia la animación para disminuir la transparencia a 0 después de 1 segundo
                        StartCoroutine(FadeImageOut());
                        correcto = 1;
                        cameraChanger.SwitchCameras();
                }
                    else
                    {

                        resultado2.text = "Incorrecto";
                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-100);
                        correcto = 0;
                }
                    contador += 1;
                    Start();
                }
            }



        StartCoroutine(ClearResultadoText());
    }

    public void Boton2()
    {   

            if (reset == 0)
            {
                if (contador <= 4)
                {
                    if (randomNumber2 == 0)
                    {
                        resultado2.text = "Incorrecto";
                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-100);
                        correcto = 0;
                }
                    else
                    {
                        resultado2.text = "Correcto";
                        resultado.text = "Correcto";
                        scoreManager.AddPoints(100);

                        // Inicia la animación para aumentar la transparencia a 1
                        StartCoroutine(FadeImageIn());

                        // Inicia la animación para disminuir la transparencia a 0 después de 1 segundo
                        StartCoroutine(FadeImageOut());
                        correcto = 1;
                        cameraChanger.SwitchCameras();
                }
                    contador += 1;
                    Start();
                }
            }
            else
            {
                if (contador <= 4)
                {
                    if (randomNumber2 == 0)
                    {
                        resultado2.text = "Incorrecto";
                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-100);
                        correcto = 0;
                    }
                    else
                    {
                        resultado2.text = "Correcto!";
                        resultado.text = "Correcto!";
                        scoreManager.AddPoints(100);


                    // Inicia la animación para aumentar la transparencia a 1
                    StartCoroutine(FadeImageIn());

                        // Inicia la animación para disminuir la transparencia a 0 después de 1 segundo
                        StartCoroutine(FadeImageOut());
                        correcto = 1;
                        cameraChanger.SwitchCameras();
                }
                    contador += 1;
                    Start();
                }
            }



        StartCoroutine(ClearResultadoText());
    }
    IEnumerator ClearResultadoText()
    {
        yield return new WaitForSeconds(3f);
        resultado.text = ""; // Clear the text after 3 seconds
        resultado2.text = ""; // Clear the text after 3 seconds
    }
    IEnumerator FadeImageIn()
    {
        // Incrementa gradualmente la transparencia de 0 a 1 en 1 segundo
        float duration = 0.8f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 0.8f, currentTime / duration);
            yield return null;
        }
        canvasGroup.alpha = 1f; // Asegúrate de que la transparencia sea exactamente 1 al final
    }

    IEnumerator FadeImageOut()
    {
        // Disminuye gradualmente la transparencia de 1 a 0 en 1 segundo después de esperar un segundo
        yield return new WaitForSeconds(1f);
        float duration = 1f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            yield return null;
        }
        canvasGroup.alpha = 0f; // Asegúrate de que la transparencia sea exactamente 0 al final
    }
}



