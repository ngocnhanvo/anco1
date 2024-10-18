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
var jqxLinkButtonComponent = /** @class */ (function () {
    function jqxLinkButtonComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'rtl', 'theme', 'width'];
        this.elementRef = containerElement;
    }
    jqxLinkButtonComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxLinkButtonComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxLinkButton(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxLinkButton(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxLinkButton(this.properties[i])) {
                        this.host.jqxLinkButton(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxLinkButtonComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxLinkButtonComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxLinkButtonComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxLinkButtonComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxLinkButtonComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxLinkButton', options);
    };
    jqxLinkButtonComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxLinkButtonComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxLinkButtonComponent.prototype.setOptions = function (options) {
        this.host.jqxLinkButton('setOptions', options);
    };
    // jqxLinkButtonComponent properties
    jqxLinkButtonComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLinkButton('disabled', arg);
        }
        else {
            return this.host.jqxLinkButton('disabled');
        }
    };
    jqxLinkButtonComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLinkButton('height', arg);
        }
        else {
            return this.host.jqxLinkButton('height');
        }
    };
    jqxLinkButtonComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLinkButton('rtl', arg);
        }
        else {
            return this.host.jqxLinkButton('rtl');
        }
    };
    jqxLinkButtonComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLinkButton('theme', arg);
        }
        else {
            return this.host.jqxLinkButton('theme');
        }
    };
    jqxLinkButtonComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLinkButton('width', arg);
        }
        else {
            return this.host.jqxLinkButton('width');
        }
    };
    jqxLinkButtonComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxLinkButtonComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxLinkButtonComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxLinkButtonComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxLinkButtonComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxLinkButtonComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxLinkButtonComponent.prototype, "autoCreate", void 0);
    jqxLinkButtonComponent = __decorate([
        core_1.Component({
            selector: 'jqxLinkButton',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxLinkButtonComponent);
    return jqxLinkButtonComponent;
}()); //jqxLinkButtonComponent
exports.jqxLinkButtonComponent = jqxLinkButtonComponent;
