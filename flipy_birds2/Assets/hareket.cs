using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    Rigidbody2D fizik;
    public float hiz = 10f;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        
        TemelHareketler(yatay);
    }
    void TemelHareketler(float yatay)
    {
        fizik.velocity = new Vector2(yatay * hiz , fizik.velocity.y);
    }
}
