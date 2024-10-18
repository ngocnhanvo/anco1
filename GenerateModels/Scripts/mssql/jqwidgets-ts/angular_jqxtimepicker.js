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
require("../jqwidgets/jqxtimepicker.js");
var core_1 = require("@angular/core");
var jqxTimePickerComponent = /** @class */ (function () {
    function jqxTimePickerComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoSwitchToMinutes', 'disabled', 'footer', 'footerTemplate', 'format', 'height', 'minuteInterval', 'name', 'readonly', 'selection', 'theme', 'unfocusable', 'value', 'view', 'width'];
        // jqxTimePickerComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxTimePickerComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxTimePickerComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxTimePicker(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxTimePicker(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxTimePicker(this.properties[i])) {
                        this.host.jqxTimePicker(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxTimePickerComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxTimePickerComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxTimePickerComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxTimePickerComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxTimePickerComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxTimePicker', options);
    };
    jqxTimePickerComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxTimePickerComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxTimePickerComponent.prototype.setOptions = function (options) {
        this.host.jqxTimePicker('setOptions', options);
    };
    // jqxTimePickerComponent properties
    jqxTimePickerComponent.prototype.autoSwitchToMinutes = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('autoSwitchToMinutes', arg);
        }
        else {
            return this.host.jqxTimePicker('autoSwitchToMinutes');
        }
    };
    jqxTimePickerComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('disabled', arg);
        }
        else {
            return this.host.jqxTimePicker('disabled');
        }
    };
    jqxTimePickerComponent.prototype.footer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('footer', arg);
        }
        else {
            return this.host.jqxTimePicker('footer');
        }
    };
    jqxTimePickerComponent.prototype.footerTemplate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('footerTemplate', arg);
        }
        else {
            return this.host.jqxTimePicker('footerTemplate');
        }
    };
    jqxTimePickerComponent.prototype.format = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('format', arg);
        }
        else {
            return this.host.jqxTimePicker('format');
        }
    };
    jqxTimePickerComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('height', arg);
        }
        else {
            return this.host.jqxTimePicker('height');
        }
    };
    jqxTimePickerComponent.prototype.minuteInterval = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('minuteInterval', arg);
        }
        else {
            return this.host.jqxTimePicker('minuteInterval');
        }
    };
    jqxTimePickerComponent.prototype.name = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('name', arg);
        }
        else {
            return this.host.jqxTimePicker('name');
        }
    };
    jqxTimePickerComponent.prototype.readonly = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('readonly', arg);
        }
        else {
            return this.host.jqxTimePicker('readonly');
        }
    };
    jqxTimePickerComponent.prototype.selection = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('selection', arg);
        }
        else {
            return this.host.jqxTimePicker('selection');
        }
    };
    jqxTimePickerComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('theme', arg);
        }
        else {
            return this.host.jqxTimePicker('theme');
        }
    };
    jqxTimePickerComponent.prototype.unfocusable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('unfocusable', arg);
        }
        else {
            return this.host.jqxTimePicker('unfocusable');
        }
    };
    jqxTimePickerComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('value', arg);
        }
        else {
            return this.host.jqxTimePicker('value');
        }
    };
    jqxTimePickerComponent.prototype.view = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('view', arg);
        }
        else {
            return this.host.jqxTimePicker('view');
        }
    };
    jqxTimePickerComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimePicker('width', arg);
        }
        else {
            return this.host.jqxTimePicker('width');
        }
    };
    // jqxTimePickerComponent functions
    jqxTimePickerComponent.prototype.setHours = function (hours) {
        this.host.jqxTimePicker('setHours', hours);
    };
    jqxTimePickerComponent.prototype.setMinutes = function (minutes) {
        this.host.jqxTimePicker('setMinutes', minutes);
    };
    jqxTimePickerComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
    };
    __decorate([
        core_1.Input('autoSwitchToMinutes')
    ], jqxTimePickerComponent.prototype, "attrAutoSwitchToMinutes", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxTimePickerComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('footer')
    ], jqxTimePickerComponent.prototype, "attrFooter", void 0);
    __decorate([
        core_1.Input('footerTemplate')
    ], jqxTimePickerComponent.prototype, "attrFooterTemplate", void 0);
    __decorate([
        core_1.Input('format')
    ], jqxTimePickerComponent.prototype, "attrFormat", void 0);
    __decorate([
        core_1.Input('minuteInterval')
    ], jqxTimePickerComponent.prototype, "attrMinuteInterval", void 0);
    __decorate([
        core_1.Input('name')
    ], jqxTimePickerComponent.prototype, "attrName", void 0);
    __decorate([
        core_1.Input('readonly')
    ], jqxTimePickerComponent.prototype, "attrReadonly", void 0);
    __decorate([
        core_1.Input('selection')
    ], jqxTimePickerComponent.prototype, "attrSelection", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxTimePickerComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('unfocusable')
    ], jqxTimePickerComponent.prototype, "attrUnfocusable", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxTimePickerComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('view')
    ], jqxTimePickerComponent.prototype, "attrView", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxTimePickerComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxTimePickerComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxTimePickerComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxTimePickerComponent.prototype, "onChange", void 0);
    jqxTimePickerComponent = __decorate([
        core_1.Component({
            selector: 'jqxTimePicker',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxTimePickerComponent);
    return jqxTimePickerComponent;
}()); //jqxTimePickerComponent
exports.jqxTimePickerComponent = jqxTimePickerComponent;
