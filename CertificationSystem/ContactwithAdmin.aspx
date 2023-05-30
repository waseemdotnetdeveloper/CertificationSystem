<%@ Page Title="Contact" Language="C#" MasterPageFile="~/CertificationSystem.Master" AutoEventWireup="true" CodeBehind="ContactwithAdmin.aspx.cs" Inherits="CertificationSystem.Contact.ContactwithAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .alert 
        {
   
    color: #fbfbfb;
    
        }
    </style>
    <main id="main">
        <div class="row">
            <div class="col-md-12">
                <center>
                     <div id="dvMessage" runat="server">
                </div>
                </center>
               
            </div>
        </div>
    <!-- ======= Breadcrumbs ======= -->
    
      <div class="breadcrumbs" data-aos="fade-in">
      <div class="container">
        <h2>contact with admin</h2>
        <p>est dolorum ut non facere possimus quibusdam eligendi voluptatem. quia id aut similique quia voluptas sit quaerat debitis. rerum omnis ipsam aperiam consequatur laboriosam nemo harum praesentium. </p>
      </div>
    </div>
        <!-- End Breadcrumbs   -->

    <!-- ======= Contact Section ======= -->
    <section id="contact" class="contact">
      <div data-aos="fade-up">
       <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d7924.909400169796!2d74.35818002412189!3d31.482870034886794!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x391905d1c67ca0fb%3a0xa3367d968cc49665!2swateen%20telecom%20limited!5e0!3m2!1sen!2s!4v1684133981058!5m2!1sen!2s" style="border:0; width: 100%; height: 350px;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
      </div>

      <div class="container" data-aos="fade-up">

        <div class="row mt-5">

          <div class="col-lg-4">
            <div class="info">
              <div class="address">
                <i class="bi bi-geo-alt"></i>
                <h4>Location:</h4>
                <p>A108 Adam Street, New York, NY 535022</p>
              </div>

              <div class="email">
                <i class="bi bi-envelope"></i>
                <h4>Email:</h4>
                <p>info@example.com</p>
              </div>

              <div class="phone">
                <i class="bi bi-phone"></i>
                <h4>Call:</h4>
                <p>+1 5589 55488 55s</p>
              </div>

            </div>

          </div>

          <div class="col-lg-8 mt-5 mt-lg-0">
              <div class="row">
                <div class="col-md-6 form-group">
                  
                  <asp:TextBox ID="Nametxtbox" runat="server" type="text" class="form-control" name="name" placeholder="Your Name"></asp:TextBox>
                </div>
                <div class="col-md-6 form-group mt-3 mt-md-0">
                  <asp:TextBox ID="emailtxtbox" runat="server" type="email" class="form-control" name="email" placeholder="Your Email" ></asp:TextBox>
                </div>
                  
              </div>
              <div class="form-group mt-3">
               <asp:TextBox ID="subjecttxtbox" runat="server" type="subject" class="form-control" name="subject" placeholder="Your Subject" ></asp:TextBox>
              </div>
              <div class="form-group mt-3">
                <asp:TextBox id="messageBox" runat="server" class="form-control" name="message" rows="5" placeholder="Message" ></asp:TextBox>
               
              </div>
            
              
              <div class="my-3">
                <div class="loading">Loading</div>
                <div class="error-message"></div>
                <div class="sentmessage">Your message has been sent. Thank you!</div>
              </div>
              <div class="text-center"> 
                  <asp:Button ID="contactbutton" class="btn btn-success btn-rounded" runat="server" Text="Send Message" OnClick="contactbutton_Click" />

              </div>
             

          </div>

        </div>

      </div>
    </section><!-- End Contact Section -->

  </main><!-- End #main -->
</asp:Content>
<asp:Content ID="scriptFooter" runat="server" ContentPlaceHolderID="footerPlace" >
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#contactbutton").click(function () {
                $("#ContentPlaceHolder1_dvMessage").css("background-color", "white");
            });
        });
    </script>
    </asp:Content>


