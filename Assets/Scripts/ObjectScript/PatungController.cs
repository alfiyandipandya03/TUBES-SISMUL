using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PatungControl : MonoBehaviour
{
    public Dialog dialog;

    public void Interact()
    {
        print("ini patung");
        DialogManager.Instance.ShowDialog(dialog);
    }

}
