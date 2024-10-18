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
require("../jqwidgets/jqxribbon.js");
require("../jqwidgets/jqxlayout.js");
require("../jqwidgets/jqxmenu.js");
require("../jqwidgets/jqxscrollbar.js");
require("../jqwidgets/jqxdockinglayout.js");
var core_1 = require("@angular/core");
var jqxDockingLayoutComponent = /** @class */ (function () {
    function jqxDockingLayoutComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['contextMenu', 'height', 'layout', 'minGroupHeight', 'minGroupWidth', 'resizable', 'rtl', 'theme', 'width'];
        // jqxDockingLayoutComponent events
        this.onDock = new core_1.EventEmitter();
        this.onFloatGroupClosed = new core_1.EventEmitter();
        this.onFloat = new core_1.EventEmitter();
        this.onPin = new core_1.EventEmitter();
        this.onResize = new core_1.EventEmitter();
        this.onUnpin = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxDockingLayoutComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxDockingLayoutComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxDockingLayout(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxDockingLayout(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxDockingLayout(this.properties[i])) {
                        this.host.jqxDockingLayout(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxDockingLayoutComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxDockingLayoutComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxDockingLayoutComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxDockingLayoutComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxDockingLayoutComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxDockingLayout', options);
    };
    jqxDockingLayoutComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxDockingLayoutComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxDockingLayoutComponent.prototype.setOptions = function (options) {
        this.host.jqxDockingLayout('setOptions', options);
    };
    // jqxDockingLayoutComponent properties
    jqxDockingLayoutComponent.prototype.contextMenu = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('contextMenu', arg);
        }
        else {
            return this.host.jqxDockingLayout('contextMenu');
        }
    };
    jqxDockingLayoutComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('height', arg);
        }
        else {
            return this.host.jqxDockingLayout('height');
        }
    };
    jqxDockingLayoutComponent.prototype.layout = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('layout', arg);
        }
        else {
            return this.host.jqxDockingLayout('layout');
        }
    };
    jqxDockingLayoutComponent.prototype.minGroupHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('minGroupHeight', arg);
        }
        else {
            return this.host.jqxDockingLayout('minGroupHeight');
        }
    };
    jqxDockingLayoutComponent.prototype.minGroupWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('minGroupWidth', arg);
        }
        else {
            return this.host.jqxDockingLayout('minGroupWidth');
        }
    };
    jqxDockingLayoutComponent.prototype.resizable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('resizable', arg);
        }
        else {
            return this.host.jqxDockingLayout('resizable');
        }
    };
    jqxDockingLayoutComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('rtl', arg);
        }
        else {
            return this.host.jqxDockingLayout('rtl');
        }
    };
    jqxDockingLayoutComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('theme', arg);
        }
        else {
            return this.host.jqxDockingLayout('theme');
        }
    };
    jqxDockingLayoutComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockingLayout('width', arg);
        }
        else {
            return this.host.jqxDockingLayout('width');
        }
    };
    // jqxDockingLayoutComponent functions
    jqxDockingLayoutComponent.prototype.addFloatGroup = function (width, height, position, panelType, title, content, initContent) {
        this.host.jqxDockingLayout('addFloatGroup', width, height, position, panelType, title, content, initContent);
    };
    jqxDockingLayoutComponent.prototype.destroy = function () {
        this.host.jqxDockingLayout('destroy');
    };
    jqxDockingLayoutComponent.prototype.loadLayout = function (layout) {
        this.host.jqxDockingLayout('loadLayout', layout);
    };
    jqxDockingLayoutComponent.prototype.refresh = function () {
        this.host.jqxDockingLayout('refresh');
    };
    jqxDockingLayoutComponent.prototype.render = function () {
        this.host.jqxDockingLayout('render');
    };
    jqxDockingLayoutComponent.prototype.saveLayout = function () {
        return this.host.jqxDockingLayout('saveLayout');
    };
    jqxDockingLayoutComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('dock', function (eventData) { _this.onDock.emit(eventData); });
        this.host.on('floatGroupClosed', function (eventData) { _this.onFloatGroupClosed.emit(eventData); });
        this.host.on('float', function (eventData) { _this.onFloat.emit(eventData); });
        this.host.on('pin', function (eventData) { _this.onPin.emit(eventData); });
        this.host.on('resize', function (eventData) { _this.onResize.emit(eventData); });
        this.host.on('unpin', function (eventData) { _this.onUnpin.emit(eventData); });
    };
    __decorate([
        core_1.Input('contextMenu')
    ], jqxDockingLayoutComponent.prototype, "attrContextMenu", void 0);
    __decorate([
        core_1.Input('layout')
    ], jqxDockingLayoutComponent.prototype, "attrLayout", void 0);
    __decorate([
        core_1.Input('minGroupHeight')
    ], jqxDockingLayoutComponent.prototype, "attrMinGroupHeight", void 0);
    __decorate([
        core_1.Input('minGroupWidth')
    ], jqxDockingLayoutComponent.prototype, "attrMinGroupWidth", void 0);
    __decorate([
        core_1.Input('resizable')
    ], jqxDockingLayoutComponent.prototype, "attrResizable", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxDockingLayoutComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxDockingLayoutComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxDockingLayoutComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxDockingLayoutComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxDockingLayoutComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingLayoutComponent.prototype, "onDock", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingLayoutComponent.prototype, "onFloatGroupClosed", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingLayoutComponent.prototype, "onFloat", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingLayoutComponent.prototype, "onPin", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingLayoutComponent.prototype, "onResize", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockingLayoutComponent.prototype, "onUnpin", void 0);
    jqxDockingLayoutComponent = __decorate([
        core_1.Component({
            selector: 'jqxDockingLayout',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxDockingLayoutComponent);
    return jqxDockingLayoutComponent;
}()); //jqxDockingLayoutComponent
exports.jqxDockingLayoutComponent = jqxDockingLayoutComponent;
