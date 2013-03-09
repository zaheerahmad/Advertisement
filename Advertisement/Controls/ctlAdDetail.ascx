<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlAdDetail.ascx.cs" Inherits="Advertisement.Controls.ctlAdDetail" %>
<link href="../assets/themes/2/js-image-slider.css" rel="stylesheet" type="text/css" />
<script src="../assets/themes/2/js-image-slider.js" type="text/javascript"></script>

<div class="page-header">
            <h1>Details<small> Ad Name here</small></h1>
        </div>
        <div id="sliderFrame">
            <div id="slider">
                        
                  <!--  <img src="../../assets/images/image-slider-1.jpg" alt="Welcome to jQuery Slider" />-->
                  <%int id = TTD.Common.Utility.GetIntParameter("id");
                    Advertisement.Model.Ad ad = new Advertisement.Model.Ad("AdId", id);
                    string[] adImage = ad.AdPicture.Split(new Char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string image in adImage)
                    {
                        if (ad.AdDetail.Length > 60)
                        {
                            %>
                      <img src="../upload/AdImage/Detail/<%=image%>" alt="<%=ad.AdDetail.Substring(0,60)+"..." %>" />
                      <%}
                        else
                        {%>
                      <img src="../upload/AdImage/Detail/<%=image%>" alt="<%=ad.AdDetail%>" />
                        <%}
                    }%>
                      
            </div>
            <!--thumbnails-->
            <div id="thumbs">
            <%
                    foreach (string image in adImage)
                    {%>
                        <div class="thumb">
                        <div class="frame"><img src="../upload/AdImage/Detail/<%=image %>" /></div>
                        <%if (ad.AdDetail.Length > 20)
                        {
                            %>
                      <div class="thumb-content"><p><%=ad.AdTitle %></p><%=ad.AdDetail.Substring(0,20)+"..." %></div>
                      <%}
                        else
                        {%>
                      <div class="thumb-content"><p><%=ad.AdTitle %></p><%=ad.AdDetail %></div>
                        <%}%>
                        
                        <div style="clear:both;"></div>
                    </div>
                   <% }%>
            </div>

            <!--clear above float:left elements. It is required if above #slider is styled as float:left. -->
            <div style="clear:both;height:0;"></div>
        </div>
        <div class="page-header">
            <h4>Contact Details</h4>
        </div>
        <address>
            <strong>Twitter, Inc.</strong><br>
            795 Folsom Ave, Suite 600<br>
            San Francisco, CA 94107<br>
            <abbr title="Phone">P:</abbr> (123) 456-7890
        </address>
 
        <address>
            <strong>Full Name</strong><br>
            <a href="mailto:#">first.last@example.com</a>
        </address>
        <div class='page-header'>
			<h4>
				Suggestions for use
			</h4>
		</div>
        <div class='commentBox'>
           
            
        </div>
         <div class='suggestionArea' style="margin-top:40px;">            
            <div class='control'>                    
                    <textarea name='suggestionBox' style='width: 500px;' placeholder='Suggestions'></textarea></br>
                    <a class='btn btn-mini btn-primary sugst' type='button'>Suggest</a>
            </div>
        </div>