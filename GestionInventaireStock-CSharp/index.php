<!DOCTYPE html>
<html lang="fr">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestion d'Inventaire</title>
    <link rel="stylesheet" href="/GestionInventaireStock-CSharp/styles.css" />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"
      integrity="sha512-RL01Hzao3Tu82v4S1fhG/PQuE0qe/3M5Mj2lzauTaCqZPr3zj5tiQ11CP0NMmIp5gLkfo4TchvB9GezIYCMZ2Q=="
      crossorigin="anonymous"
    />
  </head>
  <body>
  <?php
    $db = new mysqli('192.168.45.20', 'remote', 'password', 'e-commerce');
    if (!$db){
      echo "ERROR";
      die("Connection failed: " . $db->connect_error);
    }
    
    $products = $db->query(
      "SELECT * FROM products"
    );
    $json = [];

    if ($products->num_rows > 0) {
    // output data of each row
      while ($row = $products->fetch_assoc()) {
        array_push($json, $row["Name"]." : " . $row["Price"]." $");
  }
}
  ?>
    <header>
      <h1>Application de Gestion d'Inventaire</h1>
    </header>
    <main>
      <form id="articleForm">
        <label for="articleName">Nom de l'article:</label>
        <input type="text" id="articleName" name="articleName" required />
        <button onclick="createArticle()">
          <i class="fa-solid fa-plus"></i> Ajouter Article
        </button>
      </form>
      <section>
        <h2>Liste des Articles</h2>
        <ul id="articleList"></ul>
        <?php foreach ($json as &$p):?>
          <h1><?php echo $p?></h1>
          <br/>
        <?php endforeach;?>
      </section>
    </main>
  </body>
</html>