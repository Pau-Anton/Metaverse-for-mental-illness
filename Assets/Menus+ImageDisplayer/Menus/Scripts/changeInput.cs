using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class changeInput : MonoBehaviour
{
    EventSystem system;
    public Selectable fristInput;
    public Button submit;

    // Start is called before the first frame update
    void Start()
    {
        system= EventSystem.current;
        fristInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.LeftShift)){
            Selectable previous= system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if(previous!=null){
                previous.Select();
            }
        }

        else if(Input.GetKeyDown(KeyCode.Tab)){
            Selectable next= system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if(next!=null){
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return)){
            submit.onClick.Invoke();
            Debug.Log("Returned");
        }
    }
}
