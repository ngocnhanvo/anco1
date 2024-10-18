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
var jqxBarcodeComponent = /** @class */ (function () {
    function jqxBarcodeComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['backgroundColor', 'displayLabel', 'labelColor', 'labelFont', 'labelFontSize', 'labelMarginBottom', 'labelMarginTop', 'labelPosition', 'lineColor', 'lineHeight', 'lineWidth', 'renderAs', 'type', 'value'];
        // jqxBarcodeComponent events
        this.onInvalid = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxBarcodeComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxBarcodeComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxBarcode(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxBarcode(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxBarcode(this.properties[i])) {
                        this.host.jqxBarcode(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxBarcodeComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxBarcodeComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxBarcodeComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxBarcodeComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxBarcodeComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxBarcode', options);
    };
    jqxBarcodeComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxBarcodeComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxBarcodeComponent.prototype.setOptions = function (options) {
        this.host.jqxBarcode('setOptions', options);
    };
    // jqxBarcodeComponent properties
    jqxBarcodeComponent.prototype.backgroundColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('backgroundColor', arg);
        }
        else {
            return this.host.jqxBarcode('backgroundColor');
        }
    };
    jqxBarcodeComponent.prototype.displayLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('displayLabel', arg);
        }
        else {
            return this.host.jqxBarcode('displayLabel');
        }
    };
    jqxBarcodeComponent.prototype.labelColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('labelColor', arg);
        }
        else {
            return this.host.jqxBarcode('labelColor');
        }
    };
    jqxBarcodeComponent.prototype.labelFont = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('labelFont', arg);
        }
        else {
            return this.host.jqxBarcode('labelFont');
        }
    };
    jqxBarcodeComponent.prototype.labelFontSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('labelFontSize', arg);
        }
        else {
            return this.host.jqxBarcode('labelFontSize');
        }
    };
    jqxBarcodeComponent.prototype.labelMarginBottom = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('labelMarginBottom', arg);
        }
        else {
            return this.host.jqxBarcode('labelMarginBottom');
        }
    };
    jqxBarcodeComponent.prototype.labelMarginTop = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('labelMarginTop', arg);
        }
        else {
            return this.host.jqxBarcode('labelMarginTop');
        }
    };
    jqxBarcodeComponent.prototype.labelPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('labelPosition', arg);
        }
        else {
            return this.host.jqxBarcode('labelPosition');
        }
    };
    jqxBarcodeComponent.prototype.lineColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('lineColor', arg);
        }
        else {
            return this.host.jqxBarcode('lineColor');
        }
    };
    jqxBarcodeComponent.prototype.lineHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('lineHeight', arg);
        }
        else {
            return this.host.jqxBarcode('lineHeight');
        }
    };
    jqxBarcodeComponent.prototype.lineWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('lineWidth', arg);
        }
        else {
            return this.host.jqxBarcode('lineWidth');
        }
    };
    jqxBarcodeComponent.prototype.renderAs = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('renderAs', arg);
        }
        else {
            return this.host.jqxBarcode('renderAs');
        }
    };
    jqxBarcodeComponent.prototype.type = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('type', arg);
        }
        else {
            return this.host.jqxBarcode('type');
        }
    };
    jqxBarcodeComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxBarcode('value', arg);
        }
        else {
            return this.host.jqxBarcode('value');
        }
    };
    // jqxBarcodeComponent functions
    jqxBarcodeComponent.prototype.export = function (format, fileName) {
        return this.host.jqxBarcode('export', format, fileName);
    };
    jqxBarcodeComponent.prototype.getDataURL = function (format) {
        return this.host.jqxBarcode('getDataURL', format);
    };
    jqxBarcodeComponent.prototype.getDataURLAsync = function (format) {
        return this.host.jqxBarcode('getDataURLAsync', format);
    };
    jqxBarcodeComponent.prototype.isValid = function () {
        return this.host.jqxBarcode('isValid');
    };
    jqxBarcodeComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('invalid', function (eventData) { _this.onInvalid.emit(eventData); });
    };
    __decorate([
        core_1.Input('backgroundColor')
    ], jqxBarcodeComponent.prototype, "attrBackgroundColor", void 0);
    __decorate([
        core_1.Input('displayLabel')
    ], jqxBarcodeComponent.prototype, "attrDisplayLabel", void 0);
    __decorate([
        core_1.Input('labelColor')
    ], jqxBarcodeComponent.prototype, "attrLabelColor", void 0);
    __decorate([
        core_1.Input('labelFont')
    ], jqxBarcodeComponent.prototype, "attrLabelFont", void 0);
    __decorate([
        core_1.Input('labelFontSize')
    ], jqxBarcodeComponent.prototype, "attrLabelFontSize", void 0);
    __decorate([
        core_1.Input('labelMarginBottom')
    ], jqxBarcodeComponent.prototype, "attrLabelMarginBottom", void 0);
    __decorate([
        core_1.Input('labelMarginTop')
    ], jqxBarcodeComponent.prototype, "attrLabelMarginTop", void 0);
    __decorate([
        core_1.Input('labelPosition')
    ], jqxBarcodeComponent.prototype, "attrLabelPosition", void 0);
    __decorate([
        core_1.Input('lineColor')
    ], jqxBarcodeComponent.prototype, "attrLineColor", void 0);
    __decorate([
        core_1.Input('lineHeight')
    ], jqxBarcodeComponent.prototype, "attrLineHeight", void 0);
    __decorate([
        core_1.Input('lineWidth')
    ], jqxBarcodeComponent.prototype, "attrLineWidth", void 0);
    __decorate([
        core_1.Input('renderAs')
    ], jqxBarcodeComponent.prototype, "attrRenderAs", void 0);
    __decorate([
        core_1.Input('type')
    ], jqxBarcodeComponent.prototype, "attrType", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxBarcodeComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxBarcodeComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxBarcodeComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxBarcodeComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxBarcodeComponent.prototype, "onInvalid", void 0);
    jqxBarcodeComponent = __decorate([
        core_1.Component({
            selector: 'jqxBarcode',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxBarcodeComponent);
    return jqxBarcodeComponent;
}()); //jqxBarcodeComponent
exports.jqxBarcodeComponent = jqxBarcodeComponent;
