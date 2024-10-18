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
require("../jqwidgets/jqxpopover.js");
var core_1 = require("@angular/core");
var jqxPopoverComponent = /** @class */ (function () {
    function jqxPopoverComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['arrowOffsetValue', 'animationOpenDelay', 'animationCloseDelay', 'autoClose', 'animationType', 'height', 'initContent', 'isModal', 'offset', 'position', 'rtl', 'selector', 'showArrow', 'showCloseButton', 'width', 'title', 'theme'];
        // jqxPopoverComponent events
        this.onClose = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxPopoverComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxPopoverComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxPopover(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxPopover(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxPopover(this.properties[i])) {
                        this.host.jqxPopover(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxPopoverComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxPopoverComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxPopoverComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxPopoverComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxPopoverComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxPopover', options);
        this.host = this.widgetObject['host'];
        this.__wireEvents__();
    };
    jqxPopoverComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxPopoverComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxPopoverComponent.prototype.setOptions = function (options) {
        this.host.jqxPopover('setOptions', options);
    };
    // jqxPopoverComponent properties
    jqxPopoverComponent.prototype.arrowOffsetValue = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('arrowOffsetValue', arg);
        }
        else {
            return this.host.jqxPopover('arrowOffsetValue');
        }
    };
    jqxPopoverComponent.prototype.animationOpenDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('animationOpenDelay', arg);
        }
        else {
            return this.host.jqxPopover('animationOpenDelay');
        }
    };
    jqxPopoverComponent.prototype.animationCloseDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('animationCloseDelay', arg);
        }
        else {
            return this.host.jqxPopover('animationCloseDelay');
        }
    };
    jqxPopoverComponent.prototype.autoClose = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('autoClose', arg);
        }
        else {
            return this.host.jqxPopover('autoClose');
        }
    };
    jqxPopoverComponent.prototype.animationType = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('animationType', arg);
        }
        else {
            return this.host.jqxPopover('animationType');
        }
    };
    jqxPopoverComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('height', arg);
        }
        else {
            return this.host.jqxPopover('height');
        }
    };
    jqxPopoverComponent.prototype.initContent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('initContent', arg);
        }
        else {
            return this.host.jqxPopover('initContent');
        }
    };
    jqxPopoverComponent.prototype.isModal = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('isModal', arg);
        }
        else {
            return this.host.jqxPopover('isModal');
        }
    };
    jqxPopoverComponent.prototype.offset = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('offset', arg);
        }
        else {
            return this.host.jqxPopover('offset');
        }
    };
    jqxPopoverComponent.prototype.position = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('position', arg);
        }
        else {
            return this.host.jqxPopover('position');
        }
    };
    jqxPopoverComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('rtl', arg);
        }
        else {
            return this.host.jqxPopover('rtl');
        }
    };
    jqxPopoverComponent.prototype.selector = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('selector', arg);
        }
        else {
            return this.host.jqxPopover('selector');
        }
    };
    jqxPopoverComponent.prototype.showArrow = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('showArrow', arg);
        }
        else {
            return this.host.jqxPopover('showArrow');
        }
    };
    jqxPopoverComponent.prototype.showCloseButton = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('showCloseButton', arg);
        }
        else {
            return this.host.jqxPopover('showCloseButton');
        }
    };
    jqxPopoverComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('width', arg);
        }
        else {
            return this.host.jqxPopover('width');
        }
    };
    jqxPopoverComponent.prototype.title = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('title', arg);
        }
        else {
            return this.host.jqxPopover('title');
        }
    };
    jqxPopoverComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPopover('theme', arg);
        }
        else {
            return this.host.jqxPopover('theme');
        }
    };
    // jqxPopoverComponent functions
    jqxPopoverComponent.prototype.close = function () {
        this.host.jqxPopover('close');
    };
    jqxPopoverComponent.prototype.destroy = function () {
        this.host.jqxPopover('destroy');
    };
    jqxPopoverComponent.prototype.open = function () {
        this.host.jqxPopover('open');
    };
    jqxPopoverComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        setTimeout(function () {
            _this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
            _this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        });
    };
    __decorate([
        core_1.Input('arrowOffsetValue')
    ], jqxPopoverComponent.prototype, "attrArrowOffsetValue", void 0);
    __decorate([
        core_1.Input('animationOpenDelay')
    ], jqxPopoverComponent.prototype, "attrAnimationOpenDelay", void 0);
    __decorate([
        core_1.Input('animationCloseDelay')
    ], jqxPopoverComponent.prototype, "attrAnimationCloseDelay", void 0);
    __decorate([
        core_1.Input('autoClose')
    ], jqxPopoverComponent.prototype, "attrAutoClose", void 0);
    __decorate([
        core_1.Input('animationType')
    ], jqxPopoverComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('initContent')
    ], jqxPopoverComponent.prototype, "attrInitContent", void 0);
    __decorate([
        core_1.Input('isModal')
    ], jqxPopoverComponent.prototype, "attrIsModal", void 0);
    __decorate([
        core_1.Input('offset')
    ], jqxPopoverComponent.prototype, "attrOffset", void 0);
    __decorate([
        core_1.Input('position')
    ], jqxPopoverComponent.prototype, "attrPosition", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxPopoverComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('selector')
    ], jqxPopoverComponent.prototype, "attrSelector", void 0);
    __decorate([
        core_1.Input('showArrow')
    ], jqxPopoverComponent.prototype, "attrShowArrow", void 0);
    __decorate([
        core_1.Input('showCloseButton')
    ], jqxPopoverComponent.prototype, "attrShowCloseButton", void 0);
    __decorate([
        core_1.Input('title')
    ], jqxPopoverComponent.prototype, "attrTitle", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxPopoverComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxPopoverComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxPopoverComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxPopoverComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxPopoverComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxPopoverComponent.prototype, "onOpen", void 0);
    jqxPopoverComponent = __decorate([
        core_1.Component({
            selector: 'jqxPopover',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxPopoverComponent);
    return jqxPopoverComponent;
}()); //jqxPopoverComponent
exports.jqxPopoverComponent = jqxPopoverComponent;
