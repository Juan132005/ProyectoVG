using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Seleccionar : MonoBehaviour
{
    public TMP_Text level;
    public Image imageIA;
    public Image imageHUM;
    public TMP_Text resultado;
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
    private int correcto;
    public cameraChange cameraChanger;


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
        randomNumber = Random.Range(0, 5); // Genera un número aleatorio entre 0 y 4
    }
    void GenerateRandomNumber2()
    {
        randomNumber2 = Random.Range(0, 2); // Genera un número aleatorio entre 0 y 1
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "button1")
        {
            correcto =1;
        }
        if (other.tag == "button2")
        {
            correcto = 2;
        }
    }

    public void Boton1()
    { 
        if (correcto == 1) 
        { 
            if (reset == 0)
            {
                if (contador <= 4)
                {
                    if (randomNumber2 == 0)
                    {
                        resultado.text = "¡Correcto!";
                        scoreManager.AddPoints(100);

                    }
                    else
                    {

                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-100);

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
                        resultado.text = "¡Correcto!";
                        scoreManager.AddPoints(200);

                    }
                    else
                    {

                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-200);

                    }
                    contador += 1;
                    Start();
                }
            }
        }
     correcto = 0;

    }

    public void Boton2()
    {   
        if (correcto == 2)
        {
            if (reset == 0)
            {
                if (contador <= 4)
                {
                    if (randomNumber2 == 0)
                    {
                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-100);

                    }
                    else
                    {
                        resultado.text = "¡Correcto!";
                        scoreManager.AddPoints(100);


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
                        resultado.text = "Incorrecto";
                        scoreManager.AddPoints(-200);

                    }
                    else
                    {
                        resultado.text = "¡Correcto!";
                        scoreManager.AddPoints(200);


                    }
                    contador += 1;
                    Start();
                }
            }
        }
        temporizadorActivo = true;
        Invoke("LimpiarResultado", 5f);
        correcto = 0;
    }

    private void LimpiarResultado()
    {
        resultado.text = "";
        temporizadorActivo = false;
    }
}



