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
require("../jqwidgets/jqxslider.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxSliderComponent; }),
    multi: true
};
var jqxSliderComponent = /** @class */ (function () {
    function jqxSliderComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['buttonsPosition', 'disabled', 'height', 'layout', 'mode', 'minorTicksFrequency', 'minorTickSize', 'max', 'min', 'orientation', 'rangeSlider', 'rtl', 'step', 'showTicks', 'showMinorTicks', 'showTickLabels', 'showButtons', 'showRange', 'template', 'theme', 'ticksPosition', 'ticksFrequency', 'tickSize', 'tickLabelFormatFunction', 'tooltip', 'tooltipHideDelay', 'tooltipPosition', 'tooltipFormatFunction', 'value', 'values', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxSliderComponent events
        this.onChange = new core_1.EventEmitter();
        this.onSlide = new core_1.EventEmitter();
        this.onSlideStart = new core_1.EventEmitter();
        this.onSlideEnd = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxSliderComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxSliderComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxSlider(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxSlider(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxSlider(this.properties[i])) {
                        this.host.jqxSlider(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxSliderComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxSliderComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxSliderComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxSliderComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxSliderComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxSlider', options);
    };
    jqxSliderComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxSliderComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    Object.defineProperty(jqxSliderComponent.prototype, "ngValue", {
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
    jqxSliderComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxSlider('val', '');
        }
    };
    jqxSliderComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxSliderComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxSliderComponent.prototype.setOptions = function (options) {
        this.host.jqxSlider('setOptions', options);
    };
    // jqxSliderComponent properties
    jqxSliderComponent.prototype.buttonsPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('buttonsPosition', arg);
        }
        else {
            return this.host.jqxSlider('buttonsPosition');
        }
    };
    jqxSliderComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('disabled', arg);
        }
        else {
            return this.host.jqxSlider('disabled');
        }
    };
    jqxSliderComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('height', arg);
        }
        else {
            return this.host.jqxSlider('height');
        }
    };
    jqxSliderComponent.prototype.layout = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('layout', arg);
        }
        else {
            return this.host.jqxSlider('layout');
        }
    };
    jqxSliderComponent.prototype.mode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('mode', arg);
        }
        else {
            return this.host.jqxSlider('mode');
        }
    };
    jqxSliderComponent.prototype.minorTicksFrequency = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('minorTicksFrequency', arg);
        }
        else {
            return this.host.jqxSlider('minorTicksFrequency');
        }
    };
    jqxSliderComponent.prototype.minorTickSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('minorTickSize', arg);
        }
        else {
            return this.host.jqxSlider('minorTickSize');
        }
    };
    jqxSliderComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('max', arg);
        }
        else {
            return this.host.jqxSlider('max');
        }
    };
    jqxSliderComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('min', arg);
        }
        else {
            return this.host.jqxSlider('min');
        }
    };
    jqxSliderComponent.prototype.orientation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('orientation', arg);
        }
        else {
            return this.host.jqxSlider('orientation');
        }
    };
    jqxSliderComponent.prototype.rangeSlider = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('rangeSlider', arg);
        }
        else {
            return this.host.jqxSlider('rangeSlider');
        }
    };
    jqxSliderComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('rtl', arg);
        }
        else {
            return this.host.jqxSlider('rtl');
        }
    };
    jqxSliderComponent.prototype.step = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('step', arg);
        }
        else {
            return this.host.jqxSlider('step');
        }
    };
    jqxSliderComponent.prototype.showTicks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('showTicks', arg);
        }
        else {
            return this.host.jqxSlider('showTicks');
        }
    };
    jqxSliderComponent.prototype.showMinorTicks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('showMinorTicks', arg);
        }
        else {
            return this.host.jqxSlider('showMinorTicks');
        }
    };
    jqxSliderComponent.prototype.showTickLabels = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('showTickLabels', arg);
        }
        else {
            return this.host.jqxSlider('showTickLabels');
        }
    };
    jqxSliderComponent.prototype.showButtons = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('showButtons', arg);
        }
        else {
            return this.host.jqxSlider('showButtons');
        }
    };
    jqxSliderComponent.prototype.showRange = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('showRange', arg);
        }
        else {
            return this.host.jqxSlider('showRange');
        }
    };
    jqxSliderComponent.prototype.template = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('template', arg);
        }
        else {
            return this.host.jqxSlider('template');
        }
    };
    jqxSliderComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('theme', arg);
        }
        else {
            return this.host.jqxSlider('theme');
        }
    };
    jqxSliderComponent.prototype.ticksPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('ticksPosition', arg);
        }
        else {
            return this.host.jqxSlider('ticksPosition');
        }
    };
    jqxSliderComponent.prototype.ticksFrequency = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('ticksFrequency', arg);
        }
        else {
            return this.host.jqxSlider('ticksFrequency');
        }
    };
    jqxSliderComponent.prototype.tickSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('tickSize', arg);
        }
        else {
            return this.host.jqxSlider('tickSize');
        }
    };
    jqxSliderComponent.prototype.tickLabelFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('tickLabelFormatFunction', arg);
        }
        else {
            return this.host.jqxSlider('tickLabelFormatFunction');
        }
    };
    jqxSliderComponent.prototype.tooltip = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('tooltip', arg);
        }
        else {
            return this.host.jqxSlider('tooltip');
        }
    };
    jqxSliderComponent.prototype.tooltipHideDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('tooltipHideDelay', arg);
        }
        else {
            return this.host.jqxSlider('tooltipHideDelay');
        }
    };
    jqxSliderComponent.prototype.tooltipPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('tooltipPosition', arg);
        }
        else {
            return this.host.jqxSlider('tooltipPosition');
        }
    };
    jqxSliderComponent.prototype.tooltipFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('tooltipFormatFunction', arg);
        }
        else {
            return this.host.jqxSlider('tooltipFormatFunction');
        }
    };
    jqxSliderComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('value', arg);
        }
        else {
            return this.host.jqxSlider('value');
        }
    };
    jqxSliderComponent.prototype.values = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('values', arg);
        }
        else {
            return this.host.jqxSlider('values');
        }
    };
    jqxSliderComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSlider('width', arg);
        }
        else {
            return this.host.jqxSlider('width');
        }
    };
    // jqxSliderComponent functions
    jqxSliderComponent.prototype.destroy = function () {
        this.host.jqxSlider('destroy');
    };
    jqxSliderComponent.prototype.decrementValue = function () {
        this.host.jqxSlider('decrementValue');
    };
    jqxSliderComponent.prototype.disable = function () {
        this.host.jqxSlider('disable');
    };
    jqxSliderComponent.prototype.enable = function () {
        this.host.jqxSlider('enable');
    };
    jqxSliderComponent.prototype.focus = function () {
        this.host.jqxSlider('focus');
    };
    jqxSliderComponent.prototype.getValue = function () {
        return this.host.jqxSlider('getValue');
    };
    jqxSliderComponent.prototype.incrementValue = function () {
        this.host.jqxSlider('incrementValue');
    };
    jqxSliderComponent.prototype.setValue = function (index) {
        this.host.jqxSlider('setValue', index);
    };
    jqxSliderComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxSlider('val', value);
        }
        else {
            return this.host.jqxSlider('val');
        }
    };
    ;
    jqxSliderComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); _this.onChangeCallback(_this.host.val()); });
        this.host.on('slide', function (eventData) { _this.onSlide.emit(eventData); });
        this.host.on('slideStart', function (eventData) { _this.onSlideStart.emit(eventData); });
        this.host.on('slideEnd', function (eventData) { _this.onSlideEnd.emit(eventData); });
    };
    __decorate([
        core_1.Input('buttonsPosition')
    ], jqxSliderComponent.prototype, "attrButtonsPosition", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxSliderComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('layout')
    ], jqxSliderComponent.prototype, "attrLayout", void 0);
    __decorate([
        core_1.Input('mode')
    ], jqxSliderComponent.prototype, "attrMode", void 0);
    __decorate([
        core_1.Input('minorTicksFrequency')
    ], jqxSliderComponent.prototype, "attrMinorTicksFrequency", void 0);
    __decorate([
        core_1.Input('minorTickSize')
    ], jqxSliderComponent.prototype, "attrMinorTickSize", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxSliderComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxSliderComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('orientation')
    ], jqxSliderComponent.prototype, "attrOrientation", void 0);
    __decorate([
        core_1.Input('rangeSlider')
    ], jqxSliderComponent.prototype, "attrRangeSlider", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxSliderComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('step')
    ], jqxSliderComponent.prototype, "attrStep", void 0);
    __decorate([
        core_1.Input('showTicks')
    ], jqxSliderComponent.prototype, "attrShowTicks", void 0);
    __decorate([
        core_1.Input('showMinorTicks')
    ], jqxSliderComponent.prototype, "attrShowMinorTicks", void 0);
    __decorate([
        core_1.Input('showTickLabels')
    ], jqxSliderComponent.prototype, "attrShowTickLabels", void 0);
    __decorate([
        core_1.Input('showButtons')
    ], jqxSliderComponent.prototype, "attrShowButtons", void 0);
    __decorate([
        core_1.Input('showRange')
    ], jqxSliderComponent.prototype, "attrShowRange", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxSliderComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxSliderComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('ticksPosition')
    ], jqxSliderComponent.prototype, "attrTicksPosition", void 0);
    __decorate([
        core_1.Input('ticksFrequency')
    ], jqxSliderComponent.prototype, "attrTicksFrequency", void 0);
    __decorate([
        core_1.Input('tickSize')
    ], jqxSliderComponent.prototype, "attrTickSize", void 0);
    __decorate([
        core_1.Input('tickLabelFormatFunction')
    ], jqxSliderComponent.prototype, "attrTickLabelFormatFunction", void 0);
    __decorate([
        core_1.Input('tooltip')
    ], jqxSliderComponent.prototype, "attrTooltip", void 0);
    __decorate([
        core_1.Input('tooltipHideDelay')
    ], jqxSliderComponent.prototype, "attrTooltipHideDelay", void 0);
    __decorate([
        core_1.Input('tooltipPosition')
    ], jqxSliderComponent.prototype, "attrTooltipPosition", void 0);
    __decorate([
        core_1.Input('tooltipFormatFunction')
    ], jqxSliderComponent.prototype, "attrTooltipFormatFunction", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxSliderComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('values')
    ], jqxSliderComponent.prototype, "attrValues", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxSliderComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxSliderComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxSliderComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSliderComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxSliderComponent.prototype, "onSlide", void 0);
    __decorate([
        core_1.Output()
    ], jqxSliderComponent.prototype, "onSlideStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxSliderComponent.prototype, "onSlideEnd", void 0);
    jqxSliderComponent = __decorate([
        core_1.Component({
            selector: 'jqxSlider',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxSliderComponent);
    return jqxSliderComponent;
}()); //jqxSliderComponent
exports.jqxSliderComponent = jqxSliderComponent;
