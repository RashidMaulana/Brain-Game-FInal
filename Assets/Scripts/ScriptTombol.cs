using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptTombol : MonoBehaviour
{
    public void pindahHalaman(string namaHalaman)
    {
        SceneManager.LoadScene(namaHalaman);
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
    }

    public void scale(float scale)
    {
        transform.localScale = new Vector2(1 / scale, 1 * scale);
    }
}
