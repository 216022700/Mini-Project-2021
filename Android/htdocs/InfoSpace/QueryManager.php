<?php
require "ConnectionManager.php";

class QueryManager
{
    public $connect;
    public $data;
    private $sql;
    protected $servername;
    protected $username;
    protected $password;
    protected $databasename;

    public function __construct()
    {
        $this->connect = null;
        $this->data = null;
        $this->sql = null;
        $dbc = new ConnectionManager();
        $this->servername = $dbc->servername;
        $this->username = $dbc->username;
        $this->password = $dbc->password;
        $this->databasename = $dbc->databasename;
    }

    function dbConnect()
    {
        $this->connect = mysqli_connect($this->servername, $this->username, $this->password, $this->databasename);
        return $this->connect;
    }

    function prepareData($data)
    {
        return mysqli_real_escape_string($this->connect, stripslashes(htmlspecialchars($data)));
    }

    function logIn($table, $username, $password)
    {
        $username = $this->prepareData($username);
        $password = $this->prepareData($password);
        $this->sql = "select * from " . $table . " where username = '" . $username . "'";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
        if (mysqli_num_rows($result) != 0) {
            $dbusername = $row['username'];
            $dbpassword = $row['password'];
            if ($dbusername == $username && $dbpassword == $password) {
                $login = true;
            } else $login = false;
        } else $login = false;

        return $login;
    }

	//Can be used for all types of insers only with appropriate fields and data
    function signUp($table, $fullname, $email, $username, $password)
    {
        $fullname = $this->prepareData($fullname);
        $username = $this->prepareData($username);
        $password = $this->prepareData($password);
        $email = $this->prepareData($email);
        $password = $this->prepareData($password);
        $this->sql =
            "INSERT INTO " . $table . " (fullname, username, password, email) VALUES ('" . $fullname . "','" . $username . "','" . $password . "','" . $email . "')";
        if (mysqli_query($this->connect, $this->sql)) {
            return true;
        } else return false;
    }
	
	function deleteRow($table, $username)
	{
		$this->sql = "select * from ".$table." where username = '".$username."';";
        $result = mysqli_query($this->connect, $this->sql);
        $row = mysqli_fetch_assoc($result);
		if (mysqli_num_rows($result) != 0) {
			$delQuery = "delete from ".$table." where username = '".$username."';";
			if(mysqli_query($this->connect, $delQuery))
			{
				return true;
			}
			else return false;
		} else return false;
		
	}

    function getColumnNames($tableName, $expectedRowNum)
    {
        $this->sql = "select `COLUMN_NAME` from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='".$tableName."';";
        $result = mysqli_query($this->connect,$this->sql);
        $rowNum = mysqli_num_rows($result);

        if($rowNum > $expectedRowNum)
        {
           while(($row = mysqli_fetch_assoc($result)) && $expectedRowNum > 0)
           {
               echo $row["COLUMN_NAME"]."!@#"; //!@# are special seperator characters
               $expectedRowNum = $expectedRowNum - 1;
           }
        }
        else
        {
            while(($row = mysqli_fetch_assoc($result)))
            {
                echo $row["COLUMN_NAME"]."!@#"; //!@# are special seperator characters
            }
        }
    }


}

?>
