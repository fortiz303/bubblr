function OpenChat(post_id, conver_id,post_title) {
    $("#room-title").html("@" + post_title);
    $("#conversation-show").html('');
    clearInterval(inter_load_mess);
    LoadMessSync(post_id,conver_id);
    inter_load_chat_sync = setInterval(function () {
        LoadMessSync2(post_id,conver_id);
    }, 5000);

    $("#page-conver .ic-back").attr("onclick", "BackToChatHistory()");
    $("#btn-Chat-Send").attr("onclick", "SendChat(" + post_id + ")");
    GoTo('page-conver');

    _h = $(window).height() - 170;

    $("#conversation-show").css({ "height": _h + "px", "max-height": _h + "px" });
    localStorage.nav_stack_post_id = post_id;
    localStorage.nav_stack_chat = conver_id;
    localStorage.nav_stack_post_title = post_title;
}

$(window).resize(function () {
    _h = $(window).height() - 170;

    $("#conversation-show").css({ "height": _h + "px", "max-height": _h + "px" });
});

function BackToChatHistory() {
    localStorage.nav_stack_chat = 0;
    ChangeTab(2);
}

/*Chat V2: 22.03.2022*/
/*Update Chat SignalR*/
function OpenChat_V2(post_id) {
    token = localStorage.token;
    // get message conversation
    localStorage.page = 11;
    //alert(post_id);
    $("#room-title").html("@" + $("#post-details-title").html());
    $("#conversation-show").html('');
    $("#btn-Chat-Send").attr("onclick", "SendChat(" + post_id + ")");
    $("#btn-Chat-Send").attr("disabled","disabled");
    GoTo('page-conver');

    flag_JoinGroup = 0;

    $.ajax({
        data: {
            token: token,
            post_id:post_id
        },
        dataType: "json",
        url: BASE_API + 'chat/load-conver-v2.aspx',
        success: function (data) {
            cs = "";
            start_time = '';
            $.each(data, function (key, val) {

                if (val.timespan == "-1") {
                    console.log("Trying to Join group");
                    JoinGroup(val.from_id);
                    $("#btn-Chat-Send").removeAttr("disabled");
                    return;
                }
                else {
                    if (flag_JoinGroup == 0) {
                        console.log("Trying to Join group");
                        flag_JoinGroup = 1;
                        $.post(BASE_API + "chat/get-converId.aspx", {
                            token: token,
                            post_id: post_id
                        }, function (dt2) {
                            if (dt2 != -1) {
                                console.log("Getting ConverId ... Trying to Join group");
                                JoinGroup(dt2);
                                $("#btn-Chat-Send").removeAttr("disabled");
                            }
                        });
                    }
                }

                time = val.timespan;
                date = time.split(' ')[0];
                time = time.split(' ')[1] + ' ' + time.split(' ')[2];

                if (start_time != date) {
                    start_time = date;
                    cs += '<div class="chat-date">' + start_time + '</div>';
                }

                if (val.from_id == localStorage.user_id)
                    cs += '<div class="chat-right">' + val.mess + '<div class="chat-time">' + time + '</div></div><div style="clear:both"></div>';
                else
                    cs += '<div class="chat-left"><b>' + val.from_name + '</b>: ' + val.mess + '<div class="chat-time">' + time + '</div></div><div style="clear:both"></div>';

            });

            $("#conversation-show").html(cs);
            $('#conversation-show').scrollTop($('#conversation-show')[0].scrollHeight);
        }
    });

}

function RefreshConversation(conver_id) {
    $.ajax({
        url: BASE_API + 'chat/load-message-v2.aspx',
        dataType: 'json',
        data: {
            token: localStorage.token,
            conver_id: conver_id,
            post_id: 0
        },
        success: function (data) {
            cs = "";
            start_time = '';
            $.each(data, function (key, val) {

                time = val.timespan;
                date = time.split(' ')[0];
                time = time.split(' ')[1] + ' ' + time.split(' ')[2];

                if (start_time != date) {
                    start_time = date;
                    cs += '<div class="chat-date">' + start_time + '</div>';
                }

                if (val.from_id == localStorage.user_id)
                    cs += '<div class="chat-right">' + val.mess + '<div class="chat-time">' + time + '</div></div><div style="clear:both"></div>';
                else
                    cs += '<div class="chat-left"><b>' + val.from_name + '</b>: ' + val.mess + '<div class="chat-time">' + time + '</div></div><div style="clear:both"></div>';

            });

            $("#conversation-show").html(cs);
            $('#conversation-show').scrollTop($('#conversation-show')[0].scrollHeight);
        }
    });
}

function OpenConversation(post_id,conver_id,post_title) {

    JoinGroup(conver_id);

    $("#room-title").html("@" + post_title);
    $("#conversation-show").html('');

    $("#page-conver .ic-back").attr("onclick", "BackToChatHistory()");
    $("#btn-Chat-Send").attr("onclick", "SendReply(" + conver_id + ")");
    GoTo('page-conver');

    _h = $(window).height() - 170;

    $("#conversation-show").css({ "height": _h + "px", "max-height": _h + "px" });
    localStorage.nav_stack_post_id = post_id;
    localStorage.nav_stack_chat = conver_id;
    localStorage.nav_stack_post_title = post_title;

    $.ajax({
        url: BASE_API + 'chat/load-message-v2.aspx',
        dataType: 'json',
        data: {
            token: localStorage.token,
            conver_id: conver_id,
            post_id: post_id
        },
        success: function (data) {
            cs = "";
            start_time = '';
            $.each(data, function (key, val) {

                time = val.timespan;
                date = time.split(' ')[0];
                time = time.split(' ')[1] + ' ' + time.split(' ')[2];

                if (start_time != date) {
                    start_time = date;
                    cs += '<div class="chat-date">' + start_time + '</div>';
                }

                if (val.from_id == localStorage.user_id)
                    cs += '<div class="chat-right">' + val.mess + '<div class="chat-time">' + time + '</div></div><div style="clear:both"></div>';
                else
                    cs += '<div class="chat-left"><b>' + val.from_name + '</b>: ' + val.mess + '<div class="chat-time">' + time + '</div></div><div style="clear:both"></div>';

            });

            $("#conversation-show").html(cs);
            $('#conversation-show').scrollTop($('#conversation-show')[0].scrollHeight);
        }
    });

}

// from OpenChat_V2, open chat conver by button Chat Message
// only need post_id
function SendChat(post_id) {
    var mess = $("#txtChat").val();

    $.post(BASE_API + "chat/send.aspx", {
        token: localStorage.token,
        mess: mess,
        post_id: post_id
    }, function (data) {
        $("#txtChat").val('');
        //LoadMessSync(post_id);
        SendSignalChat(data);
    });
}

function SendReply(conver_id) {
    var mess = $("#txtChat").val();

    $.post(BASE_API + "chat/reply.aspx", {
        token: localStorage.token,
        mess: mess,
        conver_id: conver_id
    }, function (data) {
        $("#txtChat").val('');
        //LoadMessSync(post_id); //need to be update by signalR
        SendSignalChat(conver_id);
    });
}