

function showCats() {
    var e = document.getElementById("selectedCategory");
    var category = e.options[e.selectedIndex].value;
   
    var data = {
        "CategoryID": category
    };

    var url = "/Sales/ProductDropDownValues";
    $.ajax({
        type: 'POST',
        url: url,
        contentType:"application/json",
        data: JSON.stringify(data),
        success: function (result) {
            //debugger
            var productsList = $('#productListforSelectedCategory');
            productsList.empty();
            $('#productListforSelectedCategory').append($('<option value="">-- Select Product--</option>'));
            for (var i = 0; i < result.length; i++) {

                $('#productListforSelectedCategory').append($('<option>', {
                    value: result[i].id,
                    text: result[i].name
                }));

            }
        }
    });

}

// get the product price hen the product is selected
function GetProductPrice() {
    //debugger
    var e = document.getElementById("productListforSelectedCategory");
    var product = e.options[e.selectedIndex].value;
    var data = {
        "ProductID": product
    };
    var url = "/Sales/GetProductPrice";

    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (result) {
            
            var productsList = $('#ProductPrice');
            productsList.empty();

            for (var i = 0; i < result.length; i++) {
                $('#ProductPrice').append($('<span>', {
                   
                    text: result[i].price
                }));
            }
        }
    });
}

// add details to cart
var count = 0;
function AddToCart() {

    var d = document.getElementById("customer");
    var customer = d.options[d.selectedIndex].value; 
    

    var e = document.getElementById("selectedCategory");
    var category = e.options[e.selectedIndex].text;
     
    var f = document.getElementById("productListforSelectedCategory");
    var product = f.options[f.selectedIndex].text;
    var productID = f.options[f.selectedIndex].value;
   
    //p tag
    var price = document.getElementById("ProductPrice").innerText;
    //input tag
    var quantity = document.getElementById("Quantity").value;

    var subtotal = price * quantity;

    var h = document.getElementById("TotalAmount").innerText;
    debugger

    if (count == 0) {
        var total1 = $('#TotalAmount');
        total1.empty();
        total1.append($('<span>', {
            text: subtotal
        }))
        count = count + 1;
        GetRandomTransactionID();
    }
    else {
        var Total = subtotal + parseFloat(h);
        var total1 = $('#TotalAmount');
        total1.empty();
        total1.append($('<span>', {
            text: Total
        }));

    }

     //get the table
    var table = document.getElementById("orderDetailsTable");
    var row = table.insertRow(0);
    // insert cell(td) to the row
    var td1 = row.insertCell(0);
    var td2 = row.insertCell(1);
    var td3 = row.insertCell(2);
    var td4 = row.insertCell(3);
    var td5 = row.insertCell(4);

    td1.innerHTML = product;
    td2.innerHTML = price;
    td3.innerHTML = quantity;
    td4.innerHTML = subtotal;
    td5.innerHTML = "<button class='btn  tanColor' >Remove</button>"

    // get the details to save in sale details table
    //get current date
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    var transactionDate = date + ' ' + time;
    var transacID = document.getElementById("transactionID").innerText;
    var data = {
        "ProductID": productID,
        "QuantityPurchased": quantity,
        "SubTotal": subtotal,
        "DatePurchased": transactionDate,
        "TransctionID":transacID
        };
    var url = "/MakeSales/SaveSalesDetails";
    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/json",
        data: JSON.stringify(data)

    });

 }



// generate transactionID
function GetRandomTransactionID() {
    var transactID = $('#transactionID');
    var trans = Math.floor((Math.random() * 6000) + 1);
    transactID.empty();
    transactID.append($('<span>', { text: trans })); 
}

function PrintReceipt() {
    debugger
    var d = document.getElementById("customer");
    var customer = d.options[d.selectedIndex].value;
    var transactionID = document.getElementById("transactionID").innerText;
    var TotalAmount = document.getElementById("TotalAmount").innerText;
    var AmountPaid = document.getElementById("AmountPaid").value;
    //var Balance = document.getElementById("Balance").value; 
    //get current date;
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    var dateTime = date + ' ' + time;
    var transactionDate = dateTime;
    var Balance = TotalAmount - AmountPaid;
    var data = {
        "TransctionID": transactionID,
        "TotalAmount": TotalAmount,
        "AmountPaid": AmountPaid,
        "Balance": Balance,
        "TranscationDate": transactionDate,
        "CustomerID": customer

    };
    var url = "/MakeSales/SaveSales";
    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/json",
        data: JSON.stringify(data),
     
    });
}
function getSubtotal() {
    var price = document.getElementById("ProductPrice").innerText;
    var quantity = document.getElementById("Quantity").value;
    var e = price * quantity;
    var subTotal = document.getElementById("SubTotal");
    subTotal.innerText = e;
}
function ComputeBalance() {
    var TotalAmount = document.getElementById("TotalAmount").innerText;
    var amountPaid = document.getElementById("AmountPaid").value;

    var change = document.getElementById("Change");
    change.innerText = amountPaid - TotalAmount;

}

    
  

    
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           