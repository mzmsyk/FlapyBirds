using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenu : MonoBehaviour
{
    //public Text enYuksekPuanText;
    //public Text puanText;
    public Text enYuksekPuanText;
    public Text puanText;
    
    void Start()
    {
        int enYuksekSkor = PlayerPrefs.GetInt("enYuksekPuankayit");
        int puan = PlayerPrefs.GetInt("puanKayit");
        enYuksekPuanText.text = "EN YÜKSEK PUAN= " + enYuksekSkor;
        puanText.text = "PUAN= " + puan;
        
    }


    void Update()
    {
        
    }
    public void oyunaGit()
    {
        SceneManager.LoadScene("Level1");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }
}
