using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public void ShowDialog(Dialog dialog)
    {

        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypingDialog(dialog.Lines()[0]));

    }

    public IEnumerator TypingDialog(string lines)
    {
        isTyping = true;


        dialogText.text = "";
        foreach (var letter in lines.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        isTyping = false;
    }

    public void HandleUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            Debug.Log("cr line : " + currentLine + "dial line : " + dialog.Lines().Count);
            ++currentLine;
            
            if (currentLine < dialog.Lines().Count)
            {
                StartCoroutine(TypingDialog(dialog.Lines()[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }
}
