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
require("../jqwidgets/jqxtooltip.js");
var core_1 = require("@angular/core");
var jqxTooltipComponent = /** @class */ (function () {
    function jqxTooltipComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['absolutePositionX', 'absolutePositionY', 'autoHide', 'autoHideDelay', 'animationShowDelay', 'animationHideDelay', 'content', 'closeOnClick', 'disabled', 'enableBrowserBoundsDetection', 'height', 'left', 'name', 'opacity', 'position', 'rtl', 'showDelay', 'showArrow', 'top', 'trigger', 'theme', 'width'];
        // jqxTooltipComponent events
        this.onClose = new core_1.EventEmitter();
        this.onClosing = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.onOpening = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxTooltipComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxTooltipComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxTooltip(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxTooltip(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxTooltip(this.properties[i])) {
                        this.host.jqxTooltip(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxTooltipComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxTooltipComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxTooltipComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxTooltipComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxTooltipComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxTooltip', options);
    };
    jqxTooltipComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxTooltipComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxTooltipComponent.prototype.setOptions = function (options) {
        this.host.jqxTooltip('setOptions', options);
    };
    // jqxTooltipComponent properties
    jqxTooltipComponent.prototype.absolutePositionX = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('absolutePositionX', arg);
        }
        else {
            return this.host.jqxTooltip('absolutePositionX');
        }
    };
    jqxTooltipComponent.prototype.absolutePositionY = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('absolutePositionY', arg);
        }
        else {
            return this.host.jqxTooltip('absolutePositionY');
        }
    };
    jqxTooltipComponent.prototype.autoHide = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('autoHide', arg);
        }
        else {
            return this.host.jqxTooltip('autoHide');
        }
    };
    jqxTooltipComponent.prototype.autoHideDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('autoHideDelay', arg);
        }
        else {
            return this.host.jqxTooltip('autoHideDelay');
        }
    };
    jqxTooltipComponent.prototype.animationShowDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('animationShowDelay', arg);
        }
        else {
            return this.host.jqxTooltip('animationShowDelay');
        }
    };
    jqxTooltipComponent.prototype.animationHideDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('animationHideDelay', arg);
        }
        else {
            return this.host.jqxTooltip('animationHideDelay');
        }
    };
    jqxTooltipComponent.prototype.content = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('content', arg);
        }
        else {
            return this.host.jqxTooltip('content');
        }
    };
    jqxTooltipComponent.prototype.closeOnClick = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('closeOnClick', arg);
        }
        else {
            return this.host.jqxTooltip('closeOnClick');
        }
    };
    jqxTooltipComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('disabled', arg);
        }
        else {
            return this.host.jqxTooltip('disabled');
        }
    };
    jqxTooltipComponent.prototype.enableBrowserBoundsDetection = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('enableBrowserBoundsDetection', arg);
        }
        else {
            return this.host.jqxTooltip('enableBrowserBoundsDetection');
        }
    };
    jqxTooltipComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('height', arg);
        }
        else {
            return this.host.jqxTooltip('height');
        }
    };
    jqxTooltipComponent.prototype.left = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('left', arg);
        }
        else {
            return this.host.jqxTooltip('left');
        }
    };
    jqxTooltipComponent.prototype.name = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('name', arg);
        }
        else {
            return this.host.jqxTooltip('name');
        }
    };
    jqxTooltipComponent.prototype.opacity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('opacity', arg);
        }
        else {
            return this.host.jqxTooltip('opacity');
        }
    };
    jqxTooltipComponent.prototype.position = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('position', arg);
        }
        else {
            return this.host.jqxTooltip('position');
        }
    };
    jqxTooltipComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('rtl', arg);
        }
        else {
            return this.host.jqxTooltip('rtl');
        }
    };
    jqxTooltipComponent.prototype.showDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('showDelay', arg);
        }
        else {
            return this.host.jqxTooltip('showDelay');
        }
    };
    jqxTooltipComponent.prototype.showArrow = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('showArrow', arg);
        }
        else {
            return this.host.jqxTooltip('showArrow');
        }
    };
    jqxTooltipComponent.prototype.top = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('top', arg);
        }
        else {
            return this.host.jqxTooltip('top');
        }
    };
    jqxTooltipComponent.prototype.trigger = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('trigger', arg);
        }
        else {
            return this.host.jqxTooltip('trigger');
        }
    };
    jqxTooltipComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('theme', arg);
        }
        else {
            return this.host.jqxTooltip('theme');
        }
    };
    jqxTooltipComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTooltip('width', arg);
        }
        else {
            return this.host.jqxTooltip('width');
        }
    };
    // jqxTooltipComponent functions
    jqxTooltipComponent.prototype.close = function (index) {
        this.host.jqxTooltip('close', index);
    };
    jqxTooltipComponent.prototype.destroy = function () {
        this.host.jqxTooltip('destroy');
    };
    jqxTooltipComponent.prototype.open = function (left, top) {
        this.host.jqxTooltip('open', left, top);
    };
    jqxTooltipComponent.prototype.refresh = function () {
        this.host.jqxTooltip('refresh');
    };
    jqxTooltipComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
        this.host.on('closing', function (eventData) { _this.onClosing.emit(eventData); });
        this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        this.host.on('opening', function (eventData) { _this.onOpening.emit(eventData); });
    };
    __decorate([
        core_1.Input('absolutePositionX')
    ], jqxTooltipComponent.prototype, "attrAbsolutePositionX", void 0);
    __decorate([
        core_1.Input('absolutePositionY')
    ], jqxTooltipComponent.prototype, "attrAbsolutePositionY", void 0);
    __decorate([
        core_1.Input('autoHide')
    ], jqxTooltipComponent.prototype, "attrAutoHide", void 0);
    __decorate([
        core_1.Input('autoHideDelay')
    ], jqxTooltipComponent.prototype, "attrAutoHideDelay", void 0);
    __decorate([
        core_1.Input('animationShowDelay')
    ], jqxTooltipComponent.prototype, "attrAnimationShowDelay", void 0);
    __decorate([
        core_1.Input('animationHideDelay')
    ], jqxTooltipComponent.prototype, "attrAnimationHideDelay", void 0);
    __decorate([
        core_1.Input('content')
    ], jqxTooltipComponent.prototype, "attrContent", void 0);
    __decorate([
        core_1.Input('closeOnClick')
    ], jqxTooltipComponent.prototype, "attrCloseOnClick", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxTooltipComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('enableBrowserBoundsDetection')
    ], jqxTooltipComponent.prototype, "attrEnableBrowserBoundsDetection", void 0);
    __decorate([
        core_1.Input('left')
    ], jqxTooltipComponent.prototype, "attrLeft", void 0);
    __decorate([
        core_1.Input('name')
    ], jqxTooltipComponent.prototype, "attrName", void 0);
    __decorate([
        core_1.Input('opacity')
    ], jqxTooltipComponent.prototype, "attrOpacity", void 0);
    __decorate([
        core_1.Input('position')
    ], jqxTooltipComponent.prototype, "attrPosition", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxTooltipComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('showDelay')
    ], jqxTooltipComponent.prototype, "attrShowDelay", void 0);
    __decorate([
        core_1.Input('showArrow')
    ], jqxTooltipComponent.prototype, "attrShowArrow", void 0);
    __decorate([
        core_1.Input('top')
    ], jqxTooltipComponent.prototype, "attrTop", void 0);
    __decorate([
        core_1.Input('trigger')
    ], jqxTooltipComponent.prototype, "attrTrigger", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxTooltipComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxTooltipComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxTooltipComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxTooltipComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxTooltipComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxTooltipComponent.prototype, "onClosing", void 0);
    __decorate([
        core_1.Output()
    ], jqxTooltipComponent.prototype, "onOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxTooltipComponent.prototype, "onOpening", void 0);
    jqxTooltipComponent = __decorate([
        core_1.Component({
            selector: 'jqxTooltip',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxTooltipComponent);
    return jqxTooltipComponent;
}()); //jqxTooltipComponent
exports.jqxTooltipComponent = jqxTooltipComponent;
