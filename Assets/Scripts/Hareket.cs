using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    [SerializeField]
    private float ileriHizi;
    [SerializeField]
    private float yonHizi;
    void Start()
    {
        
    }
    void Update()
    {
        float yatayEksen = Input.GetAxis("Horizontal")*yonHizi*Time.deltaTime;
        this.transform.Translate(yatayEksen, 0, ileriHizi * Time.deltaTime);
        
        
    }
}
