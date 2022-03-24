connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44319/chatHub").build();

connection.on("ReceiveMessage2", function (token, message, post_id) {
    console.log("ReciveMessage2...");
    console.log(token + " " + message + " " + post_id);
});

connection.start().then(function () {
    console.log("Connection Start....");

    connection.invoke("JoinGroup", "Conver1").catch(function (err) {
        return console.error(err.toString());
    }).then(function (e) {
        console.log("Join Group");
    });

}).catch(function (err) {
    return console.error(err.toString());
});

function SendChat() {
    console.log("sending chat...");
    connection.invoke("SendMessage2", "333333fetoken", "Message Token", 1).catch(function (err) {
        return console.error(err.toString());
    });

}