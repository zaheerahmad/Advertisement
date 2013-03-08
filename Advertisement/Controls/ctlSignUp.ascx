<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlSignUp.ascx.cs" Inherits="Advertisement.Controls.ctlSignUp" %>
<br />
<br />
<script type="text/javascript">
    $(document).ready(function () {
        $('#signUpErrorAlert').hide();
        $('#signUpSuccessAlert').hide();
    });
</script>

<script type="text/javascript">
    function SignUp() {
        var fullName = document.getElementById('fullName').value;
        var username = document.getElementById('user').value;
        var password = document.getElementById('Password').value;
        var cPassword = document.getElementById('cPassword').value;

        if (fullName == "" || username == "" || password == "" || cPassword == "") {
            $('#signUpErrorAlert').fadeIn(100);
        }
        else if (password != cPassword) {
            $('#signUpErrorAlert').fadeIn(100);
            alert("Password & Confirm Password mismatch");
            //document.getElementById('signUpErrorAlert'). == "<h4>Error!</h4>Mismatch Passwords."
        }
        else {
            $('#signUpErrorAlert').fadeOut(0);
            $.ajax({
                type: "POST",
                url: "WebServices/Users.asmx/SignUpUser",
                //data: .encode({pUserName: inp});
                data: "{'fullName':'" + fullName + "','userName':'" + username + "','password':'" + password + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                cache: false,
                success: function (msg) {
                    var obj = jQuery.parseJSON(msg.d);
                    if (obj.serviceErrorCode == 0) {
                        $('#signUpSuccessAlert').fadeIn(0);
                        document.getElementById('fullName').value = "";
                        document.getElementById('user').value = "";
                        document.getElementById('Password').value = "";
                        document.getElementById('cPassword').value = "";
                    }
                    else {
                        $('#signUpErrorAlert').fadeIn(0);
                    }
                }
            });
        }
    }
</script>
<div class="container">
    <div class="row">
        <div class="span6 offset3">
            <div class="hero-unit">
                <legend>Signup Form</legend>
                <div class="alert alert-error" id="signUpErrorAlert">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <h4>Error!</h4>
                    Invalid User/Password.
                </div>
                <div class="alert alert-success" id="signUpSuccessAlert">
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                    <h4>Success!</h4>
                    User Created Successfully.
                </div>
                <form class="form-horizontal" action="">
                  <div class="control-group">
                    <label class="control-label" for="fullName">Full Name</label>
                    <div class="controls">
                      <input type="text" id="fullName" placeholder="Enter Full Name here..." />
                    </div>
                  </div>
                  <div class="control-group">
                    <label class="control-label" for="user">User</label>
                    <div class="controls">
                      <input type="text" id="user" placeholder="Enter username here..." />
                    </div>
                  </div>
                  <div class="control-group">
                    <label class="control-label" for="Password">Password</label>
                    <div class="controls">
                      <input type="password" id="Password" placeholder="Enter Password here..." />
                    </div>
                  </div>
                  <div class="control-group">
                    <label class="control-label" for="cPassword">Confirm Password</label>
                    <div class="controls">
                      <input type="password" id="cPassword" placeholder="Enter Confirm Password here..." />
                    </div>
                  </div>
                  <div class="control-group">
                    <div class="controls">
                      <input type="button" class="btn btn-primary" value="Sign Up" onclick="SignUp()" />
                    </div>
                  </div>
                </form>
            </div>
        </div>
    </div>
</div>