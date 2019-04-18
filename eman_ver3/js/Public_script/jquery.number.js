/*!function(e){"use strict";function t(e,t){if(this.createTextRange){var a=this.createTextRange();a.collapse(!0),a.moveStart("character",e),a.moveEnd("character",t-e),a.select()}else this.setSelectionRange&&(this.focus(),this.setSelectionRange(e,t))}function a(e){var t=this.value.length;if(e="start"==e.toLowerCase()?"Start":"End",document.selection){var a,i,n,l=document.selection.createRange();return a=l.duplicate(),a.expand("textedit"),a.setEndPoint("EndToEnd",l),i=a.text.length-l.text.length,n=i+l.text.length,"Start"==e?i:n}return"undefined"!=typeof this["selection"+e]&&(t=this["selection"+e]),t}var i=0,n={codes:{46:127,188:44,109:45,190:46,191:47,192:96,220:92,222:39,221:93,219:91,173:45,187:61,186:59,189:45,110:46},shifts:{96:"~",49:"!",50:"@",51:"#",52:"$",53:"%",54:"^",55:"&",56:"*",57:"(",48:")",45:"_",61:"+",91:"{",93:"}",92:"|",59:":",39:'"',44:"<",46:">",47:"?"}};e.fn.number=function(l,s,r,u){u="undefined"==typeof u?",":u,r="undefined"==typeof r?".":r,s="undefined"==typeof s?0:s;var h="\\u"+("0000"+r.charCodeAt(0).toString(16)).slice(-4),o=new RegExp("[^"+h+"0-9]","g"),c=new RegExp(h,"g");return l===!0?this.is("input:text")?this.on({"keydown.format":function(l){i=1;var h=e(this),o=h.data("numFormat"),c=l.keyCode?l.keyCode:l.which,v="",d=a.apply(this,["start"]),p=a.apply(this,["end"]),f="",g=!1;if(n.codes.hasOwnProperty(c)&&(c=n.codes[c]),!l.shiftKey&&c>=65&&90>=c?c+=32:!l.shiftKey&&c>=69&&105>=c?c-=48:l.shiftKey&&n.shifts.hasOwnProperty(c)&&(v=n.shifts[c]),""==v&&(v=String.fromCharCode(c)),8!=c&&45!=c&&127!=c&&v!=r&&!v.match(/[0-9]/)){var m=l.keyCode?l.keyCode:l.which;if(46==m||8==m||127==m||9==m||27==m||13==m||(65==m||82==m||80==m||83==m||70==m||72==m||66==m||74==m||84==m||90==m||61==m||173==m||48==m)&&(l.ctrlKey||l.metaKey)===!0||(86==m||67==m||88==m)&&(l.ctrlKey||l.metaKey)===!0||m>=35&&39>=m||m>=112&&123>=m)return;return l.preventDefault(),!1}if(0==d&&p==this.value.length?8==c?(d=p=1,this.value="",o.init=s>0?-1:0,o.c=s>0?-(s+1):0,t.apply(this,[0,0])):v==r?(d=p=1,this.value="0"+r+new Array(s+1).join("0"),o.init=s>0?1:0,o.c=s>0?-(s+1):0):45==c?(d=p=2,this.value="-0"+r+new Array(s+1).join("0"),o.init=s>0?1:0,o.c=s>0?-(s+1):0,t.apply(this,[2,2])):(o.init=s>0?-1:0,o.c=s>0?-s:0):o.c=p-this.value.length,o.isPartialSelection=d==p?!1:!0,s>0&&v==r&&d==this.value.length-s-1)o.c++,o.init=Math.max(0,o.init),l.preventDefault(),g=this.value.length+o.c;else if(45!=c||0==d&&0!=this.value.indexOf("-"))if(v==r)o.init=Math.max(0,o.init),l.preventDefault();else if(s>0&&127==c&&d==this.value.length-s-1)l.preventDefault();else if(s>0&&8==c&&d==this.value.length-s)l.preventDefault(),o.c--,g=this.value.length+o.c;else if(s>0&&127==c&&d>this.value.length-s-1){if(""===this.value)return;"0"!=this.value.slice(d,d+1)&&(f=this.value.slice(0,d)+"0"+this.value.slice(d+1),h.val(f)),l.preventDefault(),g=this.value.length+o.c}else if(s>0&&8==c&&d>this.value.length-s){if(""===this.value)return;"0"!=this.value.slice(d-1,d)&&(f=this.value.slice(0,d-1)+"0"+this.value.slice(d),h.val(f)),l.preventDefault(),o.c--,g=this.value.length+o.c}else 127==c&&this.value.slice(d,d+1)==u?l.preventDefault():8==c&&this.value.slice(d-1,d)==u?(l.preventDefault(),o.c--,g=this.value.length+o.c):s>0&&d==p&&this.value.length>s+1&&d>this.value.length-s-1&&isFinite(+v)&&!l.metaKey&&!l.ctrlKey&&!l.altKey&&1===v.length&&(f=p===this.value.length?this.value.slice(0,d-1):this.value.slice(0,d)+this.value.slice(d+1),this.value=f,g=d);else l.preventDefault();g!==!1&&t.apply(this,[g,g]),h.data("numFormat",o)},"keyup.format":function(n){i=1;var l,r=e(this),u=r.data("numFormat"),h=n.keyCode?n.keyCode:n.which,o=a.apply(this,["start"]),c=a.apply(this,["end"]);0!==o||0!==c||189!==h&&109!==h||(r.val("-"+r.val()),o=1,u.c=1-this.value.length,u.init=1,r.data("numFormat",u),l=this.value.length+u.c,t.apply(this,[l,l])),""===this.value||(48>h||h>57)&&(96>h||h>105)&&8!==h&&46!==h&&110!==h||(r.val(r.val()),s>0&&(u.init<1?(o=this.value.length-s-(u.init<0?1:0),u.c=o-this.value.length,u.init=1,r.data("numFormat",u)):o>this.value.length-s&&8!=h&&(u.c++,r.data("numFormat",u))),46!=h||u.isPartialSelection||(u.c++,r.data("numFormat",u)),l=this.value.length+u.c,t.apply(this,[l,l]))},"paste.format":function(t){var a=e(this),i=t.originalEvent,n=null;return window.clipboardData&&window.clipboardData.getData?n=window.clipboardData.getData("Text"):i.clipboardData&&i.clipboardData.getData&&(n=i.clipboardData.getData("text/plain")),a.val(n),t.preventDefault(),!1}}).each(function(){var t=e(this).data("numFormat",{c:-(s+1),decimals:s,thousands_sep:u,dec_point:r,regex_dec_num:o,regex_dec:c,init:this.value.indexOf(".")?!0:!1});""!==this.value&&t.val(t.val())}):this.each(function(){var t=e(this),a=+t.text().replace(o,"").replace(c,".");t.number(isFinite(a)?+a:0,s,r,u)}):this.text(e.number.apply(window,arguments))};var l=null,s=null;e.isPlainObject(e.valHooks.text)?(e.isFunction(e.valHooks.text.get)&&(l=e.valHooks.text.get),e.isFunction(e.valHooks.text.set)&&(s=e.valHooks.text.set)):e.valHooks.text={},e.valHooks.text.get=function(t){var a,i=e(t),n=i.data("numFormat");return n?""===t.value?"":(a=+t.value.replace(n.regex_dec_num,"").replace(n.regex_dec,"."),(0===t.value.indexOf("-")?"-":"")+(isFinite(a)?a:0)):e.isFunction(l)?l(t):void 0},e.valHooks.text.set=function(t,a){var i=e(t),n=i.data("numFormat");if(n){var l=e.number(a,n.decimals,n.dec_point,n.thousands_sep);return e.isFunction(s)?s(t,l):t.value=l}return e.isFunction(s)?s(t,a):void 0},e.number=function(e,t,a,n){n="undefined"==typeof n?"1000"!==new Number(1e3).toLocaleString()?new Number(1e3).toLocaleString().charAt(1):"":n,a="undefined"==typeof a?new Number(.1).toLocaleString().charAt(1):a,t=isFinite(+t)?Math.abs(t):0;var l="\\u"+("0000"+a.charCodeAt(0).toString(16)).slice(-4),s="\\u"+("0000"+n.charCodeAt(0).toString(16)).slice(-4),r=e;if(0==i){if(","==n)r=e.replace(new RegExp(n,"g"),"");else for(;r.indexOf(n)>-1;)r=r.replace(".","");e=r}else i=0;e=(e+"").replace(".",a).replace(new RegExp(s,"g"),"").replace(new RegExp(l,"g"),".").replace(new RegExp("[^0-9+-Ee.]","g"),"");var u=isFinite(+e)?+e:0,h="",o=function(e,t){return""+ +(Math.round(e+"e+"+t)+"e-"+t)};return h=(t?o(u,t):""+Math.round(u)).split("."),h[0].length>3&&(h[0]=h[0].replace(/\B(?=(?:\d{3})+(?!\d))/g,n)),(h[1]||"").length<t&&(h[1]=h[1]||"",h[1]+=new Array(t-h[1].length+1).join("0")),h.join(a)}}(jQuery);*/
/**
 * jQuery number plug-in 2.1.5
 * Copyright 2012, Digital Fusion
 * Licensed under the MIT license.
 * http://opensource.teamdf.com/license/
 *
 * A jQuery plugin which implements a permutation of phpjs.org's number_format to provide
 * simple number formatting, insertion, and as-you-type masking of a number.
 *
 * @author	Sam Sehnert
 * @docs	http://www.teamdf.com/web/jquery-number-format-redux/196/
 */
