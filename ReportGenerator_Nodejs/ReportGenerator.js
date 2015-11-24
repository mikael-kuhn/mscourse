var http = require("http");
var url = require("url");

var req = function(location, method, callback)
{
    var options = {
        host: location.hostname,
        port: location.port,
        path: location.path + "?format=json",
        method: method
    };

    http.get(options, function(res) {
        var pageData = "";

        res.on('data', function (chunk) {
            pageData += chunk;
        });

        res.on('end', function(){
            callback(JSON.parse(pageData))
        });
    })
}

var lastId = 0;
var invoiceCreatedStreamUrl = url.parse("http://localhost:2113/streams/InvoiceCreated", true);

function getEventNumbeFromUrl(lastMessageUrl)
{
    return Number(lastMessageUrl.substr(lastMessageUrl.lastIndexOf("/") + 1));
}

function handleMessage(lastMessageUrl)
{
    req(url.parse(lastMessageUrl), "GET", function (data) {
        console.log(data);
        setupPoll();
    });
}

var poll = function () {
    req(invoiceCreatedStreamUrl, "GET", function (data) {

        var lastMessageUrl = data.entries[0].links[0].uri;
        var number = getEventNumbeFromUrl(lastMessageUrl);
        if (number > lastId) {
            console.log("Processing message number " + number);
            lastId = number;
            handleMessage(lastMessageUrl);
        }
        setupPoll();
    });
}

function setupPoll()
{
    setTimeout(poll, 1000);
}

setupPoll();


