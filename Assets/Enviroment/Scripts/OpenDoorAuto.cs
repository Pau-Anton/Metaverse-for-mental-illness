using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAuto : MonoBehaviour 
{ 

    public Animator Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //cada vez que se entre o salga del trigger se acciona la animaci�n de abrir o cerrar la puerta 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
             Door.Play("Open");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Door.Play("Close");
        }

    }
}
