<?php
if ($_SERVER['REQUEST_METHOD'] == "DELETE") {
    $db = new mysqli('192.168.45.20', 'remote', 'password', 'e-commerce');
    $err = $db->query('DELETE FROM users WHERE `users`.`UserId` = '.basename(__DIR__).'');
    if ($db->connect_error | !$err) {
        echo "ERROR";
        die('ERROR : '. $db->connect_error);
    }else{
        unlink(__FILE__);
    }
    $db->close();
}
?>
