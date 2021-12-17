using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSkor : MonoBehaviour
{
   
    public void resetSkor()
    {
        PlayerPrefs.SetInt("skor", 0);
        PlayerPrefs.SetString("kesulitan", "");
    }

   
}
