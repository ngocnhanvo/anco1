"use strict";
/*
jQWidgets v20.0.0 (2024-Sep)
Copyright (c) 2011-2024 jQWidgets.
License: https://jqwidgets.com/license/
*/
/* eslint-disable */
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path="jqwidgets.d.ts" />
require("../jqwidgets/jqxcore.js");
require("../jqwidgets/jqxdata.js");
require("../jqwidgets/jqxbuttons.js");
require("../jqwidgets/jqxribbon.js");
var core_1 = require("@angular/core");
var jqxRibbonComponent = /** @class */ (function () {
    function jqxRibbonComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['animationType', 'animationDelay', 'disabled', 'height', 'initContent', 'mode', 'popupCloseMode', 'position', 'reorder', 'rtl', 'selectedIndex', 'selectionMode', 'scrollPosition', 'scrollStep', 'scrollDelay', 'theme', 'width'];
        // jqxRibbonComponent events
        this.onChange = new core_1.EventEmitter();
        this.onReorder = new core_1.EventEmitter();
        this.onSelect = new core_1.EventEmitter();
        this.onUnselect = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxRibbonComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxRibbonComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxRibbon(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxRibbon(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxRibbon(this.properties[i])) {
                        this.host.jqxRibbon(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxRibbonComponent.prototype.arraysEqual = function (attrValue, hostValue) {
        if ((attrValue && !hostValue) || (!attrValue && hostValue)) {
            return false;
        }
        if (attrValue.length != hostValue.length) {
            return false;
        }
        for (var i = 0; i < attrValue.length; i++) {
            if (attrValue[i] !== hostValue[i]) {
                return false;
            }
        }
        return true;
    };
    jqxRibbonComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxRibbonComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxRibbonComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxRibbonComponent.prototype.createComponent = function (options) {
        if (this.host) {
            return;
        }
        if (options) {
            JQXLite.extend(options, this.manageAttributes());
        }
        else {
            options = this.manageAttributes();
        }
        this.host = JQXLite(this.elementRef.nativeElement.firstChild);
        this.moveClasses(this.elementRef.nativeElement, this.host[0]);
        this.moveStyles(this.elementRef.nativeElement, this.host[0]);
        this.__wireEvents__();
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxRibbon', options);
    };
    jqxRibbonComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxRibbonComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxRibbonComponent.prototype.setOptions = function (options) {
        this.host.jqxRibbon('setOptions', options);
    };
    // jqxRibbonComponent properties
    jqxRibbonComponent.prototype.animationType = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('animationType', arg);
        }
        else {
            return this.host.jqxRibbon('animationType');
        }
    };
    jqxRibbonComponent.prototype.animationDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('animationDelay', arg);
        }
        else {
            return this.host.jqxRibbon('animationDelay');
        }
    };
    jqxRibbonComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('disabled', arg);
        }
        else {
            return this.host.jqxRibbon('disabled');
        }
    };
    jqxRibbonComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('height', arg);
        }
        else {
            return this.host.jqxRibbon('height');
        }
    };
    jqxRibbonComponent.prototype.initContent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('initContent', arg);
        }
        else {
            return this.host.jqxRibbon('initContent');
        }
    };
    jqxRibbonComponent.prototype.mode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('mode', arg);
        }
        else {
            return this.host.jqxRibbon('mode');
        }
    };
    jqxRibbonComponent.prototype.popupCloseMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('popupCloseMode', arg);
        }
        else {
            return this.host.jqxRibbon('popupCloseMode');
        }
    };
    jqxRibbonComponent.prototype.position = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('position', arg);
        }
        else {
            return this.host.jqxRibbon('position');
        }
    };
    jqxRibbonComponent.prototype.reorder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('reorder', arg);
        }
        else {
            return this.host.jqxRibbon('reorder');
        }
    };
    jqxRibbonComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('rtl', arg);
        }
        else {
            return this.host.jqxRibbon('rtl');
        }
    };
    jqxRibbonComponent.prototype.selectedIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('selectedIndex', arg);
        }
        else {
            return this.host.jqxRibbon('selectedIndex');
        }
    };
    jqxRibbonComponent.prototype.selectionMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('selectionMode', arg);
        }
        else {
            return this.host.jqxRibbon('selectionMode');
        }
    };
    jqxRibbonComponent.prototype.scrollPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('scrollPosition', arg);
        }
        else {
            return this.host.jqxRibbon('scrollPosition');
        }
    };
    jqxRibbonComponent.prototype.scrollStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('scrollStep', arg);
        }
        else {
            return this.host.jqxRibbon('scrollStep');
        }
    };
    jqxRibbonComponent.prototype.scrollDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('scrollDelay', arg);
        }
        else {
            return this.host.jqxRibbon('scrollDelay');
        }
    };
    jqxRibbonComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('theme', arg);
        }
        else {
            return this.host.jqxRibbon('theme');
        }
    };
    jqxRibbonComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRibbon('width', arg);
        }
        else {
            return this.host.jqxRibbon('width');
        }
    };
    // jqxRibbonComponent functions
    jqxRibbonComponent.prototype.addAt = function (index, item) {
        this.host.jqxRibbon('addAt', index, item);
    };
    jqxRibbonComponent.prototype.clearSelection = function () {
        this.host.jqxRibbon('clearSelection');
    };
    jqxRibbonComponent.prototype.disableAt = function (index) {
        this.host.jqxRibbon('disableAt', index);
    };
    jqxRibbonComponent.prototype.destroy = function () {
        this.host.jqxRibbon('destroy');
    };
    jqxRibbonComponent.prototype.enableAt = function (index) {
        this.host.jqxRibbon('enableAt', index);
    };
    jqxRibbonComponent.prototype.hideAt = function (index) {
        this.host.jqxRibbon('hideAt', index);
    };
    jqxRibbonComponent.prototype.removeAt = function (index) {
        this.host.jqxRibbon('removeAt', index);
    };
    jqxRibbonComponent.prototype.render = function () {
        this.host.jqxRibbon('render');
    };
    jqxRibbonComponent.prototype.refresh = function () {
        this.host.jqxRibbon('refresh');
    };
    jqxRibbonComponent.prototype.selectAt = function (index) {
        this.host.jqxRibbon('selectAt', index);
    };
    jqxRibbonComponent.prototype.showAt = function (index) {
        this.host.jqxRibbon('showAt', index);
    };
    jqxRibbonComponent.prototype.setPopupLayout = function (index, layout, width, height) {
        this.host.jqxRibbon('setPopupLayout', index, layout, width, height);
    };
    jqxRibbonComponent.prototype.updateAt = function (index, item) {
        this.host.jqxRibbon('updateAt', index, item);
    };
    jqxRibbonComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxRibbon('val', value);
        }
        else {
            return this.host.jqxRibbon('val');
        }
    };
    ;
    jqxRibbonComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
        this.host.on('reorder', function (eventData) { _this.onReorder.emit(eventData); });
        this.host.on('select', function (eventData) { _this.onSelect.emit(eventData); });
        this.host.on('unselect', function (eventData) { _this.onUnselect.emit(eventData); });
    };
    __decorate([
        core_1.Input('animationType')
    ], jqxRibbonComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('animationDelay')
    ], jqxRibbonComponent.prototype, "attrAnimationDelay", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxRibbonComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('initContent')
    ], jqxRibbonComponent.prototype, "attrInitContent", void 0);
    __decorate([
        core_1.Input('mode')
    ], jqxRibbonComponent.prototype, "attrMode", void 0);
    __decorate([
        core_1.Input('popupCloseMode')
    ], jqxRibbonComponent.prototype, "attrPopupCloseMode", void 0);
    __decorate([
        core_1.Input('position')
    ], jqxRibbonComponent.prototype, "attrPosition", void 0);
    __decorate([
        core_1.Input('reorder')
    ], jqxRibbonComponent.prototype, "attrReorder", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxRibbonComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('selectedIndex')
    ], jqxRibbonComponent.prototype, "attrSelectedIndex", void 0);
    __decorate([
        core_1.Input('selectionMode')
    ], jqxRibbonComponent.prototype, "attrSelectionMode", void 0);
    __decorate([
        core_1.Input('scrollPosition')
    ], jqxRibbonComponent.prototype, "attrScrollPosition", void 0);
    __decorate([
        core_1.Input('scrollStep')
    ], jqxRibbonComponent.prototype, "attrScrollStep", void 0);
    __decorate([
        core_1.Input('scrollDelay')
    ], jqxRibbonComponent.prototype, "attrScrollDelay", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxRibbonComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxRibbonComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxRibbonComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxRibbonComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxRibbonComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxRibbonComponent.prototype, "onReorder", void 0);
    __decorate([
        core_1.Output()
    ], jqxRibbonComponent.prototype, "onSelect", void 0);
    __decorate([
        core_1.Output()
    ], jqxRibbonComponent.prototype, "onUnselect", void 0);
    jqxRibbonComponent = __decorate([
        core_1.Component({
            selector: 'jqxRibbon',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxRibbonComponent);
    return jqxRibbonComponent;
}()); //jqxRibbonComponent
exports.jqxRibbonComponent = jqxRibbonComponent;
