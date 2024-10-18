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
require("../jqwidgets/jqxdata.js");
require("../jqwidgets/jqxbuttons.js");
require("../jqwidgets/jqxscrollbar.js");
require("../jqwidgets/jqxtextarea.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxTextAreaComponent; }),
    multi: true
};
var jqxTextAreaComponent = /** @class */ (function () {
    function jqxTextAreaComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'displayMember', 'dropDownWidth', 'height', 'items', 'maxLength', 'minLength', 'opened', 'placeHolder', 'popupZIndex', 'query', 'renderer', 'roundedCorners', 'rtl', 'scrollBarSize', 'searchMode', 'source', 'theme', 'valueMember', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxTextAreaComponent events
        this.onChange = new core_1.EventEmitter();
        this.onClose = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.onSelect = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxTextAreaComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxTextAreaComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxTextArea(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxTextArea(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxTextArea(this.properties[i])) {
                        this.host.jqxTextArea(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxTextAreaComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxTextAreaComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxTextAreaComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxTextAreaComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxTextAreaComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxTextArea', options);
    };
    jqxTextAreaComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxTextAreaComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxTextAreaComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            if (value !== null && value !== undefined)
                this.host.jqxTextArea('val', value);
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxTextArea('val', '');
        }
    };
    jqxTextAreaComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxTextAreaComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxTextAreaComponent.prototype.setOptions = function (options) {
        this.host.jqxTextArea('setOptions', options);
    };
    // jqxTextAreaComponent properties
    jqxTextAreaComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('disabled', arg);
        }
        else {
            return this.host.jqxTextArea('disabled');
        }
    };
    jqxTextAreaComponent.prototype.displayMember = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('displayMember', arg);
        }
        else {
            return this.host.jqxTextArea('displayMember');
        }
    };
    jqxTextAreaComponent.prototype.dropDownWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('dropDownWidth', arg);
        }
        else {
            return this.host.jqxTextArea('dropDownWidth');
        }
    };
    jqxTextAreaComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('height', arg);
        }
        else {
            return this.host.jqxTextArea('height');
        }
    };
    jqxTextAreaComponent.prototype.items = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('items', arg);
        }
        else {
            return this.host.jqxTextArea('items');
        }
    };
    jqxTextAreaComponent.prototype.maxLength = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('maxLength', arg);
        }
        else {
            return this.host.jqxTextArea('maxLength');
        }
    };
    jqxTextAreaComponent.prototype.minLength = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('minLength', arg);
        }
        else {
            return this.host.jqxTextArea('minLength');
        }
    };
    jqxTextAreaComponent.prototype.opened = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('opened', arg);
        }
        else {
            return this.host.jqxTextArea('opened');
        }
    };
    jqxTextAreaComponent.prototype.placeHolder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('placeHolder', arg);
        }
        else {
            return this.host.jqxTextArea('placeHolder');
        }
    };
    jqxTextAreaComponent.prototype.popupZIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('popupZIndex', arg);
        }
        else {
            return this.host.jqxTextArea('popupZIndex');
        }
    };
    jqxTextAreaComponent.prototype.query = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('query', arg);
        }
        else {
            return this.host.jqxTextArea('query');
        }
    };
    jqxTextAreaComponent.prototype.renderer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('renderer', arg);
        }
        else {
            return this.host.jqxTextArea('renderer');
        }
    };
    jqxTextAreaComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('roundedCorners', arg);
        }
        else {
            return this.host.jqxTextArea('roundedCorners');
        }
    };
    jqxTextAreaComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('rtl', arg);
        }
        else {
            return this.host.jqxTextArea('rtl');
        }
    };
    jqxTextAreaComponent.prototype.scrollBarSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('scrollBarSize', arg);
        }
        else {
            return this.host.jqxTextArea('scrollBarSize');
        }
    };
    jqxTextAreaComponent.prototype.searchMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('searchMode', arg);
        }
        else {
            return this.host.jqxTextArea('searchMode');
        }
    };
    jqxTextAreaComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('source', arg);
        }
        else {
            return this.host.jqxTextArea('source');
        }
    };
    jqxTextAreaComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('theme', arg);
        }
        else {
            return this.host.jqxTextArea('theme');
        }
    };
    jqxTextAreaComponent.prototype.valueMember = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('valueMember', arg);
        }
        else {
            return this.host.jqxTextArea('valueMember');
        }
    };
    jqxTextAreaComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTextArea('width', arg);
        }
        else {
            return this.host.jqxTextArea('width');
        }
    };
    // jqxTextAreaComponent functions
    jqxTextAreaComponent.prototype.destroy = function () {
        this.host.jqxTextArea('destroy');
    };
    jqxTextAreaComponent.prototype.focus = function () {
        this.host.jqxTextArea('focus');
    };
    jqxTextAreaComponent.prototype.refresh = function () {
        this.host.jqxTextArea('refresh');
    };
    jqxTextAreaComponent.prototype.render = function () {
        this.host.jqxTextArea('render');
    };
    jqxTextAreaComponent.prototype.selectAll = function () {
        this.host.jqxTextArea('selectAll');
    };
    jqxTextAreaComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxTextArea('val', value);
        }
        else {
            return this.host.jqxTextArea('val');
        }
    };
    ;
    jqxTextAreaComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); _this.onChangeCallback(_this.host.val()); });
        this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
        this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        this.host.on('select', function (eventData) { _this.onSelect.emit(eventData); });
        this.host.on('keyup', function () { _this.onChangeCallback(_this.host.val()); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxTextAreaComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('displayMember')
    ], jqxTextAreaComponent.prototype, "attrDisplayMember", void 0);
    __decorate([
        core_1.Input('dropDownWidth')
    ], jqxTextAreaComponent.prototype, "attrDropDownWidth", void 0);
    __decorate([
        core_1.Input('items')
    ], jqxTextAreaComponent.prototype, "attrItems", void 0);
    __decorate([
        core_1.Input('maxLength')
    ], jqxTextAreaComponent.prototype, "attrMaxLength", void 0);
    __decorate([
        core_1.Input('minLength')
    ], jqxTextAreaComponent.prototype, "attrMinLength", void 0);
    __decorate([
        core_1.Input('opened')
    ], jqxTextAreaComponent.prototype, "attrOpened", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxTextAreaComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('popupZIndex')
    ], jqxTextAreaComponent.prototype, "attrPopupZIndex", void 0);
    __decorate([
        core_1.Input('query')
    ], jqxTextAreaComponent.prototype, "attrQuery", void 0);
    __decorate([
        core_1.Input('renderer')
    ], jqxTextAreaComponent.prototype, "attrRenderer", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxTextAreaComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxTextAreaComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('scrollBarSize')
    ], jqxTextAreaComponent.prototype, "attrScrollBarSize", void 0);
    __decorate([
        core_1.Input('searchMode')
    ], jqxTextAreaComponent.prototype, "attrSearchMode", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxTextAreaComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxTextAreaComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('valueMember')
    ], jqxTextAreaComponent.prototype, "attrValueMember", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxTextAreaComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxTextAreaComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxTextAreaComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxTextAreaComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxTextAreaComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxTextAreaComponent.prototype, "onOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxTextAreaComponent.prototype, "onSelect", void 0);
    jqxTextAreaComponent = __decorate([
        core_1.Component({
            selector: 'jqxTextArea',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxTextAreaComponent);
    return jqxTextAreaComponent;
}()); //jqxTextAreaComponent
exports.jqxTextAreaComponent = jqxTextAreaComponent;
