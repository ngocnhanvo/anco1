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
require("../jqwidgets/jqxribbon.js");
require("../jqwidgets/jqxmenu.js");
require("../jqwidgets/jqxlayout.js");
var core_1 = require("@angular/core");
var jqxLayoutComponent = /** @class */ (function () {
    function jqxLayoutComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['contextMenu', 'height', 'layout', 'minGroupHeight', 'minGroupWidth', 'resizable', 'rtl', 'theme', 'width'];
        // jqxLayoutComponent events
        this.onPin = new core_1.EventEmitter();
        this.onResize = new core_1.EventEmitter();
        this.onUnpin = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxLayoutComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxLayoutComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxLayout(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxLayout(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxLayout(this.properties[i])) {
                        this.host.jqxLayout(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxLayoutComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxLayoutComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxLayoutComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxLayoutComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxLayoutComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxLayout', options);
    };
    jqxLayoutComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxLayoutComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxLayoutComponent.prototype.setOptions = function (options) {
        this.host.jqxLayout('setOptions', options);
    };
    // jqxLayoutComponent properties
    jqxLayoutComponent.prototype.contextMenu = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('contextMenu', arg);
        }
        else {
            return this.host.jqxLayout('contextMenu');
        }
    };
    jqxLayoutComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('height', arg);
        }
        else {
            return this.host.jqxLayout('height');
        }
    };
    jqxLayoutComponent.prototype.layout = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('layout', arg);
        }
        else {
            return this.host.jqxLayout('layout');
        }
    };
    jqxLayoutComponent.prototype.minGroupHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('minGroupHeight', arg);
        }
        else {
            return this.host.jqxLayout('minGroupHeight');
        }
    };
    jqxLayoutComponent.prototype.minGroupWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('minGroupWidth', arg);
        }
        else {
            return this.host.jqxLayout('minGroupWidth');
        }
    };
    jqxLayoutComponent.prototype.resizable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('resizable', arg);
        }
        else {
            return this.host.jqxLayout('resizable');
        }
    };
    jqxLayoutComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('rtl', arg);
        }
        else {
            return this.host.jqxLayout('rtl');
        }
    };
    jqxLayoutComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('theme', arg);
        }
        else {
            return this.host.jqxLayout('theme');
        }
    };
    jqxLayoutComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxLayout('width', arg);
        }
        else {
            return this.host.jqxLayout('width');
        }
    };
    // jqxLayoutComponent functions
    jqxLayoutComponent.prototype.destroy = function () {
        this.host.jqxLayout('destroy');
    };
    jqxLayoutComponent.prototype.loadLayout = function (Layout) {
        this.host.jqxLayout('loadLayout', Layout);
    };
    jqxLayoutComponent.prototype.refresh = function () {
        this.host.jqxLayout('refresh');
    };
    jqxLayoutComponent.prototype.render = function () {
        this.host.jqxLayout('render');
    };
    jqxLayoutComponent.prototype.saveLayout = function () {
        return this.host.jqxLayout('saveLayout');
    };
    jqxLayoutComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('pin', function (eventData) { _this.onPin.emit(eventData); });
        this.host.on('resize', function (eventData) { _this.onResize.emit(eventData); });
        this.host.on('unpin', function (eventData) { _this.onUnpin.emit(eventData); });
    };
    __decorate([
        core_1.Input('contextMenu')
    ], jqxLayoutComponent.prototype, "attrContextMenu", void 0);
    __decorate([
        core_1.Input('layout')
    ], jqxLayoutComponent.prototype, "attrLayout", void 0);
    __decorate([
        core_1.Input('minGroupHeight')
    ], jqxLayoutComponent.prototype, "attrMinGroupHeight", void 0);
    __decorate([
        core_1.Input('minGroupWidth')
    ], jqxLayoutComponent.prototype, "attrMinGroupWidth", void 0);
    __decorate([
        core_1.Input('resizable')
    ], jqxLayoutComponent.prototype, "attrResizable", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxLayoutComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxLayoutComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxLayoutComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxLayoutComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxLayoutComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxLayoutComponent.prototype, "onPin", void 0);
    __decorate([
        core_1.Output()
    ], jqxLayoutComponent.prototype, "onResize", void 0);
    __decorate([
        core_1.Output()
    ], jqxLayoutComponent.prototype, "onUnpin", void 0);
    jqxLayoutComponent = __decorate([
        core_1.Component({
            selector: 'jqxLayout',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxLayoutComponent);
    return jqxLayoutComponent;
}()); //jqxLayoutComponent
exports.jqxLayoutComponent = jqxLayoutComponent;
