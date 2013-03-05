<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlHome.ascx.cs" Inherits="Advertisement.Controls.ctlHome" %>
<link href="../assets/slider/themes/generic.css" rel="stylesheet" type="text/css" />
<link href="../assets/slider/themes/4/slider.css" rel="stylesheet" type="text/css" />
<script src="../assets/slider/themes/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="../assets/slider/themes/4/jquery-slider.js" type="text/javascript"></script>
<script src="../assets/slider/themes/4/tooltip.js" type="text/javascript"></script>
<link href="../assets/slider/themes/4/tooltip.css" rel="stylesheet" type="text/css" />
<style>
    .tips b {display:block; text-align:left; margin-bottom:9px;}
</style>
<div class="row">
    <div class="span10">
    <div class="hero-unit">
        <legend>Featured Ads</legend>
        <div class="div2">
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
        </div>
    </div>
    </div>
    <div class="span2">
        <div class="row">
            <div class="span2">
                <legend>Filter Results</legend>
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