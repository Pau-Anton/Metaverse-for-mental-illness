<?php

    $con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');

    //check connection
    if(mysqli_connect_errno()){
        echo "1: Connection failed."; //error 1 = connection failed
        exit();
    }

    $username = $_POST["username"];
    $password = $_POST["password"];
    $pathology = $_POST["pathology"];

    //check availability of username
    $namecheckquery = "SELECT username FROM patients WHERE username = '" . $username ." ';";
    $namecheck = mysqli_query( $con, $namecheckquery) or die("2: Name check query failed"); //error code 2 : name check failed 

    if (mysqli_num_rows($namecheck)> 0){
        echo "3: Name already exists";
        exit();
    }

    //add user to table --> separate password into salt and hash. 
    $salt = "\$5\$rounds=5000\$" . $username . "\$";
    $hash = crypt($password, $salt); 

    $insertuserquery = "INSERT INTO patients (username, salt, hash, pathology) VALUES ('" . $username . " ',' " . $salt . " ',' " . $hash . " ',' " . $pathology . " ');";
    mysqli_query($con, $insertuserquery) or die("4: Insert patient query failed.");

    echo("0: Success.");

?>