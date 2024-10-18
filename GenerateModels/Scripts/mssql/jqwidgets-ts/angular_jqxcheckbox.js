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
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxCheckBoxComponent; }),
    multi: true
};
var jqxCheckBoxComponent = /** @class */ (function () {
    function jqxCheckBoxComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['animationShowDelay', 'animationHideDelay', 'boxSize', 'checked', 'disabled', 'enableContainerClick', 'groupName', 'height', 'hasThreeStates', 'locked', 'rtl', 'theme', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxCheckBoxComponent events
        this.onChecked = new core_1.EventEmitter();
        this.onChange = new core_1.EventEmitter();
        this.onIndeterminate = new core_1.EventEmitter();
        this.onUnchecked = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxCheckBoxComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxCheckBoxComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxCheckBox(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxCheckBox(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxCheckBox(this.properties[i])) {
                        this.host.jqxCheckBox(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxCheckBoxComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxCheckBoxComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxCheckBoxComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxCheckBoxComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxCheckBoxComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxCheckBox', options);
        options.checked !== undefined ? this.onChangeCallback(options.checked) : this.onChangeCallback(false);
    };
    jqxCheckBoxComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxCheckBoxComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxCheckBoxComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxCheckBox('val', '');
        }
    };
    jqxCheckBoxComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxCheckBoxComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxCheckBoxComponent.prototype.setOptions = function (options) {
        this.host.jqxCheckBox('setOptions', options);
    };
    // jqxCheckBoxComponent properties
    jqxCheckBoxComponent.prototype.animationShowDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('animationShowDelay', arg);
        }
        else {
            return this.host.jqxCheckBox('animationShowDelay');
        }
    };
    jqxCheckBoxComponent.prototype.animationHideDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('animationHideDelay', arg);
        }
        else {
            return this.host.jqxCheckBox('animationHideDelay');
        }
    };
    jqxCheckBoxComponent.prototype.boxSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('boxSize', arg);
        }
        else {
            return this.host.jqxCheckBox('boxSize');
        }
    };
    jqxCheckBoxComponent.prototype.checked = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('checked', arg);
        }
        else {
            return this.host.jqxCheckBox('checked');
        }
    };
    jqxCheckBoxComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('disabled', arg);
        }
        else {
            return this.host.jqxCheckBox('disabled');
        }
    };
    jqxCheckBoxComponent.prototype.enableContainerClick = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('enableContainerClick', arg);
        }
        else {
            return this.host.jqxCheckBox('enableContainerClick');
        }
    };
    jqxCheckBoxComponent.prototype.groupName = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('groupName', arg);
        }
        else {
            return this.host.jqxCheckBox('groupName');
        }
    };
    jqxCheckBoxComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('height', arg);
        }
        else {
            return this.host.jqxCheckBox('height');
        }
    };
    jqxCheckBoxComponent.prototype.hasThreeStates = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('hasThreeStates', arg);
        }
        else {
            return this.host.jqxCheckBox('hasThreeStates');
        }
    };
    jqxCheckBoxComponent.prototype.locked = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('locked', arg);
        }
        else {
            return this.host.jqxCheckBox('locked');
        }
    };
    jqxCheckBoxComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('rtl', arg);
        }
        else {
            return this.host.jqxCheckBox('rtl');
        }
    };
    jqxCheckBoxComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('theme', arg);
        }
        else {
            return this.host.jqxCheckBox('theme');
        }
    };
    jqxCheckBoxComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxCheckBox('width', arg);
        }
        else {
            return this.host.jqxCheckBox('width');
        }
    };
    // jqxCheckBoxComponent functions
    jqxCheckBoxComponent.prototype.check = function () {
        this.host.jqxCheckBox('check');
    };
    jqxCheckBoxComponent.prototype.disable = function () {
        this.host.jqxCheckBox('disable');
    };
    jqxCheckBoxComponent.prototype.destroy = function () {
        this.host.jqxCheckBox('destroy');
    };
    jqxCheckBoxComponent.prototype.enable = function () {
        this.host.jqxCheckBox('enable');
    };
    jqxCheckBoxComponent.prototype.focus = function () {
        this.host.jqxCheckBox('focus');
    };
    jqxCheckBoxComponent.prototype.indeterminate = function () {
        this.host.jqxCheckBox('indeterminate');
    };
    jqxCheckBoxComponent.prototype.render = function () {
        this.host.jqxCheckBox('render');
    };
    jqxCheckBoxComponent.prototype.toggle = function () {
        this.host.jqxCheckBox('toggle');
    };
    jqxCheckBoxComponent.prototype.uncheck = function () {
        this.host.jqxCheckBox('uncheck');
    };
    jqxCheckBoxComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxCheckBox('val', value);
        }
        else {
            return this.host.jqxCheckBox('val');
        }
    };
    ;
    jqxCheckBoxComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('checked', function (eventData) { _this.onChecked.emit(eventData); });
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.checked); });
        this.host.on('indeterminate', function (eventData) { _this.onIndeterminate.emit(eventData); });
        this.host.on('unchecked', function (eventData) { _this.onUnchecked.emit(eventData); });
    };
    __decorate([
        core_1.Input('animationShowDelay')
    ], jqxCheckBoxComponent.prototype, "attrAnimationShowDelay", void 0);
    __decorate([
        core_1.Input('animationHideDelay')
    ], jqxCheckBoxComponent.prototype, "attrAnimationHideDelay", void 0);
    __decorate([
        core_1.Input('boxSize')
    ], jqxCheckBoxComponent.prototype, "attrBoxSize", void 0);
    __decorate([
        core_1.Input('checked')
    ], jqxCheckBoxComponent.prototype, "attrChecked", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxCheckBoxComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('enableContainerClick')
    ], jqxCheckBoxComponent.prototype, "attrEnableContainerClick", void 0);
    __decorate([
        core_1.Input('groupName')
    ], jqxCheckBoxComponent.prototype, "attrGroupName", void 0);
    __decorate([
        core_1.Input('hasThreeStates')
    ], jqxCheckBoxComponent.prototype, "attrHasThreeStates", void 0);
    __decorate([
        core_1.Input('locked')
    ], jqxCheckBoxComponent.prototype, "attrLocked", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxCheckBoxComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxCheckBoxComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxCheckBoxComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxCheckBoxComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxCheckBoxComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxCheckBoxComponent.prototype, "onChecked", void 0);
    __decorate([
        core_1.Output()
    ], jqxCheckBoxComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxCheckBoxComponent.prototype, "onIndeterminate", void 0);
    __decorate([
        core_1.Output()
    ], jqxCheckBoxComponent.prototype, "onUnchecked", void 0);
    jqxCheckBoxComponent = __decorate([
        core_1.Component({
            selector: 'jqxCheckBox',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxCheckBoxComponent);
    return jqxCheckBoxComponent;
}()); //jqxCheckBoxComponent
exports.jqxCheckBoxComponent = jqxCheckBoxComponent;
