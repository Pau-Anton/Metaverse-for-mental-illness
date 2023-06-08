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
    public Texture2D[] imagetextures;
    public Image textureImage;
    public TMP_Text imagename;
    private int picIndex=0;
    

    public void GoToMainmenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void VisualizePictureForward(){

        if(imagetextures.Length>0){

            ShowImage(picIndex);

            if(picIndex<imagetextures.Length -1 ){ //check index is not out of bounds of DBmanager.directories
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
        
        if(imagetextures.Length>0){//check if there's pictures available

            ShowImage(picIndex);
         
            if(picIndex>0){ //check index is not out of bounds of DBmanager.directories
            picIndex--;
            }
            else{
                picIndex=imagetextures.Length -1;
            }

        }
        else{
            Debug.Log("No pictures loaded");
        }
     
    }


    public void ShowImage(int index){
            Debug.Log(imagetextures[index].width);
            Debug.Log(imagetextures[index].height);
            Texture2D loadedTexture = imagetextures[index];
            imagename.text = loadedTexture.name;

            textureImage.sprite = Sprite.Create(loadedTexture, new Rect(0f, 0f, loadedTexture.width, loadedTexture.height), Vector2.zero);

            int maxpxH=300;
            int maxpxW=450;
            ResizeImage(ref textureImage, maxpxW, maxpxH);
            //textureImage.SetNativeSize();
                
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
        imagetextures= Resources.LoadAll<Texture2D>("SampleImages");
        
    }

}