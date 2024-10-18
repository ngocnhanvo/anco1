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
require("../jqwidgets/jqxknob.js");
var core_1 = require("@angular/core");
var jqxKnobComponent = /** @class */ (function () {
    function jqxKnobComponent(containerElement) {
        var _this = this;
        this.autoCreate = true;
        this.properties = ['allowValueChangeOnClick', 'allowValueChangeOnDrag', 'allowValueChangeOnMouseWheel', 'changing', 'dragEndAngle', 'dragStartAngle', 'disabled', 'dial', 'endAngle', 'height', 'labels', 'marks', 'min', 'max', 'progressBar', 'pointer', 'pointerGrabAction', 'rotation', 'startAngle', 'spinner', 'styles', 'step', 'snapToStep', 'value', 'width'];
        // jqxKnobComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
        JQXLite(window).resize(function () {
            _this.__updateRect__();
        });
    }
    jqxKnobComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxKnobComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxKnob(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxKnob(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxKnob(this.properties[i])) {
                        this.host.jqxKnob(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxKnobComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxKnobComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxKnobComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxKnobComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxKnobComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxKnob', options);
        this.__updateRect__();
    };
    jqxKnobComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxKnobComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxKnobComponent.prototype.setOptions = function (options) {
        this.host.jqxKnob('setOptions', options);
    };
    // jqxKnobComponent properties
    jqxKnobComponent.prototype.allowValueChangeOnClick = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('allowValueChangeOnClick', arg);
        }
        else {
            return this.host.jqxKnob('allowValueChangeOnClick');
        }
    };
    jqxKnobComponent.prototype.allowValueChangeOnDrag = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('allowValueChangeOnDrag', arg);
        }
        else {
            return this.host.jqxKnob('allowValueChangeOnDrag');
        }
    };
    jqxKnobComponent.prototype.allowValueChangeOnMouseWheel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('allowValueChangeOnMouseWheel', arg);
        }
        else {
            return this.host.jqxKnob('allowValueChangeOnMouseWheel');
        }
    };
    jqxKnobComponent.prototype.changing = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('changing', arg);
        }
        else {
            return this.host.jqxKnob('changing');
        }
    };
    jqxKnobComponent.prototype.dragEndAngle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('dragEndAngle', arg);
        }
        else {
            return this.host.jqxKnob('dragEndAngle');
        }
    };
    jqxKnobComponent.prototype.dragStartAngle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('dragStartAngle', arg);
        }
        else {
            return this.host.jqxKnob('dragStartAngle');
        }
    };
    jqxKnobComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('disabled', arg);
        }
        else {
            return this.host.jqxKnob('disabled');
        }
    };
    jqxKnobComponent.prototype.dial = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('dial', arg);
        }
        else {
            return this.host.jqxKnob('dial');
        }
    };
    jqxKnobComponent.prototype.endAngle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('endAngle', arg);
        }
        else {
            return this.host.jqxKnob('endAngle');
        }
    };
    jqxKnobComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('height', arg);
        }
        else {
            return this.host.jqxKnob('height');
        }
    };
    jqxKnobComponent.prototype.labels = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('labels', arg);
        }
        else {
            return this.host.jqxKnob('labels');
        }
    };
    jqxKnobComponent.prototype.marks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('marks', arg);
        }
        else {
            return this.host.jqxKnob('marks');
        }
    };
    jqxKnobComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('min', arg);
        }
        else {
            return this.host.jqxKnob('min');
        }
    };
    jqxKnobComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('max', arg);
        }
        else {
            return this.host.jqxKnob('max');
        }
    };
    jqxKnobComponent.prototype.progressBar = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('progressBar', arg);
        }
        else {
            return this.host.jqxKnob('progressBar');
        }
    };
    jqxKnobComponent.prototype.pointer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('pointer', arg);
        }
        else {
            return this.host.jqxKnob('pointer');
        }
    };
    jqxKnobComponent.prototype.pointerGrabAction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('pointerGrabAction', arg);
        }
        else {
            return this.host.jqxKnob('pointerGrabAction');
        }
    };
    jqxKnobComponent.prototype.rotation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('rotation', arg);
        }
        else {
            return this.host.jqxKnob('rotation');
        }
    };
    jqxKnobComponent.prototype.startAngle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('startAngle', arg);
        }
        else {
            return this.host.jqxKnob('startAngle');
        }
    };
    jqxKnobComponent.prototype.spinner = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('spinner', arg);
        }
        else {
            return this.host.jqxKnob('spinner');
        }
    };
    jqxKnobComponent.prototype.styles = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('styles', arg);
        }
        else {
            return this.host.jqxKnob('styles');
        }
    };
    jqxKnobComponent.prototype.step = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('step', arg);
        }
        else {
            return this.host.jqxKnob('step');
        }
    };
    jqxKnobComponent.prototype.snapToStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('snapToStep', arg);
        }
        else {
            return this.host.jqxKnob('snapToStep');
        }
    };
    jqxKnobComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('value', arg);
        }
        else {
            return this.host.jqxKnob('value');
        }
    };
    jqxKnobComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxKnob('width', arg);
        }
        else {
            return this.host.jqxKnob('width');
        }
    };
    // jqxKnobComponent functions
    jqxKnobComponent.prototype.destroy = function () {
        this.host.jqxKnob('destroy');
    };
    jqxKnobComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxKnob('val', value);
        }
        else {
            return this.host.jqxKnob('val');
        }
    };
    ;
    jqxKnobComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
    };
    __decorate([
        core_1.Input('allowValueChangeOnClick')
    ], jqxKnobComponent.prototype, "attrAllowValueChangeOnClick", void 0);
    __decorate([
        core_1.Input('allowValueChangeOnDrag')
    ], jqxKnobComponent.prototype, "attrAllowValueChangeOnDrag", void 0);
    __decorate([
        core_1.Input('allowValueChangeOnMouseWheel')
    ], jqxKnobComponent.prototype, "attrAllowValueChangeOnMouseWheel", void 0);
    __decorate([
        core_1.Input('changing')
    ], jqxKnobComponent.prototype, "attrChanging", void 0);
    __decorate([
        core_1.Input('dragEndAngle')
    ], jqxKnobComponent.prototype, "attrDragEndAngle", void 0);
    __decorate([
        core_1.Input('dragStartAngle')
    ], jqxKnobComponent.prototype, "attrDragStartAngle", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxKnobComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('dial')
    ], jqxKnobComponent.prototype, "attrDial", void 0);
    __decorate([
        core_1.Input('endAngle')
    ], jqxKnobComponent.prototype, "attrEndAngle", void 0);
    __decorate([
        core_1.Input('labels')
    ], jqxKnobComponent.prototype, "attrLabels", void 0);
    __decorate([
        core_1.Input('marks')
    ], jqxKnobComponent.prototype, "attrMarks", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxKnobComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxKnobComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('progressBar')
    ], jqxKnobComponent.prototype, "attrProgressBar", void 0);
    __decorate([
        core_1.Input('pointer')
    ], jqxKnobComponent.prototype, "attrPointer", void 0);
    __decorate([
        core_1.Input('pointerGrabAction')
    ], jqxKnobComponent.prototype, "attrPointerGrabAction", void 0);
    __decorate([
        core_1.Input('rotation')
    ], jqxKnobComponent.prototype, "attrRotation", void 0);
    __decorate([
        core_1.Input('startAngle')
    ], jqxKnobComponent.prototype, "attrStartAngle", void 0);
    __decorate([
        core_1.Input('spinner')
    ], jqxKnobComponent.prototype, "attrSpinner", void 0);
    __decorate([
        core_1.Input('styles')
    ], jqxKnobComponent.prototype, "attrStyles", void 0);
    __decorate([
        core_1.Input('step')
    ], jqxKnobComponent.prototype, "attrStep", void 0);
    __decorate([
        core_1.Input('snapToStep')
    ], jqxKnobComponent.prototype, "attrSnapToStep", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxKnobComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxKnobComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxKnobComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxKnobComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxKnobComponent.prototype, "onChange", void 0);
    jqxKnobComponent = __decorate([
        core_1.Component({
            selector: 'jqxKnob',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxKnobComponent);
    return jqxKnobComponent;
}()); //jqxKnobComponent
exports.jqxKnobComponent = jqxKnobComponent;
