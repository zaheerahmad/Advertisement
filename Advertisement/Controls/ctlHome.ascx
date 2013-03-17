<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlHome.ascx.cs" Inherits="Advertisement.Controls.ctlHome" %>
<link href="../assets/slider/themes/generic.css" rel="stylesheet" type="text/css" />
<link href="../assets/slider/themes/4/slider.css" rel="stylesheet" type="text/css" />
<%--<script src="../assets/slider/themes/jquery-1.7.1.min.js" type="text/javascript"></script>--%>
<script src="../assets/slider/themes/4/jquery-slider.js" type="text/javascript"></script>
<%--<script src="../assets/MainSlider/js/jquery-1.3.1.min.js" type="text/javascript"></script>--%>
       <html>  
            
            
                    <head>
                            <script>
                                $(document).ready(function () {

                                    //Execute the slideShow
                                    slideShow();
                                    getLatestAdds();

                                });

                            function slideShow() {

	                            //Set the opacity of all images to 0
	                            $('#gallery a').css({opacity: 0.0});
	
	                            //Get the first image and display it (set it to full opacity)
	                            $('#gallery a:first').css({opacity: 1.0});
	
	                            //Set the caption background to semi-transparent
	                            $('#gallery .caption').css({opacity: 0.7});

	                            //Resize the width of the caption according to the image width
	                            $('#gallery .caption').css({width: $('#gallery a').find('img').css('width')});
	
	                            //Get the caption of the first image from REL attribute and display it
	                            $('#gallery .content').html($('#gallery a:first').find('img').attr('rel'))
	                            .animate({opacity: 0.7}, 400);
	
	                            //Call the gallery function to run the slideshow, 6000 = change to next image after 6 seconds
	                            setInterval('gallery()',6000);
	
                            }

                            function gallery() {
	
	                            //if no IMGs have the show class, grab the first image
	                            var current = ($('#gallery a.show')?  $('#gallery a.show') : $('#gallery a:first'));

	                            //Get next image, if it reached the end of the slideshow, rotate it back to the first image
	                            var next = ((current.next().length) ? ((current.next().hasClass('caption'))? $('#gallery a:first') :current.next()) : $('#gallery a:first'));	
	
	                            //Get next image caption
	                            var caption = next.find('img').attr('rel');	
	
	                            //Set the fade in effect for the next image, show class has higher z-index
	                            next.css({opacity: 0.0})
	                            .addClass('show')
	                            .animate({opacity: 1.0}, 1000);

	                            //Hide the current image
	                            current.animate({opacity: 0.0}, 1000)
	                            .removeClass('show');
	
	                            //Set the opacity to 0 and height to 1px
	                            $('#gallery .caption').animate({opacity: 0.0}, { queue:false, duration:0 }).animate({height: '1px'}, { queue:true, duration:500 });	
	
	                            //Animate the caption, opacity to 0.7 and heigth to 100px, a slide up effect
	                            $('#gallery .caption').animate({opacity: 0.7},100 ).animate({height: '100px'},500 );
	
	                            //Display the content
	                            $('#gallery .content').html(caption);


	                        }
	                        function getLatestAdds() {

	                          



	                            $.ajax({
	                                type: "POST",
	                                url: "WebServices/Users.asmx/GetUpdatedAdds",
	                                async: false,
	                                contentType: "application/json; charset=utf-8",
	                                dataType: "json",
	                                cache: false,	                                
	                                success: function (msg) {	                                   
	                                    setTimeout(function () { getLatestAdds(); }, 20000);
	                                    var obj = jQuery.parseJSON(msg.d);	                                    
	                                    if (obj.serviceErrorCode == 0) {	                                       
	                                        $('div.materialContent').html('');
	                                        $('div.materialContent').html(obj.html);
	                                       
	                                    }
	                                    else {
	                                        $('#errorAlert').fadeIn(100);
	                                    }
	                                }
	                            });
                                    
                                    
	                            

	                        }

                            </script>

                            <script type="text/javascript">
                                function AutoRefresh(t) {
                                    setTimeout("location.reload(true);", t);
                                }
    
                                </script>
                            <style type="text/css">
                            body{
	                            font-family:arial
                            }

                            .clear {
	                            clear:both
                            }

                            #gallery {
	                            position:relative;
	                            height:353px;
                            }
	                            #gallery a {
		                            float:left;
		                            position:absolute;
	                            }
	
	                            #gallery a img {
		                            border:none;
	                            }
	
	                            #gallery a.show {
		                            z-index:500
	                            }

	                            #gallery .caption {
		                            z-index:600; 
		                            background-color:#000; 
		                            color:#ffffff; 
		                            height:100px; 
		                            width:100%; 
		                            position:absolute;
		                            bottom:0;
	                            }

	                            #gallery .caption .content {
		                            margin:5px
	                            }
	
	                            #gallery .caption .content h3 {
		                            margin:0;
		                            padding:0;
		                            color:#1DCCEF;
	                            }
                                   .infoDiv
                                        {
                                          border-bottom: 1px dotted #9E9E9E;
                                          margin-top: 19px;
                                        }
                                        .priceDiv
                                        {
                                          margin-left: 735px;
                                          color: #339304;
                                        }
                                        #panel
                                        {
                                        padding:50px;
                                        display:none;
                                        }
                                        ul
                                        {
                                            list-style-type: none;
                                        }
			                            .materialInfo{			    
			                                padding:30px;			
			                            }
			                            .moreInfo
			                            {
			                                margin-left: 210px;
			                            }
			                            .imgInfo
			                            {
			                                width:100px;
			                                height:75px;
			                            }
			                            div.comment
			                            {			
			                            margin-top:20px;
			                            display: inline-block;
           
			
			                            }
			                            .error
			                            {
			                            border: 1px solid #dd4b39;
			    
			                            }
			
			                            div { word-wrap: break-word; }	
			                            div.materialContent
			                            {
			                                margin-left:8%;
			                                margin-top:30px;
			
			                            }	
                                        div.mainGallery
                                        {
                                                height: 213px;
                                                overflow: hidden;
                                                position: relative;
                                                width: 770px;
                                        }
                            </style>

                    </head>
                    <body>
                        <div class="container">
                                <div class="row">
                                    <div class="span9">
                                    <div class="hero-unit">
                                        <legend>Featured Ads</legend>
                                        <div id="gallery" class="mainGallery">

                                            <% Advertisement.Controller.AdController controllerAd = new Advertisement.Controller.AdController();
                                               foreach (Advertisement.Model.Ad ad in controllerAd.FetchAll().OrderByDesc("AdDate"))
                                               {
                                                   string[] arr = ad.AdPicture.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                   foreach (string image in arr)
                                                   {
                                                   %>
                            
                                               <a href="Advertisement.aspx?ctl=1&id=<%=ad.AdId %>" class="show">
                                                <img src="../upload/AdImage/MainSlider/<%=image%>" alt="Flowing Rock" width="950" height="450" title="" alt="" rel="<h3><%=ad.AdTitle %></h3><%if(ad.AdDetail.Length > 60){ %><%=ad.AdDetail.Substring(0,60) + "..." %> <%}%><%else{ %><%=ad.AdDetail %><%} %>" />
                                               </a>
                             
                                               <%}
                                               }
                                                 %>

	                                        <div class="caption"><div class="content"></div></div>
                                        </div>
                                    <div class="clear"></div>
                                </div>
                                </div>
                                <div class="span3">
                                    <div class="row">
                                        <div class="span3">
                                            <div class="hero-unit">
                                            <h6>Filter Results</h6>
                                            <form action="">
                                                <table class="table">
                                                    <tr>
                                                    <td>
                                                        <label>Filter By Material Name</label>
                                                        <input type="text" class="input-medium" placeholder="Material Name"/>
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                    <td>
                                                        <label>Filter By Date</label>
                                                        <input type="text" class="input-medium" placeholder="Material Date"/>
                                                    </td>
                                                    </tr>
                                                </table>
                    
                                                <div class="control-group">
                                                <div class="controls">
                                                    <button type="submit" class="btn  btn-primary">Filter Result</button>
                                                </div>
                                                </div>
                                            </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                <legend>Recent Posts</legend>
                               <div class="row materialContent">
                                     
                               </div>
                    </div>
            </body>
   </html>  