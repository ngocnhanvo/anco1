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
require("../jqwidgets/jqxbuttons.js");
var core_1 = require("@angular/core");
var jqxToggleButtonComponent = /** @class */ (function () {
    function jqxToggleButtonComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'imgSrc', 'imgWidth', 'imgHeight', 'imgPosition', 'roundedCorners', 'rtl', 'textPosition', 'textImageRelation', 'theme', 'template', 'toggled', 'width', 'value'];
        // jqxToggleButtonComponent events
        this.onClick = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxToggleButtonComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxToggleButtonComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxToggleButton(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxToggleButton(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxToggleButton(this.properties[i])) {
                        this.host.jqxToggleButton(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxToggleButtonComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxToggleButtonComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxToggleButtonComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxToggleButtonComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxToggleButtonComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxToggleButton', options);
    };
    jqxToggleButtonComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxToggleButtonComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxToggleButtonComponent.prototype.setOptions = function (options) {
        this.host.jqxToggleButton('setOptions', options);
    };
    // jqxToggleButtonComponent properties
    jqxToggleButtonComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('disabled', arg);
        }
        else {
            return this.host.jqxToggleButton('disabled');
        }
    };
    jqxToggleButtonComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('height', arg);
        }
        else {
            return this.host.jqxToggleButton('height');
        }
    };
    jqxToggleButtonComponent.prototype.imgSrc = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('imgSrc', arg);
        }
        else {
            return this.host.jqxToggleButton('imgSrc');
        }
    };
    jqxToggleButtonComponent.prototype.imgWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('imgWidth', arg);
        }
        else {
            return this.host.jqxToggleButton('imgWidth');
        }
    };
    jqxToggleButtonComponent.prototype.imgHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('imgHeight', arg);
        }
        else {
            return this.host.jqxToggleButton('imgHeight');
        }
    };
    jqxToggleButtonComponent.prototype.imgPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('imgPosition', arg);
        }
        else {
            return this.host.jqxToggleButton('imgPosition');
        }
    };
    jqxToggleButtonComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('roundedCorners', arg);
        }
        else {
            return this.host.jqxToggleButton('roundedCorners');
        }
    };
    jqxToggleButtonComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('rtl', arg);
        }
        else {
            return this.host.jqxToggleButton('rtl');
        }
    };
    jqxToggleButtonComponent.prototype.textPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('textPosition', arg);
        }
        else {
            return this.host.jqxToggleButton('textPosition');
        }
    };
    jqxToggleButtonComponent.prototype.textImageRelation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('textImageRelation', arg);
        }
        else {
            return this.host.jqxToggleButton('textImageRelation');
        }
    };
    jqxToggleButtonComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('theme', arg);
        }
        else {
            return this.host.jqxToggleButton('theme');
        }
    };
    jqxToggleButtonComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('template', arg);
        }
        else {
            return this.host.jqxToggleButton('template');
        }
    };
    jqxToggleButtonComponent.prototype.toggled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('toggled', arg);
        }
        else {
            return this.host.jqxToggleButton('toggled');
        }
    };
    jqxToggleButtonComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('width', arg);
        }
        else {
            return this.host.jqxToggleButton('width');
        }
    };
    jqxToggleButtonComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxToggleButton('value', arg);
        }
        else {
            return this.host.jqxToggleButton('value');
        }
    };
    // jqxToggleButtonComponent functions
    jqxToggleButtonComponent.prototype.check = function () {
        this.host.jqxToggleButton('check');
    };
    jqxToggleButtonComponent.prototype.destroy = function () {
        this.host.jqxToggleButton('destroy');
    };
    jqxToggleButtonComponent.prototype.focus = function () {
        this.host.jqxToggleButton('focus');
    };
    jqxToggleButtonComponent.prototype.render = function () {
        this.host.jqxToggleButton('render');
    };
    jqxToggleButtonComponent.prototype.toggle = function () {
        this.host.jqxToggleButton('toggle');
    };
    jqxToggleButtonComponent.prototype.unCheck = function () {
        this.host.jqxToggleButton('unCheck');
    };
    jqxToggleButtonComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxToggleButton('val', value);
        }
        else {
            return this.host.jqxToggleButton('val');
        }
    };
    ;
    jqxToggleButtonComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('click', function (eventData) { _this.onClick.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxToggleButtonComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('imgSrc')
    ], jqxToggleButtonComponent.prototype, "attrImgSrc", void 0);
    __decorate([
        core_1.Input('imgWidth')
    ], jqxToggleButtonComponent.prototype, "attrImgWidth", void 0);
    __decorate([
        core_1.Input('imgHeight')
    ], jqxToggleButtonComponent.prototype, "attrImgHeight", void 0);
    __decorate([
        core_1.Input('imgPosition')
    ], jqxToggleButtonComponent.prototype, "attrImgPosition", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxToggleButtonComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxToggleButtonComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('textPosition')
    ], jqxToggleButtonComponent.prototype, "attrTextPosition", void 0);
    __decorate([
        core_1.Input('textImageRelation')
    ], jqxToggleButtonComponent.prototype, "attrTextImageRelation", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxToggleButtonComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxToggleButtonComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('toggled')
    ], jqxToggleButtonComponent.prototype, "attrToggled", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxToggleButtonComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxToggleButtonComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxToggleButtonComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxToggleButtonComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxToggleButtonComponent.prototype, "onClick", void 0);
    jqxToggleButtonComponent = __decorate([
        core_1.Component({
            selector: 'jqxToggleButton',
            template: '<button><ng-content></ng-content></button>'
        })
    ], jqxToggleButtonComponent);
    return jqxToggleButtonComponent;
}()); //jqxToggleButtonComponent
exports.jqxToggleButtonComponent = jqxToggleButtonComponent;
