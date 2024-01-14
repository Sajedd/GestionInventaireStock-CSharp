<?php
$db = new mysqli('192.168.45.20', 'remote', 'password', 'e-commerce');
if (!$db){
  echo "ERROR";
  die("Connection failed: " . $db->connect_error);
}
?>
<?php

$products = $db->query(
  "SELECT * FROM products"
);
$json = [];

if ($products->num_rows > 0) {
  // output data of each row
  while ($row = $products->fetch_assoc()) {
    if (!file_exists($row["ProductId"] . "/index.php")) {
      mkdir($row["ProductId"] . "/", 0777, true);
      $myfile = fopen($row["ProductId"] . "/index.php", "w") or die("Unable to open file!");
      fwrite($myfile, json_encode($row) . file_get_contents("delete.php"));
      fclose($myfile);
    }
    array_push($json, $row);
  }
}
if ($_SERVER['REQUEST_METHOD'] == "GET") {
  echo json_encode($json);
} else if ($_SERVER['REQUEST_METHOD'] == "POST") {
  $log = fopen("log.txt", "w");
  $_POST = json_decode(file_get_contents("php://input"), true);
  echo $_POST["Name"];
  $db->query(
    "INSERT INTO products (Name, Price, Vendor, Quantity) VALUES ('" . $_POST["Name"] . "', '" . $_POST["Price"] . "', '" . $_POST["Vendor"] . "', '".$_POST["Quantity"]."');"
  );
  if ($db->connect_error) {
    die("Connection failed: " . $db->connect_error);
  }
  $db->close();
}  else if ($_SERVER['REQUEST_METHOD'] == "PUT") {
  /* PUT data comes in on the stdin stream */
  $putdata = fopen("php://input", "r");

  /* Open a file for writing */
  $fp = fopen("myputfile.txt", "w");

  /* Read the data 1 KB at a time
     and write to the file */
  while ($data = fread($putdata, 1024))
    fwrite($fp, $data);

  fclose($putdata);
  fclose($fp);
  $PUT = json_decode(file_get_contents("myputfile.txt"), true);
  fwrite($log, $PUT["Name"] . "\n" . $PUT["Price"] . "\n" . $PUT["Vendor"] );
  fclose($log);
  $err = $db->query(
    "UPDATE 'products' SET 'Name'='" . $PUT["Name"] . "', 'Price'='" . $PUT["Price"] . "', 'Vendor'='" . $PUT["Vendor"] . "', 'Quantity'='".$PUT["Quantity"]."' WHERE 'productId'=" . $PUT["ProductId"] . ");"
  );
  if ($db->connect_error | !$err) {
    die("Connection failed: " . $db->connect_error);
  }
  $db->close();
}

?>
