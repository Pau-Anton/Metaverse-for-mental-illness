<?php

if ( isset($_FILES["dataFile"])) {

	//if there was an error uploading the file
	if ($_FILES["dataFile"]["error"] > 0)
		echo "Return Code: " . $_FILES["dataFile"]["error"] . "<br />";
	else{
		$filename = $_FILES["dataFile"]["name"];
		$dupFilename = rtrim($filename , ".csv") . "_1.csv";

		if(file_exists("data/" . $filename)){ // file exists
			echo " FILE OK - IGNORED as duplicate "; //just ignore it
			
		}else{ // new file
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
