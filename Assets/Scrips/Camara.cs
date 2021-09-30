using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform Jugador;

    void Start()
    {
    }

    void Update()
    {
        var x = Jugador.position.x + 4f;
        var y = Jugador.position.y + 2f;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
