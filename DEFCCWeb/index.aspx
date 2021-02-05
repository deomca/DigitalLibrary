<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <!-- Banner and serach section -->
     <section id="banner-search">
      <div class="container-fluid position-relative">
        <!-- Banner Logo Section -->
        <div class="row align-items-center mb-5 mb-md-0">
          <div class="col">
            <div class="client-logo">
              <a href="#" target="_blank">
                <img src="images/forest-bihar-logo.png" alt="forest bihar logo" class="img-fluid" />
              </a>
            </div>
          </div>
          <div class="col d-none d-md-block">
            <div class="main-logo text-center">
              <a href="#" class="text-white">
                <p class="mb-0 logo-text">DEFCC DIGITAL LIBRARY</p>
                <p>Patna Bihar</p>
              </a>
            </div>
          </div>
          <div class="col">
            <div class="developer-logo text-right">
              <a href="#" target="_blank">
                <img src="images/Nic.png" alt="nic" class="img-fluid"/>
              </a>
            </div>
          </div>
        </div>
        <!-- End Banner Logo Section -->
        <!-- Banner Search -->
        <div class="row justify-content-center">
          <div class="col-12 col-md-10 col-lg-7">
            <div class="search-box">
              <div class="card card-sm px-3 rounded-pill">
                  <div class="card-body row no-gutters align-items-center search-padding">
                      <div class="col-auto">
                          <i class="fas fa-search h4 text-body"></i>
                      </div>
                      <!--end of col-->
                      <div class="col">
                          <input id="active" class="form-control form-control-lg form-control-borderless" type="search" placeholder="Search topics or keywords">
                      </div>
                      <!--end of col-->
                      <div class="col-auto">
                          <button class="btn btn-sm btn-success" type="submit">Search</button>
                      </div>
                      <!--end of col-->
                  </div>
              </div>
            </div>
          </div>
          <!--end of col-->
          <!-- End Banner Search -->
        </div>
        <%--<div class="divider">
          <img src="images/divider.png" alt="divider">
        </div>--%>
      </div>
    </section>
 <!-- Main  -->
  <main id="main" class="mt-5">
    <div class="container-fluid mb-4">
      <div class="row">
        <div class="col-12">
          <h1 class="text-center heading">Collection of Wings</h1>
        </div>
      </div>
      <div class="row mt-4">
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> PCCF(HoFF)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> PCCF(DEV)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> APCCF(WP)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> APCCF(CWLW)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> APCCF(CAMPA)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> APCCF(CLIMATE CHANGE) </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> CCF(CLIMATE CHANGE)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> CCF(IT)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> CCF(HRD)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> CCF(JFM)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> CCF(HQ)  </a>
        </div>
        <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> CCF(M & E)  </a>
        </div>
         <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> HARIYALI MISSION  </a>
        </div>
         <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> F(SOUTH)  </a>
        </div>
         <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="Upload.aspx" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> F(NORTH)  </a>
        </div>
         <div class="col-sm-6 col-md-4 col-lg-3">        
            <a href="#" class="text-capitalize btn btn-lg btn-outline-success d-block mb-3"> OTHERS </a>
        </div>
      </div>
    </div>
    
  </main>
  <!-- End Main -->

</asp:Content>

