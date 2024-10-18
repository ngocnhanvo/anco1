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
require("../jqwidgets/jqxlistbox.js");
require("../jqwidgets/jqxdropdownlist.js");
require("../jqwidgets/jqxdropdownbutton.js");
require("../jqwidgets/jqxwindow.js");
require("../jqwidgets/jqxeditor.js");
require("../jqwidgets/jqxcheckbox.js");
require("../jqwidgets/jqxtooltip.js");
require("../jqwidgets/jqxcolorpicker.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxEditorComponent; }),
    multi: true
};
var jqxEditorComponent = /** @class */ (function () {
    function jqxEditorComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['createCommand', 'disabled', 'editable', 'height', 'lineBreak', 'localization', 'pasteMode', 'rtl', 'stylesheets', 'theme', 'toolbarPosition', 'tools', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxEditorComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxEditorComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxEditorComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxEditor(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxEditor(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxEditor(this.properties[i])) {
                        this.host.jqxEditor(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxEditorComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxEditorComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxEditorComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxEditorComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxEditorComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxEditor', options);
        this.host = this.widgetObject['host'];
        this.__wireEvents__();
    };
    jqxEditorComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxEditorComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxEditorComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxEditor('val', '');
        }
    };
    jqxEditorComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxEditorComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxEditorComponent.prototype.setOptions = function (options) {
        this.host.jqxEditor('setOptions', options);
    };
    // jqxEditorComponent properties
    jqxEditorComponent.prototype.createCommand = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('createCommand', arg);
        }
        else {
            return this.host.jqxEditor('createCommand');
        }
    };
    jqxEditorComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('disabled', arg);
        }
        else {
            return this.host.jqxEditor('disabled');
        }
    };
    jqxEditorComponent.prototype.editable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('editable', arg);
        }
        else {
            return this.host.jqxEditor('editable');
        }
    };
    jqxEditorComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('height', arg);
        }
        else {
            return this.host.jqxEditor('height');
        }
    };
    jqxEditorComponent.prototype.lineBreak = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('lineBreak', arg);
        }
        else {
            return this.host.jqxEditor('lineBreak');
        }
    };
    jqxEditorComponent.prototype.localization = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('localization', arg);
        }
        else {
            return this.host.jqxEditor('localization');
        }
    };
    jqxEditorComponent.prototype.pasteMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('pasteMode', arg);
        }
        else {
            return this.host.jqxEditor('pasteMode');
        }
    };
    jqxEditorComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('rtl', arg);
        }
        else {
            return this.host.jqxEditor('rtl');
        }
    };
    jqxEditorComponent.prototype.stylesheets = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('stylesheets', arg);
        }
        else {
            return this.host.jqxEditor('stylesheets');
        }
    };
    jqxEditorComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('theme', arg);
        }
        else {
            return this.host.jqxEditor('theme');
        }
    };
    jqxEditorComponent.prototype.toolbarPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('toolbarPosition', arg);
        }
        else {
            return this.host.jqxEditor('toolbarPosition');
        }
    };
    jqxEditorComponent.prototype.tools = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('tools', arg);
        }
        else {
            return this.host.jqxEditor('tools');
        }
    };
    jqxEditorComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxEditor('width', arg);
        }
        else {
            return this.host.jqxEditor('width');
        }
    };
    // jqxEditorComponent functions
    jqxEditorComponent.prototype.destroy = function () {
        this.host.jqxEditor('destroy');
    };
    jqxEditorComponent.prototype.focus = function () {
        this.host.jqxEditor('focus');
    };
    jqxEditorComponent.prototype.print = function () {
        this.host.jqxEditor('print');
    };
    jqxEditorComponent.prototype.setMode = function (mode) {
        this.host.jqxEditor('setMode', mode);
    };
    jqxEditorComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxEditor('val', value);
        }
        else {
            return this.host.jqxEditor('val');
        }
    };
    ;
    jqxEditorComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); _this.onChangeCallback(_this.host.val()); });
    };
    __decorate([
        core_1.Input('createCommand')
    ], jqxEditorComponent.prototype, "attrCreateCommand", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxEditorComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('editable')
    ], jqxEditorComponent.prototype, "attrEditable", void 0);
    __decorate([
        core_1.Input('lineBreak')
    ], jqxEditorComponent.prototype, "attrLineBreak", void 0);
    __decorate([
        core_1.Input('localization')
    ], jqxEditorComponent.prototype, "attrLocalization", void 0);
    __decorate([
        core_1.Input('pasteMode')
    ], jqxEditorComponent.prototype, "attrPasteMode", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxEditorComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('stylesheets')
    ], jqxEditorComponent.prototype, "attrStylesheets", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxEditorComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('toolbarPosition')
    ], jqxEditorComponent.prototype, "attrToolbarPosition", void 0);
    __decorate([
        core_1.Input('tools')
    ], jqxEditorComponent.prototype, "attrTools", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxEditorComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxEditorComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxEditorComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxEditorComponent.prototype, "onChange", void 0);
    jqxEditorComponent = __decorate([
        core_1.Component({
            selector: 'jqxEditor',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxEditorComponent);
    return jqxEditorComponent;
}()); //jqxEditorComponent
exports.jqxEditorComponent = jqxEditorComponent;
