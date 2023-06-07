
using AnotherFileBrowser.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class FileBrowserUpdate : MonoBehaviour
{
    public TMP_Text prompt2;
    public RawImage rawImage;
    public string localImgPath="none";
    public Button uploadButton;
    
    public TMP_InputField pathologyField;

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>{    
            //Load image from local path with UWR
            localImgPath=path;
            StartCoroutine(LoadImage(path));
        });
    }

    public void CallUploadImage(){

        if(localImgPath!="none"){
            StartCoroutine(UploadImage(localImgPath));
            prompt2.text="Image uploaded successfully";
        }
        else{
            Debug.Log("No image selected");
        }
    }

    public void verifyInputs(){
        uploadButton.interactable = (pathologyField.text.Length>=1 && localImgPath!="none");
    }

    IEnumerator LoadImage(string path)
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path);
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                rawImage.texture = uwrTexture;
                //uploadButton.interactable=true;
            }
        }
    }

    IEnumerator UploadImage(string path)
    {
        
        WWWForm form = new WWWForm();
        UnityWebRequest dataFile = UnityWebRequest.Get(path);
        yield return dataFile.SendWebRequest();

        form.AddBinaryData("dataFile", dataFile.downloadHandler.data, path);
        form.AddField("pathologyType",pathologyField.text);

        UnityWebRequest req = UnityWebRequest.Post("http://localhost/sqlconnect/Picturebank/uploadImageDB.php", form);
        yield return req.SendWebRequest();

        Debug.Log("SERVER: " + req.downloadHandler.text); // server response

        if (req.result == UnityWebRequest.Result.ConnectionError || req.result == UnityWebRequest.Result.ConnectionError || !(req.downloadHandler.text.Contains("FILE OK")))
            {
                Debug.Log(req.error);
            }
        
        yield break;
    }
}
