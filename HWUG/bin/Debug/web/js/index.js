
function signclick(){
	var obj = document.getElementById("sign");
	obj.style.backgroundColor= "#A9A9A9";

	var obj = document.getElementById("finger");
	obj.style.backgroundColor= "#A50A0A";
	var obj = document.getElementById("sfinger");
	obj.style.backgroundColor= "#A50A0A";
	
	var signcontent = document.getElementById("signcontent");
	signcontent.innerHTML="";
	
	var iframe = document.createElement('iframe'); 
    iframe.id="iframe";
	iframe.src="sign.html"; 
	iframe.width="100%";
    iframe.height="100%";
	signcontent.appendChild(iframe);
		
} 


function fingerclick(){
	var obj = document.getElementById("finger");
    obj.style.backgroundColor= "#A9A9A9";

	var obj = document.getElementById("sign");
	obj.style.backgroundColor= "#A50A0A";
	var obj = document.getElementById("sfinger");
	obj.style.backgroundColor= "#A50A0A";

	
	var signcontent = document.getElementById("signcontent");
	signcontent.innerHTML="";
	
	var iframe = document.createElement('iframe'); 
    iframe.id="iframe";
	iframe.src="finger.html"; 
	iframe.width="100%";
    iframe.height="100%";
	signcontent.appendChild(iframe);
	
} 

function sfingerclick(){
	var obj = document.getElementById("sfinger");
    obj.style.backgroundColor= "#A9A9A9";

	var obj = document.getElementById("sign");
	obj.style.backgroundColor= "#A50A0A";
	
	var obj = document.getElementById("finger");
	obj.style.backgroundColor= "#A50A0A";
	
	var signcontent = document.getElementById("signcontent");
	signcontent.innerHTML="";
	
	var iframe = document.createElement('iframe'); 
    iframe.id="iframe";
	iframe.src="sfinger.html"; 
	iframe.width="100%";
    iframe.height="100%";
	signcontent.appendChild(iframe);

}


