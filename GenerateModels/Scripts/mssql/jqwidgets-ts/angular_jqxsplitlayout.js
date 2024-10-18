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
require("../jqwidgets/jqxsplitlayout.js");
var core_1 = require("@angular/core");
var jqxSplitLayoutComponent = /** @class */ (function () {
    function jqxSplitLayoutComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'dataSource', 'ready', 'orientation'];
        // jqxSplitLayoutComponent events
        this.onResize = new core_1.EventEmitter();
        this.onStateChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxSplitLayoutComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxSplitLayoutComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxSplitLayout(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxSplitLayout(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxSplitLayout(this.properties[i])) {
                        this.host.jqxSplitLayout(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxSplitLayoutComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxSplitLayoutComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxSplitLayoutComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxSplitLayoutComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxSplitLayoutComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxSplitLayout', options);
    };
    jqxSplitLayoutComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxSplitLayoutComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxSplitLayoutComponent.prototype.setOptions = function (options) {
        this.host.jqxSplitLayout('setOptions', options);
    };
    // jqxSplitLayoutComponent properties
    jqxSplitLayoutComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitLayout('disabled', arg);
        }
        else {
            return this.host.jqxSplitLayout('disabled');
        }
    };
    jqxSplitLayoutComponent.prototype.dataSource = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitLayout('dataSource', arg);
        }
        else {
            return this.host.jqxSplitLayout('dataSource');
        }
    };
    jqxSplitLayoutComponent.prototype.ready = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitLayout('ready', arg);
        }
        else {
            return this.host.jqxSplitLayout('ready');
        }
    };
    jqxSplitLayoutComponent.prototype.orientation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSplitLayout('orientation', arg);
        }
        else {
            return this.host.jqxSplitLayout('orientation');
        }
    };
    // jqxSplitLayoutComponent functions
    jqxSplitLayoutComponent.prototype.refresh = function () {
        this.host.jqxSplitLayout('refresh');
    };
    jqxSplitLayoutComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('resize', function (eventData) { _this.onResize.emit(eventData); });
        this.host.on('stateChange', function (eventData) { _this.onStateChange.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxSplitLayoutComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('dataSource')
    ], jqxSplitLayoutComponent.prototype, "attrDataSource", void 0);
    __decorate([
        core_1.Input('ready')
    ], jqxSplitLayoutComponent.prototype, "attrReady", void 0);
    __decorate([
        core_1.Input('orientation')
    ], jqxSplitLayoutComponent.prototype, "attrOrientation", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxSplitLayoutComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxSplitLayoutComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxSplitLayoutComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSplitLayoutComponent.prototype, "onResize", void 0);
    __decorate([
        core_1.Output()
    ], jqxSplitLayoutComponent.prototype, "onStateChange", void 0);
    jqxSplitLayoutComponent = __decorate([
        core_1.Component({
            selector: 'jqxSplitLayout',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxSplitLayoutComponent);
    return jqxSplitLayoutComponent;
}()); //jqxSplitLayoutComponent
exports.jqxSplitLayoutComponent = jqxSplitLayoutComponent;
