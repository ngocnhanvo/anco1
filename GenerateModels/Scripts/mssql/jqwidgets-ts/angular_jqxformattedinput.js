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
require("../jqwidgets/jqxformattedinput.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxFormattedInputComponent; }),
    multi: true
};
var jqxFormattedInputComponent = /** @class */ (function () {
    function jqxFormattedInputComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'decimalNotation', 'dropDown', 'dropDownWidth', 'height', 'min', 'max', 'placeHolder', 'popupZIndex', 'roundedCorners', 'rtl', 'radix', 'spinButtons', 'spinButtonsStep', 'template', 'theme', 'upperCase', 'value', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxFormattedInputComponent events
        this.onChange = new core_1.EventEmitter();
        this.onClose = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.onRadixChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxFormattedInputComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxFormattedInputComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxFormattedInput(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxFormattedInput(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxFormattedInput(this.properties[i])) {
                        this.host.jqxFormattedInput(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxFormattedInputComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxFormattedInputComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxFormattedInputComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxFormattedInputComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxFormattedInputComponent.prototype.createComponent = function (options) {
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
        if (this.attrRtl !== true) {
            if (this.attrSpinButtons === false) {
                this.host.children()[1].remove();
            }
            if (this.attrDropDown !== true) {
                this.host.children()[1].remove();
            }
        }
        else if (this.attrRtl === true) {
            this.host.children()[1].remove();
            this.host.children()[1].remove();
            if (this.attrSpinButtons !== false) {
                this.host.prepend('<div></div>');
            }
            if (this.attrDropDown === true) {
                this.host.prepend('<div></div>');
            }
        }
        this.__wireEvents__();
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxFormattedInput', options);
    };
    jqxFormattedInputComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxFormattedInputComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    Object.defineProperty(jqxFormattedInputComponent.prototype, "ngValue", {
        get: function () {
            if (this.widgetObject) {
                var value = this.host.val();
                return value;
            }
            return '';
        },
        set: function (value) {
            if (this.widgetObject) {
                this.onChangeCallback(value);
            }
        },
        enumerable: true,
        configurable: true
    });
    jqxFormattedInputComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.host.jqxFormattedInput('val', value);
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxFormattedInput('val', '');
        }
    };
    jqxFormattedInputComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxFormattedInputComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxFormattedInputComponent.prototype.setOptions = function (options) {
        this.host.jqxFormattedInput('setOptions', options);
    };
    // jqxFormattedInputComponent properties
    jqxFormattedInputComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('disabled', arg);
        }
        else {
            return this.host.jqxFormattedInput('disabled');
        }
    };
    jqxFormattedInputComponent.prototype.decimalNotation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('decimalNotation', arg);
        }
        else {
            return this.host.jqxFormattedInput('decimalNotation');
        }
    };
    jqxFormattedInputComponent.prototype.dropDown = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('dropDown', arg);
        }
        else {
            return this.host.jqxFormattedInput('dropDown');
        }
    };
    jqxFormattedInputComponent.prototype.dropDownWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('dropDownWidth', arg);
        }
        else {
            return this.host.jqxFormattedInput('dropDownWidth');
        }
    };
    jqxFormattedInputComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('height', arg);
        }
        else {
            return this.host.jqxFormattedInput('height');
        }
    };
    jqxFormattedInputComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('min', arg);
        }
        else {
            return this.host.jqxFormattedInput('min');
        }
    };
    jqxFormattedInputComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('max', arg);
        }
        else {
            return this.host.jqxFormattedInput('max');
        }
    };
    jqxFormattedInputComponent.prototype.placeHolder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('placeHolder', arg);
        }
        else {
            return this.host.jqxFormattedInput('placeHolder');
        }
    };
    jqxFormattedInputComponent.prototype.popupZIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('popupZIndex', arg);
        }
        else {
            return this.host.jqxFormattedInput('popupZIndex');
        }
    };
    jqxFormattedInputComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('roundedCorners', arg);
        }
        else {
            return this.host.jqxFormattedInput('roundedCorners');
        }
    };
    jqxFormattedInputComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('rtl', arg);
        }
        else {
            return this.host.jqxFormattedInput('rtl');
        }
    };
    jqxFormattedInputComponent.prototype.radix = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('radix', arg);
        }
        else {
            return this.host.jqxFormattedInput('radix');
        }
    };
    jqxFormattedInputComponent.prototype.spinButtons = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('spinButtons', arg);
        }
        else {
            return this.host.jqxFormattedInput('spinButtons');
        }
    };
    jqxFormattedInputComponent.prototype.spinButtonsStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('spinButtonsStep', arg);
        }
        else {
            return this.host.jqxFormattedInput('spinButtonsStep');
        }
    };
    jqxFormattedInputComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('template', arg);
        }
        else {
            return this.host.jqxFormattedInput('template');
        }
    };
    jqxFormattedInputComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('theme', arg);
        }
        else {
            return this.host.jqxFormattedInput('theme');
        }
    };
    jqxFormattedInputComponent.prototype.upperCase = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('upperCase', arg);
        }
        else {
            return this.host.jqxFormattedInput('upperCase');
        }
    };
    jqxFormattedInputComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('value', arg);
        }
        else {
            return this.host.jqxFormattedInput('value');
        }
    };
    jqxFormattedInputComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFormattedInput('width', arg);
        }
        else {
            return this.host.jqxFormattedInput('width');
        }
    };
    // jqxFormattedInputComponent functions
    jqxFormattedInputComponent.prototype.close = function () {
        this.host.jqxFormattedInput('close');
    };
    jqxFormattedInputComponent.prototype.destroy = function () {
        this.host.jqxFormattedInput('destroy');
    };
    jqxFormattedInputComponent.prototype.focus = function () {
        this.host.jqxFormattedInput('focus');
    };
    jqxFormattedInputComponent.prototype.open = function () {
        this.host.jqxFormattedInput('open');
    };
    jqxFormattedInputComponent.prototype.render = function () {
        this.host.jqxFormattedInput('render');
    };
    jqxFormattedInputComponent.prototype.refresh = function () {
        this.host.jqxFormattedInput('refresh');
    };
    jqxFormattedInputComponent.prototype.selectAll = function () {
        this.host.jqxFormattedInput('selectAll');
    };
    jqxFormattedInputComponent.prototype.selectFirst = function () {
        this.host.jqxFormattedInput('selectFirst');
    };
    jqxFormattedInputComponent.prototype.selectLast = function () {
        this.host.jqxFormattedInput('selectLast');
    };
    jqxFormattedInputComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxFormattedInput('val', value);
        }
        else {
            return this.host.jqxFormattedInput('val');
        }
    };
    ;
    jqxFormattedInputComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.value); });
        this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
        this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        this.host.on('radixChange', function (eventData) { _this.onRadixChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.value); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxFormattedInputComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('decimalNotation')
    ], jqxFormattedInputComponent.prototype, "attrDecimalNotation", void 0);
    __decorate([
        core_1.Input('dropDown')
    ], jqxFormattedInputComponent.prototype, "attrDropDown", void 0);
    __decorate([
        core_1.Input('dropDownWidth')
    ], jqxFormattedInputComponent.prototype, "attrDropDownWidth", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxFormattedInputComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxFormattedInputComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxFormattedInputComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('popupZIndex')
    ], jqxFormattedInputComponent.prototype, "attrPopupZIndex", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxFormattedInputComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxFormattedInputComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('radix')
    ], jqxFormattedInputComponent.prototype, "attrRadix", void 0);
    __decorate([
        core_1.Input('spinButtons')
    ], jqxFormattedInputComponent.prototype, "attrSpinButtons", void 0);
    __decorate([
        core_1.Input('spinButtonsStep')
    ], jqxFormattedInputComponent.prototype, "attrSpinButtonsStep", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxFormattedInputComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxFormattedInputComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('upperCase')
    ], jqxFormattedInputComponent.prototype, "attrUpperCase", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxFormattedInputComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxFormattedInputComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxFormattedInputComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxFormattedInputComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxFormattedInputComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxFormattedInputComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxFormattedInputComponent.prototype, "onOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxFormattedInputComponent.prototype, "onRadixChange", void 0);
    jqxFormattedInputComponent = __decorate([
        core_1.Component({
            selector: 'jqxFormattedInput',
            template: '<div><input type="text" [(ngModel)]="ngValue"><div></div><div></div></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxFormattedInputComponent);
    return jqxFormattedInputComponent;
}()); //jqxFormattedInputComponent
exports.jqxFormattedInputComponent = jqxFormattedInputComponent;
