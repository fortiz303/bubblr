/// BOTTOM MENU CHANGE TAB
function ChangeTab(id) {

    clearInterval(inter_load_mess);
    clearInterval(inter_load_chat_sync);

    $(".page").hide();

    $(".menu-active").removeClass("menu-active");
    $(".menu-item").eq(id - 1).addClass("menu-active");
    if (id == 1) {
        ViewPostList();
        $("#page-post").show();
    }
    else if (id == 2) {

        if (localStorage.nav_stack_chat!= null && localStorage.nav_stack_chat != 0) {
            // open the current chat
            OpenChat(localStorage.nav_stack_chat, localStorage.nav_stack_post_title);
        }
        else {
            //load list of chat history room
            LoadMessenger();

            inter_load_mess = setInterval(LoadMessenger, 6000);

            $("#page-messages").show();
        }
    }
    else if (id == 3)
        $("#page-create-post").show();
    else if (id == 4) {
        ListPostByUser();
        $("#page-account").show();
    }
        
}