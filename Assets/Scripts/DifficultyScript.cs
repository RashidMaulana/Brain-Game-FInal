using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    public string difficulty;
    [SerializeField] Button btnmudah;
    [SerializeField] Button btnsedang;
    [SerializeField] Button btnsulit;


    private void Start()
    {
        btnmudah.onClick.AddListener(() => {
            difficulty = "mudah";
            PlayerPrefs.SetString("kesulitan", difficulty);
            SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
            SceneManager.LoadScene("PuzzleGame");
        });

        btnsedang.onClick.AddListener(() => {
            difficulty = "sedang";
            PlayerPrefs.SetString("kesulitan", difficulty);
            SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
            SceneManager.LoadScene("PuzzleGame");
        });

        btnsulit.onClick.AddListener(() => {
            difficulty = "sulit";
            PlayerPrefs.SetString("kesulitan", difficulty);
            SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
            SceneManager.LoadScene("PuzzleGame");
        });
    }

}
