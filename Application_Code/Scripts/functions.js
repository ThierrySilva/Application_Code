function textGenerate() {

    var totalCardPerCarousel = 3;
    var totalArray = 0;
    var totalCarousel = Math.ceil(_cardpathSend.length / totalCardPerCarousel);
    var divPrincipal = document.getElementById("CarouselLine");
    divPrincipal.style.display = "block";
  

    var principal_card = document.getElementById("carousel-inner");
    if (principal_card != null) {
        for (var i = 1; i <= totalCarousel; i++) {

            if (i == 1) {
                var carousel_item = document.createElement("div");
                carousel_item.className = "carousel-item active divActive" + i + "";
                principal_card.appendChild(carousel_item);
            }
            else {
                var carousel_item = document.createElement("div");
                carousel_item.className = "carousel-item divActive" + i + "";
                principal_card.appendChild(carousel_item);
            }

            var carousel_container_row = document.createElement("div");
            carousel_container_row.className = "row";
            carousel_item.appendChild(carousel_container_row);


            for (var f = 1; f <= totalCardPerCarousel; f++) {


                var carousel_container = document.createElement("div");
                carousel_container.className = "col-sm-3 col-md-4";
                carousel_container_row.appendChild(carousel_container);

                var carousel_card = document.createElement("div");
                carousel_card.className = "card h-100";
                carousel_card.style.cssText = style = "width: 300px; margin: auto";
                carousel_container.appendChild(carousel_card);


                var carousel_card_body = document.createElement("div");
                carousel_card_body.className = "card-body";
                carousel_card.appendChild(carousel_card_body);



                var carousel_h3 = document.createElement("h3");
                carousel_h3.className = "card-title";
                var texto4 = document.createTextNode("Sessão " + (totalArray + 1) + ".txt");
                //var texto4 = document.createTextNode("Arquivo: " + _cardpathSend[totalArray]);

                carousel_h3.appendChild(texto4);
                carousel_card_body.appendChild(carousel_h3);

                var carousel_card_iframe = document.createElement("iframe");
                carousel_card_iframe.className = "hidden";
                carousel_card_iframe.id = "iframe_download" + totalArray;
                carousel_card_iframe.src = _cardpathSend[totalArray];
                carousel_card_iframe.style.display = "none";
                carousel_card_body.appendChild(carousel_card_iframe);

                var carousel_text = document.createElement("a");
                carousel_text.className = "card-text ";
                carousel_text.setAttribute("href", "Output/" + (totalArray + 1) + ".txt");
                carousel_text.setAttribute("download", "" + (totalArray + 1) + ".txt")
                var texto = document.createTextNode("Baixar");
                carousel_text.appendChild(texto);

                carousel_card_body.appendChild(carousel_text);

                totalArray++;


            }

        }

    }

}



