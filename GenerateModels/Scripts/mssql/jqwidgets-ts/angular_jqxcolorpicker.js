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
require("../jqwidgets/jqxdropdownbutton.js");
require("../jqwidgets/jqxradiobutton.js");
require("../jqwidgets/jqxcolorpicker.js");
var core_1 = require("@angular/core");
var jqxColorPickerComponent = /** @class */ (function () {
    function jqxColorPickerComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['color', 'colorMode', 'disabled', 'height', 'showTransparent', 'width'];
        // jqxColorPickerComponent events
        this.onColorchange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxColorPickerComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxColorPickerComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxColorPicker(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxColorPicker(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxColorPicker(this.properties[i])) {
                        this.host.jqxColorPicker(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxColorPickerComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxColorPickerComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxColorPickerComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxColorPickerComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxColorPickerComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxColorPicker', options);
    };
    jqxColorPickerComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxColorPickerComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxColorPickerComponent.prototype.setOptions = function (options) {
        this.host.jqxColorPicker('setOptions', options);
    };
    // jqxColorPickerComponent properties
    jqxColorPickerComponent.prototype.color = function (arg) {
        if (arg !== undefined) {
            this.host.jqxColorPicker('color', arg);
        }
        else {
            return this.host.jqxColorPicker('color');
        }
    };
    jqxColorPickerComponent.prototype.colorMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxColorPicker('colorMode', arg);
        }
        else {
            return this.host.jqxColorPicker('colorMode');
        }
    };
    jqxColorPickerComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxColorPicker('disabled', arg);
        }
        else {
            return this.host.jqxColorPicker('disabled');
        }
    };
    jqxColorPickerComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxColorPicker('height', arg);
        }
        else {
            return this.host.jqxColorPicker('height');
        }
    };
    jqxColorPickerComponent.prototype.showTransparent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxColorPicker('showTransparent', arg);
        }
        else {
            return this.host.jqxColorPicker('showTransparent');
        }
    };
    jqxColorPickerComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxColorPicker('width', arg);
        }
        else {
            return this.host.jqxColorPicker('width');
        }
    };
    // jqxColorPickerComponent functions
    jqxColorPickerComponent.prototype.getColor = function () {
        return this.host.jqxColorPicker('getColor');
    };
    jqxColorPickerComponent.prototype.setColor = function (color) {
        this.host.jqxColorPicker('setColor', color);
    };
    jqxColorPickerComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('colorchange', function (eventData) { _this.onColorchange.emit(eventData); });
    };
    __decorate([
        core_1.Input('color')
    ], jqxColorPickerComponent.prototype, "attrColor", void 0);
    __decorate([
        core_1.Input('colorMode')
    ], jqxColorPickerComponent.prototype, "attrColorMode", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxColorPickerComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('showTransparent')
    ], jqxColorPickerComponent.prototype, "attrShowTransparent", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxColorPickerComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxColorPickerComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxColorPickerComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxColorPickerComponent.prototype, "onColorchange", void 0);
    jqxColorPickerComponent = __decorate([
        core_1.Component({
            selector: 'jqxColorPicker',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxColorPickerComponent);
    return jqxColorPickerComponent;
}()); //jqxColorPickerComponent
exports.jqxColorPickerComponent = jqxColorPickerComponent;
