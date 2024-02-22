using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;
    [SerializeField] GameObject jawabanBox;
    [SerializeField] TMP_Text[] jawabanText;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;
    public event Action OnShowQuestion;
    public event Action OnCloseQuestion;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    int currentQuestion = 0;
    bool isTyping;

    public void ShowQuestionDialog(Dialog dialog)
    {
        OnShowQuestion?.Invoke();

        List<string> listJawaban = dialog.ListJawaban[currentQuestion].Item1;
        Dialog.jwbnBenar jwbnBenar = dialog.ListJawaban[currentQuestion].Item2;
        dialogBox.SetActive(true);
        jawabanBox.SetActive(true);

        Debug.Log(listJawaban[0]);

        StartCoroutine(TypingJawaban(0, listJawaban[0]));
        StartCoroutine(TypingJawaban(1, listJawaban[1]));
        StartCoroutine(TypingJawaban(2, listJawaban[2]));

        ++currentQuestion;
    }

    public IEnumerator TypingJawaban(int index, string jawaban)
    {
        isTyping = true;


        jawabanText[index].text = "";

            foreach (var letter in jawaban)
            {
                jawabanText[index].text += letter;
                yield return new WaitForSeconds(1f / lettersPerSecond);
            }

        isTyping = false;
    }

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
                if (dialog.IsSoal()[currentLine])
                {
                    if (currentQuestion < dialog.ListJawaban.Count)
                    {
                        StartCoroutine(TypingDialog(dialog.Lines()[currentLine]));
                        ShowQuestionDialog(dialog);
                    }
                    
                }
                else
                {
                    StartCoroutine(TypingDialog(dialog.Lines()[currentLine]));
                }
                
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
