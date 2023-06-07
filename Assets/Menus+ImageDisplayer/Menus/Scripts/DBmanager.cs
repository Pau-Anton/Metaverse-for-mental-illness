using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DBmanager 
{
    public static string username;
    public static int pathology;
    public static int avatarcode=1;

    public static string prompt= "";

    public static string doctor;

    public static string[] directories = new string[]{};

    public static bool LoggedIn{ get { return username!= null; } }

    public static void LogOut(){
        Debug.Log("LOGGEDOUT");
        username= null;
    }

}
