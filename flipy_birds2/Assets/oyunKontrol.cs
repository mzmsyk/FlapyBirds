using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunKontrol : MonoBehaviour
{
    public GameObject gokyuzu1;
    public GameObject gokyuzu2;
    public float arkaplanhiz = -1.5f;
    Rigidbody2D fizik1;
    Rigidbody2D fizik2;
    float uzunluk=0;
    public GameObject engel;
    public int kacAdetEngel = 5;
    GameObject[] engeller;
    float degisimzaman = 0;
    int sayac = 0;
    bool oyunbitti = true;
    void Start()
    {
        fizik1 = gokyuzu1.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzu2.GetComponent<Rigidbody2D>();
        fizik1.velocity = new Vector2(arkaplanhiz, 0);
        fizik2.velocity = new Vector2(arkaplanhiz, 0);
        uzunluk = gokyuzu1.GetComponent<BoxCollider2D>().size.x;
        engeller = new GameObject[kacAdetEngel];
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D fizikengel = engeller[i].AddComponent<Rigidbody2D>();
            fizikengel.gravityScale = 0;
            fizikengel.velocity = new Vector2(arkaplanhiz, 0);
        }
    }

    
    void Update()
    {
        if (oyunbitti)
        {
            if (gokyuzu1.transform.position.x <= -uzunluk)
            {
                gokyuzu1.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzu2.transform.position.x <= -uzunluk)
            {
                gokyuzu2.transform.position += new Vector3(uzunluk * 2, 0);
            }
            //...............................................................................................
            degisimzaman += Time.deltaTime;
            if (degisimzaman > 2f)
            {
                degisimzaman = 0;
                float yEksenim = Random.Range(-5f, -3.5f);
                engeller[sayac].transform.position = new Vector3(12, yEksenim);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }
            }
        }
        
    }
    public void oyunBitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }
        oyunbitti = false;
    }
}
