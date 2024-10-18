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
var core_1 = require("@angular/core");
var jqxQRcodeComponent = /** @class */ (function () {
    function jqxQRcodeComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['backgroundColor', 'displayLabel', 'embedImage', 'errorLevel', 'imageHeight', 'imageWidth', 'labelColor', 'labelFont', 'labelFontSize', 'labelMarginBottom', 'labelMarginTop', 'labelPosition', 'lineColor', 'squareWidth', 'renderAs', 'value'];
        // jqxQRcodeComponent events
        this.onInvalid = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxQRcodeComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxQRcodeComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxQRcode(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxQRcode(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxQRcode(this.properties[i])) {
                        this.host.jqxQRcode(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxQRcodeComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxQRcodeComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxQRcodeComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxQRcodeComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxQRcodeComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxQRcode', options);
    };
    jqxQRcodeComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxQRcodeComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxQRcodeComponent.prototype.setOptions = function (options) {
        this.host.jqxQRcode('setOptions', options);
    };
    // jqxQRcodeComponent properties
    jqxQRcodeComponent.prototype.backgroundColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('backgroundColor', arg);
        }
        else {
            return this.host.jqxQRcode('backgroundColor');
        }
    };
    jqxQRcodeComponent.prototype.displayLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('displayLabel', arg);
        }
        else {
            return this.host.jqxQRcode('displayLabel');
        }
    };
    jqxQRcodeComponent.prototype.embedImage = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('embedImage', arg);
        }
        else {
            return this.host.jqxQRcode('embedImage');
        }
    };
    jqxQRcodeComponent.prototype.errorLevel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('errorLevel', arg);
        }
        else {
            return this.host.jqxQRcode('errorLevel');
        }
    };
    jqxQRcodeComponent.prototype.imageHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('imageHeight', arg);
        }
        else {
            return this.host.jqxQRcode('imageHeight');
        }
    };
    jqxQRcodeComponent.prototype.imageWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('imageWidth', arg);
        }
        else {
            return this.host.jqxQRcode('imageWidth');
        }
    };
    jqxQRcodeComponent.prototype.labelColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('labelColor', arg);
        }
        else {
            return this.host.jqxQRcode('labelColor');
        }
    };
    jqxQRcodeComponent.prototype.labelFont = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('labelFont', arg);
        }
        else {
            return this.host.jqxQRcode('labelFont');
        }
    };
    jqxQRcodeComponent.prototype.labelFontSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('labelFontSize', arg);
        }
        else {
            return this.host.jqxQRcode('labelFontSize');
        }
    };
    jqxQRcodeComponent.prototype.labelMarginBottom = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('labelMarginBottom', arg);
        }
        else {
            return this.host.jqxQRcode('labelMarginBottom');
        }
    };
    jqxQRcodeComponent.prototype.labelMarginTop = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('labelMarginTop', arg);
        }
        else {
            return this.host.jqxQRcode('labelMarginTop');
        }
    };
    jqxQRcodeComponent.prototype.labelPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('labelPosition', arg);
        }
        else {
            return this.host.jqxQRcode('labelPosition');
        }
    };
    jqxQRcodeComponent.prototype.lineColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('lineColor', arg);
        }
        else {
            return this.host.jqxQRcode('lineColor');
        }
    };
    jqxQRcodeComponent.prototype.squareWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('squareWidth', arg);
        }
        else {
            return this.host.jqxQRcode('squareWidth');
        }
    };
    jqxQRcodeComponent.prototype.renderAs = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('renderAs', arg);
        }
        else {
            return this.host.jqxQRcode('renderAs');
        }
    };
    jqxQRcodeComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxQRcode('value', arg);
        }
        else {
            return this.host.jqxQRcode('value');
        }
    };
    // jqxQRcodeComponent functions
    jqxQRcodeComponent.prototype.export = function (format, fileName) {
        return this.host.jqxQRcode('export', format, fileName);
    };
    jqxQRcodeComponent.prototype.getDataURL = function (format) {
        return this.host.jqxQRcode('getDataURL', format);
    };
    jqxQRcodeComponent.prototype.getDataURLAsync = function (format) {
        return this.host.jqxQRcode('getDataURLAsync', format);
    };
    jqxQRcodeComponent.prototype.isValid = function () {
        return this.host.jqxQRcode('isValid');
    };
    jqxQRcodeComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('invalid', function (eventData) { _this.onInvalid.emit(eventData); });
    };
    __decorate([
        core_1.Input('backgroundColor')
    ], jqxQRcodeComponent.prototype, "attrBackgroundColor", void 0);
    __decorate([
        core_1.Input('displayLabel')
    ], jqxQRcodeComponent.prototype, "attrDisplayLabel", void 0);
    __decorate([
        core_1.Input('embedImage')
    ], jqxQRcodeComponent.prototype, "attrEmbedImage", void 0);
    __decorate([
        core_1.Input('errorLevel')
    ], jqxQRcodeComponent.prototype, "attrErrorLevel", void 0);
    __decorate([
        core_1.Input('imageHeight')
    ], jqxQRcodeComponent.prototype, "attrImageHeight", void 0);
    __decorate([
        core_1.Input('imageWidth')
    ], jqxQRcodeComponent.prototype, "attrImageWidth", void 0);
    __decorate([
        core_1.Input('labelColor')
    ], jqxQRcodeComponent.prototype, "attrLabelColor", void 0);
    __decorate([
        core_1.Input('labelFont')
    ], jqxQRcodeComponent.prototype, "attrLabelFont", void 0);
    __decorate([
        core_1.Input('labelFontSize')
    ], jqxQRcodeComponent.prototype, "attrLabelFontSize", void 0);
    __decorate([
        core_1.Input('labelMarginBottom')
    ], jqxQRcodeComponent.prototype, "attrLabelMarginBottom", void 0);
    __decorate([
        core_1.Input('labelMarginTop')
    ], jqxQRcodeComponent.prototype, "attrLabelMarginTop", void 0);
    __decorate([
        core_1.Input('labelPosition')
    ], jqxQRcodeComponent.prototype, "attrLabelPosition", void 0);
    __decorate([
        core_1.Input('lineColor')
    ], jqxQRcodeComponent.prototype, "attrLineColor", void 0);
    __decorate([
        core_1.Input('squareWidth')
    ], jqxQRcodeComponent.prototype, "attrSquareWidth", void 0);
    __decorate([
        core_1.Input('renderAs')
    ], jqxQRcodeComponent.prototype, "attrRenderAs", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxQRcodeComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxQRcodeComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxQRcodeComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxQRcodeComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxQRcodeComponent.prototype, "onInvalid", void 0);
    jqxQRcodeComponent = __decorate([
        core_1.Component({
            selector: 'jqxQRcode',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxQRcodeComponent);
    return jqxQRcodeComponent;
}()); //jqxQRcodeComponent
exports.jqxQRcodeComponent = jqxQRcodeComponent;
