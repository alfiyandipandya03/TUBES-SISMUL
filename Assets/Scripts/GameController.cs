using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Play, Dialog }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject GameUi;
    GameState state;


    // Update is called once per frame
    void Update()
    {
        if (state == GameState.Play)
        {
            GameUi.SetActive(true);
            playerController.HandleUpdate();
        } else if (state == GameState.Dialog)
        {
            GameUi.SetActive(false);
        }
    }
}
