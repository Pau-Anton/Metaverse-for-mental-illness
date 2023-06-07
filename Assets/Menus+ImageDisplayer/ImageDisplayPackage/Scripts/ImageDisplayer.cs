using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;



public class ImageDisplayer : MonoBehaviour
{
    public Image textureImage;
    public TMP_Text imagename;
    private int picIndex=0;
    



    public void GoToMainmenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GetPicturesURL(){ 

        StartCoroutine( GetURLS());
        // foreach (var item in DBmanager.directories){ Debug.Log($" ==> {item}");  }
        
    }

    public void VisualizePictureForward(){

        if(DBmanager.directories.Length>0){

            StartCoroutine(GetandShowImage(DBmanager.directories[picIndex]));

            if(picIndex<DBmanager.directories.Length -1 ){ //check index is not out of bounds of DBmanager.directories
            picIndex++;
            }
            else{
                picIndex=0;
            }
        }
        else{
            Debug.Log("No pictures loaded");
        }
        
    }

    public void VisualizePictureBackwards(){
        
        if(DBmanager.directories.Length>0){//check if there's urls available

            StartCoroutine(GetandShowImage(DBmanager.directories[picIndex]));
         
            if(picIndex>0){ //check index is not out of bounds of DBmanager.directories
            picIndex--;
            }
            else{
                picIndex=DBmanager.directories.Length -1;
            }
        }
        else{
            Debug.Log("No pictures loaded");
        }
     
    }

    IEnumerator GetURLS(){ //gets all urls with the pathology type of the user and stores it into DBmanager.directories
        
        WWWForm form = new WWWForm();
        form.AddField("pathology", DBmanager.pathology);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/Picturebank/geturl.php", form);
        yield return www.SendWebRequest();
        string wwwtext = www.downloadHandler.text;
        
        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ConnectionError) //check error connecions
            {
                Debug.Log(www.error);
            }
        else{
            //extract info from CSV format
            string[] urls = wwwtext.Split(',');
            Array.Resize(ref urls, urls.Length-1); //removes last component of the array which contained nothing
            DBmanager.directories=urls; //stores urls into DBmanager object
            Debug.Log("URLs obtained");
        }           
    }

    IEnumerator GetandShowImage(string dir){

            imagename.text = dir.Remove(0,28);

            UnityWebRequest www = UnityWebRequestTexture.GetTexture("http://localhost/"+dir);
            yield return www.SendWebRequest();
    
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            { 
                Texture2D loadedTexture = DownloadHandlerTexture.GetContent(www);
                
                textureImage.sprite = Sprite.Create(loadedTexture, new Rect(0f, 0f, loadedTexture.width, loadedTexture.height), Vector2.zero);

                int maxpxW=200;
                int maxpxH=100;
                ResizeImage(ref textureImage, maxpxW, maxpxH);
                //textureImage.SetNativeSize();
                
            }
    }

    public void ResizeImage(ref Image imageToResize, int maxsizepxW, int maxsizepxH){

        // Get the original dimensions of the image
        float originalWidth = imageToResize.sprite.bounds.size.x;
        float originalHeight = imageToResize.sprite.bounds.size.y;

        // Calculate the scale factor needed to fit the image into a 400x400 box
        float scaleFactor = Mathf.Min( maxsizepxW / originalWidth, maxsizepxH / originalHeight);

        // Set the new dimensions of the image based on the scale factor
        float newWidth = originalWidth * scaleFactor;
        float newHeight = originalHeight * scaleFactor;

        // Set the new size of the image
        imageToResize.rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        picIndex=0;
        if(DBmanager.pathology==0){
            DBmanager.pathology=1;
        }
        GetPicturesURL();
    }

}
