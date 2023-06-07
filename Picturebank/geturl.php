<?php

    $con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');

    //check connection
    if(mysqli_connect_errno()){
        echo "1: Connection failed."; //error 1 = connection failed
        exit();
    }

    $pathology = $_POST["pathology"];

    //check availability of username
    $directorycheck = "SELECT id,directory FROM pictures WHERE pathology = '" . $pathology . " ';";
    $namecheck = mysqli_query( $con, $directorycheck) or die("2: Directory check query failed"); 

    if (mysqli_num_rows($namecheck)==0){
        echo "5: Pictures of this pathology don't exist";
        exit();
    }
    else{ //there pictures of pathology type

        while($row = mysqli_fetch_assoc($namecheck)) {

            //$URLS[] = $row["directory"]; // pushes directory to list of urls
            echo trim($row["directory"]).","; //enumerate directories in CSV (coma separated values)        
            
        } 

    }

?>