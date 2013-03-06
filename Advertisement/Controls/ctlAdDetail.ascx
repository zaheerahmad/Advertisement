<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlAdDetail.ascx.cs" Inherits="Advertisement.Controls.ctlAdDetail" %>
<link href="../assets/themes/2/js-image-slider.css" rel="stylesheet" type="text/css" />
<script src="../assets/themes/2/js-image-slider.js" type="text/javascript"></script>

<div class="page-header">
            <h1>Details<small> Ad Name here</small></h1>
        </div>
        <div id="sliderFrame">
            <div id="slider">
                        
                  <!--  <img src="../../assets/images/image-slider-1.jpg" alt="Welcome to jQuery Slider" />-->
                     
                     <img src="../assets/images/ScrapMetalRecycling.jpg" alt="Welcome to jQuery Slider" />
                   
                        <img src="../assets/images/waste-material-handler.jpg" alt="Pure Javascript. No jQuery. No Flash." />
                        <img src="../assets/images/1201302-74275-crane-carrying-waste-material-at-recycling-center.jpg" />
                        <img src="../assets/images/image-slider-4.jpg" />
            </div>
            <!--thumbnails-->
            <div id="thumbs">
                <div class="thumb">
                    <div class="frame"><img src="../assets/images/ScrapMetalRecycling.jpg" /></div>
                    <div class="thumb-content"><p>HTML Content</p>Thumbnails allows any HTML content</div>
                    <div style="clear:both;"></div>
                </div>
                <div class="thumb">
                    <div class="frame"><img src="../assets/images/waste-material-handler.jpg" /></div>
                    <div class="thumb-content"><p>Customizable</p>Thumbnail style is customizable</div>
                    <div style="clear:both;"></div>
                </div>
                <div class="thumb">
                    <div class="frame"><img src="../assets/images/1201302-74275-crane-carrying-waste-material-at-recycling-center.jpg" /></div>
                    <div class="thumb-content"><p>Variety of Layouts</p>Just a CSS tweak.</div>
                    <div style="clear:both;"></div>
                </div>
                <div class="thumb">
                    <div class="frame"><img src="../assets/images/thumb4.jpg" /></div>
                    <div class="thumb-content"><p>Integration</p>Built-in functions for the thumbnails</div>
                    <div style="clear:both;"></div>
                </div>
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