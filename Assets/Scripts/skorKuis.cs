using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skorKuis : MonoBehaviour
{

    [SerializeField] Text tSkor;
    private int skor;

    // Start is called before the first frame update
    void Start()
    {
        skor = PlayerPrefs.GetInt("skor");
        tSkor.text = skor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        skor = PlayerPrefs.GetInt("skor");
        tSkor.text = skor.ToString();
    }
}
