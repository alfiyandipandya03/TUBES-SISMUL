using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;

    [SerializeField] int letterPerSecond;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypingDialog(dialog.Lines[0]));

    }

    public IEnumerator TypingDialog(string lines)
    {
        dialogText.text = "";
        foreach (var letter in lines.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }
}
