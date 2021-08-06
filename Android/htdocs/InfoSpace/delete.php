<?php
require "QueryManager.php";
$queryManager = new QueryManager();
if($queryManager->dbConnect())
{
	if($queryManager->deleteRow("users",$_POST['username']))
	{
		echo "Removal Operation Success";
	}
	else
	{
		echo "Could Not complete Removal";
	}
}
else echo "Error: Database connection";
?>
