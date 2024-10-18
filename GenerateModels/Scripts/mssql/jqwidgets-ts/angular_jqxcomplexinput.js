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
require("../jqwidgets/jqxcomplexinput.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxComplexInputComponent; }),
    multi: true
};
var jqxComplexInputComponent = /** @class */ (function () {
    function jqxComplexInputComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['decimalNotation', 'disabled', 'height', 'placeHolder', 'roundedCorners', 'rtl', 'spinButtons', 'spinButtonsStep', 'template', 'theme', 'value', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxComplexInputComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxComplexInputComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxComplexInputComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxComplexInput(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxComplexInput(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxComplexInput(this.properties[i])) {
                        this.host.jqxComplexInput(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxComplexInputComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxComplexInputComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxComplexInputComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxComplexInputComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxComplexInputComponent.prototype.createComponent = function (options) {
        var _this = this;
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxComplexInput', options);
        setTimeout(function (_) {
            var valueWithWS = 'JQXLite{options.value}';
            _this.host.jqxComplexInput({ value: valueWithWS });
        });
    };
    jqxComplexInputComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxComplexInputComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    Object.defineProperty(jqxComplexInputComponent.prototype, "ngValue", {
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
    jqxComplexInputComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
            this.host.jqxComplexInput('val', value);
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxComplexInput('val', '');
        }
    };
    jqxComplexInputComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxComplexInputComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxComplexInputComponent.prototype.setOptions = function (options) {
        this.host.jqxComplexInput('setOptions', options);
    };
    // jqxComplexInputComponent properties
    jqxComplexInputComponent.prototype.decimalNotation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('decimalNotation', arg);
        }
        else {
            return this.host.jqxComplexInput('decimalNotation');
        }
    };
    jqxComplexInputComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('disabled', arg);
        }
        else {
            return this.host.jqxComplexInput('disabled');
        }
    };
    jqxComplexInputComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('height', arg);
        }
        else {
            return this.host.jqxComplexInput('height');
        }
    };
    jqxComplexInputComponent.prototype.placeHolder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('placeHolder', arg);
        }
        else {
            return this.host.jqxComplexInput('placeHolder');
        }
    };
    jqxComplexInputComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('roundedCorners', arg);
        }
        else {
            return this.host.jqxComplexInput('roundedCorners');
        }
    };
    jqxComplexInputComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('rtl', arg);
        }
        else {
            return this.host.jqxComplexInput('rtl');
        }
    };
    jqxComplexInputComponent.prototype.spinButtons = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('spinButtons', arg);
        }
        else {
            return this.host.jqxComplexInput('spinButtons');
        }
    };
    jqxComplexInputComponent.prototype.spinButtonsStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('spinButtonsStep', arg);
        }
        else {
            return this.host.jqxComplexInput('spinButtonsStep');
        }
    };
    jqxComplexInputComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('template', arg);
        }
        else {
            return this.host.jqxComplexInput('template');
        }
    };
    jqxComplexInputComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('theme', arg);
        }
        else {
            return this.host.jqxComplexInput('theme');
        }
    };
    jqxComplexInputComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('value', arg);
        }
        else {
            return this.host.jqxComplexInput('value');
        }
    };
    jqxComplexInputComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxComplexInput('width', arg);
        }
        else {
            return this.host.jqxComplexInput('width');
        }
    };
    // jqxComplexInputComponent functions
    jqxComplexInputComponent.prototype.destroy = function () {
        this.host.jqxComplexInput('destroy');
    };
    jqxComplexInputComponent.prototype.getDecimalNotation = function (part, decimalNotation) {
        return this.host.jqxComplexInput('getDecimalNotation', part, decimalNotation);
    };
    jqxComplexInputComponent.prototype.getReal = function (complexnumber) {
        return this.host.jqxComplexInput('getReal', complexnumber);
    };
    jqxComplexInputComponent.prototype.getImaginary = function (complexnumber) {
        return this.host.jqxComplexInput('getImaginary', complexnumber);
    };
    jqxComplexInputComponent.prototype.render = function () {
        this.host.jqxComplexInput('render');
    };
    jqxComplexInputComponent.prototype.refresh = function () {
        this.host.jqxComplexInput('refresh');
    };
    jqxComplexInputComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxComplexInput('val', value);
        }
        else {
            return this.host.jqxComplexInput('val');
        }
    };
    ;
    jqxComplexInputComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.value); });
    };
    __decorate([
        core_1.Input('decimalNotation')
    ], jqxComplexInputComponent.prototype, "attrDecimalNotation", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxComplexInputComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxComplexInputComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxComplexInputComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxComplexInputComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('spinButtons')
    ], jqxComplexInputComponent.prototype, "attrSpinButtons", void 0);
    __decorate([
        core_1.Input('spinButtonsStep')
    ], jqxComplexInputComponent.prototype, "attrSpinButtonsStep", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxComplexInputComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxComplexInputComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxComplexInputComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxComplexInputComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxComplexInputComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxComplexInputComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxComplexInputComponent.prototype, "onChange", void 0);
    jqxComplexInputComponent = __decorate([
        core_1.Component({
            selector: 'jqxComplexInput',
            template: '<div style="display: inline-flex;"><input [(ngModel)]="ngValue"><div></div></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxComplexInputComponent);
    return jqxComplexInputComponent;
}()); //jqxComplexInputComponent
exports.jqxComplexInputComponent = jqxComplexInputComponent;
