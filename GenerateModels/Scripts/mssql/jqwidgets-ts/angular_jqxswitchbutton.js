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
require("../jqwidgets/jqxswitchbutton.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxSwitchButtonComponent; }),
    multi: true
};
var jqxSwitchButtonComponent = /** @class */ (function () {
    function jqxSwitchButtonComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['checked', 'disabled', 'height', 'orientation', 'onLabel', 'offLabel', 'thumbSize', 'rtl', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxSwitchButtonComponent events
        this.onChecked = new core_1.EventEmitter();
        this.onChange = new core_1.EventEmitter();
        this.onUnchecked = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxSwitchButtonComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxSwitchButtonComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxSwitchButton(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxSwitchButton(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxSwitchButton(this.properties[i])) {
                        this.host.jqxSwitchButton(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxSwitchButtonComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxSwitchButtonComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxSwitchButtonComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxSwitchButtonComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxSwitchButtonComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxSwitchButton', options);
    };
    jqxSwitchButtonComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxSwitchButtonComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxSwitchButtonComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxSwitchButton('val', '');
        }
    };
    jqxSwitchButtonComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxSwitchButtonComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxSwitchButtonComponent.prototype.setOptions = function (options) {
        this.host.jqxSwitchButton('setOptions', options);
    };
    // jqxSwitchButtonComponent properties
    jqxSwitchButtonComponent.prototype.checked = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('checked', arg);
        }
        else {
            return this.host.jqxSwitchButton('checked');
        }
    };
    jqxSwitchButtonComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('disabled', arg);
        }
        else {
            return this.host.jqxSwitchButton('disabled');
        }
    };
    jqxSwitchButtonComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('height', arg);
        }
        else {
            return this.host.jqxSwitchButton('height');
        }
    };
    jqxSwitchButtonComponent.prototype.orientation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('orientation', arg);
        }
        else {
            return this.host.jqxSwitchButton('orientation');
        }
    };
    jqxSwitchButtonComponent.prototype.onLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('onLabel', arg);
        }
        else {
            return this.host.jqxSwitchButton('onLabel');
        }
    };
    jqxSwitchButtonComponent.prototype.offLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('offLabel', arg);
        }
        else {
            return this.host.jqxSwitchButton('offLabel');
        }
    };
    jqxSwitchButtonComponent.prototype.thumbSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('thumbSize', arg);
        }
        else {
            return this.host.jqxSwitchButton('thumbSize');
        }
    };
    jqxSwitchButtonComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('rtl', arg);
        }
        else {
            return this.host.jqxSwitchButton('rtl');
        }
    };
    jqxSwitchButtonComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSwitchButton('width', arg);
        }
        else {
            return this.host.jqxSwitchButton('width');
        }
    };
    // jqxSwitchButtonComponent functions
    jqxSwitchButtonComponent.prototype.check = function () {
        this.host.jqxSwitchButton('check');
    };
    jqxSwitchButtonComponent.prototype.disable = function () {
        this.host.jqxSwitchButton('disable');
    };
    jqxSwitchButtonComponent.prototype.enable = function () {
        this.host.jqxSwitchButton('enable');
    };
    jqxSwitchButtonComponent.prototype.toggle = function () {
        this.host.jqxSwitchButton('toggle');
    };
    jqxSwitchButtonComponent.prototype.uncheck = function () {
        this.host.jqxSwitchButton('uncheck');
    };
    jqxSwitchButtonComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxSwitchButton('val', value);
        }
        else {
            return this.host.jqxSwitchButton('val');
        }
    };
    ;
    jqxSwitchButtonComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('checked', function (eventData) { _this.onChecked.emit(eventData); });
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); _this.onChangeCallback(_this.host.val()); });
        this.host.on('unchecked', function (eventData) { _this.onUnchecked.emit(eventData); });
    };
    __decorate([
        core_1.Input('checked')
    ], jqxSwitchButtonComponent.prototype, "attrChecked", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxSwitchButtonComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('orientation')
    ], jqxSwitchButtonComponent.prototype, "attrOrientation", void 0);
    __decorate([
        core_1.Input('onLabel')
    ], jqxSwitchButtonComponent.prototype, "attrOnLabel", void 0);
    __decorate([
        core_1.Input('offLabel')
    ], jqxSwitchButtonComponent.prototype, "attrOffLabel", void 0);
    __decorate([
        core_1.Input('thumbSize')
    ], jqxSwitchButtonComponent.prototype, "attrThumbSize", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxSwitchButtonComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxSwitchButtonComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxSwitchButtonComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxSwitchButtonComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSwitchButtonComponent.prototype, "onChecked", void 0);
    __decorate([
        core_1.Output()
    ], jqxSwitchButtonComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxSwitchButtonComponent.prototype, "onUnchecked", void 0);
    jqxSwitchButtonComponent = __decorate([
        core_1.Component({
            selector: 'jqxSwitchButton',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxSwitchButtonComponent);
    return jqxSwitchButtonComponent;
}()); //jqxSwitchButtonComponent
exports.jqxSwitchButtonComponent = jqxSwitchButtonComponent;
