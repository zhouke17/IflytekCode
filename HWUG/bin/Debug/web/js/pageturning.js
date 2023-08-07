
var obj;
var pgindex = 1; //当前页
var allpages = 1;//总页数

	function pageUp()
	{
	
		if(pgindex >0)
		{			
			//alert(pgindex);
			pgindex -=1;
			obj.scrollTop = (pgindex-1) * parseInt(obj.offsetHeight); //根据高度，输出指定的页
		}
	}
	
	function pageDown()
	{
		if(pgindex <= allpages)
		{									
			pgindex +=1;
			obj.scrollTop = (pgindex-1) * parseInt(obj.offsetHeight);			
		}
	}
	
	function pageInit()
	{
		obj = document.getElementById("frameContent"); //获取内容层
		allpages = Math.ceil(parseInt(obj.scrollHeight) / parseInt(obj.offsetHeight)); //获取页面数量
	}
	
	function getButtonsInfo(){
		var button_up = document.getElementById("pageup").getBoundingClientRect();
		var button_down = document.getElementById("pagedown").getBoundingClientRect();

		
		var upInfo = getButRect("201", button_up);
		var downInfo = getButRect("202", button_down);
		var info = upInfo+downInfo;
		return info.slice(0,-1);
	};

	function getButRect(rectName,dom){
		var rectInfo= "{";
		rectInfo += "\"left\":\"" + Math.round(dom.left)+"\",";
		rectInfo += "\"top\":\"" + Math.round(dom.top)+"\",";
		rectInfo += "\"right\":\"" + Math.round(dom.right)+"\",";
		rectInfo += "\"bottom\":\"" + Math.round(dom.bottom)+"\",";
		rectInfo += "\"btnid\":\"" + rectName+"\"},";
		return rectInfo;	
	};