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
require("../jqwidgets/jqxcheckbox.js");
require("../jqwidgets/jqxcheckboxgroup.js");
var core_1 = require("@angular/core");
var jqxCheckBoxGroupComponent = /** @class */ (function () {
    function jqxCheckBoxGroupComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['change', 'disabled', 'items', 'value', 'layout', 'labelPosition', 'rtl', 'theme'];
        this.elementRef = containerElement;
    }
    jqxCheckBoxGroupComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxCheckBoxGroupComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxCheckBoxGroup(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxCheckBoxGroup(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxCheckBoxGroup(this.properties[i])) {
                        this.host.jqxCheckBoxGroup(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxCheckBoxGroupComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxCheckBoxGroupComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxCheckBoxGroupComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxCheckBoxGroupComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxCheckBoxGroupComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxCheckBoxGroup', options);
    };
    jqxCheckBoxGroupComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxCheckBoxGroupComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxCheckBoxGroupComponent.prototype.setOptions = function (options) {
        this.host.jqxCheckBoxGroup('setOptions', options);
    };
    // jqxCheckBoxGroupComponent properties
    jqxCheckBoxGroupComponent.prototype.change = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('change', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('change');
        }
    };
    jqxCheckBoxGroupComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('disabled', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('disabled');
        }
    };
    jqxCheckBoxGroupComponent.prototype.items = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('items', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('items');
        }
    };
    jqxCheckBoxGroupComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('value', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('value');
        }
    };
    jqxCheckBoxGroupComponent.prototype.layout = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('layout', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('layout');
        }
    };
    jqxCheckBoxGroupComponent.prototype.labelPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('labelPosition', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('labelPosition');
        }
    };
    jqxCheckBoxGroupComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('rtl', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('rtl');
        }
    };
    jqxCheckBoxGroupComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBoxGroup('theme', arg);
        }
        else {
            return this.host.jqxCheckBoxGroup('theme');
        }
    };
    // jqxCheckBoxGroupComponent functions
    jqxCheckBoxGroupComponent.prototype.getValue = function () {
        return this.host.jqxCheckBoxGroup('getValue');
    };
    jqxCheckBoxGroupComponent.prototype.getValueAt = function (index) {
        return this.host.jqxCheckBoxGroup('getValueAt', index);
    };
    jqxCheckBoxGroupComponent.prototype.enableAt = function (index) {
        this.host.jqxCheckBoxGroup('enableAt', index);
    };
    jqxCheckBoxGroupComponent.prototype.disableAt = function (index) {
        this.host.jqxCheckBoxGroup('disableAt', index);
    };
    jqxCheckBoxGroupComponent.prototype.checkAt = function (index) {
        this.host.jqxCheckBoxGroup('checkAt', index);
    };
    jqxCheckBoxGroupComponent.prototype.uncheckAt = function (index) {
        this.host.jqxCheckBoxGroup('uncheckAt', index);
    };
    jqxCheckBoxGroupComponent.prototype.uncheckAll = function () {
        this.host.jqxCheckBoxGroup('uncheckAll');
    };
    jqxCheckBoxGroupComponent.prototype.checkAll = function () {
        this.host.jqxCheckBoxGroup('checkAll');
    };
    jqxCheckBoxGroupComponent.prototype.checkValue = function (value) {
        this.host.jqxCheckBoxGroup('checkValue', value);
    };
    jqxCheckBoxGroupComponent.prototype.uncheckValue = function (value) {
        this.host.jqxCheckBoxGroup('uncheckValue', value);
    };
    jqxCheckBoxGroupComponent.prototype.disable = function () {
        this.host.jqxCheckBoxGroup('disable');
    };
    jqxCheckBoxGroupComponent.prototype.destroy = function () {
        this.host.jqxCheckBoxGroup('destroy');
    };
    jqxCheckBoxGroupComponent.prototype.enable = function () {
        this.host.jqxCheckBoxGroup('enable');
    };
    jqxCheckBoxGroupComponent.prototype.render = function () {
        this.host.jqxCheckBoxGroup('render');
    };
    jqxCheckBoxGroupComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxCheckBoxGroup('val', value);
        }
        else {
            return this.host.jqxCheckBoxGroup('val');
        }
    };
    ;
    // jqxCheckBoxGroupComponent events
    jqxCheckBoxGroupComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('change')
    ], jqxCheckBoxGroupComponent.prototype, "attrChange", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxCheckBoxGroupComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('items')
    ], jqxCheckBoxGroupComponent.prototype, "attrItems", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxCheckBoxGroupComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('layout')
    ], jqxCheckBoxGroupComponent.prototype, "attrLayout", void 0);
    __decorate([
        core_1.Input('labelPosition')
    ], jqxCheckBoxGroupComponent.prototype, "attrLabelPosition", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxCheckBoxGroupComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxCheckBoxGroupComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxCheckBoxGroupComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxCheckBoxGroupComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxCheckBoxGroupComponent.prototype, "autoCreate", void 0);
    jqxCheckBoxGroupComponent = __decorate([
        core_1.Component({
            selector: 'jqxCheckBoxGroup',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxCheckBoxGroupComponent);
    return jqxCheckBoxGroupComponent;
}()); //jqxCheckBoxGroupComponent
exports.jqxCheckBoxGroupComponent = jqxCheckBoxGroupComponent;
