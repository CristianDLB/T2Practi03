using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public Text Puntos;
    public Text Vida;

    private int PuntosTotales = 0;
    private int miVida=5;


    void Start()
    {
        Puntos.text = "Puntaje: " + PuntosTotales;
        Vida.text = "Vida: " + miVida;
    }

    /*ENEMIGOS*/
    public int getScorePuntos()
    {
        return this.PuntosTotales;
    }
    public void SumPuntos(int score)
    {
        this.PuntosTotales += score;
        Puntos.text = "Enemigos: " + PuntosTotales;
    }


    /*VIDA*/

    public int getScoreVidas()
    {
        return this.miVida;
    }
    public void MenosVida(int score)
    {
        this.miVida -= score;
        Vida.text = "Vida: " + miVida;
    }


}
