using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class buttonController : MonoBehaviour
{   
    public Selectable button;
    public Color disabledTextColor;
    private Color originalcolor;

    void Start(){
        originalcolor=button.GetComponentInChildren<TMP_Text>().color;
    }

    void Update(){
        if(!button.interactable){
            button.GetComponentInChildren<TMP_Text>().color= disabledTextColor;
           // button.GetComponentInChildren<TMP_Text>().color.a= alphavalue;
        }
        else{
            button.GetComponentInChildren<TMP_Text>().color= originalcolor;
            //button.GetComponentInChildren<TMP_Text>().color.a= 1;
        }
    }


}
