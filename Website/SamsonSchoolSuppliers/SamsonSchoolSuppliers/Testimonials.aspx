<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Testimonials.aspx.cs" Inherits="SamsonSchoolSuppliers.Testimonials" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="banner-area" class="banner-area" style="background-image:url(images/banner/banner3.png)">
  <div class="banner-text">
    <div class="container">
        <div class="row">
          <div class="col-lg-12">
              <div class="banner-heading">
                <h1 class="banner-title">Testimonials</h1>
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb justify-content-center">
                      <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
                      <li class="breadcrumb-item"><a href="#">Company</a></li>
                      <li class="breadcrumb-item active" aria-current="page">Testimonials</li>
                    </ol>
                </nav>
              </div>
          </div><!-- Col end -->
        </div><!-- Row end -->
    </div><!-- Container end -->
  </div><!-- Banner text end -->
</div><!-- Banner area end --> 

<section id="main-container" class="main-container">
   <div class="container">
      <div class="row text-center">
         <div class="col-12">
            <h3 class="section-sub-title mb-4">What People Said</h3>
         </div>
      </div>
      <!--/ Title row end -->

      <div class="row">
         <div class="col-lg-4 col-md-6">
            <div class="quote-item quote-border mt-5">
               <div class="quote-text-border">
                   My shopping experience with the Samson School Suppliers's Website was great. I just loved how their website was interactive,
                   and just beautiful. I managed to get all what I needed for my kids in a just few clicks. 
               </div>

               <div class="quote-item-footer">
                  <img loading="lazy" class="testimonial-thumb" src="images/clients/testimonial4.png" alt="testimonial">
                  <div class="quote-item-info">
                     <h3 class="quote-author">Donna Ndlovu</h3>
                     <span class="quote-subtext">Parent</span>
                  </div>
               </div>
            </div><!-- Quote item end -->
         </div><!-- End col md 4 -->

         <div class="col-lg-4 col-md-6">
            <div class="quote-item quote-border mt-5">
               <div class="quote-text-border">
                                      After a long time of searching, I finally found a supplier that provides timely and quality school wear for my school. 
                        When I ordered in bulk, I was given discounts which helped a lot of parents in my school.
               </div>

               <div class="quote-item-footer">
                  <img loading="lazy" class="testimonial-thumb" src="images/clients/testimonial1.png" alt="testimonial">
                  <div class="quote-item-info">
                     <h3 class="quote-author">Phephisile Khumalo</h3>
                     <span class="quote-subtext">Principal, Simtfolile High School</span>
                  </div>
               </div>
            </div><!-- Quote item end -->
         </div><!-- End col md 4 -->

         <div class="col-lg-4 col-md-6">
            <div class="quote-item quote-border mt-5">
               <div class="quote-text-border">
                  One of the greatest experience as a teacher is seeing your students smile. Samson School Suppliers has brough back
                   smiles onto my students face. Loving their uniforms has made them love school even more. Thank Samsons. 
               </div>

               <div class="quote-item-footer">
                  <img loading="lazy" class="testimonial-thumb" src="images/clients/testimonial5.png" alt="testimonial">
                  <div class="quote-item-info">
                     <h3 class="quote-author">Hyram Izzy</h3>
                     <span class="quote-subtext">Teacher, World Class Academy</span>
                  </div>
               </div>
            </div><!-- Quote item end -->
         </div><!-- End col md 4 -->

      </div><!-- Content row end -->

   </div><!-- Container end -->
</section><!-- Main container end -->

    </asp:Content>