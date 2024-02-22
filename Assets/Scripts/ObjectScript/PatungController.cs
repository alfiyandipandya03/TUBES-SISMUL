using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PatungControl : MonoBehaviour
{
    public Dialog dialog;

    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }

}
