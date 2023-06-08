using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Mainmenu : MonoBehaviour
{
    public TMP_Text playerDisplay;
    public Button LogInButton;
    public Button LogOutButton;
    public Button StartButton;

    public GameObject Avatar1;
    public GameObject Avatar2;
    public GameObject Avatar3;
    public GameObject Avatar4;
    public GameObject Avatar5;

    private GameObject avatar=null;
    

    public void GoToLogin()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMetaverse()
    {   
        SceneManager.LoadScene(2);
    }

    public void nextavatar(){
 
        if(avatar){
            Destroy(avatar);
        }

        if(DBmanager.avatarcode==5)DBmanager.avatarcode=1;
        else DBmanager.avatarcode++;

        Showavatar();

    }

    public void Showavatar(){
        if     (DBmanager.avatarcode==1)avatar= Instantiate(Avatar1);
        else if(DBmanager.avatarcode==2)avatar= Instantiate(Avatar2);
        else if(DBmanager.avatarcode==3)avatar= Instantiate(Avatar3);
        else if(DBmanager.avatarcode==4)avatar= Instantiate(Avatar4);
        else   avatar= Instantiate(Avatar5);
    }

    public void Logout(){
        DBmanager.LogOut();
        playerDisplay.text= "User: User not logged in";
        LogInButton.interactable = true;
        LogOutButton.interactable = false;
        StartButton.interactable = false;
    }

    private void Start(){
        if(DBmanager.LoggedIn){
            playerDisplay.text= "User: "+ DBmanager.username;
            LogOutButton.interactable =true;
            LogInButton.interactable = false;
            StartButton.interactable = true;
        }
        else {
            playerDisplay.text= "User not logged in";
            LogInButton.interactable = true;
            StartButton.interactable = false;
            LogOutButton.interactable =false;
            
        }
        
        Showavatar();
    }

}
