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
require("../jqwidgets/jqxtreemap.js");
require("../jqwidgets/jqxtooltip.js");
var core_1 = require("@angular/core");
var jqxTreeMapComponent = /** @class */ (function () {
    function jqxTreeMapComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['baseColor', 'colorRanges', 'colorRange', 'colorMode', 'displayMember', 'height', 'hoverEnabled', 'headerHeight', 'legendLabel', 'legendPosition', 'legendScaleCallback', 'renderCallbacks', 'selectionEnabled', 'showLegend', 'source', 'theme', 'valueMember', 'width'];
        // jqxTreeMapComponent events
        this.onBindingComplete = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxTreeMapComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxTreeMapComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxTreeMap(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxTreeMap(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxTreeMap(this.properties[i])) {
                        this.host.jqxTreeMap(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxTreeMapComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxTreeMapComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxTreeMapComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxTreeMapComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxTreeMapComponent.prototype.createComponent = function (options) {
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
        this.host[0].style.marginLeft = '1px';
        this.__wireEvents__();
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxTreeMap', options);
    };
    jqxTreeMapComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxTreeMapComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxTreeMapComponent.prototype.setOptions = function (options) {
        this.host.jqxTreeMap('setOptions', options);
    };
    // jqxTreeMapComponent properties
    jqxTreeMapComponent.prototype.baseColor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('baseColor', arg);
        }
        else {
            return this.host.jqxTreeMap('baseColor');
        }
    };
    jqxTreeMapComponent.prototype.colorRanges = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('colorRanges', arg);
        }
        else {
            return this.host.jqxTreeMap('colorRanges');
        }
    };
    jqxTreeMapComponent.prototype.colorRange = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('colorRange', arg);
        }
        else {
            return this.host.jqxTreeMap('colorRange');
        }
    };
    jqxTreeMapComponent.prototype.colorMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('colorMode', arg);
        }
        else {
            return this.host.jqxTreeMap('colorMode');
        }
    };
    jqxTreeMapComponent.prototype.displayMember = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('displayMember', arg);
        }
        else {
            return this.host.jqxTreeMap('displayMember');
        }
    };
    jqxTreeMapComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('height', arg);
        }
        else {
            return this.host.jqxTreeMap('height');
        }
    };
    jqxTreeMapComponent.prototype.hoverEnabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('hoverEnabled', arg);
        }
        else {
            return this.host.jqxTreeMap('hoverEnabled');
        }
    };
    jqxTreeMapComponent.prototype.headerHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('headerHeight', arg);
        }
        else {
            return this.host.jqxTreeMap('headerHeight');
        }
    };
    jqxTreeMapComponent.prototype.legendLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('legendLabel', arg);
        }
        else {
            return this.host.jqxTreeMap('legendLabel');
        }
    };
    jqxTreeMapComponent.prototype.legendPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('legendPosition', arg);
        }
        else {
            return this.host.jqxTreeMap('legendPosition');
        }
    };
    jqxTreeMapComponent.prototype.legendScaleCallback = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('legendScaleCallback', arg);
        }
        else {
            return this.host.jqxTreeMap('legendScaleCallback');
        }
    };
    jqxTreeMapComponent.prototype.renderCallbacks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('renderCallbacks', arg);
        }
        else {
            return this.host.jqxTreeMap('renderCallbacks');
        }
    };
    jqxTreeMapComponent.prototype.selectionEnabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('selectionEnabled', arg);
        }
        else {
            return this.host.jqxTreeMap('selectionEnabled');
        }
    };
    jqxTreeMapComponent.prototype.showLegend = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('showLegend', arg);
        }
        else {
            return this.host.jqxTreeMap('showLegend');
        }
    };
    jqxTreeMapComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('source', arg);
        }
        else {
            return this.host.jqxTreeMap('source');
        }
    };
    jqxTreeMapComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('theme', arg);
        }
        else {
            return this.host.jqxTreeMap('theme');
        }
    };
    jqxTreeMapComponent.prototype.valueMember = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('valueMember', arg);
        }
        else {
            return this.host.jqxTreeMap('valueMember');
        }
    };
    jqxTreeMapComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTreeMap('width', arg);
        }
        else {
            return this.host.jqxTreeMap('width');
        }
    };
    // jqxTreeMapComponent functions
    jqxTreeMapComponent.prototype.destroy = function () {
        this.host.jqxTreeMap('destroy');
    };
    jqxTreeMapComponent.prototype.render = function () {
        this.host.jqxTreeMap('render');
    };
    jqxTreeMapComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('bindingComplete', function (eventData) { _this.onBindingComplete.emit(eventData); });
    };
    __decorate([
        core_1.Input('baseColor')
    ], jqxTreeMapComponent.prototype, "attrBaseColor", void 0);
    __decorate([
        core_1.Input('colorRanges')
    ], jqxTreeMapComponent.prototype, "attrColorRanges", void 0);
    __decorate([
        core_1.Input('colorRange')
    ], jqxTreeMapComponent.prototype, "attrColorRange", void 0);
    __decorate([
        core_1.Input('colorMode')
    ], jqxTreeMapComponent.prototype, "attrColorMode", void 0);
    __decorate([
        core_1.Input('displayMember')
    ], jqxTreeMapComponent.prototype, "attrDisplayMember", void 0);
    __decorate([
        core_1.Input('hoverEnabled')
    ], jqxTreeMapComponent.prototype, "attrHoverEnabled", void 0);
    __decorate([
        core_1.Input('headerHeight')
    ], jqxTreeMapComponent.prototype, "attrHeaderHeight", void 0);
    __decorate([
        core_1.Input('legendLabel')
    ], jqxTreeMapComponent.prototype, "attrLegendLabel", void 0);
    __decorate([
        core_1.Input('legendPosition')
    ], jqxTreeMapComponent.prototype, "attrLegendPosition", void 0);
    __decorate([
        core_1.Input('legendScaleCallback')
    ], jqxTreeMapComponent.prototype, "attrLegendScaleCallback", void 0);
    __decorate([
        core_1.Input('renderCallbacks')
    ], jqxTreeMapComponent.prototype, "attrRenderCallbacks", void 0);
    __decorate([
        core_1.Input('selectionEnabled')
    ], jqxTreeMapComponent.prototype, "attrSelectionEnabled", void 0);
    __decorate([
        core_1.Input('showLegend')
    ], jqxTreeMapComponent.prototype, "attrShowLegend", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxTreeMapComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxTreeMapComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('valueMember')
    ], jqxTreeMapComponent.prototype, "attrValueMember", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxTreeMapComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxTreeMapComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxTreeMapComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxTreeMapComponent.prototype, "onBindingComplete", void 0);
    jqxTreeMapComponent = __decorate([
        core_1.Component({
            selector: 'jqxTreeMap',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxTreeMapComponent);
    return jqxTreeMapComponent;
}()); //jqxTreeMapComponent
exports.jqxTreeMapComponent = jqxTreeMapComponent;
