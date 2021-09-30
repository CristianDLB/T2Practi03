using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velocidadX = 10f;
    private const string ENEMIGO = "Enemigo";

    private Rigidbody2D Body;
     private Puntaje Score;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Score = FindObjectOfType<Puntaje>();
        Destroy(this.gameObject, 2);
    }


    void Update()
    {
        Body.velocity = new Vector2(velocidadX, Body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(ENEMIGO))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Score.SumPuntos(10);
            Debug.Log("Enemigo: " + Score.getScorePuntos());
        }
    }

}
