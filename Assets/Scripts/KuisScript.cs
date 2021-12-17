using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KuisScript : MonoBehaviour
{
    public string kesulitan;
    //Game Objects
    [SerializeField] Text tSisaKuis;
    
    [SerializeField] Text tKuis;
    [SerializeField] Button btnA;
    [SerializeField] Text tBtnA;
    [SerializeField] Button btnB;
    [SerializeField] Text tBtnB;
    [SerializeField] Button btnC;
    [SerializeField] Text tBtnC;
    [SerializeField] Button btnD;
    [SerializeField] Text tBtnD;

    public int skor;
    //Attributes
    int indeks = 0;
    [SerializeField] int skorTiapSoal;

    //Kelas soal
    [System.Serializable] public class soal {
        [SerializeField] public string pertanyaan;
        [SerializeField] public string teksA;
        [SerializeField] public string teksB;
        [SerializeField] public string teksC;
        [SerializeField] public string teksD;
        [SerializeField] public string jawaban;
    }

    [SerializeField] soal[] paketSoalMudah;
    [SerializeField] soal[] paketSoalSedang;
    [SerializeField] soal[] paketSoalSulit;

   public void tampilSoal(soal[] paketSoal) {
        tKuis.text = paketSoal[indeks].pertanyaan;
        tBtnA.text = paketSoal[indeks].teksA;
        tBtnB.text = paketSoal[indeks].teksB;
        tBtnC.text = paketSoal[indeks].teksC;
        tBtnD.text = paketSoal[indeks].teksD;
        tSisaKuis.text = (indeks + 1) + " / " + paketSoal.Length;
    }

    void Start() {
        skor = PlayerPrefs.GetInt("skor");
        kesulitan = PlayerPrefs.GetString("kesulitan");
        if (kesulitan.Equals("mudah"))
        {
            tampilSoal(paketSoalMudah);
        } else if (kesulitan.Equals("sedang"))
        {
            tampilSoal(paketSoalSedang);
        } else
        {
            tampilSoal(paketSoalSulit);
        }
        
    }

    //Fungsi Tombol
    public void fTombol(string pilihan) {
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
        if (kesulitan.Equals("mudah")){
            if (pilihan == "A")
            {
                if (paketSoalMudah[indeks].teksA == paketSoalMudah[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "B")
            {
                if (paketSoalMudah[indeks].teksB == paketSoalMudah[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "C")
            {
                if (paketSoalMudah[indeks].teksC == paketSoalMudah[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "D")
            {
                if (paketSoalMudah[indeks].teksD == paketSoalMudah[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }

            if (indeks < paketSoalMudah.Length - 1)
            {
                indeks += 1;
            }

            else
            {
                SceneManager.LoadScene("MathGame");
            }

            EventSystem.current.SetSelectedGameObject(null);
            tampilSoal(paketSoalMudah);

        } else if(kesulitan.Equals("sedang")){
            if (pilihan == "A")
            {
                if (paketSoalSedang[indeks].teksA == paketSoalSedang[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "B")
            {
                if (paketSoalSedang[indeks].teksB == paketSoalSedang[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "C")
            {
                if (paketSoalSedang[indeks].teksC == paketSoalSedang[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "D")
            {
                if (paketSoalSedang[indeks].teksD == paketSoalSedang[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }

            if (indeks < paketSoalSedang.Length - 1)
            {
                indeks += 1;
            }

            else
            {
                SceneManager.LoadScene("MathGame");
            }

            EventSystem.current.SetSelectedGameObject(null);
            tampilSoal(paketSoalSedang);

        } else {
            if (pilihan == "A")
            {
                if (paketSoalSulit[indeks].teksA == paketSoalSulit[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "B")
            {
                if (paketSoalSulit[indeks].teksB == paketSoalSulit[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "C")
            {
                if (paketSoalSulit[indeks].teksC == paketSoalSulit[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }
            else if (pilihan == "D")
            {
                if (paketSoalSulit[indeks].teksD == paketSoalSulit[indeks].jawaban)
                {
                    skor += skorTiapSoal;
                    PlayerPrefs.SetInt("skor", skor);
                }
            }

            if (indeks < paketSoalSulit.Length - 1)
            {
                indeks += 1;
            }

            else
            {
                SceneManager.LoadScene("MathGame");
            }

            EventSystem.current.SetSelectedGameObject(null);
            tampilSoal(paketSoalSulit);
        }
    }
        

}
