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
require("../jqwidgets/jqxsplitter.js");
var core_1 = require("@angular/core");
var jqxSplitterComponent = /** @class */ (function () {
    function jqxSplitterComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'orientation', 'panels', 'resizable', 'splitBarSize', 'showSplitBar', 'theme', 'width'];
        // jqxSplitterComponent events
        this.onCollapsed = new core_1.EventEmitter();
        this.onExpanded = new core_1.EventEmitter();
        this.onResize = new core_1.EventEmitter();
        this.onResizeStart = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxSplitterComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxSplitterComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxSplitter(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxSplitter(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxSplitter(this.properties[i])) {
                        this.host.jqxSplitter(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxSplitterComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxSplitterComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxSplitterComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxSplitterComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxSplitterComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxSplitter', options);
    };
    jqxSplitterComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxSplitterComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxSplitterComponent.prototype.setOptions = function (options) {
        this.host.jqxSplitter('setOptions', options);
    };
    // jqxSplitterComponent properties
    jqxSplitterComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('disabled', arg);
        }
        else {
            return this.host.jqxSplitter('disabled');
        }
    };
    jqxSplitterComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('height', arg);
        }
        else {
            return this.host.jqxSplitter('height');
        }
    };
    jqxSplitterComponent.prototype.orientation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('orientation', arg);
        }
        else {
            return this.host.jqxSplitter('orientation');
        }
    };
    jqxSplitterComponent.prototype.panels = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('panels', arg);
        }
        else {
            return this.host.jqxSplitter('panels');
        }
    };
    jqxSplitterComponent.prototype.resizable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('resizable', arg);
        }
        else {
            return this.host.jqxSplitter('resizable');
        }
    };
    jqxSplitterComponent.prototype.splitBarSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('splitBarSize', arg);
        }
        else {
            return this.host.jqxSplitter('splitBarSize');
        }
    };
    jqxSplitterComponent.prototype.showSplitBar = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('showSplitBar', arg);
        }
        else {
            return this.host.jqxSplitter('showSplitBar');
        }
    };
    jqxSplitterComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('theme', arg);
        }
        else {
            return this.host.jqxSplitter('theme');
        }
    };
    jqxSplitterComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitter('width', arg);
        }
        else {
            return this.host.jqxSplitter('width');
        }
    };
    // jqxSplitterComponent functions
    jqxSplitterComponent.prototype.collapse = function () {
        this.host.jqxSplitter('collapse');
    };
    jqxSplitterComponent.prototype.destroy = function () {
        this.host.jqxSplitter('destroy');
    };
    jqxSplitterComponent.prototype.disable = function () {
        this.host.jqxSplitter('disable');
    };
    jqxSplitterComponent.prototype.enable = function () {
        this.host.jqxSplitter('enable');
    };
    jqxSplitterComponent.prototype.expand = function () {
        this.host.jqxSplitter('expand');
    };
    jqxSplitterComponent.prototype.render = function () {
        this.host.jqxSplitter('render');
    };
    jqxSplitterComponent.prototype.refresh = function () {
        this.host.jqxSplitter('refresh');
    };
    jqxSplitterComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('collapsed', function (eventData) { _this.onCollapsed.emit(eventData); });
        this.host.on('expanded', function (eventData) { _this.onExpanded.emit(eventData); });
        this.host.on('resize', function (eventData) { _this.onResize.emit(eventData); });
        this.host.on('resizeStart', function (eventData) { _this.onResizeStart.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxSplitterComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('orientation')
    ], jqxSplitterComponent.prototype, "attrOrientation", void 0);
    __decorate([
        core_1.Input('panels')
    ], jqxSplitterComponent.prototype, "attrPanels", void 0);
    __decorate([
        core_1.Input('resizable')
    ], jqxSplitterComponent.prototype, "attrResizable", void 0);
    __decorate([
        core_1.Input('splitBarSize')
    ], jqxSplitterComponent.prototype, "attrSplitBarSize", void 0);
    __decorate([
        core_1.Input('showSplitBar')
    ], jqxSplitterComponent.prototype, "attrShowSplitBar", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxSplitterComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxSplitterComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxSplitterComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxSplitterComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSplitterComponent.prototype, "onCollapsed", void 0);
    __decorate([
        core_1.Output()
    ], jqxSplitterComponent.prototype, "onExpanded", void 0);
    __decorate([
        core_1.Output()
    ], jqxSplitterComponent.prototype, "onResize", void 0);
    __decorate([
        core_1.Output()
    ], jqxSplitterComponent.prototype, "onResizeStart", void 0);
    jqxSplitterComponent = __decorate([
        core_1.Component({
            selector: 'jqxSplitter',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxSplitterComponent);
    return jqxSplitterComponent;
}()); //jqxSplitterComponent
exports.jqxSplitterComponent = jqxSplitterComponent;
