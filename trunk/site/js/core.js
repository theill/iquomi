	
	var FadeSteps = 50;

	function HideNotificationStep(id, opacity, height, steps) {
		var e = document.getElementById(id);
		
		e.style.filter = "progid:DXImageTransform.Microsoft.Alpha(opacity=" + opacity + ")";
		height -= steps;
//		e.style.clip = "rect(0 580 " + (steps * FadeSteps + height) + " 0)";
		
		opacity -= 2;
		
		if (opacity > 0) {
			self.setTimeout("HideNotificationStep('" + id + "', " + opacity + ", " + height + ", " + steps + ")", 10);
		} else {
			e.style.display = "none";
		}
	}
	
	function HideNotification(id, waitInMillis) {
		var e = document.getElementById(id);
		if (e == null) {
			return;
		}
		
		var height = e.offsetHeight;
		var steps = height / FadeSteps;
		
		e.style.overflow = "hidden";
//		e.style.height = height;
		
		self.setTimeout("HideNotificationStep('" + id + "', " + "100" + ", " + 0 + ", " + steps + ")", waitInMillis);
	}
	
	function SetFocusUI(field) {
		if (field.value == "Search") {
			field.value = "";
			field.className = "Text";
		}
	}
	