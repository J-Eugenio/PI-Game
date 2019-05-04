using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public List<Button> btns = new List<Button>();

    void Start() {
        GetButtons();
    }
    void GetButtons() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i = 0; i < objects.Length; i++) {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }
}
