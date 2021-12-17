using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip click;
    public static SFXManager sfx;

    private void Awake()
    {
        if (sfx != null && sfx != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfx = this;

        DontDestroyOnLoad(this);
    }
}
