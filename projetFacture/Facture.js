var articlesQuantites = [];

var articles = new Map();
articles.set("Eau", 2);
articles.set("Coca", 3.5);
articles.set("Fanta", 3);
articles.set("IceTea", 2.5);

function genererFacture() {
  // Récupérer les valeurs
  let article = document.getElementById("Article").value;
  let quantite = document.getElementById("Quantite").value;
  let client = document.getElementById("Client").value;
  let genre = document.querySelector('input[name="genre"]:checked');

  const prix = articles.get(article);

  // Vérifier les options sélectionnées
  let detailChecked = document.getElementById("Detail").checked;
  let totalChecked = document.getElementById("Total").checked;

  // Construire le récapitulatif

  if (detailChecked && !totalChecked) {
    articlesQuantites.push({article, quantite, prix});
    // Afficher les articles et quantités
    var articlesList = document.getElementById("articlesList");
    articlesList.innerHTML = "Detail Facture: ";
    articlesQuantites.forEach((item) => {
      articlesList.innerHTML +=
        "<p>" +
        item.article +
        " *" +
        item.quantite +
        " =" +
        item.prix * item.quantite +
        "euros " +
        "</p>";
    });

    document.getElementById("articlesList").classList.remove("hidden");
  }

  // Afficher le total si la case est cochée
  if (totalChecked) {
    var total = document.getElementById("totalResult");
    total.innerHTML = " Total Facture:" + "<br>";
    total.innerHTML +=
      " " +
      genre.value +
      " " +
      client +
      " , " +
      "                " +
      "  " +
      "Total =" +
      " " +
      calculerTotal() +
      " euros";

    document.getElementById("totalResult").classList.remove("hidden");
  } else {
    document.getElementById("totalResult").classList.add("hidden");
  }
  // Afficher la section résultat
  // document.getElementById("resultat").classList.remove("hidden");
}

function calculerTotal() {
  var total = 0;
  articlesQuantites.forEach((item) => {
    total += item.quantite * item.prix;
  });
  return total;
}
