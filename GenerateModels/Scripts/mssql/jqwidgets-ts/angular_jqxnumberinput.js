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
require("../jqwidgets/jqxnumberinput.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxNumberInputComponent; }),
    multi: true
};
var jqxNumberInputComponent = /** @class */ (function () {
    function jqxNumberInputComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['allowNull', 'decimal', 'disabled', 'decimalDigits', 'decimalSeparator', 'digits', 'groupSeparator', 'groupSize', 'height', 'inputMode', 'min', 'max', 'negativeSymbol', 'placeHolder', 'promptChar', 'rtl', 'readOnly', 'spinMode', 'spinButtons', 'spinButtonsWidth', 'spinButtonsStep', 'symbol', 'symbolPosition', 'textAlign', 'template', 'theme', 'value', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxNumberInputComponent events
        this.onChange = new core_1.EventEmitter();
        this.onTextchanged = new core_1.EventEmitter();
        this.onValueChanged = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxNumberInputComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxNumberInputComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxNumberInput(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxNumberInput(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxNumberInput(this.properties[i])) {
                        this.host.jqxNumberInput(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxNumberInputComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxNumberInputComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxNumberInputComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxNumberInputComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxNumberInputComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxNumberInput', options);
        this.host = this.widgetObject['host'];
        this.__wireEvents__();
    };
    jqxNumberInputComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxNumberInputComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxNumberInputComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.host.jqxNumberInput('val', value);
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxNumberInput('val', '');
        }
    };
    jqxNumberInputComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxNumberInputComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxNumberInputComponent.prototype.setOptions = function (options) {
        this.host.jqxNumberInput('setOptions', options);
    };
    // jqxNumberInputComponent properties
    jqxNumberInputComponent.prototype.allowNull = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('allowNull', arg);
        }
        else {
            return this.host.jqxNumberInput('allowNull');
        }
    };
    jqxNumberInputComponent.prototype.decimal = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('decimal', arg);
        }
        else {
            return this.host.jqxNumberInput('decimal');
        }
    };
    jqxNumberInputComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('disabled', arg);
        }
        else {
            return this.host.jqxNumberInput('disabled');
        }
    };
    jqxNumberInputComponent.prototype.decimalDigits = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('decimalDigits', arg);
        }
        else {
            return this.host.jqxNumberInput('decimalDigits');
        }
    };
    jqxNumberInputComponent.prototype.decimalSeparator = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('decimalSeparator', arg);
        }
        else {
            return this.host.jqxNumberInput('decimalSeparator');
        }
    };
    jqxNumberInputComponent.prototype.digits = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('digits', arg);
        }
        else {
            return this.host.jqxNumberInput('digits');
        }
    };
    jqxNumberInputComponent.prototype.groupSeparator = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('groupSeparator', arg);
        }
        else {
            return this.host.jqxNumberInput('groupSeparator');
        }
    };
    jqxNumberInputComponent.prototype.groupSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('groupSize', arg);
        }
        else {
            return this.host.jqxNumberInput('groupSize');
        }
    };
    jqxNumberInputComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('height', arg);
        }
        else {
            return this.host.jqxNumberInput('height');
        }
    };
    jqxNumberInputComponent.prototype.inputMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('inputMode', arg);
        }
        else {
            return this.host.jqxNumberInput('inputMode');
        }
    };
    jqxNumberInputComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('min', arg);
        }
        else {
            return this.host.jqxNumberInput('min');
        }
    };
    jqxNumberInputComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('max', arg);
        }
        else {
            return this.host.jqxNumberInput('max');
        }
    };
    jqxNumberInputComponent.prototype.negativeSymbol = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('negativeSymbol', arg);
        }
        else {
            return this.host.jqxNumberInput('negativeSymbol');
        }
    };
    jqxNumberInputComponent.prototype.placeHolder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('placeHolder', arg);
        }
        else {
            return this.host.jqxNumberInput('placeHolder');
        }
    };
    jqxNumberInputComponent.prototype.promptChar = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('promptChar', arg);
        }
        else {
            return this.host.jqxNumberInput('promptChar');
        }
    };
    jqxNumberInputComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('rtl', arg);
        }
        else {
            return this.host.jqxNumberInput('rtl');
        }
    };
    jqxNumberInputComponent.prototype.readOnly = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('readOnly', arg);
        }
        else {
            return this.host.jqxNumberInput('readOnly');
        }
    };
    jqxNumberInputComponent.prototype.spinMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('spinMode', arg);
        }
        else {
            return this.host.jqxNumberInput('spinMode');
        }
    };
    jqxNumberInputComponent.prototype.spinButtons = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('spinButtons', arg);
        }
        else {
            return this.host.jqxNumberInput('spinButtons');
        }
    };
    jqxNumberInputComponent.prototype.spinButtonsWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('spinButtonsWidth', arg);
        }
        else {
            return this.host.jqxNumberInput('spinButtonsWidth');
        }
    };
    jqxNumberInputComponent.prototype.spinButtonsStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('spinButtonsStep', arg);
        }
        else {
            return this.host.jqxNumberInput('spinButtonsStep');
        }
    };
    jqxNumberInputComponent.prototype.symbol = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('symbol', arg);
        }
        else {
            return this.host.jqxNumberInput('symbol');
        }
    };
    jqxNumberInputComponent.prototype.symbolPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('symbolPosition', arg);
        }
        else {
            return this.host.jqxNumberInput('symbolPosition');
        }
    };
    jqxNumberInputComponent.prototype.textAlign = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('textAlign', arg);
        }
        else {
            return this.host.jqxNumberInput('textAlign');
        }
    };
    jqxNumberInputComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('template', arg);
        }
        else {
            return this.host.jqxNumberInput('template');
        }
    };
    jqxNumberInputComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('theme', arg);
        }
        else {
            return this.host.jqxNumberInput('theme');
        }
    };
    jqxNumberInputComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('value', arg);
        }
        else {
            return this.host.jqxNumberInput('value');
        }
    };
    jqxNumberInputComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNumberInput('width', arg);
        }
        else {
            return this.host.jqxNumberInput('width');
        }
    };
    // jqxNumberInputComponent functions
    jqxNumberInputComponent.prototype.clear = function () {
        this.host.jqxNumberInput('clear');
    };
    jqxNumberInputComponent.prototype.destroy = function () {
        this.host.jqxNumberInput('destroy');
    };
    jqxNumberInputComponent.prototype.focus = function () {
        this.host.jqxNumberInput('focus');
    };
    jqxNumberInputComponent.prototype.getDecimal = function () {
        return this.host.jqxNumberInput('getDecimal');
    };
    jqxNumberInputComponent.prototype.setDecimal = function (index) {
        this.host.jqxNumberInput('setDecimal', index);
    };
    jqxNumberInputComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxNumberInput('val', value);
        }
        else {
            return this.host.jqxNumberInput('val');
        }
    };
    ;
    jqxNumberInputComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.value); });
        this.host.on('textchanged', function (eventData) { _this.onTextchanged.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.value); });
        this.host.on('valueChanged', function (eventData) { _this.onValueChanged.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.value); });
    };
    __decorate([
        core_1.Input('allowNull')
    ], jqxNumberInputComponent.prototype, "attrAllowNull", void 0);
    __decorate([
        core_1.Input('decimal')
    ], jqxNumberInputComponent.prototype, "attrDecimal", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxNumberInputComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('decimalDigits')
    ], jqxNumberInputComponent.prototype, "attrDecimalDigits", void 0);
    __decorate([
        core_1.Input('decimalSeparator')
    ], jqxNumberInputComponent.prototype, "attrDecimalSeparator", void 0);
    __decorate([
        core_1.Input('digits')
    ], jqxNumberInputComponent.prototype, "attrDigits", void 0);
    __decorate([
        core_1.Input('groupSeparator')
    ], jqxNumberInputComponent.prototype, "attrGroupSeparator", void 0);
    __decorate([
        core_1.Input('groupSize')
    ], jqxNumberInputComponent.prototype, "attrGroupSize", void 0);
    __decorate([
        core_1.Input('inputMode')
    ], jqxNumberInputComponent.prototype, "attrInputMode", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxNumberInputComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxNumberInputComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('negativeSymbol')
    ], jqxNumberInputComponent.prototype, "attrNegativeSymbol", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxNumberInputComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('promptChar')
    ], jqxNumberInputComponent.prototype, "attrPromptChar", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxNumberInputComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('readOnly')
    ], jqxNumberInputComponent.prototype, "attrReadOnly", void 0);
    __decorate([
        core_1.Input('spinMode')
    ], jqxNumberInputComponent.prototype, "attrSpinMode", void 0);
    __decorate([
        core_1.Input('spinButtons')
    ], jqxNumberInputComponent.prototype, "attrSpinButtons", void 0);
    __decorate([
        core_1.Input('spinButtonsWidth')
    ], jqxNumberInputComponent.prototype, "attrSpinButtonsWidth", void 0);
    __decorate([
        core_1.Input('spinButtonsStep')
    ], jqxNumberInputComponent.prototype, "attrSpinButtonsStep", void 0);
    __decorate([
        core_1.Input('symbol')
    ], jqxNumberInputComponent.prototype, "attrSymbol", void 0);
    __decorate([
        core_1.Input('symbolPosition')
    ], jqxNumberInputComponent.prototype, "attrSymbolPosition", void 0);
    __decorate([
        core_1.Input('textAlign')
    ], jqxNumberInputComponent.prototype, "attrTextAlign", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxNumberInputComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxNumberInputComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxNumberInputComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxNumberInputComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxNumberInputComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxNumberInputComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxNumberInputComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxNumberInputComponent.prototype, "onTextchanged", void 0);
    __decorate([
        core_1.Output()
    ], jqxNumberInputComponent.prototype, "onValueChanged", void 0);
    jqxNumberInputComponent = __decorate([
        core_1.Component({
            selector: 'jqxNumberInput',
            template: '<input>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxNumberInputComponent);
    return jqxNumberInputComponent;
}()); //jqxNumberInputComponent
exports.jqxNumberInputComponent = jqxNumberInputComponent;
