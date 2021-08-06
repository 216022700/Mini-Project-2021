<?php
    require "QueryManager.php";
    $queryManager = new QueryManager();
    if($queryManager->dbConnect())
    {
        $colNames = $queryManager->getColumnNames("users",5);
        echo $colNames;

    }
?>