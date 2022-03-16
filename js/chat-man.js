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