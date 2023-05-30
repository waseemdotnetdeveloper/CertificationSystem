<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CertificationSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login 10</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet"/>

	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
	
	<link rel="stylesheet" <%--href="css/style.css"--%> href="assets/Login/css/style.css"/>

  <!-- =======================================================
  * Template Name: Mentor
  * Updated: Mar 10 2023 with Bootstrap v5.2.3
  * Template URL: https://bootstrapmade.com/mentor-free-education-bootstrap-theme/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
   <style type="text/css">
				body {
					background-image:url(assets/Login/images/bg.jpg)
				}
   </style>
</head>
<body class="img js-fullheight">
    <form id="form1" runat="server" class="signin-form" >
       <div>
		   <div class="row">
                   <div class="col-md-12">
                       <div id="dvMessage" runat="server"></div>
                       <asp:Label ID="studentno" runat="server" Text="" Visible="false"></asp:Label>
                   </div>
                   
               </div>
		   <section class="ftco-section">
			   <div class="container">
				    <div class="row justify-content-center">
				   <div class="col-md-6 text-center mb-5">
					   <h2 class="heading-section"><b>Certification System</b></h2><br />
					   <h2 class="heading-section"><b>Please Login</b></h2>
				   </div>
			   </div>
				   <div class="row justify-content-center">
					   <div class="col-md-6 col-lg-4">
						   <div class="login-wrap p-0">
							   <h3 class="mb-4 text-center">Have an Account</h3>
							   <div class="form-group">
								   <asp:Label ID="lbl" runat="server" Text="Username" CssClass="control-label"></asp:Label>
								   <asp:TextBox ID="usernametxt" runat="server" CssClass="form-control" placeholder="Please Enter Username" required="*"></asp:TextBox>
							   </div>
							    <div class="form-group">
									<asp:Label ID="Lbl2" runat="server" Text="Password" CssClass="control-label"></asp:Label>
								   <asp:TextBox ID="passwordtxt" runat="server" CssClass="form-control" TextMode="Password" placeholder="Please Enter your Password" required="*"></asp:TextBox>
									<span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
							   </div>
							   <div class="form-group">
								   <asp:Button ID="loginbtn" runat="server" CssClass="btn btn-primary submit px-3" Width="100%" Text="Login" OnClick="loginbtn_Click"/>
							   </div>
							   <div class="form-group d-md-flex">
								   <div class="w-50">
									<label class="checkbox-wrap checkbox-primary">Remember Me
									  <input type="checkbox" checked>
									  <span class="checkmark"></span>
									</label>
									  </div>
								   <div class="w-50 text-md-right">
									<a href="#" style="color: #fff">Forgot Password</a>
								</div>
							   </div>
							   <div class="form-group d-md-flex">
								   <div class="w-50 text-md-left">
									   <asp:Label ID="register" runat="server" CssClass="control-label d-inline-block" Text="Don't Have an Account?" ForeColor="#fbceb5" ></asp:Label>&nbsp;&nbsp; <asp:LinkButton ID="link" runat="server" CssClass="d-inline-block" ForeColor="Red" ><b>Click to Register</b></asp:LinkButton>
									  

								   </div>
									   
								   </div>
							    <p class="w-100 text-center">&mdash; Or Sign In With &mdash;</p>
	          <div class="social d-flex text-center">
	          	<a href="#" class="px-2 py-2 mr-md-1 rounded"><span class="ion-logo-facebook mr-2"></span> Facebook</a>
	          	<a href="#" class="px-2 py-2 ml-md-1 rounded"><span class="ion-logo-twitter mr-2"></span> Twitter</a>
	          </div>
						   </div>
					   </div>
				   </div>
			   </div>
			  
		   </section>
       </div>
 

	

    </form>
	<script src="assets/Login/js/jquery.min.js"></script>
<script src="assets/Login/js/popper.js"></script>
<script src="assets/Login/js/bootstrap.min.js"></script>
<script src="assets/Login/js/main.js"></script>
</body>
</html>
