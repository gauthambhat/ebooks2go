// JavaScript Document
$(document).ready(function(e) {
    $('.bankinfo').css('overflow', 'hidden');
});
function bankAnim(e){
	$('.bankinfo').css('overflow', 'hidden');
	$('.bankinfo').animate({'height':'3em'});
	$('.bankinfo').css('overflow','hidden');
}