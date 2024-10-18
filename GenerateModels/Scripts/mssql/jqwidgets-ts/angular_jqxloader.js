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
require("../jqwidgets/jqxloader.js");
var core_1 = require("@angular/core");
var jqxLoaderComponent = /** @class */ (function () {
    function jqxLoaderComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoOpen', 'height', 'html', 'isModal', 'imagePosition', 'rtl', 'text', 'textPosition', 'theme', 'width'];
        this.elementRef = containerElement;
    }
    jqxLoaderComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxLoaderComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxLoader(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxLoader(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxLoader(this.properties[i])) {
                        this.host.jqxLoader(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxLoaderComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxLoaderComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxLoaderComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxLoaderComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxLoaderComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxLoader', options);
    };
    jqxLoaderComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxLoaderComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxLoaderComponent.prototype.setOptions = function (options) {
        this.host.jqxLoader('setOptions', options);
    };
    // jqxLoaderComponent properties
    jqxLoaderComponent.prototype.autoOpen = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('autoOpen', arg);
        }
        else {
            return this.host.jqxLoader('autoOpen');
        }
    };
    jqxLoaderComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('height', arg);
        }
        else {
            return this.host.jqxLoader('height');
        }
    };
    jqxLoaderComponent.prototype.html = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('html', arg);
        }
        else {
            return this.host.jqxLoader('html');
        }
    };
    jqxLoaderComponent.prototype.isModal = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('isModal', arg);
        }
        else {
            return this.host.jqxLoader('isModal');
        }
    };
    jqxLoaderComponent.prototype.imagePosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('imagePosition', arg);
        }
        else {
            return this.host.jqxLoader('imagePosition');
        }
    };
    jqxLoaderComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('rtl', arg);
        }
        else {
            return this.host.jqxLoader('rtl');
        }
    };
    jqxLoaderComponent.prototype.text = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('text', arg);
        }
        else {
            return this.host.jqxLoader('text');
        }
    };
    jqxLoaderComponent.prototype.textPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('textPosition', arg);
        }
        else {
            return this.host.jqxLoader('textPosition');
        }
    };
    jqxLoaderComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('theme', arg);
        }
        else {
            return this.host.jqxLoader('theme');
        }
    };
    jqxLoaderComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLoader('width', arg);
        }
        else {
            return this.host.jqxLoader('width');
        }
    };
    // jqxLoaderComponent functions
    jqxLoaderComponent.prototype.close = function () {
        this.host.jqxLoader('close');
    };
    jqxLoaderComponent.prototype.open = function (left, top) {
        this.host.jqxLoader('open', left, top);
    };
    jqxLoaderComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('autoOpen')
    ], jqxLoaderComponent.prototype, "attrAutoOpen", void 0);
    __decorate([
        core_1.Input('html')
    ], jqxLoaderComponent.prototype, "attrHtml", void 0);
    __decorate([
        core_1.Input('isModal')
    ], jqxLoaderComponent.prototype, "attrIsModal", void 0);
    __decorate([
        core_1.Input('imagePosition')
    ], jqxLoaderComponent.prototype, "attrImagePosition", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxLoaderComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('text')
    ], jqxLoaderComponent.prototype, "attrText", void 0);
    __decorate([
        core_1.Input('textPosition')
    ], jqxLoaderComponent.prototype, "attrTextPosition", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxLoaderComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxLoaderComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxLoaderComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxLoaderComponent.prototype, "autoCreate", void 0);
    jqxLoaderComponent = __decorate([
        core_1.Component({
            selector: 'jqxLoader',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxLoaderComponent);
    return jqxLoaderComponent;
}()); //jqxLoaderComponent
exports.jqxLoaderComponent = jqxLoaderComponent;
