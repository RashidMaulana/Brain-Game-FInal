using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField] private Transform puzzleField;
    [SerializeField] private GameObject btn;

    public string difficulty;

    private void Awake()
    {
        //Debug.Log(PlayerPrefs.GetString("kesulitan"));
        difficulty = PlayerPrefs.GetString("kesulitan");

        if (difficulty.Equals("mudah")){
            for(int i= 0; i <8; i++)
            {
                GameObject button = Instantiate(btn);
                button.name = "" + i;
                button.transform.SetParent(puzzleField, false);
            }

        } else if (difficulty.Equals("sedang")) {

            for (int i = 0; i < 12; i++)
            {
                GameObject button = Instantiate(btn);
                button.name = "" + i;
                button.transform.SetParent(puzzleField, false);
            }

        } else {
            for (int i = 0; i < 16; i++)
            {
                GameObject button = Instantiate(btn);
                button.name = "" + i;
                button.transform.SetParent(puzzleField, false);
            }
        } 
    }
}
