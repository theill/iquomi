	
	/**
	 * 
	 * 
	 */
	function QueryIquomi(subscriptionName, serviceMethodName) {
		var head = document.getElementsByTagName('head').item(0);
		if (!head) {
			return;
		}
		
		var old  = document.getElementById('lastLoadedCmds');
		if (old) {
			head.removeChild(old);
		}
		
		script = document.createElement('script');
		
		var scriptUrl = "http://services.iquomi.com/" + subscriptionName + "/" + serviceMethodName + ".rpc" + '&rnd=' + Math.random();
		script.src = scriptUrl;
		script.type = 'text/javascript';
		script.defer = true;
		script.id = 'lastLoadedCmds';
		
		void(head.appendChild(script));
		
	} // > function QueryIquomi(...)
