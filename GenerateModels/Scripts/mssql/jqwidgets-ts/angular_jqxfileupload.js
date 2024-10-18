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
require("../jqwidgets/jqxfileupload.js");
var core_1 = require("@angular/core");
var jqxFileUploadComponent = /** @class */ (function () {
    function jqxFileUploadComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoUpload', 'accept', 'browseTemplate', 'cancelTemplate', 'disabled', 'fileInputName', 'height', 'localization', 'multipleFilesUpload', 'renderFiles', 'rtl', 'theme', 'uploadUrl', 'uploadTemplate', 'width'];
        // jqxFileUploadComponent events
        this.onRemove = new core_1.EventEmitter();
        this.onSelect = new core_1.EventEmitter();
        this.onUploadStart = new core_1.EventEmitter();
        this.onUploadEnd = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxFileUploadComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxFileUploadComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxFileUpload(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxFileUpload(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxFileUpload(this.properties[i])) {
                        this.host.jqxFileUpload(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxFileUploadComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxFileUploadComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxFileUploadComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxFileUploadComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxFileUploadComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxFileUpload', options);
    };
    jqxFileUploadComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxFileUploadComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxFileUploadComponent.prototype.setOptions = function (options) {
        this.host.jqxFileUpload('setOptions', options);
    };
    // jqxFileUploadComponent properties
    jqxFileUploadComponent.prototype.autoUpload = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('autoUpload', arg);
        }
        else {
            return this.host.jqxFileUpload('autoUpload');
        }
    };
    jqxFileUploadComponent.prototype.accept = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('accept', arg);
        }
        else {
            return this.host.jqxFileUpload('accept');
        }
    };
    jqxFileUploadComponent.prototype.browseTemplate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('browseTemplate', arg);
        }
        else {
            return this.host.jqxFileUpload('browseTemplate');
        }
    };
    jqxFileUploadComponent.prototype.cancelTemplate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('cancelTemplate', arg);
        }
        else {
            return this.host.jqxFileUpload('cancelTemplate');
        }
    };
    jqxFileUploadComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('disabled', arg);
        }
        else {
            return this.host.jqxFileUpload('disabled');
        }
    };
    jqxFileUploadComponent.prototype.fileInputName = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('fileInputName', arg);
        }
        else {
            return this.host.jqxFileUpload('fileInputName');
        }
    };
    jqxFileUploadComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('height', arg);
        }
        else {
            return this.host.jqxFileUpload('height');
        }
    };
    jqxFileUploadComponent.prototype.localization = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('localization', arg);
        }
        else {
            return this.host.jqxFileUpload('localization');
        }
    };
    jqxFileUploadComponent.prototype.multipleFilesUpload = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('multipleFilesUpload', arg);
        }
        else {
            return this.host.jqxFileUpload('multipleFilesUpload');
        }
    };
    jqxFileUploadComponent.prototype.renderFiles = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('renderFiles', arg);
        }
        else {
            return this.host.jqxFileUpload('renderFiles');
        }
    };
    jqxFileUploadComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('rtl', arg);
        }
        else {
            return this.host.jqxFileUpload('rtl');
        }
    };
    jqxFileUploadComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('theme', arg);
        }
        else {
            return this.host.jqxFileUpload('theme');
        }
    };
    jqxFileUploadComponent.prototype.uploadUrl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('uploadUrl', arg);
        }
        else {
            return this.host.jqxFileUpload('uploadUrl');
        }
    };
    jqxFileUploadComponent.prototype.uploadTemplate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('uploadTemplate', arg);
        }
        else {
            return this.host.jqxFileUpload('uploadTemplate');
        }
    };
    jqxFileUploadComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxFileUpload('width', arg);
        }
        else {
            return this.host.jqxFileUpload('width');
        }
    };
    // jqxFileUploadComponent functions
    jqxFileUploadComponent.prototype.browse = function () {
        this.host.jqxFileUpload('browse');
    };
    jqxFileUploadComponent.prototype.cancelFile = function (fileIndex) {
        this.host.jqxFileUpload('cancelFile', fileIndex);
    };
    jqxFileUploadComponent.prototype.cancelAll = function () {
        this.host.jqxFileUpload('cancelAll');
    };
    jqxFileUploadComponent.prototype.destroy = function () {
        this.host.jqxFileUpload('destroy');
    };
    jqxFileUploadComponent.prototype.render = function () {
        this.host.jqxFileUpload('render');
    };
    jqxFileUploadComponent.prototype.refresh = function () {
        this.host.jqxFileUpload('refresh');
    };
    jqxFileUploadComponent.prototype.uploadFile = function (fileIndex) {
        this.host.jqxFileUpload('uploadFile', fileIndex);
    };
    jqxFileUploadComponent.prototype.uploadAll = function () {
        this.host.jqxFileUpload('uploadAll');
    };
    jqxFileUploadComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('remove', function (eventData) { _this.onRemove.emit(eventData); });
        this.host.on('select', function (eventData) { _this.onSelect.emit(eventData); });
        this.host.on('uploadStart', function (eventData) { _this.onUploadStart.emit(eventData); });
        this.host.on('uploadEnd', function (eventData) { _this.onUploadEnd.emit(eventData); });
    };
    __decorate([
        core_1.Input('autoUpload')
    ], jqxFileUploadComponent.prototype, "attrAutoUpload", void 0);
    __decorate([
        core_1.Input('accept')
    ], jqxFileUploadComponent.prototype, "attrAccept", void 0);
    __decorate([
        core_1.Input('browseTemplate')
    ], jqxFileUploadComponent.prototype, "attrBrowseTemplate", void 0);
    __decorate([
        core_1.Input('cancelTemplate')
    ], jqxFileUploadComponent.prototype, "attrCancelTemplate", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxFileUploadComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('fileInputName')
    ], jqxFileUploadComponent.prototype, "attrFileInputName", void 0);
    __decorate([
        core_1.Input('localization')
    ], jqxFileUploadComponent.prototype, "attrLocalization", void 0);
    __decorate([
        core_1.Input('multipleFilesUpload')
    ], jqxFileUploadComponent.prototype, "attrMultipleFilesUpload", void 0);
    __decorate([
        core_1.Input('renderFiles')
    ], jqxFileUploadComponent.prototype, "attrRenderFiles", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxFileUploadComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxFileUploadComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('uploadUrl')
    ], jqxFileUploadComponent.prototype, "attrUploadUrl", void 0);
    __decorate([
        core_1.Input('uploadTemplate')
    ], jqxFileUploadComponent.prototype, "attrUploadTemplate", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxFileUploadComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxFileUploadComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxFileUploadComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxFileUploadComponent.prototype, "onRemove", void 0);
    __decorate([
        core_1.Output()
    ], jqxFileUploadComponent.prototype, "onSelect", void 0);
    __decorate([
        core_1.Output()
    ], jqxFileUploadComponent.prototype, "onUploadStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxFileUploadComponent.prototype, "onUploadEnd", void 0);
    jqxFileUploadComponent = __decorate([
        core_1.Component({
            selector: 'jqxFileUpload',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxFileUploadComponent);
    return jqxFileUploadComponent;
}()); //jqxFileUploadComponent
exports.jqxFileUploadComponent = jqxFileUploadComponent;
