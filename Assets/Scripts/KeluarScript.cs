using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeluarScript : MonoBehaviour
{
   public void KeluarGame()
    {
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
        PlayerPrefs.SetInt("skor", 0);
        PlayerPrefs.SetString("kesulitan", "");
        Application.Quit();
        Debug.Log("Keluar!");
    }
}
