using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject GameUi;
    GameState state;


    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            GameUi.SetActive(true);
            playerController.HandleUpdate();
        }
        if (state == GameState.Dialog)
        {
            GameUi.SetActive(false);
            DialogManager.Instance.HandleUpdate();
        }

    }
}
