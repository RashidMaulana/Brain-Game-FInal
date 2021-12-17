using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    bool aktif;
    float waktu;
    TimeSpan angka;

    [SerializeField] Text tMenit;
    [SerializeField] Text tDetik;

    string tingkatKesulitan;


    void tulisTeks(Text teks, int nilai)
    {
        if(nilai < 10)
        {
            teks.text = "0" + nilai;
        }
        else
        {
            teks.text = nilai.ToString();
        }
    }

    void TimerBerjalan()
    {
        waktu -= Time.deltaTime;

        if(waktu >0)
        {
            angka = TimeSpan.FromSeconds(waktu);

            tulisTeks(tMenit, angka.Minutes);
            tulisTeks(tDetik, angka.Seconds);
        }
        else
        {
            aktif = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tingkatKesulitan = PlayerPrefs.GetString("kesulitan");
        
        if (tingkatKesulitan.Equals("mudah")) {
            waktu = 120;
        } else if (tingkatKesulitan.Equals("sedang")) {
            waktu = 90;
        } else{
            waktu = 60;
        }

        aktif = true;
        angka = TimeSpan.FromSeconds(waktu);


        tulisTeks(tMenit, angka.Minutes);
        tulisTeks(tDetik, angka.Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if(aktif == true)
        {
            TimerBerjalan();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
