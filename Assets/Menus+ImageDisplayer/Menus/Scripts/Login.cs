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
        StartCoroutine(LogIn());
    }

    public void GoToMainmenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator LogIn(){

        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();
        string wwwtext = www.downloadHandler.text;
        
        Debug.Log(wwwtext);

        if (wwwtext[0] !='0') //failed
        {
            Debug.Log("User login failed. Error #"+ wwwtext);
        }
        else{
            //extract info from server to DBmanager
            DBmanager.username = nameField.text;
            DBmanager.pathology = int.Parse(wwwtext.Split('\t')[1]); 
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        
    }

    public void verifyInputs(){
        submitButton.interactable = ( nameField.text.Length >=8 && passwordField.text.Length >=8 );
    }
}
