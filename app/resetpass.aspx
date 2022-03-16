<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpass.aspx.cs" Inherits="app_resetpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <title>Bubblr Reset Pass</title>

     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.min.js" integrity="sha384-QJHtvGhmr9XOIpI6YVutG+2QOK9T+ZnN4kzFN1RtK3zEFEIsxhlmWl5/YESvpZ13" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta2/css/all.min.css" integrity="sha512-YWzhKL2whUzgiheMoBFwW8CKV4qpHQAEuvilg9FAn5VJUDwKZZxkJNuGM4XkWuk94WCrrwslk8yWNGmY1EduTA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>


    <link href="/css/style.css" rel="stylesheet" />
    <script>
        function UpdatePass() {
            var code = '<%=Request["code"]%>';
            var new_pass = $("#txtNewPass").val();

            $(".validation").remove();
            if (new_pass == '' || new_pass.length<7) {
                $("#txtNewPass").after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter your new password.<br/>Password must be greater than 6 characters.</div>");
                $("#txtNewPass").focus();
            }
            else {
                $.post("/api/user/update-pass.aspx", {
                    code: code,
                    pass: new_pass
                }, function (data) {
                    if (data == 1) {
                        alert("Updated new password!");
                        location.href = '/';
                    }
                });
            }

        }

        function PassValidate() {
            $(".validation").remove();
            if (new_pass == '' || new_pass.length < 7) {
                $("#txtNewPass").after("<div class='validation' style='color:red;margin-bottom: 5px;'>Please enter your new password.<br/>Password must be greater than 6 characters.</div>");
               
            }
        }
    </script>
</head>
<body>
    
     <div class="page" id="page-forgetpass" >
        <div style="float:right">
            <button class="btn btn-primary" style="margin:10px" onclick="location.href='/'">Bubblr</button>
        </div>
        <div style="clear:both"></div>
        <div class="logo-header">Reset Password.</div>
        <div class="text-desc">
            Please enter your new password <br />

        </div>
        <div class="col-xl-4 offset-xl-4 col-lg-6 offset-lg-3 col-8 offset-2" id="form-resetpass" style="margin-top:10px">
            <input type="text" class="form-control" id="txtResetEmail" placeholder="Email" readonly="readonly" value="<%= u.Email %>" /> <br />

            <input type="password" class="form-control" id="txtNewPass" placeholder="New Password" onchange="PassValidate()" /> 

           

            <div style="text-align:center;">
                <br />
                <button class="btn btn-primary" style="width:100%" onclick="UpdatePass()">Update My Password</button>
            </div>

        </div>

    </div>

</body>
</html>
