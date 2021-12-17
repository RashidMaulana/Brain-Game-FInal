using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathScript : MonoBehaviour
{
    public InputField input_jawaban;
    public string kesulitan;

    Text tSisaKuis;
    [SerializeField] Text tKuis;
    //Game Objects

    public int skor;
    //Attributes
    int indeks = 0;
    [SerializeField] int skorTiapSoal;

    //Kelas soal
    [System.Serializable]
    public class soal
    {
        [SerializeField] public string pertanyaan;
        [SerializeField] public string jawaban;
    }

    [SerializeField] soal[] paketSoalMudah;
    [SerializeField] soal[] paketSoalSedang;
    [SerializeField] soal[] paketSoalSulit;

    public void tampilSoal(soal[] paketSoal)
    {
        tKuis.text = paketSoal[indeks].pertanyaan;
    }




    // Start is called before the first frame update
    void Start()
    {
        skor = PlayerPrefs.GetInt("skor");
        kesulitan = PlayerPrefs.GetString("kesulitan");
        if (kesulitan.Equals("mudah"))
        {
            tampilSoal(paketSoalMudah);
        }
        else if (kesulitan.Equals("sedang"))
        {
            tampilSoal(paketSoalSedang);
        }
        else
        {
            tampilSoal(paketSoalSulit);
        }
    }

    public void Jawab()
    {
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
        if (kesulitan.Equals("mudah"))
        {
            if (paketSoalMudah[indeks].jawaban == input_jawaban.text)
            {
                skor += skorTiapSoal;
                PlayerPrefs.SetInt("skor", skor);
            }
            if (indeks < paketSoalMudah.Length - 1)
            {
                indeks += 1;
            }

            else
            {
                SceneManager.LoadScene("MainMenu");
            }
            EventSystem.current.SetSelectedGameObject(null);
            tampilSoal(paketSoalMudah);
        }
        else if (kesulitan.Equals("sedang"))
        {
            if (paketSoalSedang[indeks].jawaban == input_jawaban.text)
            {
                skor += skorTiapSoal;
                PlayerPrefs.SetInt("skor", skor);
            }
            if (indeks < paketSoalMudah.Length - 1)
            {
                indeks += 1;
            }

            else
            {
                SceneManager.LoadScene("MainMenu");
            }

            EventSystem.current.SetSelectedGameObject(null);
            tampilSoal(paketSoalSedang);
        }
        else
        {
            if (paketSoalSulit[indeks].jawaban == input_jawaban.text)
            {
                skor += skorTiapSoal;
                PlayerPrefs.SetInt("skor", skor);
            }
            if (indeks < paketSoalMudah.Length - 1)
            {
                indeks += 1;
            }

            else
            {
                SceneManager.LoadScene("MainMenu");
            }
            EventSystem.current.SetSelectedGameObject(null);
            tampilSoal(paketSoalSulit);
        }

        // Update is called once per frame
    }
}
