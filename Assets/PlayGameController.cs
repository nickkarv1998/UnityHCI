using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameController : MonoBehaviour
{
    //fruit Variable
    public GameObject fruitContainer;
    public GameObject canvas;
    public GameObject boton;
    public GameObject premio;
    public GameObject arma;
    public GameObject Puntero;
    private Fruit[] fruits;
    private Fruit fruiThrowing;
    timer timer;
    Text countdowntext;

    // Start is called before the first frame update
    void Start()
    {
        //Get Fruit from Fruit Container
        
        fruits = fruitContainer.GetComponentsInChildren<Fruit>();
        StartCoroutine(Delayf(UnityEngine.Random.Range(2, 9)));
        countdowntext = canvas.GetComponentInChildren<Text>();
        timer = canvas.GetComponent<timer>();
        boton.active = false;
        premio.active = false;
        Puntero.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        countdowntext.text = timer.waitTime.ToString("0");
        if(timer.waitTime == 0)
            countdowntext.text = timer.playtime.ToString("0");

    }

    IEnumerator Delayf(float delay)
    {
        yield return new WaitForSeconds(delay/10);

        string waittimestring = timer.waitTime.ToString("0");
        string playtimestring = timer.playtime.ToString("0");

        //Throw Fruit
        if (waittimestring.Equals("0") && !playtimestring.Equals("0")) {
            Delayf(UnityEngine.Random.Range(2, 9));
            fruiThrowing = fruits[UnityEngine.Random.Range(0, fruits.Length)];
            fruiThrowing.transform.position = transform.position;
            fruiThrowing.showWholeFruit();
            StartCoroutine(Delayf(UnityEngine.Random.Range(2, 9)));
        }
        else
        {
            if (playtimestring.Equals("0"))
            {
                boton.active = true;
                premio.active = true;
                premio.GetComponent<Text>().text = "Te has ganado $" + UnityEngine.Random.Range(50, 500) + " pesos en descuento!";
                Puntero.active = true;
                arma.active = false;
            }
            else
            {
                StartCoroutine(Delayf(UnityEngine.Random.Range(2, 9)));
            }
        }
        
    }
}
