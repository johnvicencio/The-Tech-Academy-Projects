(function(){
  "use strict";
    //Hide the div for the section on showing receipt
    document.getElementById('showReceipt').style.display = "none";

    //Submitted
    document.getElementById('formMenu').addEventListener('submit', getReceipt);

    function getReceipt(event) {
      event.preventDefault();
      //Show div for receipt and hide menu
      document.getElementById('showReceipt').style.display = "initial";
      document.getElementById('formMenu').style.display = "none";

      //Initialize total for cummulative amount
      var menuTotal = 0;
      var sizePersonalPizza = 6;
      var sizeMediumPizza = 10;
      var sizeLargePizza = 14;
      var sizeExtraLargePizza = 16;
      var meatAdditional = 1;
      var veggieAdditional = 1;
      var cheeseExtra = 3;
      var crustStuffed = 3;

      //Get size of pizza
      var sizeSelected = document.querySelector('input[name=size]:checked').value;
      var itemDisplay = "<tr>";
      //Determine price based on size and display item
      if (sizeSelected == 'Personal Pizza') {
        menuTotal += sizePersonalPizza;
        itemDisplay += "<td>" + sizeSelected + "</td><td>$ " + sizePersonalPizza +".00</td>";
      } else if (sizeSelected == 'Medium Pizza') {
        menuTotal += sizeMediumPizza;
        itemDisplay += "<td>" + sizeSelected +"</td><td>$ " + sizeMediumPizza +".00</td>";
      } else if (sizeSelected == 'Large Pizza') {
        menuTotal += sizeLargePizza;
        itemDisplay += "<td>" + sizeSelected + "</td><td>$ " + sizeLargePizza + ".00</td>";
      } else {
        menuTotal += sizeExtraLargePizza;
        itemDisplay += "<td>" + sizeSelected + "</td><td>$ " + sizeExtraLargePizza + ".00</td>";
      }
      itemDisplay += "</tr>";


      //Get meat selection of pizza, if any and display item
      var pizzaMeat = document.querySelectorAll('input[name=meat]:checked');
      var meatSelected = '';

      for (var i = 0; i < pizzaMeat.length; i++) {
        meatSelected += pizzaMeat[i].value;
        //Calculate meat after one meat selected, which is after first index zero
        //Also displays selected and price
        if (i > 0) {
          menuTotal += meatAdditional;
          itemDisplay += "<tr><td>"  + pizzaMeat[i].value + "</td><td>$ " + meatAdditional + ".00</td></tr>";
        } else {
          itemDisplay += "<tr><td>" + pizzaMeat[i].value + "</td><td>FREE</td></tr>";
        }

      }

      //Get veggie selection of pizza, if any
      var pizzaVeggie = document.querySelectorAll('input[name=veggie]:checked');
      var veggieSelected = '';
      for (var i = 0; i < pizzaVeggie.length; i++) {
        veggieSelected += pizzaVeggie[i].value + "<br>";

        //Calculate veggie after one meat selected
        if (i > 0) {
          menuTotal += veggieAdditional;
          itemDisplay += "<tr><td>"  + pizzaVeggie[i].value + "</td><td>$ " + veggieAdditional + ".00</td></tr>";
        } else {
          itemDisplay += "<tr><td>" + pizzaVeggie[i].value + "</td><td>FREE</td></tr>";
        }
      }

      //Get cheeze selection
      var cheeseSelected = document.querySelector('input[name=cheese]:checked').value;
      itemDisplay += "<tr>";
      //Calculate extra cheeze if selected and display selection and price
      if (cheeseSelected == 'Extra Cheese') {
        menuTotal += cheeseExtra;
        itemDisplay += "<td>" + cheeseSelected + "</td><td>$ " + cheeseExtra + ".00</td>";
      } else {
        itemDisplay += "<td>" + cheeseSelected + "</td><td>FREE</td>";
      }
      itemDisplay += "</tr>";


      //Get sauce selection and display selected
      var sauceSelected = document.querySelector('input[name=sauce]:checked').value;
      itemDisplay += "<tr><td>" + sauceSelected + "</td><td>FREE</td></tr>";
      //Get crust selection
      var crustSelected = document.querySelector('input[name=crust]:checked').value;

      //Calculate crust and display selected with price
      itemDisplay += "<tr>";
      if (crustSelected == 'Cheese Stuffed Crust') {
        menuTotal += crustStuffed;
        itemDisplay += "<td>" + crustSelected + "</td><td>$ " + crustStuffed + ".00</td>";
      } else {
        itemDisplay += "<td>" + crustSelected + "</td><td>FREE</td>";
      }
      itemDisplay += "</tr>";

      //Display Total
      itemDisplay += "<tr><td><strong>Total</strong></td><td><strong>$ " + menuTotal + ".00</strong></td></tr>";
      //Display receipt
      document.getElementById('menuItem').innerHTML = itemDisplay;

    }

})();
