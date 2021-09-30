using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombis : MonoBehaviour
{
    private SpriteRenderer Render;
    private Rigidbody2D Body;
    private Animator Animar;

    private const int Correr = 0;

    public float velocidadX = 2f;

    public static int da�o;
    public int refeDa�o = 2;


    void Start()
    {
        da�o = refeDa�o;
        Render = GetComponent<SpriteRenderer>();
        Body = GetComponent<Rigidbody2D>();
        Animar = GetComponent<Animator>();
    }



    void Update()
    {
        Body.velocity = new Vector2(velocidadX, Body.velocity.y);
        RealizarAnimacion(Correr);

    }


    private void RealizarAnimacion(int Animaciones)
    {
        Animar.SetInteger("Estado1", Animaciones);
    }
}
