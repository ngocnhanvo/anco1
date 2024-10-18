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
require("../jqwidgets/jqxscrollbar.js");
require("../jqwidgets/jqxpanel.js");
var core_1 = require("@angular/core");
var jqxPanelComponent = /** @class */ (function () {
    function jqxPanelComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoUpdate', 'disabled', 'height', 'rtl', 'sizeMode', 'scrollBarSize', 'theme', 'width'];
        this.elementRef = containerElement;
    }
    jqxPanelComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxPanelComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxPanel(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxPanel(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxPanel(this.properties[i])) {
                        this.host.jqxPanel(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxPanelComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxPanelComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxPanelComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxPanelComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxPanelComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxPanel', options);
    };
    jqxPanelComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxPanelComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxPanelComponent.prototype.setOptions = function (options) {
        this.host.jqxPanel('setOptions', options);
    };
    // jqxPanelComponent properties
    jqxPanelComponent.prototype.autoUpdate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('autoUpdate', arg);
        }
        else {
            return this.host.jqxPanel('autoUpdate');
        }
    };
    jqxPanelComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('disabled', arg);
        }
        else {
            return this.host.jqxPanel('disabled');
        }
    };
    jqxPanelComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('height', arg);
        }
        else {
            return this.host.jqxPanel('height');
        }
    };
    jqxPanelComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('rtl', arg);
        }
        else {
            return this.host.jqxPanel('rtl');
        }
    };
    jqxPanelComponent.prototype.sizeMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('sizeMode', arg);
        }
        else {
            return this.host.jqxPanel('sizeMode');
        }
    };
    jqxPanelComponent.prototype.scrollBarSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('scrollBarSize', arg);
        }
        else {
            return this.host.jqxPanel('scrollBarSize');
        }
    };
    jqxPanelComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('theme', arg);
        }
        else {
            return this.host.jqxPanel('theme');
        }
    };
    jqxPanelComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPanel('width', arg);
        }
        else {
            return this.host.jqxPanel('width');
        }
    };
    // jqxPanelComponent functions
    jqxPanelComponent.prototype.append = function (HTMLElement) {
        this.host.jqxPanel('append', HTMLElement);
    };
    jqxPanelComponent.prototype.clearcontent = function () {
        this.host.jqxPanel('clearcontent');
    };
    jqxPanelComponent.prototype.destroy = function () {
        this.host.jqxPanel('destroy');
    };
    jqxPanelComponent.prototype.focus = function () {
        this.host.jqxPanel('focus');
    };
    jqxPanelComponent.prototype.getScrollHeight = function () {
        return this.host.jqxPanel('getScrollHeight');
    };
    jqxPanelComponent.prototype.getVScrollPosition = function () {
        return this.host.jqxPanel('getVScrollPosition');
    };
    jqxPanelComponent.prototype.getScrollWidth = function () {
        return this.host.jqxPanel('getScrollWidth');
    };
    jqxPanelComponent.prototype.getHScrollPosition = function () {
        return this.host.jqxPanel('getHScrollPosition');
    };
    jqxPanelComponent.prototype.prepend = function (HTMLElement) {
        this.host.jqxPanel('prepend', HTMLElement);
    };
    jqxPanelComponent.prototype.remove = function (HTMLElement) {
        this.host.jqxPanel('remove', HTMLElement);
    };
    jqxPanelComponent.prototype.scrollTo = function (left, top) {
        this.host.jqxPanel('scrollTo', left, top);
    };
    // jqxPanelComponent events
    jqxPanelComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('autoUpdate')
    ], jqxPanelComponent.prototype, "attrAutoUpdate", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxPanelComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxPanelComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('sizeMode')
    ], jqxPanelComponent.prototype, "attrSizeMode", void 0);
    __decorate([
        core_1.Input('scrollBarSize')
    ], jqxPanelComponent.prototype, "attrScrollBarSize", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxPanelComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxPanelComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxPanelComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxPanelComponent.prototype, "autoCreate", void 0);
    jqxPanelComponent = __decorate([
        core_1.Component({
            selector: 'jqxPanel',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxPanelComponent);
    return jqxPanelComponent;
}()); //jqxPanelComponent
exports.jqxPanelComponent = jqxPanelComponent;
