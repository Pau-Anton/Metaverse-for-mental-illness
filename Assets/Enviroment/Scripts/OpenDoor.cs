using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{


    public Animator animDoor;
    private bool inZone, active;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //para que se pueda abrir la puerta se debe estar en la zona de collison y pulsar la tecla E
        if(animDoor.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
            if (Input.GetKeyDown(KeyCode.E) && inZone==true)
            {   

                active = !active;

                if (active == true)
                {   //el cambio de la variable DoorOpen provoca la transici�n de cerrar y abrir. 
                    animDoor.SetBool("DoorOpen", true);
                }
                if (active == false)
                {
                    animDoor.SetBool("DoorOpen", false);
                }
            }
        }

    }
    

    //estar en la zona de collison activa el localizador para abrir
    private void OnTriggerEnter(Collider other)
    {   
 
        if(other.tag== "Player")
        {
            inZone = true;
            DBmanager.prompt="Press E to open/close";
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inZone = false;
            DBmanager.prompt="";
        }

    }
}
