using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConNinja : MonoBehaviour
{
    private SpriteRenderer Render;
    private Rigidbody2D Body;
    private Animator Animar;

    private const int Normal = 0;
    private const int Sube = 1;
    private const int Planea = 2;
    private const int Corre = 3;
    private const int Desliza = 4;
    private const int Muerte = 5;

    public GameObject Disparo;
    public GameObject DisparoIzq;

    private Puntaje Scors;

    public int Vida1 = 20;
    public int Valor = 20;

    void Start()
    {
        Render = GetComponent<SpriteRenderer>();
        Body = GetComponent<Rigidbody2D>();
        Animar = GetComponent<Animator>();
        Scors = FindObjectOfType<Puntaje>();
    }


    void Update()
    {
        Body.velocity = new Vector2(0, Body.velocity.y);
        RealizarAnimacion(Normal);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Body.velocity = new Vector2(12, Body.velocity.y);
            Render.flipX = false;
            RealizarAnimacion(Corre);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Body.velocity = new Vector2(-12, Body.velocity.y);
            Render.flipX = true;
            RealizarAnimacion(Corre);
        }
        if (Input.GetKey(KeyCode.X))
        {
            RealizarAnimacion(Desliza);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            var disparoXD = Render.flipX ? DisparoIzq : Disparo;
            var posicion = new Vector2(transform.position.x, transform.position.y);
            Instantiate(disparoXD, posicion, Disparo.transform.rotation);
        }

        if (Input.GetKey(KeyCode.C))
        {
            Body.velocity = new Vector2(Body.velocity.x, -2);
            RealizarAnimacion(Planea);
        }

    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            Vida1 -= Zombis.daño;
            Debug.Log("Tengo Menos Vida");
            if (Vida1 <= 14)
            {
                Scors.MenosVida(1);
                RealizarAnimacion(Muerte);
                Debug.Log("Vida: " + Scors.getScoreVidas());
                Debug.Log("Muerto");
                Vida1 = 20;
            }

        }

        if (other.gameObject.CompareTag("PisoMuerte") && Input.GetKey(KeyCode.C))
        {
            Debug.Log("Estoy Vivo");

        }else if (other.gameObject.CompareTag("PisoMuerte")){
            Scors.MenosVida(1);
            RealizarAnimacion(Muerte);
            Debug.Log("Vida: " + Scors.getScoreVidas());
            Debug.Log("Muerto");
            Vida1 = 20;
        }



    }
    private void RealizarAnimacion(int Animaciones)
    {
        Animar.SetInteger("Estado", Animaciones);
    }

}
