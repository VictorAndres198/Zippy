using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSidetoSide : MonoBehaviour
{
    [SerializeField] private float distancia = 3f;   // Distancia máxima de ida y vuelta
    [SerializeField] private float velocidad = 1f;   // Qué tan rápido se mueve

    private Vector3 posicionInicial;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        float desplazamiento = Mathf.PingPong(Time.time * velocidad, distancia);
        transform.position = new Vector3(posicionInicial.x + desplazamiento, posicionInicial.y, posicionInicial.z);
    }
}
