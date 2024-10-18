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
require("../jqwidgets/jqxdraw.js");
require("../jqwidgets/jqxgauge.js");
var core_1 = require("@angular/core");
var jqxGaugeComponent = /** @class */ (function () {
    function jqxGaugeComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['animationDuration', 'border', 'caption', 'cap', 'colorScheme', 'disabled', 'easing', 'endAngle', 'height', 'int64', 'labels', 'min', 'max', 'pointer', 'radius', 'ranges', 'startAngle', 'showRanges', 'styles', 'ticksMajor', 'ticksMinor', 'ticksDistance', 'value', 'width'];
        // jqxGaugeComponent events
        this.onValueChanging = new core_1.EventEmitter();
        this.onValueChanged = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxGaugeComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxGaugeComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxGauge(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxGauge(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxGauge(this.properties[i])) {
                        this.host.jqxGauge(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxGaugeComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxGaugeComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxGaugeComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxGaugeComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxGaugeComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxGauge', options);
    };
    jqxGaugeComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxGaugeComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxGaugeComponent.prototype.setOptions = function (options) {
        this.host.jqxGauge('setOptions', options);
    };
    // jqxGaugeComponent properties
    jqxGaugeComponent.prototype.animationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('animationDuration', arg);
        }
        else {
            return this.host.jqxGauge('animationDuration');
        }
    };
    jqxGaugeComponent.prototype.border = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('border', arg);
        }
        else {
            return this.host.jqxGauge('border');
        }
    };
    jqxGaugeComponent.prototype.caption = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('caption', arg);
        }
        else {
            return this.host.jqxGauge('caption');
        }
    };
    jqxGaugeComponent.prototype.cap = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('cap', arg);
        }
        else {
            return this.host.jqxGauge('cap');
        }
    };
    jqxGaugeComponent.prototype.colorScheme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('colorScheme', arg);
        }
        else {
            return this.host.jqxGauge('colorScheme');
        }
    };
    jqxGaugeComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('disabled', arg);
        }
        else {
            return this.host.jqxGauge('disabled');
        }
    };
    jqxGaugeComponent.prototype.easing = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('easing', arg);
        }
        else {
            return this.host.jqxGauge('easing');
        }
    };
    jqxGaugeComponent.prototype.endAngle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('endAngle', arg);
        }
        else {
            return this.host.jqxGauge('endAngle');
        }
    };
    jqxGaugeComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('height', arg);
        }
        else {
            return this.host.jqxGauge('height');
        }
    };
    jqxGaugeComponent.prototype.int64 = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('int64', arg);
        }
        else {
            return this.host.jqxGauge('int64');
        }
    };
    jqxGaugeComponent.prototype.labels = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('labels', arg);
        }
        else {
            return this.host.jqxGauge('labels');
        }
    };
    jqxGaugeComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('min', arg);
        }
        else {
            return this.host.jqxGauge('min');
        }
    };
    jqxGaugeComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('max', arg);
        }
        else {
            return this.host.jqxGauge('max');
        }
    };
    jqxGaugeComponent.prototype.pointer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('pointer', arg);
        }
        else {
            return this.host.jqxGauge('pointer');
        }
    };
    jqxGaugeComponent.prototype.radius = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('radius', arg);
        }
        else {
            return this.host.jqxGauge('radius');
        }
    };
    jqxGaugeComponent.prototype.ranges = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('ranges', arg);
        }
        else {
            return this.host.jqxGauge('ranges');
        }
    };
    jqxGaugeComponent.prototype.startAngle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('startAngle', arg);
        }
        else {
            return this.host.jqxGauge('startAngle');
        }
    };
    jqxGaugeComponent.prototype.showRanges = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('showRanges', arg);
        }
        else {
            return this.host.jqxGauge('showRanges');
        }
    };
    jqxGaugeComponent.prototype.styles = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('styles', arg);
        }
        else {
            return this.host.jqxGauge('styles');
        }
    };
    jqxGaugeComponent.prototype.ticksMajor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('ticksMajor', arg);
        }
        else {
            return this.host.jqxGauge('ticksMajor');
        }
    };
    jqxGaugeComponent.prototype.ticksMinor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('ticksMinor', arg);
        }
        else {
            return this.host.jqxGauge('ticksMinor');
        }
    };
    jqxGaugeComponent.prototype.ticksDistance = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('ticksDistance', arg);
        }
        else {
            return this.host.jqxGauge('ticksDistance');
        }
    };
    jqxGaugeComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('value', arg);
        }
        else {
            return this.host.jqxGauge('value');
        }
    };
    jqxGaugeComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGauge('width', arg);
        }
        else {
            return this.host.jqxGauge('width');
        }
    };
    // jqxGaugeComponent functions
    jqxGaugeComponent.prototype.disable = function () {
        this.host.jqxGauge('disable');
    };
    jqxGaugeComponent.prototype.enable = function () {
        this.host.jqxGauge('enable');
    };
    jqxGaugeComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxGauge('val', value);
        }
        else {
            return this.host.jqxGauge('val');
        }
    };
    ;
    jqxGaugeComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('valueChanging', function (eventData) { _this.onValueChanging.emit(eventData); });
        this.host.on('valueChanged', function (eventData) { _this.onValueChanged.emit(eventData); });
    };
    __decorate([
        core_1.Input('animationDuration')
    ], jqxGaugeComponent.prototype, "attrAnimationDuration", void 0);
    __decorate([
        core_1.Input('border')
    ], jqxGaugeComponent.prototype, "attrBorder", void 0);
    __decorate([
        core_1.Input('caption')
    ], jqxGaugeComponent.prototype, "attrCaption", void 0);
    __decorate([
        core_1.Input('cap')
    ], jqxGaugeComponent.prototype, "attrCap", void 0);
    __decorate([
        core_1.Input('colorScheme')
    ], jqxGaugeComponent.prototype, "attrColorScheme", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxGaugeComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('easing')
    ], jqxGaugeComponent.prototype, "attrEasing", void 0);
    __decorate([
        core_1.Input('endAngle')
    ], jqxGaugeComponent.prototype, "attrEndAngle", void 0);
    __decorate([
        core_1.Input('int64')
    ], jqxGaugeComponent.prototype, "attrInt64", void 0);
    __decorate([
        core_1.Input('labels')
    ], jqxGaugeComponent.prototype, "attrLabels", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxGaugeComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxGaugeComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('pointer')
    ], jqxGaugeComponent.prototype, "attrPointer", void 0);
    __decorate([
        core_1.Input('radius')
    ], jqxGaugeComponent.prototype, "attrRadius", void 0);
    __decorate([
        core_1.Input('ranges')
    ], jqxGaugeComponent.prototype, "attrRanges", void 0);
    __decorate([
        core_1.Input('startAngle')
    ], jqxGaugeComponent.prototype, "attrStartAngle", void 0);
    __decorate([
        core_1.Input('showRanges')
    ], jqxGaugeComponent.prototype, "attrShowRanges", void 0);
    __decorate([
        core_1.Input('styles')
    ], jqxGaugeComponent.prototype, "attrStyles", void 0);
    __decorate([
        core_1.Input('ticksMajor')
    ], jqxGaugeComponent.prototype, "attrTicksMajor", void 0);
    __decorate([
        core_1.Input('ticksMinor')
    ], jqxGaugeComponent.prototype, "attrTicksMinor", void 0);
    __decorate([
        core_1.Input('ticksDistance')
    ], jqxGaugeComponent.prototype, "attrTicksDistance", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxGaugeComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxGaugeComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxGaugeComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxGaugeComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxGaugeComponent.prototype, "onValueChanging", void 0);
    __decorate([
        core_1.Output()
    ], jqxGaugeComponent.prototype, "onValueChanged", void 0);
    jqxGaugeComponent = __decorate([
        core_1.Component({
            selector: 'jqxGauge',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxGaugeComponent);
    return jqxGaugeComponent;
}()); //jqxGaugeComponent
exports.jqxGaugeComponent = jqxGaugeComponent;
