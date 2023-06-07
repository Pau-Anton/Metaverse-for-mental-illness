using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneController : MonoBehaviour
{   
    public TMP_Text prompt; 
    public GameObject image;
    public Button mainmenu;
    public Button controls;
    public Button closecontrols;

    public GameObject Avatar1;
    public GameObject Avatar2;
    public GameObject Avatar3;
    public GameObject Avatar4;
    public GameObject Avatar5;

    private GameObject avatar=null;

    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(false);
        closecontrols.gameObject.SetActive(false);
        Showavatar();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePrompt(DBmanager.prompt);
    }

    public void UpdatePrompt(string text){
        prompt.text=text;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void openControlls(){
        image.SetActive(true);
        closecontrols.gameObject.SetActive(true);

        mainmenu.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        prompt.gameObject.SetActive(false);
        

    }

    public void closeControlls(){
        image.SetActive(false);
        closecontrols.gameObject.SetActive(false);

        mainmenu.gameObject.SetActive(true);
        controls.gameObject.SetActive(true);
        prompt.gameObject.SetActive(true);
        
    }

    public void Showavatar(){
        if     (DBmanager.avatarcode==1)avatar= Instantiate(Avatar1);
        else if(DBmanager.avatarcode==2)avatar= Instantiate(Avatar2);
        else if(DBmanager.avatarcode==3)avatar= Instantiate(Avatar3);
        else if(DBmanager.avatarcode==4)avatar= Instantiate(Avatar4);
        else   avatar= Instantiate(Avatar5);
    }

}
