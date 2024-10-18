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
require("../jqwidgets/jqxmaskedinput.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxMaskedInputComponent; }),
    multi: true
};
var jqxMaskedInputComponent = /** @class */ (function () {
    function jqxMaskedInputComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'mask', 'promptChar', 'readOnly', 'rtl', 'theme', 'textAlign', 'value', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxMaskedInputComponent events
        this.onChange = new core_1.EventEmitter();
        this.onValueChanged = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxMaskedInputComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxMaskedInputComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxMaskedInput(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxMaskedInput(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxMaskedInput(this.properties[i])) {
                        this.host.jqxMaskedInput(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxMaskedInputComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxMaskedInputComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxMaskedInputComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxMaskedInputComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxMaskedInputComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxMaskedInput', options);
    };
    jqxMaskedInputComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxMaskedInputComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxMaskedInputComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.host.jqxMaskedInput('val', value);
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxMaskedInput('val', '');
        }
    };
    jqxMaskedInputComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxMaskedInputComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxMaskedInputComponent.prototype.setOptions = function (options) {
        this.host.jqxMaskedInput('setOptions', options);
    };
    // jqxMaskedInputComponent properties
    jqxMaskedInputComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('disabled', arg);
        }
        else {
            return this.host.jqxMaskedInput('disabled');
        }
    };
    jqxMaskedInputComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('height', arg);
        }
        else {
            return this.host.jqxMaskedInput('height');
        }
    };
    jqxMaskedInputComponent.prototype.mask = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('mask', arg);
        }
        else {
            return this.host.jqxMaskedInput('mask');
        }
    };
    jqxMaskedInputComponent.prototype.promptChar = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('promptChar', arg);
        }
        else {
            return this.host.jqxMaskedInput('promptChar');
        }
    };
    jqxMaskedInputComponent.prototype.readOnly = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('readOnly', arg);
        }
        else {
            return this.host.jqxMaskedInput('readOnly');
        }
    };
    jqxMaskedInputComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('rtl', arg);
        }
        else {
            return this.host.jqxMaskedInput('rtl');
        }
    };
    jqxMaskedInputComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('theme', arg);
        }
        else {
            return this.host.jqxMaskedInput('theme');
        }
    };
    jqxMaskedInputComponent.prototype.textAlign = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('textAlign', arg);
        }
        else {
            return this.host.jqxMaskedInput('textAlign');
        }
    };
    jqxMaskedInputComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('value', arg);
        }
        else {
            return this.host.jqxMaskedInput('value');
        }
    };
    jqxMaskedInputComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMaskedInput('width', arg);
        }
        else {
            return this.host.jqxMaskedInput('width');
        }
    };
    // jqxMaskedInputComponent functions
    jqxMaskedInputComponent.prototype.clear = function () {
        this.host.jqxMaskedInput('clear');
    };
    jqxMaskedInputComponent.prototype.destroy = function () {
        this.host.jqxMaskedInput('destroy');
    };
    jqxMaskedInputComponent.prototype.focus = function () {
        this.host.jqxMaskedInput('focus');
    };
    jqxMaskedInputComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxMaskedInput('val', value);
        }
        else {
            return this.host.jqxMaskedInput('val');
        }
    };
    ;
    jqxMaskedInputComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.parent().on('change', function (eventData) { _this.onChange.emit(eventData); _this.onChangeCallback(_this.host.val()); });
        this.host.parent().on('valueChanged', function (eventData) { _this.onValueChanged.emit(eventData); _this.onChangeCallback(_this.host.val()); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxMaskedInputComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('mask')
    ], jqxMaskedInputComponent.prototype, "attrMask", void 0);
    __decorate([
        core_1.Input('promptChar')
    ], jqxMaskedInputComponent.prototype, "attrPromptChar", void 0);
    __decorate([
        core_1.Input('readOnly')
    ], jqxMaskedInputComponent.prototype, "attrReadOnly", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxMaskedInputComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxMaskedInputComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('textAlign')
    ], jqxMaskedInputComponent.prototype, "attrTextAlign", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxMaskedInputComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxMaskedInputComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxMaskedInputComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxMaskedInputComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxMaskedInputComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxMaskedInputComponent.prototype, "onValueChanged", void 0);
    jqxMaskedInputComponent = __decorate([
        core_1.Component({
            selector: 'jqxMaskedInput',
            template: '<input>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxMaskedInputComponent);
    return jqxMaskedInputComponent;
}()); //jqxMaskedInputComponent
exports.jqxMaskedInputComponent = jqxMaskedInputComponent;
