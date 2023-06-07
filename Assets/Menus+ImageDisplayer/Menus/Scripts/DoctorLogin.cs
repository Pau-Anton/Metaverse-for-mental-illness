using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


public class DoctorLogin : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;
    
    public Button submitButton; 

    public void CallLogin(){
        StartCoroutine(LogIn());
    }
    
    public void GoToMainmenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator LogIn(){

        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/doctorlogin.php", form);
        yield return www.SendWebRequest();
        string wwwtext = www.downloadHandler.text;
        
        Debug.Log(wwwtext);

        if (wwwtext[0] !='0') //failed
        {
            Debug.Log("User login failed. Error #"+ wwwtext);
        }
        else{
            //extract info from server to DBmanager
            DBmanager.doctor = nameField.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        
    }

    public void verifyInputs(){
        submitButton.interactable = ( nameField.text.Length >=4 && passwordField.text.Length >=4 );
    }
}

/*
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();
        string wwwtext = www.downloadHandler.text;
        
        Debug.Log(wwwtext);

        if (www.text[0] !='0') //failed
        {
            Debug.Log("User login failed. Error #"+ www.text);
        }
        else{
            DBmanager.username = nameField.text;
            DBmanager.pathology = int.Parse(www.downloadHandler.text.Split('\t')[1]); //get information from web 
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
*/
