using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    public void pause()
    {
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void pindahHalaman(string namaHalaman)
    {
        SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
        Time.timeScale = 1f;
        PlayerPrefs.SetString("kesulitan", "");
        PlayerPrefs.SetInt("skor", 0);
        SceneManager.LoadScene(namaHalaman);
        
    }
}
