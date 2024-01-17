<?php
$db = new mysqli('192.168.45.20', 'remote', 'password', 'e-commerce');
if (!$db) {
    echo "ERROR";
    die("Connection failed: " . $db->connect_error);
}
?>
<?php

$products = $db->query(
    "SELECT * FROM products"
);
$db->close();
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
        fclose($fp);
        $PUT = json_decode(file_get_contents("myputfile.txt"), true);
        try {
            $db->query(
                "UPDATE products SET Name='" . $PUT["Name"] . "', Price=" . $PUT["Price"] . ", Vendor='" . $PUT["Vendor"] . "', Quantity= " . $PUT["Quantity"] . " WHERE productId=" . $PUT["ProductId"]
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
                "INSERT INTO products (Name, Price, Vendor, Quantity) VALUES ('" . $_POST["Name"] . "', '" . $_POST["Price"] . "', '" . $_POST["Vendor"] . "', '" . $_POST["Quantity"] . "');"
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
        break;
    default:
        echo ($method + "not supported");
        break;
}

?>