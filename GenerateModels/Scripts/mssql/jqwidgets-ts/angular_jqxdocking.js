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
require("../jqwidgets/jqxwindow.js");
require("../jqwidgets/jqxdocking.js");
var core_1 = require("@angular/core");
var jqxDockingComponent = /** @class */ (function () {
    function jqxDockingComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['cookies', 'cookieOptions', 'disabled', 'floatingWindowOpacity', 'height', 'keyboardNavigation', 'mode', 'orientation', 'rtl', 'theme', 'width', 'windowsMode', 'windowsOffset'];
        // jqxDockingComponent events
        this.onDragStart = new core_1.EventEmitter();
        this.onDragEnd = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxDockingComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxDockingComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxDocking(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxDocking(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxDocking(this.properties[i])) {
                        this.host.jqxDocking(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxDockingComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxDockingComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxDockingComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxDockingComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxDockingComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxDocking', options);
    };
    jqxDockingComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxDockingComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxDockingComponent.prototype.setOptions = function (options) {
        this.host.jqxDocking('setOptions', options);
    };
    // jqxDockingComponent properties
    jqxDockingComponent.prototype.cookies = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('cookies', arg);
        }
        else {
            return this.host.jqxDocking('cookies');
        }
    };
    jqxDockingComponent.prototype.cookieOptions = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('cookieOptions', arg);
        }
        else {
            return this.host.jqxDocking('cookieOptions');
        }
    };
    jqxDockingComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('disabled', arg);
        }
        else {
            return this.host.jqxDocking('disabled');
        }
    };
    jqxDockingComponent.prototype.floatingWindowOpacity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('floatingWindowOpacity', arg);
        }
        else {
            return this.host.jqxDocking('floatingWindowOpacity');
        }
    };
    jqxDockingComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('height', arg);
        }
        else {
            return this.host.jqxDocking('height');
        }
    };
    jqxDockingComponent.prototype.keyboardNavigation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('keyboardNavigation', arg);
        }
        else {
            return this.host.jqxDocking('keyboardNavigation');
        }
    };
    jqxDockingComponent.prototype.mode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('mode', arg);
        }
        else {
            return this.host.jqxDocking('mode');
        }
    };
    jqxDockingComponent.prototype.orientation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('orientation', arg);
        }
        else {
            return this.host.jqxDocking('orientation');
        }
    };
    jqxDockingComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('rtl', arg);
        }
        else {
            return this.host.jqxDocking('rtl');
        }
    };
    jqxDockingComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('theme', arg);
        }
        else {
            return this.host.jqxDocking('theme');
        }
    };
    jqxDockingComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('width', arg);
        }
        else {
            return this.host.jqxDocking('width');
        }
    };
    jqxDockingComponent.prototype.windowsMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('windowsMode', arg);
        }
        else {
            return this.host.jqxDocking('windowsMode');
        }
    };
    jqxDockingComponent.prototype.windowsOffset = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDocking('windowsOffset', arg);
        }
        else {
            return this.host.jqxDocking('windowsOffset');
        }
    };
    // jqxDockingComponent functions
    jqxDockingComponent.prototype.addWindow = function (windowId, mode, panel, position) {
        this.host.jqxDocking('addWindow', windowId, mode, panel, position);
    };
    jqxDockingComponent.prototype.closeWindow = function (windowId) {
        this.host.jqxDocking('closeWindow', windowId);
    };
    jqxDockingComponent.prototype.collapseWindow = function (windowId) {
        this.host.jqxDocking('collapseWindow', windowId);
    };
    jqxDockingComponent.prototype.destroy = function () {
        this.host.jqxDocking('destroy');
    };
    jqxDockingComponent.prototype.disableWindowResize = function (windowId) {
        this.host.jqxDocking('disableWindowResize', windowId);
    };
    jqxDockingComponent.prototype.disable = function () {
        this.host.jqxDocking('disable');
    };
    jqxDockingComponent.prototype.exportLayout = function () {
        return this.host.jqxDocking('exportLayout');
    };
    jqxDockingComponent.prototype.enable = function () {
        this.host.jqxDocking('enable');
    };
    jqxDockingComponent.prototype.expandWindow = function (windowId) {
        this.host.jqxDocking('expandWindow', windowId);
    };
    jqxDockingComponent.prototype.enableWindowResize = function (windowId) {
        this.host.jqxDocking('enableWindowResize', windowId);
    };
    jqxDockingComponent.prototype.focus = function () {
        this.host.jqxDocking('focus');
    };
    jqxDockingComponent.prototype.hideAllCloseButtons = function () {
        this.host.jqxDocking('hideAllCloseButtons');
    };
    jqxDockingComponent.prototype.hideAllCollapseButtons = function () {
        this.host.jqxDocking('hideAllCollapseButtons');
    };
    jqxDockingComponent.prototype.hideCollapseButton = function (windowId) {
        this.host.jqxDocking('hideCollapseButton', windowId);
    };
    jqxDockingComponent.prototype.hideCloseButton = function (windowId) {
        this.host.jqxDocking('hideCloseButton', windowId);
    };
    jqxDockingComponent.prototype.importLayout = function (Json) {
        this.host.jqxDocking('importLayout', Json);
    };
    jqxDockingComponent.prototype.move = function (windowId, panel, position) {
        this.host.jqxDocking('move', windowId, panel, position);
    };
    jqxDockingComponent.prototype.pinWindow = function (windowId) {
        this.host.jqxDocking('pinWindow', windowId);
    };
    jqxDockingComponent.prototype.setWindowMode = function (windowId, mode) {
        this.host.jqxDocking('setWindowMode', windowId, mode);
    };
    jqxDockingComponent.prototype.showCloseButton = function (windowId) {
        this.host.jqxDocking('showCloseButton', windowId);
    };
    jqxDockingComponent.prototype.showCollapseButton = function (windowId) {
        this.host.jqxDocking('showCollapseButton', windowId);
    };
    jqxDockingComponent.prototype.setWindowPosition = function (windowId, top, left) {
        this.host.jqxDocking('setWindowPosition', windowId, top, left);
    };
    jqxDockingComponent.prototype.showAllCloseButtons = function () {
        this.host.jqxDocking('showAllCloseButtons');
    };
    jqxDockingComponent.prototype.showAllCollapseButtons = function () {
        this.host.jqxDocking('showAllCollapseButtons');
    };
    jqxDockingComponent.prototype.unpinWindow = function (windowId) {
        this.host.jqxDocking('unpinWindow', windowId);
    };
    jqxDockingComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('dragStart', function (eventData) { _this.onDragStart.emit(eventData); });
        this.host.on('dragEnd', function (eventData) { _this.onDragEnd.emit(eventData); });
    };
    __decorate([
        core_1.Input('cookies')
    ], jqxDockingComponent.prototype, "attrCookies", void 0);
    __decorate([
        core_1.Input('cookieOptions')
    ], jqxDockingComponent.prototype, "attrCookieOptions", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxDockingComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('floatingWindowOpacity')
    ], jqxDockingComponent.prototype, "attrFloatingWindowOpacity", void 0);
    __decorate([
        core_1.Input('keyboardNavigation')
    ], jqxDockingComponent.prototype, "attrKeyboardNavigation", void 0);
    __decorate([
        core_1.Input('mode')
    ], jqxDockingComponent.prototype, "attrMode", void 0);
    __decorate([
        core_1.Input('orientation')
    ], jqxDockingComponent.prototype, "attrOrientation", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxDockingComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxDockingComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('windowsMode')
    ], jqxDockingComponent.prototype, "attrWindowsMode", void 0);
    __decorate([
        core_1.Input('windowsOffset')
    ], jqxDockingComponent.prototype, "attrWindowsOffset", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxDockingComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxDockingComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxDockingComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingComponent.prototype, "onDragStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingComponent.prototype, "onDragEnd", void 0);
    jqxDockingComponent = __decorate([
        core_1.Component({
            selector: 'jqxDocking',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxDockingComponent);
    return jqxDockingComponent;
}()); //jqxDockingComponent
exports.jqxDockingComponent = jqxDockingComponent;