(function($){

	"use strict";

	/**
	 * Method for selecting a range of characters in an input/textarea.
	 *
	 * @param int rangeStart			: Where we want the selection to start.
	 * @param int rangeEnd				: Where we want the selection to end.
	 *
	 * @return void;
	 */
	 var vnn_number = 0, vnn_firstload = 0;
	function setSelectionRange( rangeStart, rangeEnd )
	{
		// Check which way we need to define the text range.
		if( this.createTextRange )
		{
			var range = this.createTextRange();
				range.collapse( true );
				range.moveStart( 'character',	rangeStart );
				range.moveEnd( 'character',		rangeEnd-rangeStart );
				range.select();
		}

		// Alternate setSelectionRange method for supporting browsers.
		else if( this.setSelectionRange )
		{
			this.focus();
			this.setSelectionRange( rangeStart, rangeEnd );
		}
	}

	/**
	 * Get the selection position for the given part.
	 *
	 * @param string part			: Options, 'Start' or 'End'. The selection position to get.
	 *
	 * @return int : The index position of the selection part.
	 */
	function getSelection( part )
	{
		var pos	= this.value.length;

		// Work out the selection part.
		part = ( part.toLowerCase() == 'start' ? 'Start' : 'End' );

		if( document.selection ){
			// The current selection
			var range = document.selection.createRange(), stored_range, selectionStart, selectionEnd;
			// We'll use this as a 'dummy'
			stored_range = range.duplicate();
			// Select all text
			//stored_range.moveToElementText( this );
			stored_range.expand('textedit');
			// Now move 'dummy' end point to end point of original range
			stored_range.setEndPoint( 'EndToEnd', range );
			// Now we can calculate start and end points
			selectionStart = stored_range.text.length - range.text.length;
			selectionEnd = selectionStart + range.text.length;
			return part == 'Start' ? selectionStart : selectionEnd;
		}

		else if(typeof(this['selection'+part])!="undefined")
		{
			pos = this['selection'+part];
		}
		return pos;
	}

	/**
	 * Substitutions for keydown keycodes.
	 * Allows conversion from e.which to ascii characters.
	 */
	var _keydown = {
		codes : {
			46 : 127,
			188 : 44,
			109 : 45,
			190 : 46,
			191 : 47,
			192 : 96,
			220 : 92,
			222 : 39,
			221 : 93,
			219 : 91,
			173 : 45,
			187 : 61, //IE Key codes
			186 : 59, //IE Key codes
			189 : 45, //IE Key codes
			110 : 46  //IE Key codes
		},
		shifts : {
			96 : "~",
			49 : "!",
			50 : "@",
			51 : "#",
			52 : "$",
			53 : "%",
			54 : "^",
			55 : "&",
			56 : "*",
			57 : "(",
			48 : ")",
			45 : "_",
			61 : "+",
			91 : "{",
			93 : "}",
			92 : "|",
			59 : ":",
			39 : "\"",
			44 : "<",
			46 : ">",
			47 : "?"
		}
	};

	/**
	 * jQuery number formatter plugin. This will allow you to format numbers on an element.
	 *
	 * @params proxied for format_number method.
	 *
	 * @return : The jQuery collection the method was called with.
	 */
	$.fn.number = function( number, decimals, dec_point, thousands_sep ){

		// Enter the default thousands separator, and the decimal placeholder.
		thousands_sep	= (typeof thousands_sep === 'undefined') ? ',' : thousands_sep;
		dec_point		= (typeof dec_point === 'undefined') ? '.' : dec_point;
		decimals		= (typeof decimals === 'undefined' ) ? 0 : decimals;

		// Work out the unicode character for the decimal placeholder.
		var u_dec			= ('\\u'+('0000'+(dec_point.charCodeAt(0).toString(16))).slice(-4)),
			regex_dec_num	= new RegExp('[^'+u_dec+'0-9]','g'),
			regex_dec		= new RegExp(u_dec,'g');

		// If we've specified to take the number from the target element,
		// we loop over the collection, and get the number.
		if( number === true )
		{
			// If this element is a number, then we add a keyup
			if( this.is('input:text') )
			{
				vnn_firstload = 1;
				// Return the jquery collection.
				return this.on({

					/**
					 * Handles keyup events, re-formatting numbers.
					 *
					 * Uses 'data' object to keep track of important information.
					 *
					 * data.c
					 * This variable keeps track of where the caret *should* be. It works out the position as
					 * the number of characters from the end of the string. E.g., '1^,234.56' where ^ denotes the caret,
					 * would be index -7 (e.g., 7 characters from the end of the string). At the end of both the key down
					 * and key up events, we'll re-position the caret to wherever data.c tells us the cursor should be.
					 * This gives us a mechanism for incrementing the cursor position when we come across decimals, commas
					 * etc. This figure typically doesn't increment for each keypress when to the left of the decimal,
					 * but does when to the right of the decimal.
					 *
					 * @param object e			: the keyup event object.s
					 *
					 * @return void;
					 */
					'keydown.format' : function(e){
						vnn_number = 1;
						// Define variables used in the code below.
						var $this	= $(this),
							data	= $this.data('numFormat'),
							code	= (e.keyCode ? e.keyCode : e.which),
							chara	= '', //unescape(e.originalEvent.keyIdentifier.replace('U+','%u')),
							start	= getSelection.apply(this,['start']),
							end		= getSelection.apply(this,['end']),
							val		= '',
							setPos	= false;

						// Webkit (Chrome & Safari) on windows screws up the keyIdentifier detection
						// for numpad characters. I've disabled this for now, because while keyCode munging
						// below is hackish and ugly, it actually works cross browser & platform.

//						if( typeof e.originalEvent.keyIdentifier !== 'undefined' )
//						{
//							chara = unescape(e.originalEvent.keyIdentifier.replace('U+','%u'));
//						}
//						else
//						{
							if (_keydown.codes.hasOwnProperty(code)) {
								code = _keydown.codes[code];
							}
							if (!e.shiftKey && (code >= 65 && code <= 90)){
								code += 32;
							} else if (!e.shiftKey && (code >= 69 && code <= 105)){
								code -= 48;
							} else if (e.shiftKey && _keydown.shifts.hasOwnProperty(code)){
								//get shifted keyCode value
								chara = _keydown.shifts[code];
							}

							if( chara == '' ) chara = String.fromCharCode(code);
//						}




						// Stop executing if the user didn't type a number key, a decimal character, backspace, or delete.
						if( code != 8 && code != 45 && code != 127 && chara != dec_point && !chara.match(/[0-9]/) )
						{
							// We need the original keycode now...
							var key = (e.keyCode ? e.keyCode : e.which);
							if( // Allow control keys to go through... (delete, backspace, tab, enter, escape etc)
								key == 46 || key == 8 || key == 127 || key == 9 || key == 27 || key == 13 ||
								// Allow: Ctrl+A, Ctrl+R, Ctrl+P, Ctrl+S, Ctrl+F, Ctrl+H, Ctrl+B, Ctrl+J, Ctrl+T, Ctrl+Z, Ctrl++, Ctrl+-, Ctrl+0
								( (key == 65 || key == 82 || key == 80 || key == 83 || key == 70 || key == 72 || key == 66 || key == 74 || key == 84 || key == 90|| key == 61 || key == 173 || key == 48) && ( e.ctrlKey || e.metaKey ) === true ) ||
								// Allow: Ctrl+V, Ctrl+C, Ctrl+X
								( (key == 86 || key == 67 || key == 88) && ( e.ctrlKey || e.metaKey ) === true ) ||
								// Allow: home, end, left, right
								( (key >= 35 && key <= 39) ) ||
								// Allow: F1-F12
								( (key >= 112 && key <= 123) )
							){
								return;
							}
							// But prevent all other keys.
							e.preventDefault();
							return false;
						}

						// The whole lot has been selected, or if the field is empty...
						if( start == 0 && end == this.value.length ) //|| $this.val() == 0 )
						{
							if( code == 8 )		// Backspace
							{
								// Blank out the field, but only if the data object has already been instantiated.
								start = end = 1;
								this.value = '';

								// Reset the cursor position.
								data.init = (decimals>0?-1:0);
								data.c = (decimals>0?-(decimals+1):0);
								setSelectionRange.apply(this, [0,0]);
							}
							else if( chara == dec_point )
							{
								start = end = 1;
								this.value = '0'+ dec_point + (new Array(decimals+1).join('0'));

								// Reset the cursor position.
								data.init = (decimals>0?1:0);
								data.c = (decimals>0?-(decimals+1):0);
							}
							else if( code == 45 )	// Negative sign
							{
								start = end = 2;
								this.value = '-0'+dec_point + (new Array(decimals+1).join('0'));

								// Reset the cursor position.
								data.init = (decimals>0?1:0);
								data.c = (decimals>0?-(decimals+1):0);

								setSelectionRange.apply(this, [2,2]);
							}
							else
							{
								// Reset the cursor position.
								data.init = (decimals>0?-1:0);
								data.c = (decimals>0?-(decimals):0);
							}
						}

						// Otherwise, we need to reset the caret position
						// based on the users selection.
						else
						{
							data.c = end-this.value.length;
						}

						// Track if partial selection was used
						data.isPartialSelection = start == end ? false : true;

						// If the start position is before the decimal point,
						// and the user has typed a decimal point, we need to move the caret
						// past the decimal place.
						if( decimals > 0 && chara == dec_point && start == this.value.length-decimals-1 )
						{
							data.c++;
							data.init = Math.max(0,data.init);
							e.preventDefault();

							// Set the selection position.
							setPos = this.value.length+data.c;
						}

						// Ignore negative sign unless at beginning of number (and it's not already present)
						else if( code == 45 && (start != 0 || this.value.indexOf('-') == 0) )
						{
							e.preventDefault();
						}

						// If the user is just typing the decimal place,
						// we simply ignore it.
						else if( chara == dec_point )
						{
							data.init = Math.max(0,data.init);
							e.preventDefault();
						}

						// If hitting the delete key, and the cursor is before a decimal place,
						// we simply move the cursor to the other side of the decimal place.
						else if( decimals > 0 && code == 127 && start == this.value.length-decimals-1 )
						{
							// Just prevent default but don't actually move the caret here because it's done in the keyup event
							e.preventDefault();
						}

						// If hitting the backspace key, and the cursor is behind a decimal place,
						// we simply move the cursor to the other side of the decimal place.
						else if( decimals > 0 && code == 8 && start == this.value.length-decimals )
						{
							e.preventDefault();
							data.c--;

							// Set the selection position.
							setPos = this.value.length+data.c;
						}

						// If hitting the delete key, and the cursor is to the right of the decimal
						// we replace the character after the caret with a 0.
						else if( decimals > 0 && code == 127 && start > this.value.length-decimals-1 )
						{
							if( this.value === '' ) return;

							// If the character following is not already a 0,
							// replace it with one.
							if( this.value.slice(start, start+1) != '0' )
							{
								val = this.value.slice(0, start) + '0' + this.value.slice(start+1);
								// The regex replacement below removes negative sign from numbers...
								// not sure why they're necessary here when none of the other cases use them
								//$this.val(val.replace(regex_dec_num,'').replace(regex_dec,dec_point));
								$this.val(val);
							}

							e.preventDefault();

							// Set the selection position.
							setPos = this.value.length+data.c;
						}

						// If hitting the backspace key, and the cursor is to the right of the decimal
						// (but not directly to the right) we replace the character preceding the
						// caret with a 0.
						else if( decimals > 0 && code == 8 && start > this.value.length-decimals )
						{
							if( this.value === '' ) return;

							// If the character preceding is not already a 0,
							// replace it with one.
							if( this.value.slice(start-1, start) != '0' )
							{
								val = this.value.slice(0, start-1) + '0' + this.value.slice(start);
								// The regex replacement below removes negative sign from numbers...
								// not sure why they're necessary here when none of the other cases use them
								//$this.val(val.replace(regex_dec_num,'').replace(regex_dec,dec_point));
								$this.val(val);
							}

							e.preventDefault();
							data.c--;

							// Set the selection position.
							setPos = this.value.length+data.c;
						}

						// If the delete key was pressed, and the character immediately
						// after the caret is a thousands_separator character, simply
						// step over it.
						else if( code == 127 && this.value.slice(start, start+1) == thousands_sep )
						{
							// Just prevent default but don't actually move the caret here because it's done in the keyup event
							e.preventDefault();
						}

						// If the backspace key was pressed, and the character immediately
						// before the caret is a thousands_separator character, simply
						// step over it.
						else if( code == 8 && this.value.slice(start-1, start) == thousands_sep )
						{
							e.preventDefault();
							data.c--;

							// Set the selection position.
							setPos = this.value.length+data.c;
						}

						// If the caret is to the right of the decimal place, and the user is entering a
						// number, remove the following character before putting in the new one.
						else if(
							decimals > 0 &&
							start == end &&
							this.value.length > decimals+1 &&
							start > this.value.length-decimals-1 && isFinite(+chara) &&
							!e.metaKey && !e.ctrlKey && !e.altKey && chara.length === 1
						)
						{
							// If the character preceding is not already a 0,
							// replace it with one.
							if( end === this.value.length )
							{
								val = this.value.slice(0, start-1);
							}
							else
							{
								val = this.value.slice(0, start)+this.value.slice(start+1);
							}

							// Reset the position.
							this.value = val;
							setPos = start;
						}

						// If we need to re-position the characters.
						if( setPos !== false )
						{
							//console.log('Setpos keydown: ', setPos );
							setSelectionRange.apply(this, [setPos, setPos]);
						}

						// Store the data on the element.
						$this.data('numFormat', data);

					},

					/**
					 * Handles keyup events, re-formatting numbers.
					 *
					 * @param object e			: the keyup event object.s
					 *
					 * @return void;
					 */
					'keyup.format' : function(e){
						vnn_number = 1;
						// Store these variables for use below.
						var $this	= $(this),
							data	= $this.data('numFormat'),
							code	= (e.keyCode ? e.keyCode : e.which),
							start	= getSelection.apply(this,['start']),
							end		= getSelection.apply(this,['end']),
							setPos;


						// Check for negative characters being entered at the start of the string.
						// If there's any kind of selection, just ignore the input.
						if( start === 0 && end === 0 && ( code === 189 || code === 109 ) )
						{
							$this.val('-'+$this.val());
							start		= 1;
							data.c		= 1-this.value.length;
							data.init	= 1;

							$this.data('numFormat', data);

							setPos = this.value.length+data.c;
							setSelectionRange.apply(this, [setPos, setPos]);
						}

						// Stop executing if the user didn't type a number key, a decimal, or a comma.
						if( this.value === '' || (code < 48 || code > 57) && (code < 96 || code > 105 ) && code !== 8 && code !== 46 && code !== 110 ) return;

						// Re-format the textarea.
						$this.val($this.val());

						if( decimals > 0 )
						{
							// If we haven't marked this item as 'initialized'
							// then do so now. It means we should place the caret just
							// before the decimal. This will never be un-initialized before
							// the decimal character itself is entered.
							if( data.init < 1 )
							{
								start		= this.value.length-decimals-( data.init < 0 ? 1 : 0 );
								data.c		= start-this.value.length;
								data.init	= 1;
								
								
								$this.data('numFormat', data);
							}

							// Increase the cursor position if the caret is to the right
							// of the decimal place, and the character pressed isn't the backspace key.
							else if( start > this.value.length-decimals && code != 8 )
							{
								data.c++;

								// Store the data, now that it's changed.
								$this.data('numFormat', data);
							}
						}

						// Move caret to the right after delete key pressed
						if (code == 46 && !data.isPartialSelection)
						{
							data.c++;

							// Store the data, now that it's changed.
							$this.data('numFormat', data);
						}

						//console.log( 'Setting pos: ', start, decimals, this.value.length + data.c, this.value.length, data.c );

						// Set the selection position.
						setPos = this.value.length+data.c;
						setSelectionRange.apply(this, [setPos, setPos]);
					},

					/**
					 * Reformat when pasting into the field.
					 *
					 * @param object e 		: jQuery event object.
					 *
					 * @return false : prevent default action.
					 */
					'paste.format' : function(e){

						// Defint $this. It's used twice!.
						var $this		= $(this),
							original	= e.originalEvent,
							val		= null;

						// Get the text content stream.
						if (window.clipboardData && window.clipboardData.getData) { // IE
							val = window.clipboardData.getData('Text');
						} else if (original.clipboardData && original.clipboardData.getData) {
							val = original.clipboardData.getData('text/plain');
						}

						// Do the reformat operation.
						$this.val(val);

						// Stop the actual content from being pasted.
						e.preventDefault();
						return false;
					}

				})

				// Loop each element (which isn't blank) and do the format.
				.each(function(){

					var $this = $(this).data('numFormat',{
						c				: -(decimals+1),
						decimals		: decimals,
						thousands_sep	: thousands_sep,
						dec_point		: dec_point,
						regex_dec_num	: regex_dec_num,
						regex_dec		: regex_dec,
						init			: this.value.indexOf('.') ? true : false
					});

					// Return if the element is empty.
					if( this.value === '' ) return;

					// Otherwise... format!!
					$this.val($this.val());
				});
			}
			else
			{
				// return the collection.
				return this.each(function(){
					var $this = $(this), num = +$this.text().replace(regex_dec_num,'').replace(regex_dec,'.');
					$this.number( !isFinite(num) ? 0 : +num, decimals, dec_point, thousands_sep );
				});
			}
		}

		// Add this number to the element as text.
		return this.text( $.number.apply(window,arguments) );
	};

	//
	// Create .val() hooks to get and set formatted numbers in inputs.
	//

	// We check if any hooks already exist, and cache
	// them in case we need to re-use them later on.
	var origHookGet = null, origHookSet = null;

	// Check if a text valHook already exists.
	if( $.isPlainObject( $.valHooks.text ) )
	{
		// Preserve the original valhook function
		// we'll call this for values we're not
		// explicitly handling.
		if( $.isFunction( $.valHooks.text.get ) ) origHookGet = $.valHooks.text.get;
		if( $.isFunction( $.valHooks.text.set ) ) origHookSet = $.valHooks.text.set;
	}
	else
	{
		// Define an object for the new valhook.
		$.valHooks.text = {};
	}

	/**
	* Define the valHook to return normalised field data against an input
	* which has been tagged by the number formatter.
	*
	* @param object el			: The raw DOM element that we're getting the value from.
	*
	* @return mixed : Returns the value that was written to the element as a
	*				  javascript number, or undefined to let jQuery handle it normally.
	*/
	$.valHooks.text.get = function( el ){

		// Get the element, and its data.
		var $this	= $(el), num, negative,
			data	= $this.data('numFormat');

		// Does this element have our data field?
		if( !data )
		{
			// Check if the valhook function already existed
			if( $.isFunction( origHookGet ) )
			{
				// There was, so go ahead and call it
				return origHookGet(el);
			}
			else
			{
				// No previous function, return undefined to have jQuery
				// take care of retrieving the value
				return undefined;
			}
		}
		else
		{
			// Remove formatting, and return as number.
			if( el.value === '' ) return '';


			// Convert to a number.
			num = +(el.value
				.replace( data.regex_dec_num, '' )
				.replace( data.regex_dec, '.' ));

			// If we've got a finite number, return it.
			// Otherwise, simply return 0.
			// Return as a string... thats what we're
			// used to with .val()
			return (el.value.indexOf('-') === 0 ? '-' : '')+( isFinite( num ) ? num : 0 );
		}
	};

	/**
	* A valhook which formats a number when run against an input
	* which has been tagged by the number formatter.
	*
	* @param object el		: The raw DOM element (input element).
	* @param float			: The number to set into the value field.
	*
	* @return mixed : Returns the value that was written to the element,
	*				  or undefined to let jQuery handle it normally.
	*/
	$.valHooks.text.set = function( el, val )
	{
		// Get the element, and its data.
		var $this	= $(el),
			data	= $this.data('numFormat');

		// Does this element have our data field?
		if( !data )
		{

			// Check if the valhook function already exists
			if( $.isFunction( origHookSet ) )
			{
				// There was, so go ahead and call it
				return origHookSet(el,val);
			}
			else
			{
				// No previous function, return undefined to have jQuery
				// take care of retrieving the value
				return undefined;
			}
		}
		else
		{
			var num = $.number( val, data.decimals, data.dec_point, data.thousands_sep );

			// Make sure empties are set with correct signs.
//			if(val.indexOf('-') === 0 && +num === 0)
//			{
//				num = '-'+num;
//			}

			return $.isFunction(origHookSet) ? origHookSet(el, num) : el.value = num;
		}
	};

	/**
	 * The (modified) excellent number formatting method from PHPJS.org.
	 * http://phpjs.org/functions/number_format/
	 *
	 * @modified by Sam Sehnert (teamdf.com)
	 *	- don't redefine dec_point, thousands_sep... just overwrite with defaults.
	 *	- don't redefine decimals, just overwrite as numeric.
	 *	- Generate regex for normalizing pre-formatted numbers.
	 *
	 * @param float number			: The number you wish to format, or TRUE to use the text contents
	 *								  of the element as the number. Please note that this won't work for
	 *								  elements which have child nodes with text content.
	 * @param int decimals			: The number of decimal places that should be displayed. Defaults to 0.
	 * @param string dec_point		: The character to use as a decimal point. Defaults to '.'.
	 * @param string thousands_sep	: The character to use as a thousands separator. Defaults to ','.
	 *
	 * @return string : The formatted number as a string.
	 */
	$.number = function( number, decimals, dec_point, thousands_sep ){
		// Set the default values here, instead so we can use them in the replace below.
		thousands_sep	= (typeof thousands_sep === 'undefined') ? ( new Number(1000).toLocaleString() !== '1000' ? new Number(1000).toLocaleString().charAt(1) : '' ) : thousands_sep;
		dec_point		= (typeof dec_point === 'undefined') ? new Number(0.1).toLocaleString().charAt(1) : dec_point;
		decimals		= !isFinite(+decimals) ? 0 : Math.abs(decimals);

		// Work out the unicode representation for the decimal place and thousand sep.
		var u_dec = ('\\u'+('0000'+(dec_point.charCodeAt(0).toString(16))).slice(-4));
		var u_sep = ('\\u'+('0000'+(thousands_sep.charCodeAt(0).toString(16))).slice(-4));
		// Fix the number, so that it's an actual number.
		var t_s_nb = number;
		if(vnn_number == 0){
			if(thousands_sep == ',')
				t_s_nb = number.replace(new RegExp(thousands_sep,'g'),'');
			else
			{
				if(vnn_firstload == 2){
					while(t_s_nb.indexOf(thousands_sep) > -1){
						t_s_nb = t_s_nb.replace('.','');
					};
				}
				else {
					vnn_firstload = 2;
				}
			}
			number = t_s_nb;
		}
		else
			vnn_number = 0;
		
		
		number = (number + '')
			.replace('\.', dec_point) // because the number if passed in as a float (having . as decimal point per definition) we need to replace this with the passed in decimal point character
			.replace(new RegExp(u_sep,'g'),'')
			.replace(new RegExp(u_dec,'g'),'.')
			.replace(new RegExp('[^0-9+\-Ee.]','g'),'');
		
		
		var n = !isFinite(+number) ? 0 : +number,
			s = '',
			toFixedFix = function (n, decimals) {
				return '' + (+(Math.round(n + 'e+' + decimals) + 'e-' + decimals));
			};
		
		// Fix for IE parseFloat(0.55).toFixed(0) = 0;
		s = (decimals ? toFixedFix(n, decimals) : '' + Math.round(n)).split('.');
		if (s[0].length > 3) {
			s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, thousands_sep);
		}
		if ((s[1] || '').length < decimals) {
			s[1] = s[1] || '';
			s[1] += new Array(decimals - s[1].length + 1).join('0');
		}
		
		return s.join(dec_point);
	}

})(jQuery);

