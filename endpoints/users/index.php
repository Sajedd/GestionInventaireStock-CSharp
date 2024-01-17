<?php
$db = new mysqli('192.168.45.20', 'remote', 'password', 'e-commerce');
if (!$db) {
  echo "ERROR";
  die("Connection failed: " . $db->connect_error);
}
?>
<?php

$users = $db->query(
  "SELECT * FROM users"
);
$db->close();
$json = [];

if ($users->num_rows > 0) {
  // output data of each row
  while ($row = $users->fetch_assoc()) {
    if (!file_exists($row["UserId"] . "/index.php")) {
      mkdir($row["UserId"] . "/", 0777, true);
      $myfile = fopen($row["UserId"] . "/index.php", "w") or die("Unable to open file!");
      fwrite($myfile, json_encode($row) . file_get_contents("delete.php"));
      fclose($myfile);
    }
    array_push($json, $row);
  }
}
$method = $_SERVER['REQUEST_METHOD'];
switch ($method) {
  case 'PUT':
    $db->connect('192.168.45.20', 'remote', 'password', 'e-commerce');
    /* PUT data comes in on the stdin stream */
    $putdata = fopen("php://input", "r");

    /* Open a file for writing */
    $fp = fopen("myputfile.txt", "w");

    /* Read the data 1 KB at a time
       and write to the file */
    while ($data = fread($putdata, 1024))
      fwrite($fp, $data);

    fclose($putdata);
    $test = fopen("test.txt", "w");
    $PUT = json_decode(file_get_contents("myputfile.txt"), true);
    try {
      $db->query(
        "UPDATE users SET LastName='" . $PUT["LastName"] . "', FirstName='" . $PUT["FirstName"] . "', Email='" . $PUT["Email"] . "',Passwd='" . password_hash($PUT["Passwd"], PASSWORD_DEFAULT) . "' WHERE UserId=" . $PUT["UserId"]
      );
    } catch (Exception $e) {
      echo $e;
    }
    if ($db->connect_error) {
      echo ("Connection failed: " . $db->connect_error);
    }
    $db->close();
    break;
  case 'POST':
    $db->connect('192.168.45.20', 'remote', 'password', 'e-commerce');
    echo "start";
    $log = fopen("log.txt", "w") or die("Unable to open file!");
    echo "opened";
    fwrite($log, "izhafizehfie");
    echo $_POST["Name"];
    try {
      $db->query(
        "INSERT INTO users (LastName, FirstName, Email,Passwd) VALUES ('" . $_POST["LastName"] . "', '" . $_POST["FirstName"] . "', '" . $_POST["Email"] . "','" . password_hash($_POST["Passwd"], PASSWORD_DEFAULT) . "');"
      );
    } catch (Exception $e) {
      echo $e;
    }
    if ($db->connect_error) {
      die("Connection failed: " . $db->connect_error);
    }
    $db->close();
    break;
  case 'GET':
    echo json_encode($json);
  default:
    echo ($method + "not supported");
    break;
}
?>