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
var jqxRepeatButtonComponent = /** @class */ (function () {
    function jqxRepeatButtonComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['delay', 'disabled', 'height', 'imgSrc', 'imgWidth', 'imgHeight', 'imgPosition', 'roundedCorners', 'rtl', 'textPosition', 'textImageRelation', 'theme', 'template', 'toggled', 'width', 'value'];
        // jqxRepeatButtonComponent events
        this.onClick = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxRepeatButtonComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxRepeatButtonComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxRepeatButton(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxRepeatButton(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxRepeatButton(this.properties[i])) {
                        this.host.jqxRepeatButton(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxRepeatButtonComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxRepeatButtonComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxRepeatButtonComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxRepeatButtonComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxRepeatButtonComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxRepeatButton', options);
    };
    jqxRepeatButtonComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxRepeatButtonComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxRepeatButtonComponent.prototype.setOptions = function (options) {
        this.host.jqxRepeatButton('setOptions', options);
    };
    // jqxRepeatButtonComponent properties
    jqxRepeatButtonComponent.prototype.delay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('delay', arg);
        }
        else {
            return this.host.jqxRepeatButton('delay');
        }
    };
    jqxRepeatButtonComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('disabled', arg);
        }
        else {
            return this.host.jqxRepeatButton('disabled');
        }
    };
    jqxRepeatButtonComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('height', arg);
        }
        else {
            return this.host.jqxRepeatButton('height');
        }
    };
    jqxRepeatButtonComponent.prototype.imgSrc = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('imgSrc', arg);
        }
        else {
            return this.host.jqxRepeatButton('imgSrc');
        }
    };
    jqxRepeatButtonComponent.prototype.imgWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('imgWidth', arg);
        }
        else {
            return this.host.jqxRepeatButton('imgWidth');
        }
    };
    jqxRepeatButtonComponent.prototype.imgHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('imgHeight', arg);
        }
        else {
            return this.host.jqxRepeatButton('imgHeight');
        }
    };
    jqxRepeatButtonComponent.prototype.imgPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('imgPosition', arg);
        }
        else {
            return this.host.jqxRepeatButton('imgPosition');
        }
    };
    jqxRepeatButtonComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('roundedCorners', arg);
        }
        else {
            return this.host.jqxRepeatButton('roundedCorners');
        }
    };
    jqxRepeatButtonComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('rtl', arg);
        }
        else {
            return this.host.jqxRepeatButton('rtl');
        }
    };
    jqxRepeatButtonComponent.prototype.textPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('textPosition', arg);
        }
        else {
            return this.host.jqxRepeatButton('textPosition');
        }
    };
    jqxRepeatButtonComponent.prototype.textImageRelation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('textImageRelation', arg);
        }
        else {
            return this.host.jqxRepeatButton('textImageRelation');
        }
    };
    jqxRepeatButtonComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('theme', arg);
        }
        else {
            return this.host.jqxRepeatButton('theme');
        }
    };
    jqxRepeatButtonComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('template', arg);
        }
        else {
            return this.host.jqxRepeatButton('template');
        }
    };
    jqxRepeatButtonComponent.prototype.toggled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('toggled', arg);
        }
        else {
            return this.host.jqxRepeatButton('toggled');
        }
    };
    jqxRepeatButtonComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('width', arg);
        }
        else {
            return this.host.jqxRepeatButton('width');
        }
    };
    jqxRepeatButtonComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRepeatButton('value', arg);
        }
        else {
            return this.host.jqxRepeatButton('value');
        }
    };
    // jqxRepeatButtonComponent functions
    jqxRepeatButtonComponent.prototype.destroy = function () {
        this.host.jqxRepeatButton('destroy');
    };
    jqxRepeatButtonComponent.prototype.focus = function () {
        this.host.jqxRepeatButton('focus');
    };
    jqxRepeatButtonComponent.prototype.render = function () {
        this.host.jqxRepeatButton('render');
    };
    jqxRepeatButtonComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxRepeatButton('val', value);
        }
        else {
            return this.host.jqxRepeatButton('val');
        }
    };
    ;
    jqxRepeatButtonComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('click', function (eventData) { _this.onClick.emit(eventData); });
    };
    __decorate([
        core_1.Input('delay')
    ], jqxRepeatButtonComponent.prototype, "attrDelay", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxRepeatButtonComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('imgSrc')
    ], jqxRepeatButtonComponent.prototype, "attrImgSrc", void 0);
    __decorate([
        core_1.Input('imgWidth')
    ], jqxRepeatButtonComponent.prototype, "attrImgWidth", void 0);
    __decorate([
        core_1.Input('imgHeight')
    ], jqxRepeatButtonComponent.prototype, "attrImgHeight", void 0);
    __decorate([
        core_1.Input('imgPosition')
    ], jqxRepeatButtonComponent.prototype, "attrImgPosition", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxRepeatButtonComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxRepeatButtonComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('textPosition')
    ], jqxRepeatButtonComponent.prototype, "attrTextPosition", void 0);
    __decorate([
        core_1.Input('textImageRelation')
    ], jqxRepeatButtonComponent.prototype, "attrTextImageRelation", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxRepeatButtonComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxRepeatButtonComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('toggled')
    ], jqxRepeatButtonComponent.prototype, "attrToggled", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxRepeatButtonComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxRepeatButtonComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxRepeatButtonComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxRepeatButtonComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxRepeatButtonComponent.prototype, "onClick", void 0);
    jqxRepeatButtonComponent = __decorate([
        core_1.Component({
            selector: 'jqxRepeatButton',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxRepeatButtonComponent);
    return jqxRepeatButtonComponent;
}()); //jqxRepeatButtonComponent
exports.jqxRepeatButtonComponent = jqxRepeatButtonComponent;
