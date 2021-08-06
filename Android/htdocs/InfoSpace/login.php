<?php
require "QueryManager.php";
$queryManager = new QueryManager();
if (isset($_POST['username']) && isset($_POST['password'])) {
    if ($queryManager->dbConnect()) {
        if ($queryManager->logIn("users", $_POST['username'], $_POST['password'])) {
            echo "Login Success";
        } else echo "Username or Password wrong";
    } else echo "Error: Database connection";
} else echo "All fields are required";
?>