//js/Public_script/jquery.numeric.min.js
(function(factory){if(typeof define === 'function' && define.amd){define(['jquery'], factory);}else{factory(window.jQuery);}}(function($){$.fn.numeric=function(config,callback){if(typeof config==="boolean"){config={decimal:config,negative:true,decimalPlaces:-1}}config=config||{};if(typeof config.negative=="undefined"){config.negative=true}var decimal=config.decimal===false?"":config.decimal||".";var negative=config.negative===true?true:false;var decimalPlaces=typeof config.decimalPlaces=="undefined"?-1:config.decimalPlaces;callback=typeof callback=="function"?callback:function(){};return this.data("numeric.decimal",decimal).data("numeric.negative",negative).data("numeric.callback",callback).data("numeric.decimalPlaces",decimalPlaces).keypress($.fn.numeric.keypress).keyup($.fn.numeric.keyup).blur($.fn.numeric.blur)};$.fn.numeric.keypress=function(e){var decimal=$.data(this,"numeric.decimal");var negative=$.data(this,"numeric.negative");var decimalPlaces=$.data(this,"numeric.decimalPlaces");var key=e.charCode?e.charCode:e.keyCode?e.keyCode:0;if(key==13&&this.nodeName.toLowerCase()=="input"){return true}else if(key==13){return false}var allow=false;if(e.ctrlKey&&key==97||e.ctrlKey&&key==65){return true}if(e.ctrlKey&&key==120||e.ctrlKey&&key==88){return true}if(e.ctrlKey&&key==99||e.ctrlKey&&key==67){return true}if(e.ctrlKey&&key==122||e.ctrlKey&&key==90){return true}if(e.ctrlKey&&key==118||e.ctrlKey&&key==86||e.shiftKey&&key==45){return true}if(key<48||key>57){var value=$(this).val();if($.inArray("-",value.split(""))!==0&&negative&&key==45&&(value.length===0||parseInt($.fn.getSelectionStart(this),10)===0)){return true}if(decimal&&key==decimal.charCodeAt(0)&&$.inArray(decimal,value.split(""))!=-1){allow=false}if(key!=8&&key!=9&&key!=13&&key!=35&&key!=36&&key!=37&&key!=39&&key!=46){allow=false}else{if(typeof e.charCode!="undefined"){if(e.keyCode==e.which&&e.which!==0){allow=true;if(e.which==46){allow=false}}else if(e.keyCode!==0&&e.charCode===0&&e.which===0){allow=true}}}if(decimal&&key==decimal.charCodeAt(0)){if($.inArray(decimal,value.split(""))==-1){allow=true}else{allow=false}}}else{allow=true;if(decimal&&decimalPlaces>0){var dot=$.inArray(decimal,$(this).val().split(""));if(dot>=0&&$(this).val().length>dot+decimalPlaces){allow=false}}}return allow};$.fn.numeric.keyup=function(e){var val=$(this).val();if(val&&val.length>0){var carat=$.fn.getSelectionStart(this);var selectionEnd=$.fn.getSelectionEnd(this);var decimal=$.data(this,"numeric.decimal");var negative=$.data(this,"numeric.negative");var decimalPlaces=$.data(this,"numeric.decimalPlaces");if(decimal!==""&&decimal!==null){var dot=$.inArray(decimal,val.split(""));if(dot===0){this.value="0"+val;carat++;selectionEnd++}if(dot==1&&val.charAt(0)=="-"){this.value="-0"+val.substring(1);carat++;selectionEnd++}val=this.value}var validChars=[0,1,2,3,4,5,6,7,8,9,"-",decimal];var length=val.length;for(var i=length-1;i>=0;i--){var ch=val.charAt(i);if(i!==0&&ch=="-"){val=val.substring(0,i)+val.substring(i+1)}else if(i===0&&!negative&&ch=="-"){val=val.substring(1)}var validChar=false;for(var j=0;j<validChars.length;j++){if(ch==validChars[j]){validChar=true;break}}if(!validChar||ch==" "){val=val.substring(0,i)+val.substring(i+1)}}var firstDecimal=$.inArray(decimal,val.split(""));if(firstDecimal>0){for(var k=length-1;k>firstDecimal;k--){var chch=val.charAt(k);if(chch==decimal){val=val.substring(0,k)+val.substring(k+1)}}}if(decimal&&decimalPlaces>0){var dot=$.inArray(decimal,val.split(""));if(dot>=0){val=val.substring(0,dot+decimalPlaces+1);selectionEnd=Math.min(val.length,selectionEnd)}}this.value=val;$.fn.setSelection(this,[carat,selectionEnd])}};$.fn.numeric.blur=function(){var decimal=$.data(this,"numeric.decimal");var callback=$.data(this,"numeric.callback");var negative=$.data(this,"numeric.negative");var val=this.value;if(val!==""){var re=new RegExp("^" + (negative?"-?":"") + "\\d+$|^" + (negative?"-?":"") + "\\d*" + decimal + "\\d+$");if(!re.exec(val)){callback.apply(this)}}};$.fn.removeNumeric=function(){return this.data("numeric.decimal",null).data("numeric.negative",null).data("numeric.callback",null).data("numeric.decimalPlaces",null).unbind("keypress",$.fn.numeric.keypress).unbind("keyup",$.fn.numeric.keyup).unbind("blur",$.fn.numeric.blur)};$.fn.getSelectionStart=function(o){if(o.type==="number"){return undefined}else if(o.createTextRange&&document.selection){var r=document.selection.createRange().duplicate();r.moveEnd("character",o.value.length);if(r.text=="")return o.value.length;return Math.max(0,o.value.lastIndexOf(r.text))}else{try{return o.selectionStart}catch(e){return 0}}};$.fn.getSelectionEnd=function(o){if(o.type==="number"){return undefined}else if(o.createTextRange&&document.selection){var r=document.selection.createRange().duplicate();r.moveStart("character",-o.value.length);return r.text.length}else return o.selectionEnd};$.fn.setSelection=function(o,p){if(typeof p=="number"){p=[p,p]}if(p&&p.constructor==Array&&p.length==2){if(o.type==="number"){o.focus()}else if(o.createTextRange){var r=o.createTextRange();r.collapse(true);r.moveStart("character",p[0]);r.moveEnd("character",p[1]-p[0]);r.select()}else{o.focus();try{if(o.setSelectionRange){o.setSelectionRange(p[0],p[1])}}catch(e){}}}}}));
//VNN_Datetimepicker.js
!function(e){"function"==typeof define&&define.amd?define(["jquery","jquery.ui"],e):e(jQuery)}(function($){if($.ui.timepicker=$.ui.timepicker||{},!$.ui.timepicker.version){$.extend($.ui,{timepicker:{version:"1.5.2"}});var Timepicker=function(){this.regional=[],this.regional[""]={currentText:"Now",closeText:"Done",amNames:["AM","A"],pmNames:["PM","P"],timeFormat:"HH:mm",timeSuffix:"",timeOnlyTitle:"Choose Time",timeText:"Time",hourText:"Hour",minuteText:"Minute",secondText:"Second",millisecText:"Millisecond",microsecText:"Microsecond",timezoneText:"Time Zone",isRTL:!1},this._defaults={showButtonPanel:!0,timeOnly:!1,timeOnlyShowDate:!1,showHour:null,showMinute:null,showSecond:null,showMillisec:null,showMicrosec:null,showTimezone:null,showTime:!0,stepHour:1,stepMinute:1,stepSecond:1,stepMillisec:1,stepMicrosec:1,hour:0,minute:0,second:0,millisec:0,microsec:0,timezone:null,hourMin:0,minuteMin:0,secondMin:0,millisecMin:0,microsecMin:0,hourMax:23,minuteMax:59,secondMax:59,millisecMax:999,microsecMax:999,minDateTime:null,maxDateTime:null,maxTime:null,minTime:null,onSelect:null,hourGrid:0,minuteGrid:0,secondGrid:0,millisecGrid:0,microsecGrid:0,alwaysSetTime:!0,separator:" ",altFieldTimeOnly:!0,altTimeFormat:null,altSeparator:null,altTimeSuffix:null,altRedirectFocus:!0,pickerTimeFormat:null,pickerTimeSuffix:null,showTimepicker:!0,timezoneList:null,addSliderAccess:!1,sliderAccessArgs:null,controlType:"slider",oneLine:!1,defaultValue:null,parse:"strict",afterInject:null},$.extend(this._defaults,this.regional[""])};$.extend(Timepicker.prototype,{$input:null,$altInput:null,$timeObj:null,inst:null,hour_slider:null,minute_slider:null,second_slider:null,millisec_slider:null,microsec_slider:null,timezone_select:null,maxTime:null,minTime:null,hour:0,minute:0,second:0,millisec:0,microsec:0,timezone:null,hourMinOriginal:null,minuteMinOriginal:null,secondMinOriginal:null,millisecMinOriginal:null,microsecMinOriginal:null,hourMaxOriginal:null,minuteMaxOriginal:null,secondMaxOriginal:null,millisecMaxOriginal:null,microsecMaxOriginal:null,ampm:"",formattedDate:"",formattedTime:"",formattedDateTime:"",timezoneList:null,units:["hour","minute","second","millisec","microsec"],support:{},control:null,setDefaults:function(e){return extendRemove(this._defaults,e||{}),this},_newInst:function($input,opts){var tp_inst=new Timepicker,inlineSettings={},fns={},overrides,i;for(var attrName in this._defaults)if(this._defaults.hasOwnProperty(attrName)){var attrValue=$input.attr("time:"+attrName);if(attrValue)try{inlineSettings[attrName]=eval(attrValue)}catch(err){inlineSettings[attrName]=attrValue}}overrides={beforeShow:function(e,t){return $.isFunction(tp_inst._defaults.evnts.beforeShow)?tp_inst._defaults.evnts.beforeShow.call($input[0],e,t,tp_inst):void 0},onChangeMonthYear:function(e,t,i){$.isFunction(tp_inst._defaults.evnts.onChangeMonthYear)&&tp_inst._defaults.evnts.onChangeMonthYear.call($input[0],e,t,i,tp_inst)},onClose:function(e,t){tp_inst.timeDefined===!0&&""!==$input.val()&&tp_inst._updateDateTime(t),$.isFunction(tp_inst._defaults.evnts.onClose)&&tp_inst._defaults.evnts.onClose.call($input[0],e,t,tp_inst)}};for(i in overrides)overrides.hasOwnProperty(i)&&(fns[i]=opts[i]||null);tp_inst._defaults=$.extend({},this._defaults,inlineSettings,opts,overrides,{evnts:fns,timepicker:tp_inst}),tp_inst.amNames=$.map(tp_inst._defaults.amNames,function(e){return e.toUpperCase()}),tp_inst.pmNames=$.map(tp_inst._defaults.pmNames,function(e){return e.toUpperCase()}),tp_inst.support=detectSupport(tp_inst._defaults.timeFormat+(tp_inst._defaults.pickerTimeFormat?tp_inst._defaults.pickerTimeFormat:"")+(tp_inst._defaults.altTimeFormat?tp_inst._defaults.altTimeFormat:"")),"string"==typeof tp_inst._defaults.controlType?("slider"===tp_inst._defaults.controlType&&"undefined"==typeof $.ui.slider&&(tp_inst._defaults.controlType="select"),tp_inst.control=tp_inst._controls[tp_inst._defaults.controlType]):tp_inst.control=tp_inst._defaults.controlType;var timezoneList=[-720,-660,-600,-570,-540,-480,-420,-360,-300,-270,-240,-210,-180,-120,-60,0,60,120,180,210,240,270,300,330,345,360,390,420,480,525,540,570,600,630,660,690,720,765,780,840];null!==tp_inst._defaults.timezoneList&&(timezoneList=tp_inst._defaults.timezoneList);var tzl=timezoneList.length,tzi=0,tzv=null;if(tzl>0&&"object"!=typeof timezoneList[0])for(;tzl>tzi;tzi++)tzv=timezoneList[tzi],timezoneList[tzi]={value:tzv,label:$.timepicker.timezoneOffsetString(tzv,tp_inst.support.iso8601)};return tp_inst._defaults.timezoneList=timezoneList,tp_inst.timezone=null!==tp_inst._defaults.timezone?$.timepicker.timezoneOffsetNumber(tp_inst._defaults.timezone):-1*(new Date).getTimezoneOffset(),tp_inst.hour=tp_inst._defaults.hour<tp_inst._defaults.hourMin?tp_inst._defaults.hourMin:tp_inst._defaults.hour>tp_inst._defaults.hourMax?tp_inst._defaults.hourMax:tp_inst._defaults.hour,tp_inst.minute=tp_inst._defaults.minute<tp_inst._defaults.minuteMin?tp_inst._defaults.minuteMin:tp_inst._defaults.minute>tp_inst._defaults.minuteMax?tp_inst._defaults.minuteMax:tp_inst._defaults.minute,tp_inst.second=tp_inst._defaults.second<tp_inst._defaults.secondMin?tp_inst._defaults.secondMin:tp_inst._defaults.second>tp_inst._defaults.secondMax?tp_inst._defaults.secondMax:tp_inst._defaults.second,tp_inst.millisec=tp_inst._defaults.millisec<tp_inst._defaults.millisecMin?tp_inst._defaults.millisecMin:tp_inst._defaults.millisec>tp_inst._defaults.millisecMax?tp_inst._defaults.millisecMax:tp_inst._defaults.millisec,tp_inst.microsec=tp_inst._defaults.microsec<tp_inst._defaults.microsecMin?tp_inst._defaults.microsecMin:tp_inst._defaults.microsec>tp_inst._defaults.microsecMax?tp_inst._defaults.microsecMax:tp_inst._defaults.microsec,tp_inst.ampm="",tp_inst.$input=$input,tp_inst._defaults.altField&&(tp_inst.$altInput=$(tp_inst._defaults.altField),tp_inst._defaults.altRedirectFocus===!0&&tp_inst.$altInput.css({cursor:"pointer"}).focus(function(){$input.trigger("focus")})),(0===tp_inst._defaults.minDate||0===tp_inst._defaults.minDateTime)&&(tp_inst._defaults.minDate=new Date),(0===tp_inst._defaults.maxDate||0===tp_inst._defaults.maxDateTime)&&(tp_inst._defaults.maxDate=new Date),void 0!==tp_inst._defaults.minDate&&tp_inst._defaults.minDate instanceof Date&&(tp_inst._defaults.minDateTime=new Date(tp_inst._defaults.minDate.getTime())),void 0!==tp_inst._defaults.minDateTime&&tp_inst._defaults.minDateTime instanceof Date&&(tp_inst._defaults.minDate=new Date(tp_inst._defaults.minDateTime.getTime())),void 0!==tp_inst._defaults.maxDate&&tp_inst._defaults.maxDate instanceof Date&&(tp_inst._defaults.maxDateTime=new Date(tp_inst._defaults.maxDate.getTime())),void 0!==tp_inst._defaults.maxDateTime&&tp_inst._defaults.maxDateTime instanceof Date&&(tp_inst._defaults.maxDate=new Date(tp_inst._defaults.maxDateTime.getTime())),tp_inst.$input.bind("focus",function(){tp_inst._onFocus()}),tp_inst},_addTimePicker:function(e){var t=$.trim(this.$altInput&&this._defaults.altFieldTimeOnly?this.$input.val()+" "+this.$altInput.val():this.$input.val());this.timeDefined=this._parseTime(t),this._limitMinMaxDateTime(e,!1),this._injectTimePicker(),this._afterInject()},_parseTime:function(e,t){if(this.inst||(this.inst=$.datepicker._getInst(this.$input[0])),t||!this._defaults.timeOnly){var i=$.datepicker._get(this.inst,"dateFormat");try{var s=parseDateTimeInternal(i,this._defaults.timeFormat,e,$.datepicker._getFormatConfig(this.inst),this._defaults);if(!s.timeObj)return!1;$.extend(this,s.timeObj)}catch(n){return $.timepicker.log("Error parsing the date/time string: "+n+"\ndate/time string = "+e+"\ntimeFormat = "+this._defaults.timeFormat+"\ndateFormat = "+i),!1}return!0}var a=$.datepicker.parseTime(this._defaults.timeFormat,e,this._defaults);return a?($.extend(this,a),!0):!1},_afterInject:function(){var e=this.inst.settings;$.isFunction(e.afterInject)&&e.afterInject.call(this)},_injectTimePicker:function(){var e=this.inst.dpDiv,t=this.inst.settings,i=this,s="",n="",a=null,r={},l={},o=null,c=0,u=0;if(0===e.find("div.ui-timepicker-div").length&&t.showTimepicker){var m=" ui_tpicker_unit_hide",d='<div class="ui-timepicker-div'+(t.isRTL?" ui-timepicker-rtl":"")+(t.oneLine&&"select"===t.controlType?" ui-timepicker-oneLine":"")+'"><dl><dt class="ui_tpicker_time_label"'+(t.showTime?"":m)+">"+t.timeText+'</dt><dd class="ui_tpicker_time '+(t.showTime?"":m)+'"></dd>';for(c=0,u=this.units.length;u>c;c++){if(s=this.units[c],n=s.substr(0,1).toUpperCase()+s.substr(1),a=null!==t["show"+n]?t["show"+n]:this.support[s],r[s]=parseInt(t[s+"Max"]-(t[s+"Max"]-t[s+"Min"])%t["step"+n],10),l[s]=0,d+='<dt class="ui_tpicker_'+s+"_label"+(a?"":m)+'">'+t[s+"Text"]+'</dt><dd class="ui_tpicker_'+s+(a?"":m)+'"><div class="ui_tpicker_'+s+"_slider"+(a?"":m)+'"></div>',a&&t[s+"Grid"]>0){if(d+='<div style="padding-left: 1px"><table class="ui-tpicker-grid-label"><tr>',"hour"===s)for(var h=t[s+"Min"];h<=r[s];h+=parseInt(t[s+"Grid"],10)){l[s]++;var p=$.datepicker.formatTime(this.support.ampm?"hht":"HH",{hour:h},t);d+='<td data-for="'+s+'">'+p+"</td>"}else for(var f=t[s+"Min"];f<=r[s];f+=parseInt(t[s+"Grid"],10))l[s]++,d+='<td data-for="'+s+'">'+(10>f?"0":"")+f+"</td>";d+="</tr></table></div>"}d+="</dd>"}var _=null!==t.showTimezone?t.showTimezone:this.support.timezone;d+='<dt class="ui_tpicker_timezone_label'+(_?"":m)+'">'+t.timezoneText+"</dt>",d+='<dd class="ui_tpicker_timezone'+(_?"":m)+'"></dd>',d+="</dl></div>";var g=$(d);for(t.timeOnly===!0&&(g.prepend('<div class="ui-widget-header ui-helper-clearfix ui-corner-all"><div class="ui-datepicker-title">'+t.timeOnlyTitle+"</div></div>"),e.find(".ui-datepicker-header, .ui-datepicker-calendar").hide()),c=0,u=i.units.length;u>c;c++)s=i.units[c],n=s.substr(0,1).toUpperCase()+s.substr(1),a=null!==t["show"+n]?t["show"+n]:this.support[s],i[s+"_slider"]=i.control.create(i,g.find(".ui_tpicker_"+s+"_slider"),s,i[s],t[s+"Min"],r[s],t["step"+n]),a&&t[s+"Grid"]>0&&(o=100*l[s]*t[s+"Grid"]/(r[s]-t[s+"Min"]),g.find(".ui_tpicker_"+s+" table").css({width:o+"%",marginLeft:t.isRTL?"0":o/(-2*l[s])+"%",marginRight:t.isRTL?o/(-2*l[s])+"%":"0",borderCollapse:"collapse"}).find("td").click(function(){var e=$(this),t=e.html(),n=parseInt(t.replace(/[^0-9]/g),10),a=t.replace(/[^apm]/gi),r=e.data("for");"hour"===r&&(-1!==a.indexOf("p")&&12>n?n+=12:-1!==a.indexOf("a")&&12===n&&(n=0)),i.control.value(i,i[r+"_slider"],s,n),i._onTimeChange(),i._onSelectHandler()}).css({cursor:"pointer",width:100/l[s]+"%",textAlign:"center",overflow:"hidden"}));if(this.timezone_select=g.find(".ui_tpicker_timezone").append("<select></select>").find("select"),$.fn.append.apply(this.timezone_select,$.map(t.timezoneList,function(e){return $("<option />").val("object"==typeof e?e.value:e).text("object"==typeof e?e.label:e)})),"undefined"!=typeof this.timezone&&null!==this.timezone&&""!==this.timezone){var M=-1*new Date(this.inst.selectedYear,this.inst.selectedMonth,this.inst.selectedDay,12).getTimezoneOffset();M===this.timezone?selectLocalTimezone(i):this.timezone_select.val(this.timezone)}else"undefined"!=typeof this.hour&&null!==this.hour&&""!==this.hour?this.timezone_select.val(t.timezone):selectLocalTimezone(i);this.timezone_select.change(function(){i._onTimeChange(),i._onSelectHandler(),i._afterInject()});var v=e.find(".ui-datepicker-buttonpane");if(v.length?v.before(g):e.append(g),this.$timeObj=g.find(".ui_tpicker_time"),null!==this.inst){var k=this.timeDefined;this._onTimeChange(),this.timeDefined=k}if(this._defaults.addSliderAccess){var T=this._defaults.sliderAccessArgs,D=this._defaults.isRTL;T.isRTL=D,setTimeout(function(){if(0===g.find(".ui-slider-access").length){g.find(".ui-slider:visible").sliderAccess(T);var e=g.find(".ui-slider-access:eq(0)").outerWidth(!0);e&&g.find("table:visible").each(function(){var t=$(this),i=t.outerWidth(),s=t.css(D?"marginRight":"marginLeft").toString().replace("%",""),n=i-e,a=s*n/i+"%",r={width:n,marginRight:0,marginLeft:0};r[D?"marginRight":"marginLeft"]=a,t.css(r)})}},10)}i._limitMinMaxDateTime(this.inst,!0)}},_limitMinMaxDateTime:function(e,t){var i=this._defaults,s=new Date(e.selectedYear,e.selectedMonth,e.selectedDay);if(this._defaults.showTimepicker){if(null!==$.datepicker._get(e,"minDateTime")&&void 0!==$.datepicker._get(e,"minDateTime")&&s){var n=$.datepicker._get(e,"minDateTime"),a=new Date(n.getFullYear(),n.getMonth(),n.getDate(),0,0,0,0);(null===this.hourMinOriginal||null===this.minuteMinOriginal||null===this.secondMinOriginal||null===this.millisecMinOriginal||null===this.microsecMinOriginal)&&(this.hourMinOriginal=i.hourMin,this.minuteMinOriginal=i.minuteMin,this.secondMinOriginal=i.secondMin,this.millisecMinOriginal=i.millisecMin,this.microsecMinOriginal=i.microsecMin),e.settings.timeOnly||a.getTime()===s.getTime()?(this._defaults.hourMin=n.getHours(),this.hour<=this._defaults.hourMin?(this.hour=this._defaults.hourMin,this._defaults.minuteMin=n.getMinutes(),this.minute<=this._defaults.minuteMin?(this.minute=this._defaults.minuteMin,this._defaults.secondMin=n.getSeconds(),this.second<=this._defaults.secondMin?(this.second=this._defaults.secondMin,this._defaults.millisecMin=n.getMilliseconds(),this.millisec<=this._defaults.millisecMin?(this.millisec=this._defaults.millisecMin,this._defaults.microsecMin=n.getMicroseconds()):(this.microsec<this._defaults.microsecMin&&(this.microsec=this._defaults.microsecMin),this._defaults.microsecMin=this.microsecMinOriginal)):(this._defaults.millisecMin=this.millisecMinOriginal,this._defaults.microsecMin=this.microsecMinOriginal)):(this._defaults.secondMin=this.secondMinOriginal,this._defaults.millisecMin=this.millisecMinOriginal,this._defaults.microsecMin=this.microsecMinOriginal)):(this._defaults.minuteMin=this.minuteMinOriginal,this._defaults.secondMin=this.secondMinOriginal,this._defaults.millisecMin=this.millisecMinOriginal,this._defaults.microsecMin=this.microsecMinOriginal)):(this._defaults.hourMin=this.hourMinOriginal,this._defaults.minuteMin=this.minuteMinOriginal,this._defaults.secondMin=this.secondMinOriginal,this._defaults.millisecMin=this.millisecMinOriginal,this._defaults.microsecMin=this.microsecMinOriginal)}if(null!==$.datepicker._get(e,"maxDateTime")&&void 0!==$.datepicker._get(e,"maxDateTime")&&s){var r=$.datepicker._get(e,"maxDateTime"),l=new Date(r.getFullYear(),r.getMonth(),r.getDate(),0,0,0,0);(null===this.hourMaxOriginal||null===this.minuteMaxOriginal||null===this.secondMaxOriginal||null===this.millisecMaxOriginal)&&(this.hourMaxOriginal=i.hourMax,this.minuteMaxOriginal=i.minuteMax,this.secondMaxOriginal=i.secondMax,this.millisecMaxOriginal=i.millisecMax,this.microsecMaxOriginal=i.microsecMax),e.settings.timeOnly||l.getTime()===s.getTime()?(this._defaults.hourMax=r.getHours(),this.hour>=this._defaults.hourMax?(this.hour=this._defaults.hourMax,this._defaults.minuteMax=r.getMinutes(),this.minute>=this._defaults.minuteMax?(this.minute=this._defaults.minuteMax,this._defaults.secondMax=r.getSeconds(),this.second>=this._defaults.secondMax?(this.second=this._defaults.secondMax,this._defaults.millisecMax=r.getMilliseconds(),this.millisec>=this._defaults.millisecMax?(this.millisec=this._defaults.millisecMax,this._defaults.microsecMax=r.getMicroseconds()):(this.microsec>this._defaults.microsecMax&&(this.microsec=this._defaults.microsecMax),this._defaults.microsecMax=this.microsecMaxOriginal)):(this._defaults.millisecMax=this.millisecMaxOriginal,this._defaults.microsecMax=this.microsecMaxOriginal)):(this._defaults.secondMax=this.secondMaxOriginal,this._defaults.millisecMax=this.millisecMaxOriginal,this._defaults.microsecMax=this.microsecMaxOriginal)):(this._defaults.minuteMax=this.minuteMaxOriginal,this._defaults.secondMax=this.secondMaxOriginal,this._defaults.millisecMax=this.millisecMaxOriginal,this._defaults.microsecMax=this.microsecMaxOriginal)):(this._defaults.hourMax=this.hourMaxOriginal,this._defaults.minuteMax=this.minuteMaxOriginal,this._defaults.secondMax=this.secondMaxOriginal,this._defaults.millisecMax=this.millisecMaxOriginal,this._defaults.microsecMax=this.microsecMaxOriginal)}if(null!==e.settings.minTime){var o=new Date("01/01/1970 "+e.settings.minTime);this.hour<o.getHours()?(this.hour=this._defaults.hourMin=o.getHours(),this.minute=this._defaults.minuteMin=o.getMinutes()):this.hour===o.getHours()&&this.minute<o.getMinutes()?this.minute=this._defaults.minuteMin=o.getMinutes():this._defaults.hourMin<o.getHours()?(this._defaults.hourMin=o.getHours(),this._defaults.minuteMin=o.getMinutes()):this._defaults.hourMin===o.getHours()===this.hour&&this._defaults.minuteMin<o.getMinutes()?this._defaults.minuteMin=o.getMinutes():this._defaults.minuteMin=0}if(null!==e.settings.maxTime){var c=new Date("01/01/1970 "+e.settings.maxTime);this.hour>c.getHours()?(this.hour=this._defaults.hourMax=c.getHours(),this.minute=this._defaults.minuteMax=c.getMinutes()):this.hour===c.getHours()&&this.minute>c.getMinutes()?this.minute=this._defaults.minuteMax=c.getMinutes():this._defaults.hourMax>c.getHours()?(this._defaults.hourMax=c.getHours(),this._defaults.minuteMax=c.getMinutes()):this._defaults.hourMax===c.getHours()===this.hour&&this._defaults.minuteMax>c.getMinutes()?this._defaults.minuteMax=c.getMinutes():this._defaults.minuteMax=59}if(void 0!==t&&t===!0){var u=parseInt(this._defaults.hourMax-(this._defaults.hourMax-this._defaults.hourMin)%this._defaults.stepHour,10),m=parseInt(this._defaults.minuteMax-(this._defaults.minuteMax-this._defaults.minuteMin)%this._defaults.stepMinute,10),d=parseInt(this._defaults.secondMax-(this._defaults.secondMax-this._defaults.secondMin)%this._defaults.stepSecond,10),h=parseInt(this._defaults.millisecMax-(this._defaults.millisecMax-this._defaults.millisecMin)%this._defaults.stepMillisec,10),p=parseInt(this._defaults.microsecMax-(this._defaults.microsecMax-this._defaults.microsecMin)%this._defaults.stepMicrosec,10);this.hour_slider&&(this.control.options(this,this.hour_slider,"hour",{min:this._defaults.hourMin,max:u,step:this._defaults.stepHour}),this.control.value(this,this.hour_slider,"hour",this.hour-this.hour%this._defaults.stepHour)),this.minute_slider&&(this.control.options(this,this.minute_slider,"minute",{min:this._defaults.minuteMin,max:m,step:this._defaults.stepMinute}),this.control.value(this,this.minute_slider,"minute",this.minute-this.minute%this._defaults.stepMinute)),this.second_slider&&(this.control.options(this,this.second_slider,"second",{min:this._defaults.secondMin,max:d,step:this._defaults.stepSecond}),this.control.value(this,this.second_slider,"second",this.second-this.second%this._defaults.stepSecond)),this.millisec_slider&&(this.control.options(this,this.millisec_slider,"millisec",{min:this._defaults.millisecMin,max:h,step:this._defaults.stepMillisec}),this.control.value(this,this.millisec_slider,"millisec",this.millisec-this.millisec%this._defaults.stepMillisec)),this.microsec_slider&&(this.control.options(this,this.microsec_slider,"microsec",{min:this._defaults.microsecMin,max:p,step:this._defaults.stepMicrosec}),this.control.value(this,this.microsec_slider,"microsec",this.microsec-this.microsec%this._defaults.stepMicrosec))}}},_onTimeChange:function(){if(this._defaults.showTimepicker){var e=this.hour_slider?this.control.value(this,this.hour_slider,"hour"):!1,t=this.minute_slider?this.control.value(this,this.minute_slider,"minute"):!1,i=this.second_slider?this.control.value(this,this.second_slider,"second"):!1,s=this.millisec_slider?this.control.value(this,this.millisec_slider,"millisec"):!1,n=this.microsec_slider?this.control.value(this,this.microsec_slider,"microsec"):!1,a=this.timezone_select?this.timezone_select.val():!1,r=this._defaults,l=r.pickerTimeFormat||r.timeFormat,o=r.pickerTimeSuffix||r.timeSuffix;"object"==typeof e&&(e=!1),"object"==typeof t&&(t=!1),"object"==typeof i&&(i=!1),"object"==typeof s&&(s=!1),"object"==typeof n&&(n=!1),"object"==typeof a&&(a=!1),e!==!1&&(e=parseInt(e,10)),t!==!1&&(t=parseInt(t,10)),i!==!1&&(i=parseInt(i,10)),s!==!1&&(s=parseInt(s,10)),n!==!1&&(n=parseInt(n,10)),a!==!1&&(a=a.toString());var c=r[12>e?"amNames":"pmNames"][0],u=e!==parseInt(this.hour,10)||t!==parseInt(this.minute,10)||i!==parseInt(this.second,10)||s!==parseInt(this.millisec,10)||n!==parseInt(this.microsec,10)||this.ampm.length>0&&12>e!=(-1!==$.inArray(this.ampm.toUpperCase(),this.amNames))||null!==this.timezone&&a!==this.timezone.toString();u&&(e!==!1&&(this.hour=e),t!==!1&&(this.minute=t),i!==!1&&(this.second=i),s!==!1&&(this.millisec=s),n!==!1&&(this.microsec=n),a!==!1&&(this.timezone=a),this.inst||(this.inst=$.datepicker._getInst(this.$input[0])),this._limitMinMaxDateTime(this.inst,!0)),this.support.ampm&&(this.ampm=c),this.formattedTime=$.datepicker.formatTime(r.timeFormat,this,r),this.$timeObj&&(l===r.timeFormat?this.$timeObj.text(this.formattedTime+o):this.$timeObj.text($.datepicker.formatTime(l,this,r)+o)),this.timeDefined=!0,u&&this._updateDateTime()}},_onSelectHandler:function(){var e=this._defaults.onSelect||this.inst.settings.onSelect,t=this.$input?this.$input[0]:null;e&&t&&e.apply(t,[this.formattedDateTime,this])},_updateDateTime:function(e){e=this.inst||e;var t=e.currentYear>0?new Date(e.currentYear,e.currentMonth,e.currentDay):new Date(e.selectedYear,e.selectedMonth,e.selectedDay),i=$.datepicker._daylightSavingAdjust(t),s=$.datepicker._get(e,"dateFormat"),n=$.datepicker._getFormatConfig(e),a=null!==i&&this.timeDefined;this.formattedDate=$.datepicker.formatDate(s,null===i?new Date:i,n);var r=this.formattedDate;if(""===e.lastVal&&(e.currentYear=e.selectedYear,e.currentMonth=e.selectedMonth,e.currentDay=e.selectedDay),this._defaults.timeOnly===!0&&this._defaults.timeOnlyShowDate===!1?r=this.formattedTime:(this._defaults.timeOnly!==!0&&(this._defaults.alwaysSetTime||a)||this._defaults.timeOnly===!0&&this._defaults.timeOnlyShowDate===!0)&&(r+=this._defaults.separator+this.formattedTime+this._defaults.timeSuffix),this.formattedDateTime=r,this._defaults.showTimepicker)if(this.$altInput&&this._defaults.timeOnly===!1&&this._defaults.altFieldTimeOnly===!0)this.$altInput.val(this.formattedTime),this.$input.val(this.formattedDate);else if(this.$altInput){this.$input.val(r);var l="",o=null!==this._defaults.altSeparator?this._defaults.altSeparator:this._defaults.separator,c=null!==this._defaults.altTimeSuffix?this._defaults.altTimeSuffix:this._defaults.timeSuffix;this._defaults.timeOnly||(l=this._defaults.altFormat?$.datepicker.formatDate(this._defaults.altFormat,null===i?new Date:i,n):this.formattedDate,l&&(l+=o)),l+=null!==this._defaults.altTimeFormat?$.datepicker.formatTime(this._defaults.altTimeFormat,this,this._defaults)+c:this.formattedTime+c,this.$altInput.val(l)}else this.$input.val(r);else this.$input.val(this.formattedDate);this.$input.trigger("change")},_onFocus:function(){if(!this.$input.val()&&this._defaults.defaultValue){this.$input.val(this._defaults.defaultValue);var e=$.datepicker._getInst(this.$input.get(0)),t=$.datepicker._get(e,"timepicker");if(t&&t._defaults.timeOnly&&e.input.val()!==e.lastVal)try{$.datepicker._updateDatepicker(e)}catch(i){$.timepicker.log(i)}}},_controls:{slider:{create:function(e,t,i,s,n,a,r){var l=e._defaults.isRTL;return t.prop("slide",null).slider({orientation:"horizontal",value:l?-1*s:s,min:l?-1*a:n,max:l?-1*n:a,step:r,slide:function(t,s){e.control.value(e,$(this),i,l?-1*s.value:s.value),e._onTimeChange()},stop:function(){e._onSelectHandler()}})},options:function(e,t,i,s,n){if(e._defaults.isRTL){if("string"==typeof s)return"min"===s||"max"===s?void 0!==n?t.slider(s,-1*n):Math.abs(t.slider(s)):t.slider(s);var a=s.min,r=s.max;return s.min=s.max=null,void 0!==a&&(s.max=-1*a),void 0!==r&&(s.min=-1*r),t.slider(s)}return"string"==typeof s&&void 0!==n?t.slider(s,n):t.slider(s)},value:function(e,t,i,s){return e._defaults.isRTL?void 0!==s?t.slider("value",-1*s):Math.abs(t.slider("value")):void 0!==s?t.slider("value",s):t.slider("value")}},select:{create:function(e,t,i,s,n,a,r){for(var l='<select class="ui-timepicker-select ui-state-default ui-corner-all" data-unit="'+i+'" data-min="'+n+'" data-max="'+a+'" data-step="'+r+'">',o=e._defaults.pickerTimeFormat||e._defaults.timeFormat,c=n;a>=c;c+=r)l+='<option value="'+c+'"'+(c===s?" selected":"")+">",l+="hour"===i?$.datepicker.formatTime($.trim(o.replace(/[^ht ]/gi,"")),{hour:c},e._defaults):"millisec"===i||"microsec"===i||c>=10?c:"0"+c.toString(),l+="</option>";return l+="</select>",t.children("select").remove(),$(l).appendTo(t).change(function(){e._onTimeChange(),e._onSelectHandler(),e._afterInject()}),t},options:function(e,t,i,s,n){var a={},r=t.children("select");if("string"==typeof s){if(void 0===n)return r.data(s);a[s]=n}else a=s;return e.control.create(e,t,r.data("unit"),r.val(),a.min>=0?a.min:r.data("min"),a.max||r.data("max"),a.step||r.data("step"))},value:function(e,t,i,s){var n=t.children("select");return void 0!==s?n.val(s):n.val()}}}}),$.fn.extend({timepicker:function(e){e=e||{};var t=Array.prototype.slice.call(arguments);return"object"==typeof e&&(t[0]=$.extend(e,{timeOnly:!0})),$(this).each(function(){$.fn.datetimepicker.apply($(this),t)})},datetimepicker:function(e){e=e||{};var t=arguments;return"string"==typeof e?"getDate"===e||"option"===e&&2===t.length&&"string"==typeof t[1]?$.fn.datepicker.apply($(this[0]),t):this.each(function(){var e=$(this);e.datepicker.apply(e,t)}):this.each(function(){var t=$(this);t.datepicker($.timepicker._newInst(t,e)._defaults)})}}),$.datepicker.parseDateTime=function(e,t,i,s,n){var a=parseDateTimeInternal(e,t,i,s,n);if(a.timeObj){var r=a.timeObj;a.date.setHours(r.hour,r.minute,r.second,r.millisec),a.date.setMicroseconds(r.microsec)}return a.date},$.datepicker.parseTime=function(e,t,i){var s=extendRemove(extendRemove({},$.timepicker._defaults),i||{}),n=(-1!==e.replace(/\'.*?\'/g,"").indexOf("Z"),function(e,t,i){var s,n=function(e,t){var i=[];return e&&$.merge(i,e),t&&$.merge(i,t),i=$.map(i,function(e){return e.replace(/[.*+?|()\[\]{}\\]/g,"\\$&")}),"("+i.join("|")+")?"},a=function(e){var t=e.toLowerCase().match(/(h{1,2}|m{1,2}|s{1,2}|l{1}|c{1}|t{1,2}|z|'.*?')/g),i={h:-1,m:-1,s:-1,l:-1,c:-1,t:-1,z:-1};if(t)for(var s=0;s<t.length;s++)-1===i[t[s].toString().charAt(0)]&&(i[t[s].toString().charAt(0)]=s+1);return i},r="^"+e.toString().replace(/([hH]{1,2}|mm?|ss?|[tT]{1,2}|[zZ]|[lc]|'.*?')/g,function(e){var t=e.length;switch(e.charAt(0).toLowerCase()){case"h":return 1===t?"(\\d?\\d)":"(\\d{"+t+"})";case"m":return 1===t?"(\\d?\\d)":"(\\d{"+t+"})";case"s":return 1===t?"(\\d?\\d)":"(\\d{"+t+"})";case"l":return"(\\d?\\d?\\d)";case"c":return"(\\d?\\d?\\d)";case"z":return"(z|[-+]\\d\\d:?\\d\\d|\\S+)?";case"t":return n(i.amNames,i.pmNames);default:return"("+e.replace(/\'/g,"").replace(/(\.|\$|\^|\\|\/|\(|\)|\[|\]|\?|\+|\*)/g,function(e){return"\\"+e})+")?"}}).replace(/\s/g,"\\s?")+i.timeSuffix+"$",l=a(e),o="";s=t.match(new RegExp(r,"i"));var c={hour:0,minute:0,second:0,millisec:0,microsec:0};return s?(-1!==l.t&&(void 0===s[l.t]||0===s[l.t].length?(o="",c.ampm=""):(o=-1!==$.inArray(s[l.t].toUpperCase(),$.map(i.amNames,function(e){return e.toUpperCase()}))?"AM":"PM",c.ampm=i["AM"===o?"amNames":"pmNames"][0])),-1!==l.h&&("AM"===o&&"12"===s[l.h]?c.hour=0:"PM"===o&&"12"!==s[l.h]?c.hour=parseInt(s[l.h],10)+12:c.hour=Number(s[l.h])),-1!==l.m&&(c.minute=Number(s[l.m])),-1!==l.s&&(c.second=Number(s[l.s])),-1!==l.l&&(c.millisec=Number(s[l.l])),-1!==l.c&&(c.microsec=Number(s[l.c])),-1!==l.z&&void 0!==s[l.z]&&(c.timezone=$.timepicker.timezoneOffsetNumber(s[l.z])),c):!1}),a=function(e,t,i){try{var s=new Date("2012-01-01 "+t);if(isNaN(s.getTime())&&(s=new Date("2012-01-01T"+t),isNaN(s.getTime())&&(s=new Date("01/01/2012 "+t),isNaN(s.getTime()))))throw"Unable to parse time with native Date: "+t;return{hour:s.getHours(),minute:s.getMinutes(),second:s.getSeconds(),millisec:s.getMilliseconds(),microsec:s.getMicroseconds(),timezone:-1*s.getTimezoneOffset()}}catch(a){try{return n(e,t,i)}catch(r){$.timepicker.log("Unable to parse \ntimeString: "+t+"\ntimeFormat: "+e)}}return!1};return"function"==typeof s.parse?s.parse(e,t,s):"loose"===s.parse?a(e,t,s):n(e,t,s)},$.datepicker.formatTime=function(e,t,i){i=i||{},i=$.extend({},$.timepicker._defaults,i),t=$.extend({hour:0,minute:0,second:0,millisec:0,microsec:0,timezone:null},t);var s=e,n=i.amNames[0],a=parseInt(t.hour,10);return a>11&&(n=i.pmNames[0]),s=s.replace(/(?:HH?|hh?|mm?|ss?|[tT]{1,2}|[zZ]|[lc]|'.*?')/g,function(e){switch(e){case"HH":return("0"+a).slice(-2);case"H":return a;case"hh":return("0"+convert24to12(a)).slice(-2);case"h":return convert24to12(a);case"mm":return("0"+t.minute).slice(-2);case"m":return t.minute;case"ss":return("0"+t.second).slice(-2);case"s":return t.second;case"l":return("00"+t.millisec).slice(-3);case"c":return("00"+t.microsec).slice(-3);case"z":return $.timepicker.timezoneOffsetString(null===t.timezone?i.timezone:t.timezone,!1);case"Z":return $.timepicker.timezoneOffsetString(null===t.timezone?i.timezone:t.timezone,!0);case"T":return n.charAt(0).toUpperCase();case"TT":return n.toUpperCase();case"t":return n.charAt(0).toLowerCase();case"tt":return n.toLowerCase();default:return e.replace(/'/g,"")}})},$.datepicker._base_selectDate=$.datepicker._selectDate,$.datepicker._selectDate=function(e,t){var i,s=this._getInst($(e)[0]),n=this._get(s,"timepicker");n&&s.settings.showTimepicker?(n._limitMinMaxDateTime(s,!0),i=s.inline,s.inline=s.stay_open=!0,this._base_selectDate(e,t),s.inline=i,s.stay_open=!1,this._notifyChange(s),this._updateDatepicker(s)):this._base_selectDate(e,t)},$.datepicker._base_updateDatepicker=$.datepicker._updateDatepicker,$.datepicker._updateDatepicker=function(e){var t=e.input[0];if(!($.datepicker._curInst&&$.datepicker._curInst!==e&&$.datepicker._datepickerShowing&&$.datepicker._lastInput!==t||"boolean"==typeof e.stay_open&&e.stay_open!==!1)){this._base_updateDatepicker(e);var i=this._get(e,"timepicker");i&&i._addTimePicker(e)}},$.datepicker._base_doKeyPress=$.datepicker._doKeyPress,$.datepicker._doKeyPress=function(e){var t=$.datepicker._getInst(e.target),i=$.datepicker._get(t,"timepicker");if(i&&$.datepicker._get(t,"constrainInput")){var s=i.support.ampm,n=null!==i._defaults.showTimezone?i._defaults.showTimezone:i.support.timezone,a=$.datepicker._possibleChars($.datepicker._get(t,"dateFormat")),r=i._defaults.timeFormat.toString().replace(/[hms]/g,"").replace(/TT/g,s?"APM":"").replace(/Tt/g,s?"AaPpMm":"").replace(/tT/g,s?"AaPpMm":"").replace(/T/g,s?"AP":"").replace(/tt/g,s?"apm":"").replace(/t/g,s?"ap":"")+" "+i._defaults.separator+i._defaults.timeSuffix+(n?i._defaults.timezoneList.join(""):"")+i._defaults.amNames.join("")+i._defaults.pmNames.join("")+a,l=String.fromCharCode(void 0===e.charCode?e.keyCode:e.charCode);return e.ctrlKey||" ">l||!a||r.indexOf(l)>-1}return $.datepicker._base_doKeyPress(e)},$.datepicker._base_updateAlternate=$.datepicker._updateAlternate,$.datepicker._updateAlternate=function(e){var t=this._get(e,"timepicker");if(t){var i=t._defaults.altField;if(i){var s=(t._defaults.altFormat||t._defaults.dateFormat,this._getDate(e)),n=$.datepicker._getFormatConfig(e),a="",r=t._defaults.altSeparator?t._defaults.altSeparator:t._defaults.separator,l=t._defaults.altTimeSuffix?t._defaults.altTimeSuffix:t._defaults.timeSuffix,o=null!==t._defaults.altTimeFormat?t._defaults.altTimeFormat:t._defaults.timeFormat;a+=$.datepicker.formatTime(o,t,t._defaults)+l,t._defaults.timeOnly||t._defaults.altFieldTimeOnly||null===s||(a=t._defaults.altFormat?$.datepicker.formatDate(t._defaults.altFormat,s,n)+r+a:t.formattedDate+r+a),$(i).val(e.input.val()?a:"")}}else $.datepicker._base_updateAlternate(e)},$.datepicker._base_doKeyUp=$.datepicker._doKeyUp,$.datepicker._doKeyUp=function(e){var t=$.datepicker._getInst(e.target),i=$.datepicker._get(t,"timepicker");if(i&&i._defaults.timeOnly&&t.input.val()!==t.lastVal)try{$.datepicker._updateDatepicker(t)}catch(s){$.timepicker.log(s)}return $.datepicker._base_doKeyUp(e)},$.datepicker._base_gotoToday=$.datepicker._gotoToday,$.datepicker._gotoToday=function(e){var t=this._getInst($(e)[0]);t.dpDiv;this._base_gotoToday(e);var i=this._get(t,"timepicker");selectLocalTimezone(i);var s=new Date;this._setTime(t,s),this._setDate(t,s)},$.datepicker._disableTimepickerDatepicker=function(e){var t=this._getInst(e);if(t){var i=this._get(t,"timepicker");$(e).datepicker("getDate"),i&&(t.settings.showTimepicker=!1,i._defaults.showTimepicker=!1,i._updateDateTime(t))}},$.datepicker._enableTimepickerDatepicker=function(e){var t=this._getInst(e);if(t){var i=this._get(t,"timepicker");$(e).datepicker("getDate"),i&&(t.settings.showTimepicker=!0,i._defaults.showTimepicker=!0,i._addTimePicker(t),i._updateDateTime(t))}},$.datepicker._setTime=function(e,t){var i=this._get(e,"timepicker");if(i){var s=i._defaults;i.hour=t?t.getHours():s.hour,i.minute=t?t.getMinutes():s.minute,i.second=t?t.getSeconds():s.second,i.millisec=t?t.getMilliseconds():s.millisec,i.microsec=t?t.getMicroseconds():s.microsec,i._limitMinMaxDateTime(e,!0),i._onTimeChange(),i._updateDateTime(e)}},$.datepicker._setTimeDatepicker=function(e,t,i){var s=this._getInst(e);if(s){var n=this._get(s,"timepicker");if(n){this._setDateFromField(s);var a;t&&("string"==typeof t?(n._parseTime(t,i),a=new Date,a.setHours(n.hour,n.minute,n.second,n.millisec),a.setMicroseconds(n.microsec)):(a=new Date(t.getTime()),a.setMicroseconds(t.getMicroseconds())),"Invalid Date"===a.toString()&&(a=void 0),this._setTime(s,a))}}},$.datepicker._base_setDateDatepicker=$.datepicker._setDateDatepicker,$.datepicker._setDateDatepicker=function(e,t){var i=this._getInst(e),s=t;if(i){"string"==typeof t&&(s=new Date(t),s.getTime()||(this._base_setDateDatepicker.apply(this,arguments),s=$(e).datepicker("getDate")));var n,a=this._get(i,"timepicker");s instanceof Date?(n=new Date(s.getTime()),n.setMicroseconds(s.getMicroseconds())):n=s,a&&n&&(a.support.timezone||null!==a._defaults.timezone||(a.timezone=-1*n.getTimezoneOffset()),s=$.timepicker.timezoneAdjust(s,a.timezone),n=$.timepicker.timezoneAdjust(n,a.timezone)),this._updateDatepicker(i),this._base_setDateDatepicker.apply(this,arguments),this._setTimeDatepicker(e,n,!0)}},$.datepicker._base_getDateDatepicker=$.datepicker._getDateDatepicker,$.datepicker._getDateDatepicker=function(e,t){var i=this._getInst(e);if(i){var s=this._get(i,"timepicker");if(s){void 0===i.lastVal&&this._setDateFromField(i,t);var n=this._getDate(i);return n&&s._parseTime($(e).val(),s.timeOnly)&&(n.setHours(s.hour,s.minute,s.second,s.millisec),n.setMicroseconds(s.microsec),null!=s.timezone&&(s.support.timezone||null!==s._defaults.timezone||(s.timezone=-1*n.getTimezoneOffset()),n=$.timepicker.timezoneAdjust(n,s.timezone))),n}return this._base_getDateDatepicker(e,t)}},$.datepicker._base_parseDate=$.datepicker.parseDate,$.datepicker.parseDate=function(e,t,i){var s;try{s=this._base_parseDate(e,t,i)}catch(n){if(!(n.indexOf(":")>=0))throw n;s=this._base_parseDate(e,t.substring(0,t.length-(n.length-n.indexOf(":")-2)),i),$.timepicker.log("Error parsing the date string: "+n+"\ndate string = "+t+"\ndate format = "+e)}return s},$.datepicker._base_formatDate=$.datepicker._formatDate,$.datepicker._formatDate=function(e){var t=this._get(e,"timepicker");return t?(t._updateDateTime(e),t.$input.val()):this._base_formatDate(e)},$.datepicker._base_optionDatepicker=$.datepicker._optionDatepicker,$.datepicker._optionDatepicker=function(e,t,i){var s,n=this._getInst(e);if(!n)return null;var a=this._get(n,"timepicker");if(a){var r,l,o,c,u=null,m=null,d=null,h=a._defaults.evnts,p={};if("string"==typeof t){if("minDate"===t||"minDateTime"===t)u=i;else if("maxDate"===t||"maxDateTime"===t)m=i;else if("onSelect"===t)d=i;else if(h.hasOwnProperty(t)){if("undefined"==typeof i)return h[t];p[t]=i,s={}}}else if("object"==typeof t){t.minDate?u=t.minDate:t.minDateTime?u=t.minDateTime:t.maxDate?m=t.maxDate:t.maxDateTime&&(m=t.maxDateTime);for(r in h)h.hasOwnProperty(r)&&t[r]&&(p[r]=t[r])}for(r in p)p.hasOwnProperty(r)&&(h[r]=p[r],s||(s=$.extend({},t)),delete s[r]);if(s&&isEmptyObject(s))return;if(u?(u=0===u?new Date:new Date(u),a._defaults.minDate=u,a._defaults.minDateTime=u):m?(m=0===m?new Date:new Date(m),a._defaults.maxDate=m,a._defaults.maxDateTime=m):d&&(a._defaults.onSelect=d),u||m)return c=$(e),o=c.datetimepicker("getDate"),l=this._base_optionDatepicker.call($.datepicker,e,s||t,i),c.datetimepicker("setDate",o),l}return void 0===i?this._base_optionDatepicker.call($.datepicker,e,t):this._base_optionDatepicker.call($.datepicker,e,s||t,i)};var isEmptyObject=function(e){var t;for(t in e)if(e.hasOwnProperty(t))return!1;return!0},extendRemove=function(e,t){$.extend(e,t);for(var i in t)(null===t[i]||void 0===t[i])&&(e[i]=t[i]);return e},detectSupport=function(e){var t=e.replace(/'.*?'/g,"").toLowerCase(),i=function(e,t){return-1!==e.indexOf(t)?!0:!1};return{hour:i(t,"h"),minute:i(t,"m"),second:i(t,"s"),millisec:i(t,"l"),microsec:i(t,"c"),timezone:i(t,"z"),ampm:i(t,"t")&&i(e,"h"),iso8601:i(e,"Z")}},convert24to12=function(e){return e%=12,0===e&&(e=12),String(e)},computeEffectiveSetting=function(e,t){return e&&e[t]?e[t]:$.timepicker._defaults[t]},splitDateTime=function(e,t){var i=computeEffectiveSetting(t,"separator"),s=computeEffectiveSetting(t,"timeFormat"),n=s.split(i),a=n.length,r=e.split(i),l=r.length;return l>1?{dateString:r.splice(0,l-a).join(i),timeString:r.splice(0,a).join(i)}:{dateString:e,timeString:""}},parseDateTimeInternal=function(e,t,i,s,n){var a,r,l;if(r=splitDateTime(i,n),a=$.datepicker._base_parseDate(e,r.dateString,s),""===r.timeString)return{date:a};if(l=$.datepicker.parseTime(t,r.timeString,n),!l)throw"Wrong time format";return{date:a,timeObj:l}},selectLocalTimezone=function(e,t){if(e&&e.timezone_select){var i=t||new Date;e.timezone_select.val(-i.getTimezoneOffset())}};$.timepicker=new Timepicker,$.timepicker.timezoneOffsetString=function(e,t){if(isNaN(e)||e>840||-720>e)return e;var i=e,s=i%60,n=(i-s)/60,a=t?":":"",r=(i>=0?"+":"-")+("0"+Math.abs(n)).slice(-2)+a+("0"+Math.abs(s)).slice(-2);return"+00:00"===r?"Z":r},$.timepicker.timezoneOffsetNumber=function(e){var t=e.toString().replace(":","");return"Z"===t.toUpperCase()?0:/^(\-|\+)\d{4}$/.test(t)?("-"===t.substr(0,1)?-1:1)*(60*parseInt(t.substr(1,2),10)+parseInt(t.substr(3,2),10)):e},$.timepicker.timezoneAdjust=function(e,t){var i=$.timepicker.timezoneOffsetNumber(t);return isNaN(i)||e.setMinutes(e.getMinutes()+-e.getTimezoneOffset()-i),e},$.timepicker.timeRange=function(e,t,i){return $.timepicker.handleRange("timepicker",e,t,i)},$.timepicker.datetimeRange=function(e,t,i){$.timepicker.handleRange("datetimepicker",e,t,i)},$.timepicker.dateRange=function(e,t,i){$.timepicker.handleRange("datepicker",e,t,i)},$.timepicker.handleRange=function(e,t,i,s){function n(n,a){var r=t[e]("getDate"),l=i[e]("getDate"),o=n[e]("getDate");if(null!==r){var c=new Date(r.getTime()),u=new Date(r.getTime());c.setMilliseconds(c.getMilliseconds()+s.minInterval),u.setMilliseconds(u.getMilliseconds()+s.maxInterval),s.minInterval>0&&c>l?i[e]("setDate",c):s.maxInterval>0&&l>u?i[e]("setDate",u):r>l&&a[e]("setDate",o)}}function a(t,i,n){if(t.val()){var a=t[e].call(t,"getDate");null!==a&&s.minInterval>0&&("minDate"===n&&a.setMilliseconds(a.getMilliseconds()+s.minInterval),"maxDate"===n&&a.setMilliseconds(a.getMilliseconds()-s.minInterval)),a.getTime&&i[e].call(i,"option",n,a)}}s=$.extend({},{minInterval:0,maxInterval:0,start:{},end:{}},s);var r=!1;return"timepicker"===e&&(r=!0,e="datetimepicker"),$.fn[e].call(t,$.extend({timeOnly:r,onClose:function(){n($(this),i)},onSelect:function(){a($(this),i,"minDate")}},s,s.start)),$.fn[e].call(i,$.extend({timeOnly:r,onClose:function(){n($(this),t)},onSelect:function(){a($(this),t,"maxDate")}},s,s.end)),n(t,i),a(t,i,"minDate"),a(i,t,"maxDate"),$([t.get(0),i.get(0)])},$.timepicker.log=function(){window.console&&window.console.log.apply(window.console,Array.prototype.slice.call(arguments))},$.timepicker._util={_extendRemove:extendRemove,_isEmptyObject:isEmptyObject,_convert24to12:convert24to12,_detectSupport:detectSupport,_selectLocalTimezone:selectLocalTimezone,_computeEffectiveSetting:computeEffectiveSetting,_splitDateTime:splitDateTime,_parseDateTimeInternal:parseDateTimeInternal},Date.prototype.getMicroseconds||(Date.prototype.microseconds=0,Date.prototype.getMicroseconds=function(){return this.microseconds},Date.prototype.setMicroseconds=function(e){return this.setMilliseconds(this.getMilliseconds()+Math.floor(e/1e3)),this.microseconds=e%1e3,this}),$.timepicker.version="1.5.2"}});