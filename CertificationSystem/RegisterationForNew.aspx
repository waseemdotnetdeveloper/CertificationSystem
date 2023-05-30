<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterationForNew.aspx.cs" Inherits="CertificationSystem.RegisterationForNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" ></script>
    <script href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src ="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/js/bootstrap-datetimepicker.min.js"></script>  
<link rel ="stylesheet" href ="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css"/>  
<link rel ="stylesheet" href ="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.7.14/css/bootstrap-datetimepicker.min.css"/>  
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <style type="text/css">
       .alert-danger {
    color: #fff;
    background-color: #f2dede;
    border-color: #ebccd1;
}
       .alert-success {
           color: #fff;
       }
    </style>
</head>

<body>
    <form id="form1" runat="server">
       <div>
           <div class="container">
               <div class="row">
                   <div class="col-md-12">
                       <div id="dvMessage" runat="server"></div>
                       <asp:Label ID="studentno" runat="server" Text="" Visible="false"></asp:Label>
                   </div>
                   
               </div>
               <div class="row">
                   <div class="col-md-12 bg-primary mt-1">
                        <div class="heading-section text-center">
                       <h1>Register to yourself</h1>
                   </div>
                   </div>
               </div>
               <div class="row mt-3">
                   <div class="col-md-6">
                       First Name :<asp:TextBox ID="FirstName" runat="server" CssClass="form-control" BorderColor="Black" AutoPostBack="true" placeholder="Please Enter Firts Name"></asp:TextBox>
                       </div>
                       <div class="col-md-6">
                           Last Name : <asp:TextBox ID="LastName" runat="server" CssClass="form-control" BorderColor="Black" AutoPostBack="true" placeholder="Please Enter Last Name"></asp:TextBox>
                   </div>
               </div>
               <div class="row mt-3">
                   <div class="col-md-6">
                      DOB: <asp:TextBox ID="DOB" runat="server" CssClass="form-control" BorderColor="Black"  AutoPostBack="true" TextMode="Date" placeholder="Please Enter your date of birth"></asp:TextBox>
                </div>
                      <div class="col-md-6">
                        Gender:  <asp:DropDownList ID="ddlgender" runat="server" DataTextField="GenderName" DataValueField="GenderId"  AutoPostBack="true" CssClass="form-control" BorderColor="Black" placeholder="Please Select your Gender"></asp:DropDownList>

                      </div>
                   </div>
                   <div  class="row mt-3">
                       <div class="col-md-6">
                           Email : <asp:TextBox ID="Cnic" runat="server" CssClass="form-control" BorderColor="Black"  AutoPostBack="true" TextMode="Email" placeholder="Please Enter your Email"></asp:TextBox>
                       </div>
                       <div class="col-md-6">
                           MartialStatus: <asp:DropDownList ID="ddlmartialstatus" runat="server" DataTextField="MartiaStatus" Width="100%" DataValueField="MartialId" AutoPostBack="true" BorderColor="Black" CssClass="form-control"  ></asp:DropDownList>
                       </div>
                   </div>
               <div  class="row mt-3">
                       <div class="col-md-6">
                           PhoneNumber : <asp:TextBox ID="PhoneNumber" runat="server" CssClass="form-control" BorderColor="Black"  placeholder="Please Enter your Phone Number" OnTextChanged="PhoneNumber_TextChanged" AutoPostBack="true" ></asp:TextBox>
                           </div>
                       <div class="col-md-6">
                           Education <asp:DropDownList ID="ddleducation" runat="server" DataTextField="Education" Width="100%" DataValueField="EduId" AutoPostBack="true" BorderColor="Black" CssClass="form-control"  ></asp:DropDownList>
                       </div>
                   </div>

                   <div class="row mt-3">
                       <div class="col-md-6">
                          Country : <asp:DropDownList ID="ddlcountry" runat="server" DataTextField="CountryName" Width="100%" DataValueField="CountryId" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" ></asp:DropDownList>
                       </div>
                       <div class="col-md-6">
                            City: <asp:DropDownList ID="dllcity" runat="server" DataTextField="CityName" DataValueField="CityId"  AutoPostBack="true" CssClass="form-control" Width="100%" BorderColor="Black" placeholder="Please Select your City" OnSelectedIndexChanged="dllcity_SelectedIndexChanged"></asp:DropDownList>
                       </div>
                   </div>
                   <div class="row mt-3">
                       <div class="col-md-6">
                           Department <asp:DropDownList ID="ddldepartment" runat="server" DataTextField="DepartmentName" DataValueField="DepartmentId" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Width="100%"></asp:DropDownList> 
                       </div>
                       <div class="col-md-6">
                           Sub Department <asp:DropDownList ID="ddlsubdep" runat="server" DataTextField="SubDepartmentName" DataValueField="DepartmentId" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlsubdep_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                       </div>
                   </div>
                   <div class="row mt-3">
                       <div class="col-md-6">
                           Course <asp:DropDownList ID="ddlcourse" runat="server" DataTextField="CourseName" DataValueField="DepartmentId" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                       </div>
                       <div class="col-md-6">
                           Teacher <asp:DropDownList ID="ddlteacher" runat="server" DataTextField="TeacherName" DataValueField="DepartmentId" AutoPostBack="true" CssClass="form-control" Width="100%"></asp:DropDownList>
                       </div>
                   </div>
                   <div class="row mt-3">
                       <div class="col-md-6">
                            Username:(Must be Unique) <asp:TextBox ID="Username" runat="server" CssClass="form-control" BorderColor="Black" AutoPostBack="true" placeholder="Please Enter Your Username"></asp:TextBox>
                       </div>
                      <div class="col-md-6">
                          Password:(Must be Unique) <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" BorderColor="Black" AutoPostBack="false" placeholder="Please Enter Your Password"></asp:TextBox>
                      </div>
                   </div>
                   <div class="row mt-3">
                       <div class="col-md-6">
                            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success btn-danger-width"  Width="100%" Text="Register Yourself " OnClick="btnRegister_Click" />&nbsp;&nbsp;
                
                       </div>
                       <div class="col-md-6">
                           <asp:Button ID="btnCancal" runat="server" CssClass="btn btn-danger btn-danger-width" Width="100%"  Text="Cancel Process" OnClick="btnCancal_Click" />
                       </div>
                   </div>
           </div>
       </div>
    </form>
    <script
  src="https://code.jquery.com/jquery-3.7.0.js"
  integrity="sha256-JlqSTELeR4TLqP0OG9dxM7yDPqX1ox/HfgiSLBj8+kM="
  crossorigin="anonymous"></script>
    <script type="text/javascript">
        //function formatMobileNumber() {
        //    var mobileNumber = $("#PhoneNumber").val();

        //    // Remove all non-numeric characters from the input
        //   // mobileNumber = mobileNumber.replace(/\D/g, '');
            

        //    // Format the number as "+92-xxxx-xxxxxxx"
        //    var formattedNumber = "+92-" + mobileNumber.substr(0, 4) + "-" + mobileNumber.substr(4, 7);

        //    // Set the formatted number back to the input field
        //    $("#PhoneNumber").val(formattedNumber);
        //}
    </script>
</body>
</html>
