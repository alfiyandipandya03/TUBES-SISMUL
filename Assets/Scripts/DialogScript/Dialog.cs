using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class Dialog
{
    [SerializeField] Dialogs[] jumlahDialog;
    [SerializeField] int newsize;

    List<string> lines;
    List<bool> isSoal;

    [System.Serializable]
    private class Dialogs
    {
        [SerializeField] string line;
        [SerializeField] bool isSoal;

        public string Line
        {
            get { return line; }
        }
        public bool IsSoal
        {
            get { return isSoal; }
        }

    }

    public void start()
    {
        jumlahDialog = new Dialogs[newsize];
    }

    public List<string> Lines()
    {
        lines = new List<string>();
        foreach (var dialog in jumlahDialog)
        {
            lines.Add(dialog.Line);
        }
        return lines;

    }

    public List<bool> IsSoal()
    {
        isSoal = new List<bool>();
        foreach (var dialog in jumlahDialog)
        {
            isSoal.Add(dialog.IsSoal);
        }
        return isSoal;
    }

    //[SerializeField] private QnA[] qnaArray;
    //[SerializeField] int newsize;
    //[System.Serializable]
    //private class QnA
    //{

    //    public string question;

    //    public string[] answers;

    //    public int correctAnswer;

    //}
    //public void Start()
    //{
    //    qnaArray = new QnA[newsize];
    //}


}
