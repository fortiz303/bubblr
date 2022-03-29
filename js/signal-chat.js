
//HUB_URL = "https://localhost:44319/"; // debug
HUB_URL = "https://signalr.targetvn.com/"; // product
connection = new signalR.HubConnectionBuilder().withUrl(HUB_URL + "chatHub").build();



connection.on("ReceiveSignalChat", function (conver_id) {
    console.log("ReceiveSignalChat..." + conver_id);
    //reload the chat conversation message
    if (localStorage.page == 2 && localStorage.nav_stack_chat != 0) {
        // reload page_conver
        RefreshConversation(conver_id);
    }
    else if (localStorage.page == 11) {
        // reload chat conver message when in chat message press
        RefreshConversation(conver_id);
    }
});

/*connection.on("ReceiveMessage2", function (token, message, post_id) {
    console.log("ReciveMessage2...");
    console.log(token + " " + message + " " + post_id);
});*/
connection.onclose(() => {

    $("#panel-disconnect").show();
    console.log("Connection closed");
    inter_re_connect = setInterval(function () {
        console.log("re connect loading...");
        KeepCheckConnect();
    }, 3000);
    
});

function KeepCheckConnect() {

    connection.start().then(function () {
        console.log("Connection Start....");
        $("#panel-disconnect").hide();
        clearInterval(inter_re_connect);
    }).catch(function (err) {
        $("#panel-disconnect").show();
        return console.error(err.toString());
    });
}

function JoinGroup(conver_id) {
    try {
        console.log("Start Joining Group " + conver_id);
        connection.invoke("JoinGroup", ""+conver_id);
        console.log("Joined!! ===> " + conver_id);
    } catch (err) {
        alert(err.toString());
        console.error(err);
        // Re Join...
        console.log("Re joininig Group...");
        JoinGroup(conver_id);
    }
}

function SendSignalChat(conver_id) {
    console.log("sending chat...");
    connection.invoke("SendSignalChat", "" + conver_id).catch(function (err) {
        return console.error(err.toString());
    });
}

$(function () {

    connection.start().then(function () {
        console.log("Connection Start....");
        $("body").fadeIn();
    }).catch(function (err) {
        $("body").fadeIn();
        return console.error(err.toString());
    });

});