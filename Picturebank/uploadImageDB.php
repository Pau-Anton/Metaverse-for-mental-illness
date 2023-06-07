<?php

    $con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
    if(mysqli_connect_errno()){
        echo "1: Connection failed."; //error 1 = connection failed
        exit();
    }

    if (isset($_FILES["dataFile"])) {

	//if there was an error uploading the file
	if ($_FILES["dataFile"]["error"] > 0)
		echo "Return Code: " . $_FILES["dataFile"]["error"] . "<br />";

	else{//if no error

		$filename = $_FILES["dataFile"]["name"];
        $pathology = $_POST["pathologyType"];

		if(file_exists("data/" . $filename)){ // file exists
			echo " FILE OK - IGNORED as duplicate "; //just ignore it
        }

        else{ // new file
            //update DB
            $directory= "sqlconnect/Picturebank/data/" . $filename;
            $insertuserquery = "INSERT INTO pictures (filename, directory, pathology) VALUES ('" . $filename . " ',' " . $directory . " ',' " . $pathology . " ');";           
            mysqli_query($con, $insertuserquery) or die("4: Insert picture query failed.");
            
            //copyfile into server
			move_uploaded_file($_FILES["dataFile"]["tmp_name"], "data/" . $filename);
			echo " FILE OK ";
			echo "Stored in: " . "data/" . $filename . " ";
			return;
		}
	}
}
else
	echo "FILE NOT SET";
     
 ?>
