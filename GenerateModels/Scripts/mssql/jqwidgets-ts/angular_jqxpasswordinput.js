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
require("../jqwidgets/jqxtooltip.js");
require("../jqwidgets/jqxpasswordinput.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxPasswordInputComponent; }),
    multi: true
};
var jqxPasswordInputComponent = /** @class */ (function () {
    function jqxPasswordInputComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'localization', 'maxLength', 'placeHolder', 'passwordStrength', 'rtl', 'strengthColors', 'showStrength', 'showStrengthPosition', 'strengthTypeRenderer', 'showPasswordIcon', 'theme', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxPasswordInputComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxPasswordInputComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxPasswordInputComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxPasswordInput(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxPasswordInput(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxPasswordInput(this.properties[i])) {
                        this.host.jqxPasswordInput(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxPasswordInputComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxPasswordInputComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxPasswordInputComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxPasswordInputComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxPasswordInputComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxPasswordInput', options);
    };
    jqxPasswordInputComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxPasswordInputComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    Object.defineProperty(jqxPasswordInputComponent.prototype, "ngValue", {
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
    jqxPasswordInputComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.host.jqxPasswordInput('val', value);
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxPasswordInput('val', '');
        }
    };
    jqxPasswordInputComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxPasswordInputComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxPasswordInputComponent.prototype.setOptions = function (options) {
        this.host.jqxPasswordInput('setOptions', options);
    };
    // jqxPasswordInputComponent properties
    jqxPasswordInputComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('disabled', arg);
        }
        else {
            return this.host.jqxPasswordInput('disabled');
        }
    };
    jqxPasswordInputComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('height', arg);
        }
        else {
            return this.host.jqxPasswordInput('height');
        }
    };
    jqxPasswordInputComponent.prototype.localization = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('localization', arg);
        }
        else {
            return this.host.jqxPasswordInput('localization');
        }
    };
    jqxPasswordInputComponent.prototype.maxLength = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('maxLength', arg);
        }
        else {
            return this.host.jqxPasswordInput('maxLength');
        }
    };
    jqxPasswordInputComponent.prototype.placeHolder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('placeHolder', arg);
        }
        else {
            return this.host.jqxPasswordInput('placeHolder');
        }
    };
    jqxPasswordInputComponent.prototype.passwordStrength = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('passwordStrength', arg);
        }
        else {
            return this.host.jqxPasswordInput('passwordStrength');
        }
    };
    jqxPasswordInputComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('rtl', arg);
        }
        else {
            return this.host.jqxPasswordInput('rtl');
        }
    };
    jqxPasswordInputComponent.prototype.strengthColors = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('strengthColors', arg);
        }
        else {
            return this.host.jqxPasswordInput('strengthColors');
        }
    };
    jqxPasswordInputComponent.prototype.showStrength = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('showStrength', arg);
        }
        else {
            return this.host.jqxPasswordInput('showStrength');
        }
    };
    jqxPasswordInputComponent.prototype.showStrengthPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('showStrengthPosition', arg);
        }
        else {
            return this.host.jqxPasswordInput('showStrengthPosition');
        }
    };
    jqxPasswordInputComponent.prototype.strengthTypeRenderer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('strengthTypeRenderer', arg);
        }
        else {
            return this.host.jqxPasswordInput('strengthTypeRenderer');
        }
    };
    jqxPasswordInputComponent.prototype.showPasswordIcon = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('showPasswordIcon', arg);
        }
        else {
            return this.host.jqxPasswordInput('showPasswordIcon');
        }
    };
    jqxPasswordInputComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('theme', arg);
        }
        else {
            return this.host.jqxPasswordInput('theme');
        }
    };
    jqxPasswordInputComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPasswordInput('width', arg);
        }
        else {
            return this.host.jqxPasswordInput('width');
        }
    };
    // jqxPasswordInputComponent functions
    jqxPasswordInputComponent.prototype.render = function () {
        this.host.jqxPasswordInput('render');
    };
    jqxPasswordInputComponent.prototype.refresh = function () {
        this.host.jqxPasswordInput('refresh');
    };
    jqxPasswordInputComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxPasswordInput('val', value);
        }
        else {
            return this.host.jqxPasswordInput('val');
        }
    };
    ;
    jqxPasswordInputComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxPasswordInputComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('localization')
    ], jqxPasswordInputComponent.prototype, "attrLocalization", void 0);
    __decorate([
        core_1.Input('maxLength')
    ], jqxPasswordInputComponent.prototype, "attrMaxLength", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxPasswordInputComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('passwordStrength')
    ], jqxPasswordInputComponent.prototype, "attrPasswordStrength", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxPasswordInputComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('strengthColors')
    ], jqxPasswordInputComponent.prototype, "attrStrengthColors", void 0);
    __decorate([
        core_1.Input('showStrength')
    ], jqxPasswordInputComponent.prototype, "attrShowStrength", void 0);
    __decorate([
        core_1.Input('showStrengthPosition')
    ], jqxPasswordInputComponent.prototype, "attrShowStrengthPosition", void 0);
    __decorate([
        core_1.Input('strengthTypeRenderer')
    ], jqxPasswordInputComponent.prototype, "attrStrengthTypeRenderer", void 0);
    __decorate([
        core_1.Input('showPasswordIcon')
    ], jqxPasswordInputComponent.prototype, "attrShowPasswordIcon", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxPasswordInputComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxPasswordInputComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxPasswordInputComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxPasswordInputComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxPasswordInputComponent.prototype, "onChange", void 0);
    jqxPasswordInputComponent = __decorate([
        core_1.Component({
            selector: 'jqxPasswordInput',
            template: '<input type="password" [(ngModel)]="ngValue">',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxPasswordInputComponent);
    return jqxPasswordInputComponent;
}()); //jqxPasswordInputComponent
exports.jqxPasswordInputComponent = jqxPasswordInputComponent;
