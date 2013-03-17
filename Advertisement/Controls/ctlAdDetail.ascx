<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlAdDetail.ascx.cs" Inherits="Advertisement.Controls.ctlAdDetail" %>
<link href="../assets/themes/2/js-image-slider.css" rel="stylesheet" type="text/css" />
<script src="../assets/themes/2/js-image-slider.js" type="text/javascript"></script>

<script>

    

</script>


<div class="page-header">
<%int id = TTD.Common.Utility.GetIntParameter("id");
                    Advertisement.Model.Ad ad = new Advertisement.Model.Ad("AdId", id);%>
        <div class="hero-unit">
            <h1>Details<small> <%=ad.AdTitle %></small></h1>
        
        <div id="sliderFrame">
            <div id="slider">
                        
                  <!--  <img src="../../assets/images/image-slider-1.jpg" alt="Welcome to jQuery Slider" />-->
                  
                    <%string[] adImage = ad.AdPicture.Split(new Char[]{','}, StringSplitOptions.RemoveEmptyEntries);
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
        <br />
        <br />
        <legend>
            Ad Detail
        </legend>
        <div style="display:inline-block; background-color:ThreeDHighlight">
           <p>
            <%=ad.AdDetail %>
          </p>
          </div>
          <br />
          <br />
        <legend>
            Contact Details
        </legend>
        <div style="display:inline-block">
            <%Advertisement.Model.User user = new Advertisement.Model.User("LoginId", ad.LoginId);%>
                <address>
                    <strong><%=user.FName%></strong><br>
                    <a href="mailto:#"><%=ad.AdEmailAddress%></a>
                    <p><%=ad.AdAddress%></p>
                    <strong>Price: </strong><%=ad.AdAskingPrice%><br />
                    <abbr title="Phone">P:</abbr> <%=ad.AdContactNo%>
                </address>
        </div>
        <div class='page-header'>
			<legend>
				Suggestions for use
			</legend>
		</div>
        <div class='commentBox'>

            <%  Advertisement.Model.SuggestionCollection coll = new Advertisement.Model.SuggestionCollection().Where(Advertisement.Model.Suggestion.Columns.AdverId, id).Load(); %>

            <%foreach(Advertisement.Model.Suggestion suggestionData in coll) 
                  
              {%>
                <div class="media" style="background-color:#f5f7fa">  <a class="pull-left" href="#">    <img class="media-object" src="assets/images/unknown.jpg">  </a>  <div class="media-body">    <h4 class="media-heading" style="color:#467ed6;"><%=suggestionData.Username %></h4>  <div class="media"><%=suggestionData.SuggestionText%></div>  </div>    </div>

              <%} %>


        </div>
         <div class='suggestionArea' style="margin-top:40px;">            
            <div class='control'>                    
                    <textarea name='suggestionBox' style='width: 500px;' placeholder='Suggestions'></textarea></br>
                    <a class='btn btn-mini btn-primary sugst' type='button'>Suggest</a>
                    <input type="hidden" id="adverID" value="<%=id%>"> </input >
            </div>
        </div>
        </div>
        </div>