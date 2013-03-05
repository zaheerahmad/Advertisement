<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlHome.ascx.cs" Inherits="Advertisement.Controls.ctlHome" %>
<link href="../assets/slider/themes/generic.css" rel="stylesheet" type="text/css" />
<link href="../assets/slider/themes/4/slider.css" rel="stylesheet" type="text/css" />
<script src="../assets/slider/themes/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../assets/slider/themes/4/jquery-slider.js" type="text/javascript"></script>
<script src="../assets/MainSlider/js/jquery-1.3.1.min.js" type="text/javascript"></script>
<script>
$(document).ready(function() {		
	
	//Execute the slideShow
	slideShow();

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
	height:358px
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
	

</style>
<div class="row">
    <div class="span9">
    <div class="hero-unit">
        <legend>Featured Ads</legend>
        <div id="gallery">

	        <a href="Advertisement.aspx?ctl=1" class="show">
		        <img src="../assets/MainSlider/images/flowing-rock.jpg" alt="Flowing Rock" width="950" height="450" title="" alt="" rel="<h3>Flowing Rock</h3>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "/>
	        </a>
	
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/grass-blades.jpg" alt="Grass Blades" width="950" height="450" title="" alt="" rel="<h3>Grass Blades</h3>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "/>
	        </a>
	
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/ladybug.jpg" alt="Ladybug" width="950" height="450" title="" alt="" rel="<h3>Ladybug</h3>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."/>
	        </a>

	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/lightning.jpg" alt="Lightning" width="950" height="450" title="" alt="" rel="<h3>Lightning</h3>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."/>
	        </a>
	
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/lotus.jpg" alt="Lotus" width="950" height="450" title="" alt="" rel="<h3>Lotus</h3>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo."/>
	        </a>
	
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/mojave.jpg" alt="Mojave" width="950" height="450" title="" alt="" rel="<h3>Mojave</h3>Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt."/>
	        </a>
		
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/pier.jpg" alt="Pier" width="950" height="450" title="" alt="" rel="<h3>Pier</h3>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."/>
	        </a>
	
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/sea-mist.jpg" alt="Sea Mist" width="950" height="450" title="" alt="" rel="<h3>Sea Mist</h3>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."/>
	        </a>
	
	        <a href="Advertisement.aspx?ctl=1">
		        <img src="../assets/MainSlider/images/stones.jpg" alt="Stone" width="950" height="450" title="" alt="" rel="<h3>Stone</h3>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."/>
	        </a>

	        <div class="caption"><div class="content"></div></div>
        </div>
    <div class="clear"></div>
        <%--<div class="div2">
            <div id="mcts1">
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-1.jpg" onmouseover="tooltip.pop(this, 'This is the first slide')" /></a>
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-2.jpg" onmouseover="tooltip.pop(this, '#tip2')" /></a>
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-3.jpg" onmouseover="tooltip.pop(this, '#tip3')" /></a>
                <a href="Advertisement.aspx?ctl=1"><div class="class1" onmouseover="tooltip.pop(this, '#tip4')"><p>HTML Content</p>This slide shows that HTML/Text can also be used as thumbnails</div></a>
                <a href="Advertisement.aspx?ctl=1"><a href="#" onmouseover="tooltip.pop(this, '#tipA')"><img src="../assets/slider/images/thumbnail-slider-4.jpg" /></a></a>
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-5.jpg" onmouseover="tooltip.pop(this, '#tipB')" /></a>
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-6.jpg" onmouseover="tooltip.pop(this, 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')" /></a>
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-7.jpg" onmouseover="tooltip.pop(this, '#tipC')" /></a>
                <a href="Advertisement.aspx?ctl=1"><img src="../assets/slider/images/thumbnail-slider-8.jpg" onmouseover="tooltip.pop(this, 'Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur')" /></a>
            </div>
        </div>
        <div style="display:none;">
            <div id="tip2">
                <div class="tips">
                    <img src="../assets/slider/images/thumbnail-slider-2.jpg" style="float:right;margin-left:6px;margin-bottom:6px;width:154px;height:80px;" />
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                </div>
            </div>
            <div id="tip3">
                <div class="tips">
                    <img src="../assets/slider/images/thumbnail-slider-3.jpg" style="float:left;margin-right:8px;margin-bottom:8px;width:87px;height:80px;" />
                    <b>Lorem Ipsum</b>
                    Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </div>
            </div>
            <div id="tip4">
                <div class="tips">
                    <img src="../assets/slider/images/thumbnail-slider-1.jpg" style="float:left;margin-right:8px;margin-bottom:8px;width:111px;height:80px;" />
                    <b>Lorem Ipsum</b>
                    Donec nec orci sed enim malesuada scelerisque eget id felis. Phasellus sapien sem, convallis quis vehicula ut, lobortis ut ipsum. Aliquam erat volutpat. Curabitur ac sem ac orci accumsan feugiat.
                </div>
            </div>
            <div id="tipA">
                <div class="tips">
                    <b>Duis Aute Irure</b>
                    Nullam sodales lectus id justo facilisis dignissim quis a dui. Curabitur dictum lectus porttitor felis hendrerit varius.
                </div>
            </div>
            <div id="tipB">
                <div class="tips">
                    <b>Phasellus Et Nulla Sem</b>
                    Etiam interdum consectetur quam, ac aliquet dui ornare nec. Ut tincidunt elit enim, eu posuere orci. Mauris et velit ac risus vehicula aliquet et a dolor. Fusce id nulla orci, sed aliquam nunc.
                </div>
            </div>
            <div id="tipC">
                <div class="tips">
                    <img src="../assets/slider/images/thumbnail-slider-7.jpg" style="float:left;margin-right:8px;margin-bottom:8px;width:140px;height:80px;" />
                    <b>jQuery Slider with Tooltip</b>
                    This is a demo showing how to integrate the Menucool Tooltip with the Menucool jQuery Slider.
                </div>
            </div>
        </div>--%>
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
                            <label>Material Name</label>
                            <input type="text" class="input-small" placeholder="Material Name"/>
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
        <div class="row">
            <div class="span3">
                
                    <h6>Ads Streaming</h6>
                        <table class="table table-striped">
                            <tr>
                            <td>
                                <div class="media">
                                    <a class="pull-left" href="#">
                                    <img class="media-object" src="../assets/images/thumb1.jpg" data-src="holder.js/64x64">
                                    </a>
                                    <div class="media-body">
                                    <h4 class="media-heading">Material Name</h4>
                                    This is a test material Detail for Demo
                                    </div>
                                </div>
                            </td>
                            </tr>
                            <tr>
                            <td>
                                <div class="media">
                                    <a class="pull-left" href="#">
                                    <img class="media-object" src="../assets/images/thumb1.jpg" data-src="holder.js/64x64">
                                    </a>
                                    <div class="media-body">
                                    <h4 class="media-heading">Material Name</h4>
                                    This is a test material Detail for Demo
                                    </div>
                                </div>
                            </td>
                            </tr>
                            </table>
            </div>
        </div>
    </div>
</div>
<div class="row">
    <div class="span12">
        <Legend>Material Information</Legend>
                    <table class='table table-striped'><th>Material</th><th>Material Type</th><th>Status</th><th>Date</th><th>Name</th><th>Image</th><th>Operations</th>
                                           <div class='row' style='margin-top:10px'> 
                                                <tr class='materialInfo'>
                                                <td class='materialInfo'>Material Name A</td>
                                                <td>Material Type A</td>                                               
                                                <td>10-12-2012</td>
                                                <td>Zaheer Ahmad</td>
                                                <td><i class='icon-ok'></i>Sold</td>
                                                <td><img src='../../assets/images/thumb1.jpg' alt='no img avaiable'></td>
                                                <td><a type='submit' href='Advertisement.aspx?ctl=1'>Details</a></td>
                                                </tr>
                                                </div>
									       <div class='row' style='margin-top:10px'> 
                                                    <tr class='materialInfo'>
                                                    <td>Material Name A</td>
                                                    <td>Material Type A</td>                                               
                                                    <td>10-12-2012</td>
                                                    <td>Khurram Farooq</td>
                                                    <td><i class='icon-ok'></i>Sold</td>
                                                    <td><img src='../../assets/images/thumb1.jpg' alt='no img avaiable'></td>
                                                    <td><a type='submit' href='Advertisement.aspx?ctl=1'>Details</a></td>
                                                    </tr>
                                                    </div></table><div class='row'><ul class='pager'>
                                                    <li class='previous'>
                                                    <a href='#' onClick=''>&larr; Older</a>
                                                    </li>
                                                    <li class='next'>
                                                    <a href='#'>Newer &rarr;</a>
                                                    </li>
                                                    </ul>
                                         </div>
    </div>
</div>