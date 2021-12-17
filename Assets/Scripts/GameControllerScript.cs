using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public List<Button> btns = new List<Button>();
    [SerializeField] Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    private bool firstGuess, secondGuess;

    private string firstGuessPuzzle, secondGuessPuzzle;
    private int firstGuessIndex, secondGuessIndex;
    private int gameGuess, correctGuess;

    public int skor = 0;
    [SerializeField] Text tSkor;

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Sampah");
    }

    void Start()
    {
        GetButtons();
        AddListener();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuess = gamePuzzles.Count / 2;
    }

    private void Update()
    {
        tSkor.text = skor.ToString();
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {

            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListener()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => pickAPuzzle());
        }
    }

    public void pickAPuzzle()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
            btns[firstGuessIndex].interactable = false;
        } else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            SFXManager.sfx.Audio.PlayOneShot(SFXManager.sfx.click);
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            StartCoroutine(CheckIfThePuzzleMatch());

        }
    }


    IEnumerator CheckIfThePuzzleMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);
            skor += 10;
            PlayerPrefs.SetInt("skor", skor);
            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = true;
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        correctGuess++;
        if(correctGuess == gameGuess)
        {
            SceneManager.LoadScene("KuisGame");
        }
    }


    void Shuffle(List<Sprite> list)
    {
        for (int i= 0; i<list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
