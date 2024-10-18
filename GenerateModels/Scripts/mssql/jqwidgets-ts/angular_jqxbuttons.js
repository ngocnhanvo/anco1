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
var jqxButtonComponent = /** @class */ (function () {
    function jqxButtonComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'imgSrc', 'imgWidth', 'imgHeight', 'imgPosition', 'roundedCorners', 'rtl', 'enableDefault', 'cursor', 'textPosition', 'textImageRelation', 'theme', 'template', 'width', 'value'];
        // jqxButtonComponent events
        this.onClick = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxButtonComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxButtonComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxButton(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxButton(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxButton(this.properties[i])) {
                        this.host.jqxButton(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxButtonComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxButtonComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxButtonComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxButtonComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxButtonComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxButton', options);
        this.host = this.widgetObject['host'];
        this.__wireEvents__();
    };
    jqxButtonComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxButtonComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxButtonComponent.prototype.setOptions = function (options) {
        this.host.jqxButton('setOptions', options);
    };
    // jqxButtonComponent properties
    jqxButtonComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('disabled', arg);
        }
        else {
            return this.host.jqxButton('disabled');
        }
    };
    jqxButtonComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('height', arg);
        }
        else {
            return this.host.jqxButton('height');
        }
    };
    jqxButtonComponent.prototype.imgSrc = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('imgSrc', arg);
        }
        else {
            return this.host.jqxButton('imgSrc');
        }
    };
    jqxButtonComponent.prototype.imgWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('imgWidth', arg);
        }
        else {
            return this.host.jqxButton('imgWidth');
        }
    };
    jqxButtonComponent.prototype.imgHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('imgHeight', arg);
        }
        else {
            return this.host.jqxButton('imgHeight');
        }
    };
    jqxButtonComponent.prototype.imgPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('imgPosition', arg);
        }
        else {
            return this.host.jqxButton('imgPosition');
        }
    };
    jqxButtonComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('roundedCorners', arg);
        }
        else {
            return this.host.jqxButton('roundedCorners');
        }
    };
    jqxButtonComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('rtl', arg);
        }
        else {
            return this.host.jqxButton('rtl');
        }
    };
    jqxButtonComponent.prototype.enableDefault = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('enableDefault', arg);
        }
        else {
            return this.host.jqxButton('enableDefault');
        }
    };
    jqxButtonComponent.prototype.cursor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('cursor', arg);
        }
        else {
            return this.host.jqxButton('cursor');
        }
    };
    jqxButtonComponent.prototype.textPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('textPosition', arg);
        }
        else {
            return this.host.jqxButton('textPosition');
        }
    };
    jqxButtonComponent.prototype.textImageRelation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('textImageRelation', arg);
        }
        else {
            return this.host.jqxButton('textImageRelation');
        }
    };
    jqxButtonComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('theme', arg);
        }
        else {
            return this.host.jqxButton('theme');
        }
    };
    jqxButtonComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('template', arg);
        }
        else {
            return this.host.jqxButton('template');
        }
    };
    jqxButtonComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('width', arg);
        }
        else {
            return this.host.jqxButton('width');
        }
    };
    jqxButtonComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxButton('value', arg);
        }
        else {
            return this.host.jqxButton('value');
        }
    };
    // jqxButtonComponent functions
    jqxButtonComponent.prototype.destroy = function () {
        this.host.jqxButton('destroy');
    };
    jqxButtonComponent.prototype.focus = function () {
        this.host.jqxButton('focus');
    };
    jqxButtonComponent.prototype.render = function () {
        this.host.jqxButton('render');
    };
    jqxButtonComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxButton('val', value);
        }
        else {
            return this.host.jqxButton('val');
        }
    };
    ;
    jqxButtonComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('click', function (eventData) { _this.onClick.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxButtonComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('imgSrc')
    ], jqxButtonComponent.prototype, "attrImgSrc", void 0);
    __decorate([
        core_1.Input('imgWidth')
    ], jqxButtonComponent.prototype, "attrImgWidth", void 0);
    __decorate([
        core_1.Input('imgHeight')
    ], jqxButtonComponent.prototype, "attrImgHeight", void 0);
    __decorate([
        core_1.Input('imgPosition')
    ], jqxButtonComponent.prototype, "attrImgPosition", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxButtonComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxButtonComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('enableDefault')
    ], jqxButtonComponent.prototype, "attrEnableDefault", void 0);
    __decorate([
        core_1.Input('cursor')
    ], jqxButtonComponent.prototype, "attrCursor", void 0);
    __decorate([
        core_1.Input('textPosition')
    ], jqxButtonComponent.prototype, "attrTextPosition", void 0);
    __decorate([
        core_1.Input('textImageRelation')
    ], jqxButtonComponent.prototype, "attrTextImageRelation", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxButtonComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxButtonComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxButtonComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxButtonComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxButtonComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxButtonComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxButtonComponent.prototype, "onClick", void 0);
    jqxButtonComponent = __decorate([
        core_1.Component({
            selector: 'jqxButton',
            template: '<button><ng-content></ng-content></button>'
        })
    ], jqxButtonComponent);
    return jqxButtonComponent;
}()); //jqxButtonComponent
exports.jqxButtonComponent = jqxButtonComponent;
