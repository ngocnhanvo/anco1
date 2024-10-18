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
require("../jqwidgets/jqxradiobutton.js");
require("../jqwidgets/jqxradiobuttongroup.js");
var core_1 = require("@angular/core");
var jqxRadioButtonGroupComponent = /** @class */ (function () {
    function jqxRadioButtonGroupComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['change', 'disabled', 'items', 'value', 'layout', 'labelPosition', 'rtl', 'theme'];
        this.elementRef = containerElement;
    }
    jqxRadioButtonGroupComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxRadioButtonGroupComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxRadioButtonGroup(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxRadioButtonGroup(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxRadioButtonGroup(this.properties[i])) {
                        this.host.jqxRadioButtonGroup(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxRadioButtonGroupComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxRadioButtonGroupComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxRadioButtonGroupComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxRadioButtonGroupComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxRadioButtonGroupComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxRadioButtonGroup', options);
    };
    jqxRadioButtonGroupComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxRadioButtonGroupComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxRadioButtonGroupComponent.prototype.setOptions = function (options) {
        this.host.jqxRadioButtonGroup('setOptions', options);
    };
    // jqxRadioButtonGroupComponent properties
    jqxRadioButtonGroupComponent.prototype.change = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('change', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('change');
        }
    };
    jqxRadioButtonGroupComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('disabled', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('disabled');
        }
    };
    jqxRadioButtonGroupComponent.prototype.items = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('items', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('items');
        }
    };
    jqxRadioButtonGroupComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('value', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('value');
        }
    };
    jqxRadioButtonGroupComponent.prototype.layout = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('layout', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('layout');
        }
    };
    jqxRadioButtonGroupComponent.prototype.labelPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('labelPosition', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('labelPosition');
        }
    };
    jqxRadioButtonGroupComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('rtl', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('rtl');
        }
    };
    jqxRadioButtonGroupComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRadioButtonGroup('theme', arg);
        }
        else {
            return this.host.jqxRadioButtonGroup('theme');
        }
    };
    // jqxRadioButtonGroupComponent functions
    jqxRadioButtonGroupComponent.prototype.getValue = function () {
        return this.host.jqxRadioButtonGroup('getValue');
    };
    jqxRadioButtonGroupComponent.prototype.getValueAt = function (index) {
        return this.host.jqxRadioButtonGroup('getValueAt', index);
    };
    jqxRadioButtonGroupComponent.prototype.enableAt = function (index) {
        this.host.jqxRadioButtonGroup('enableAt', index);
    };
    jqxRadioButtonGroupComponent.prototype.disableAt = function (index) {
        this.host.jqxRadioButtonGroup('disableAt', index);
    };
    jqxRadioButtonGroupComponent.prototype.checkAt = function (index) {
        this.host.jqxRadioButtonGroup('checkAt', index);
    };
    jqxRadioButtonGroupComponent.prototype.uncheckAt = function (index) {
        this.host.jqxRadioButtonGroup('uncheckAt', index);
    };
    jqxRadioButtonGroupComponent.prototype.uncheckAll = function () {
        this.host.jqxRadioButtonGroup('uncheckAll');
    };
    jqxRadioButtonGroupComponent.prototype.checkValue = function (value) {
        this.host.jqxRadioButtonGroup('checkValue', value);
    };
    jqxRadioButtonGroupComponent.prototype.uncheckValue = function (value) {
        this.host.jqxRadioButtonGroup('uncheckValue', value);
    };
    jqxRadioButtonGroupComponent.prototype.disable = function () {
        this.host.jqxRadioButtonGroup('disable');
    };
    jqxRadioButtonGroupComponent.prototype.destroy = function () {
        this.host.jqxRadioButtonGroup('destroy');
    };
    jqxRadioButtonGroupComponent.prototype.enable = function () {
        this.host.jqxRadioButtonGroup('enable');
    };
    jqxRadioButtonGroupComponent.prototype.render = function () {
        this.host.jqxRadioButtonGroup('render');
    };
    jqxRadioButtonGroupComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxRadioButtonGroup('val', value);
        }
        else {
            return this.host.jqxRadioButtonGroup('val');
        }
    };
    ;
    // jqxRadioButtonGroupComponent events
    jqxRadioButtonGroupComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('change')
    ], jqxRadioButtonGroupComponent.prototype, "attrChange", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxRadioButtonGroupComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('items')
    ], jqxRadioButtonGroupComponent.prototype, "attrItems", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxRadioButtonGroupComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('layout')
    ], jqxRadioButtonGroupComponent.prototype, "attrLayout", void 0);
    __decorate([
        core_1.Input('labelPosition')
    ], jqxRadioButtonGroupComponent.prototype, "attrLabelPosition", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxRadioButtonGroupComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxRadioButtonGroupComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxRadioButtonGroupComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxRadioButtonGroupComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxRadioButtonGroupComponent.prototype, "autoCreate", void 0);
    jqxRadioButtonGroupComponent = __decorate([
        core_1.Component({
            selector: 'jqxRadioButtonGroup',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxRadioButtonGroupComponent);
    return jqxRadioButtonGroupComponent;
}()); //jqxRadioButtonGroupComponent
exports.jqxRadioButtonGroupComponent = jqxRadioButtonGroupComponent;
