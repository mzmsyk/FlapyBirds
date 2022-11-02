using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class karakterKontrol : MonoBehaviour
{
    public Sprite[] kusSprites;
    SpriteRenderer spriteRenderer;
    bool ilerigerikontrol = true;
    int kussayac=0;
    float kusanimasyonzamanı=0;
    Rigidbody2D fizik;
    int puan = 0;
    public Text puanText;
    bool oyunbitti = true;
    oyunKontrol oyunkontrol;
    AudioSource[] sesler;
    int enYuksekPuan = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunkontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<oyunKontrol>();
        sesler = GetComponents<AudioSource>();
    }

    
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            fizik.velocity = Vector2.zero;
            fizik.AddForce(new Vector2(0, 200f));
            sesler[0].Play();
            enYuksekPuan = PlayerPrefs.GetInt("enYuksekPuankayit");
        }
        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        Animasyon();
    }
    void Animasyon()
    {
        kusanimasyonzamanı += Time.deltaTime;
        if (kusanimasyonzamanı > 0.3f)
        {
            kusanimasyonzamanı = 0;
            if (ilerigerikontrol)
            {
                spriteRenderer.sprite = kusSprites[kussayac];
                kussayac++;
                if (kussayac == kusSprites.Length)
                {
                    kussayac--;
                    ilerigerikontrol = false;
                }
            }
            else
            {
                kussayac--;
                spriteRenderer.sprite = kusSprites[kussayac];
                if (kussayac == 0)
                {
                    kussayac++;
                    ilerigerikontrol = true;
                }
            }
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "puan")
        {
            puan += 100; ;
            puanText.text = "PUAN= " + puan;
            sesler[2].Play();
        }
        if (col.gameObject.tag == "engel")
        {
            oyunbitti = false;
            oyunkontrol.oyunBitti();
            sesler[1].Play();
            GetComponent<CircleCollider2D>().enabled = false;
            if (puan > enYuksekPuan)
            {
                enYuksekPuan = puan;

                PlayerPrefs.SetInt("enYuksekPuankayit", enYuksekPuan);

            }
            Invoke("anaMenuyeDon", 1.7f);

        }

    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puanKayit", puan);
        SceneManager.LoadScene("AnaMenu");

    }
}
