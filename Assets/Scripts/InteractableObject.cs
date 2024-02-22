using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public bool isInrange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject interactText;

    bool isInteract;
    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            isInteract = true;
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            isInteract = false;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (isInrange)
        {
            if (Input.GetKeyDown(interactKey) && !isInteract)
            {
                
                interactAction.Invoke();
                print("Nice Interaction!!!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("masuk");
        if (collision.gameObject.CompareTag("Player"))
        {
            isInrange = true;
            interactText.SetActive(true);
            Debug.Log("You're in interaction range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInrange = false;
            interactText.SetActive(false);
            Debug.Log("You're leaving interaction range");
        }
    }
}
