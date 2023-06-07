using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


public class Registration : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;
    public TMP_InputField pathologyField;
    public TMP_Text prompt2;
   

    public Button submitButton; 

    public void CallRegister(){
        StartCoroutine(Register());
    }

    IEnumerator Register(){
        
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("pathology", pathologyField.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text !="0: Success.")
        {
            Debug.Log(www.downloadHandler.text);
        } 
        else {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");
            prompt2.text="Patient registered successfully";
           
        }             
        
        
    }

    public void verifyInputs(){
        submitButton.interactable = ( nameField.text.Length >=8 && passwordField.text.Length >=8 && pathologyField.text.Length>=1);

    }
    
    
}

/*           
        non optimal
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if (www.text =="0: Success."){
            Debug.Log("Form upload complete!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
           
        }
        else
        {
            Debug.Log("User creation failed. Error#" + www.text); //will return debug log form php file 
        }

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.downloadHandler.text !="0: Success.")
        {
            Debug.Log(www.downloadHandler.text);
        } 
        else {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
           
        }
        */