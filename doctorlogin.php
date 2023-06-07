<?php

    $con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');

    //check connection
    if(mysqli_connect_errno()){
        echo "1: Connection failed."; //error 1 = connection failed
        exit();
    }

    $username = $_POST["username"];
    $password = $_POST["password"];

    //check availability of username
    $namecheckquery = "SELECT username, salt, hash FROM doctors WHERE username = '" . $username . " ';";
    $namecheck = mysqli_query( $con, $namecheckquery) or die("2: Name check query failed"); //error code 2 : name check failed // if query ok, namecheck continer of select query

    if (mysqli_num_rows($namecheck)!=1){
        echo "5: Name doesn't exist";
        exit();
    }

    $info = mysqli_fetch_assoc($namecheck); 
    $salt = trim($info["salt"]);
    $hash = trim($info["hash"]);

    $loginhash = crypt( $password, $salt);
    
    if ($loginhash != $hash ){
        
        echo("6: Incorrect password");
        exit();
    }

    echo ("0") ;

?>