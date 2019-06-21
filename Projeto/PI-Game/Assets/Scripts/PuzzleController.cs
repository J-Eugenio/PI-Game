using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject puzzleController;
    public GameObject BonusPuzzle;

    [SerializeField]
    private Sprite[] bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    public int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    void Awake() {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Puzzles");
    }

    void Start() {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }
    void GetButtons() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        int index = 1;
        for(int i = 0; i < objects.Length; i++) {
            btns.Add(objects[i].GetComponent<Button>());
            if(index > 4) {
                index = 1;
            }
            btns[i].image.sprite = bgImage[index];
            index++;
            btns[i].interactable = false;
        }
        StartCoroutine(EsconderPuzzle());
    }
    IEnumerator EsconderPuzzle() {
        int looper = btns.Count;
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < looper; i++) {
            btns[i].image.sprite = bgImage[0];
            btns[i].interactable = true;
        }
    }
    void AddGamePuzzles() {
        int looper = btns.Count;
        int index = 0;
        for(int i = 0; i < looper; i++) {
            if(index == looper / 2) {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners() {
         foreach(Button btn in btns) {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle() {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess) {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            btns[firstGuessIndex].interactable = false;
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];           
        } else if(!secondGuess) {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            btns[secondGuessIndex].interactable = false;
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzleMatch());
        }
    }

    IEnumerator CheckIfThePuzzleMatch() {
        yield return new WaitForSeconds(1f);

        if(firstGuessPuzzle == secondGuessPuzzle) {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfTheGameIsFinished();
        } else {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].image.sprite = bgImage[0];
            btns[secondGuessIndex].image.sprite = bgImage[0];
            btns[firstGuessIndex].interactable = true;
            btns[secondGuessIndex].interactable = true;
        }
        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished() {
        countCorrectGuesses++;
        if(countCorrectGuesses == gameGuesses) {
            //se o jogo for terminado
            Debug.Log("Game Finished");
            Debug.Log("Voce fez " + countGuesses + " tentativas para completar o jogo");
            GameManager.gm.AddScorePuzzle(countGuesses);
            puzzle.SetActive(false);
            puzzleController.SetActive(false);
            Destroy(BonusPuzzle);
            GameManager.gm.ativarTime = true;
            GameManager.gm.ativarInimigos = true;
        }
    }

    void Shuffle(List<Sprite> list) {
        for(int i = 0; i < list.Count; i++) {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
