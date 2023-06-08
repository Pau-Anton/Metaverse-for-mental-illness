using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


public class Login : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;
    
    public Button submitButton; 

    public void CallLogin(){
        LogIn();
    }

    public void GoToMainmenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void LogIn(){

        if(nameField.text=="userdemo" && passwordField.text=="userdemo"){
        
            DBmanager.username = nameField.text;
            DBmanager.pathology = 0; 
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    
        
    }

    public void verifyInputs(){
        submitButton.interactable = ( nameField.text.Length >=8 && passwordField.text.Length >=8 );
    }
}
