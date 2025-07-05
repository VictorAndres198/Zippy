using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AParalallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier = 0.5f;
    private Transform camara;
    private Vector3 ultimaPosCamara;

    void Start()
    {
        camara = Camera.main.transform;
        ultimaPosCamara = camara.position;
    }

    void LateUpdate()
    {
        Vector3 movimientoCamara = camara.position - ultimaPosCamara;
        transform.position += new Vector3(movimientoCamara.x * parallaxMultiplier, movimientoCamara.y * parallaxMultiplier, 0);
        ultimaPosCamara = camara.position;
    }
}
