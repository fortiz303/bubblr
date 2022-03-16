var base64 = "";

function SelectPhoto() {
    $("#filePhoto").click();
}

function Preview(event) {
    var input = event.target;
    if (input.files) {
        var reader = new FileReader();
        reader.fileName = input.files[0].name;
        reader.onload = function (e) {
            base64 = e.target.result.replace(/^data:image\/[a-z]+;base64,/, "");
            //$("#preview").attr("src", e.target.result);
            //$("#preview").attr("style", "max-width:200px");
            $("#post-photo").attr("src", e.target.result);
            $(".vali-photo").remove();
            $("#post-photo-close").show();
        }
        reader.readAsDataURL(input.files[0]);
    }
};

/// CREATE NEW POST
function CreatePost() {
    var token = localStorage.token;
    $("#btnSave").attr("disabled", "disabled");
    $(".validation").remove();
    var title = $("#txtTitle").val();
    var shortdes = $("#txtShortDes").val();
    var contdes = $("#txtContDes").val();
    var location = $("#txtLocation").val();
    var err = '';

    if (base64 == '') {
        err += 'Please select photo.';
        $("#lblPostImg").after("<div class='validation vali-photo'  style='color:red;margin-bottom: 15px;text-align:center'>Please select photo</div>");
        $("#lblPostImg").focus();
    }

    if (title == '') {
        /*alert("Please enter title.")*/
        err += 'Please enter title.';
        $("#txtTitle").parent().after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter title</div>");
        $("#txtTitle").focus();
    }
    /*if (shortdes == '') {
        err += 'Please enter short Description.';
        $("#txtShortDes").parent().after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter short Description</div>");
        $("#txtShortDes").focus();
    }*/
    if (contdes == '') {
        /*alert("Please enter title.")*/
        err += 'Please enter Content Description.';
        $("#txtContDes").parent().after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter Content Description</div>");
        $("#txtContDes").focus();
    }
    if (err != '') {
        /* alert("Please enter title.");*/
        $("#btnSave").removeAttr("disabled");
    }
    else {

        $.post(BASE_API + "post/create-post.aspx", {
            base64: base64,
            title: title,
            shortdes: shortdes,
            contdes: contdes,
            token: token,
            location: location

        }, function (data) {
            if (data == 1) {
                $("#txtTitle").val('');
                $("#txtShortDes").val('');
                $("#txtContDes").val('');
                $("#txtLocation").val('');
                base64 = "";
                $("#btnSave").removeAttr("disabled");
                alert("New post Created!")
                //GoTo('page-post');
                ChangeTab(1);
                $("#menu").show();
            }
            else {
                alert("Please try again.")
                $("#btnSave").removeAttr("disabled");
            }

        });

    }


}

function RemovePostPhoto() {
    $("#post-photo-close").hide();
    base64 = '';
    $("#post-photo").attr("src", "img/icon/ic-add-pic.png");
}

/// LIST ALL POST BY LOGIN USERS
function ListPostByUser() {
    var token = localStorage.token;
    $.ajax({
        data: { token: token },
        dataType: "json",
        url: BASE_API + 'post/get-list-post-by-user.aspx',

        success: function (data) {
            //    console.log(data);
            pr_list = '';
            pr_list += '<table>';
            pr_list += '<tr>';
            pr_list += '<th> Posts </th>';
            pr_list += '<th> Action </th>';
            pr_list += '</tr>';

            $.each(data, function (key, val) {
                //console.log(key + " " + val.title);
                if (val.title.length > 40) { val.title = val.title.substring(0, 40) + " ..." }
                if (val.short_desc.length > 70) { val.short_desc = val.short_desc.substring(0, 70) + " ..." }
                pr_list += '<tr>';
                pr_list += '<td>';
                pr_list += '<div class="post-block" onclick="ViewMyPostDetails(' + val.post_id + ')">';
                pr_list += '<div class="post-img"><img src="/img/post/' + val.img + '" class="img-avt-circle rounded-circle" /></div>';
                pr_list += '<div class="post-desc">';
                pr_list += '<div class="post-title">' + val.title + '</div>';
                pr_list += '<div class="post-short-desc">' + val.short_desc + '</div>';
                pr_list += '</div>';
                pr_list += '<div class="post-clear"></div>';
                pr_list += '</div>';
                pr_list += '</td>';
                pr_list += '<td>';
               /* pr_list += '<div class="post-block" onclick="ViewEditPost(' + val.post_id + ')">';
                pr_list += '<i class="fas fa-edit"></i>';
                pr_list += '</div>';
                pr_list += '</br>';*/
                pr_list += '<div class="post-block" onclick="DeletePost(' + val.post_id + ')">';
                pr_list += '<i class="fa-solid fa-trash"></i>';
                pr_list += '</div>';
                pr_list += '</td>';
                pr_list += '</tr>';

            });

            $("#post-list-by-user").html(pr_list);
        }
    });
}

