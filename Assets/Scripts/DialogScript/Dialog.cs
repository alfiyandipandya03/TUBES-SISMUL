using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class Dialog
{
    public enum jwbnBenar { PilihanA, PilihanB, PilihanC }

    [SerializeField] Dialogs[] jumlahDialog;
    [SerializeField] JumlahSoal[] jumlahSoal;

    [System.Serializable]
    private class JumlahSoal
    {

        [SerializeField] string PilihanA;
        [SerializeField] string PilihanB;
        [SerializeField] string PilihanC;
        [SerializeField] public jwbnBenar jwbBnr;

        private List<string> listJawaban;

        public List<string> ListJawaban
        {
            get {
                listJawaban = new List<string> { PilihanA, PilihanB, PilihanC };
                return listJawaban; }
        }

        public jwbnBenar JwbBnr
        {
            get { return jwbBnr; }
        }

    }

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
    jwbnBenar jwbBnr;
    List<string> lines;
    List<bool> isSoal;
    List<Tuple<List<string>, jwbnBenar>> listJawaban;

    public List<Tuple<List<string>, jwbnBenar>> ListJawaban {
        get 
        {
            listJawaban = new List<Tuple<List<string>, jwbnBenar>>();
            foreach (var listjwb in jumlahSoal)
            {
                listJawaban.Add(new Tuple<List<string>, jwbnBenar>(listjwb.ListJawaban, listjwb.JwbBnr));
            }
            return listJawaban; 
        }
        
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
