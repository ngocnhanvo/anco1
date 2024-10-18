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
require("../jqwidgets/jqxdockpanel.js");
var core_1 = require("@angular/core");
var jqxDockPanelComponent = /** @class */ (function () {
    function jqxDockPanelComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'height', 'lastchildfill', 'width'];
        // jqxDockPanelComponent events
        this.onLayout = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxDockPanelComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxDockPanelComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxDockPanel(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxDockPanel(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxDockPanel(this.properties[i])) {
                        this.host.jqxDockPanel(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxDockPanelComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxDockPanelComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxDockPanelComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxDockPanelComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxDockPanelComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxDockPanel', options);
    };
    jqxDockPanelComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxDockPanelComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxDockPanelComponent.prototype.setOptions = function (options) {
        this.host.jqxDockPanel('setOptions', options);
    };
    // jqxDockPanelComponent properties
    jqxDockPanelComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockPanel('disabled', arg);
        }
        else {
            return this.host.jqxDockPanel('disabled');
        }
    };
    jqxDockPanelComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockPanel('height', arg);
        }
        else {
            return this.host.jqxDockPanel('height');
        }
    };
    jqxDockPanelComponent.prototype.lastchildfill = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockPanel('lastchildfill', arg);
        }
        else {
            return this.host.jqxDockPanel('lastchildfill');
        }
    };
    jqxDockPanelComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDockPanel('width', arg);
        }
        else {
            return this.host.jqxDockPanel('width');
        }
    };
    // jqxDockPanelComponent functions
    jqxDockPanelComponent.prototype.refresh = function () {
        this.host.jqxDockPanel('refresh');
    };
    jqxDockPanelComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('layout', function (eventData) { _this.onLayout.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxDockPanelComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('lastchildfill')
    ], jqxDockPanelComponent.prototype, "attrLastchildfill", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxDockPanelComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxDockPanelComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxDockPanelComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxDockPanelComponent.prototype, "onLayout", void 0);
    jqxDockPanelComponent = __decorate([
        core_1.Component({
            selector: 'jqxDockPanel',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxDockPanelComponent);
    return jqxDockPanelComponent;
}()); //jqxDockPanelComponent
exports.jqxDockPanelComponent = jqxDockPanelComponent;
