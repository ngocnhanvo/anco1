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
require("../jqwidgets/jqxrating.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxRatingComponent; }),
    multi: true
};
var jqxRatingComponent = /** @class */ (function () {
    function jqxRatingComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['count', 'disabled', 'height', 'itemHeight', 'itemWidth', 'precision', 'singleVote', 'value', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxRatingComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxRatingComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxRatingComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxRating(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxRating(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxRating(this.properties[i])) {
                        this.host.jqxRating(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxRatingComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxRatingComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxRatingComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxRatingComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxRatingComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxRating', options);
    };
    jqxRatingComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxRatingComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxRatingComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxRating('val', '');
        }
    };
    jqxRatingComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxRatingComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxRatingComponent.prototype.setOptions = function (options) {
        this.host.jqxRating('setOptions', options);
    };
    // jqxRatingComponent properties
    jqxRatingComponent.prototype.count = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('count', arg);
        }
        else {
            return this.host.jqxRating('count');
        }
    };
    jqxRatingComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('disabled', arg);
        }
        else {
            return this.host.jqxRating('disabled');
        }
    };
    jqxRatingComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('height', arg);
        }
        else {
            return this.host.jqxRating('height');
        }
    };
    jqxRatingComponent.prototype.itemHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('itemHeight', arg);
        }
        else {
            return this.host.jqxRating('itemHeight');
        }
    };
    jqxRatingComponent.prototype.itemWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('itemWidth', arg);
        }
        else {
            return this.host.jqxRating('itemWidth');
        }
    };
    jqxRatingComponent.prototype.precision = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('precision', arg);
        }
        else {
            return this.host.jqxRating('precision');
        }
    };
    jqxRatingComponent.prototype.singleVote = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('singleVote', arg);
        }
        else {
            return this.host.jqxRating('singleVote');
        }
    };
    jqxRatingComponent.prototype.value = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('value', arg);
        }
        else {
            return this.host.jqxRating('value');
        }
    };
    jqxRatingComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRating('width', arg);
        }
        else {
            return this.host.jqxRating('width');
        }
    };
    // jqxRatingComponent functions
    jqxRatingComponent.prototype.disable = function () {
        this.host.jqxRating('disable');
    };
    jqxRatingComponent.prototype.enable = function () {
        this.host.jqxRating('enable');
    };
    jqxRatingComponent.prototype.getValue = function () {
        return this.host.jqxRating('getValue');
    };
    jqxRatingComponent.prototype.setValue = function (value) {
        this.host.jqxRating('setValue', value);
    };
    jqxRatingComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxRating('val', value);
        }
        else {
            return this.host.jqxRating('val');
        }
    };
    ;
    jqxRatingComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); _this.onChangeCallback(_this.host.val()); });
    };
    __decorate([
        core_1.Input('count')
    ], jqxRatingComponent.prototype, "attrCount", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxRatingComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('itemHeight')
    ], jqxRatingComponent.prototype, "attrItemHeight", void 0);
    __decorate([
        core_1.Input('itemWidth')
    ], jqxRatingComponent.prototype, "attrItemWidth", void 0);
    __decorate([
        core_1.Input('precision')
    ], jqxRatingComponent.prototype, "attrPrecision", void 0);
    __decorate([
        core_1.Input('singleVote')
    ], jqxRatingComponent.prototype, "attrSingleVote", void 0);
    __decorate([
        core_1.Input('value')
    ], jqxRatingComponent.prototype, "attrValue", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxRatingComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxRatingComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxRatingComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxRatingComponent.prototype, "onChange", void 0);
    jqxRatingComponent = __decorate([
        core_1.Component({
            selector: 'jqxRating',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxRatingComponent);
    return jqxRatingComponent;
}()); //jqxRatingComponent
exports.jqxRatingComponent = jqxRatingComponent;