/// UPDATE POST
function UpdatePost(post_id) {
    var token = localStorage.token;
    $("#btnUpdate").attr("disabled", "disabled");
    $(".validation").remove();
    var title = $("#txtEditTitle").val();
    var shortdes = $("#txtEditShortDes").val();
    var contdes = $("#txtEditContDes").val();
    var err = '';
    if (title == '') {
        /*alert("Please enter title.")*/
        err += 'Please enter title.';
        $("#txtEditTitle").parent().after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter title</div>");
        $("#txtEditTitle").focus();
    }
    if (shortdes == '') {
        /*alert("Please enter title.")*/
        err += 'Please enter short Description.';
        $("#txtEditShortDes").parent().after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter short Description</div>");
        $("#txtEditShortDes").focus();
    }
    if (contdes == '') {
        /*alert("Please enter title.")*/
        err += 'Please enter Content Description.';
        $("#txtEditContDes").parent().after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter Content Description</div>");
        $("#txtEditContDes").focus();
    }
    if (err != '') {
        /* alert("Please enter title.");*/
        $("#btnUpdate").removeAttr("disabled");
    }
    else {

        $.post(BASE_API + "post/update-post.aspx", {
            base64: base64,
            title: title,
            shortdes: shortdes,
            contdes: contdes,
            token: token,
            post_id: post_id

        }, function (data) {
            if (data == 1) {
               
                base64 = "";
                $("#btnUpdate").removeAttr("disabled");
                alert("Updated Post!")
                GoTo('page-post');
                $("#menu").show();
            }
            else {
                alert("Please try again.")
                $("#btnUpdate").removeAttr("disabled");
            }

        });

    }
}

/// DELETE POST
function DeletePost(post_id) {
    t = confirm("Are you sure you want to delete?");
    if (t) {
        $.post(BASE_API + "post/delete-post.aspx?post_id=" + post_id, {
            token: localStorage.token
        }, function (data) {
            if (data == 1) {
                ListPostByUser();
            }
        });
    }
}


function ViewMyPostDetails(post_id) {
    $.ajax({
        dataType: "json",
        url: BASE_API + 'post/get-top-content.aspx?post_id=' + post_id,
        success: function (data) {

            $.each(data, function (key, val) {

                $("#my-post-details-img img").attr('src', "/img/post/" + val.img);
                $("#my-post-details-user").html('<i class="fas fa-user" style="margin-right:10px"></i>' + val.user_name);
                $("#my-post-details-title").html(val.title);
                $("#my-post-details-desc").html(val.post_content);

                GoTo('page-my-post-details');


            })

        }
    });
}

function ViewEditPost(post_id) {
    $.ajax({
        dataType: "json",
        url: BASE_API + 'post/get-top-content.aspx?post_id=' + post_id,
        success: function (data) {
            $.each(data, function (key, val) {

                $("#txtEditTitle").val(val.title);
                $("#txtEditShortDes").val(val.short_desc);
                $("#txtEditContDes").val(val.post_content);
                $("#btnUpdate").attr("onclick", "UpdatePost(" + post_id + ")");
                GoTo('page-edit-post');
            })

        }
    });
}