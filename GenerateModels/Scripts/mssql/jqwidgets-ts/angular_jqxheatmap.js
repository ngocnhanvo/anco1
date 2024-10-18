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
require("../jqwidgets/jqxheatmap.js");
var core_1 = require("@angular/core");
var jqxHeatMapComponent = /** @class */ (function () {
    function jqxHeatMapComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['xAxis', 'yAxis', 'paletteSettings', 'legendSettings', 'source', 'title', 'width', 'tooltipRender'];
        this.elementRef = containerElement;
    }
    jqxHeatMapComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxHeatMapComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxHeatMap(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxHeatMap(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxHeatMap(this.properties[i])) {
                        this.host.jqxHeatMap(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxHeatMapComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxHeatMapComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxHeatMapComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxHeatMapComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxHeatMapComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxHeatMap', options);
    };
    jqxHeatMapComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxHeatMapComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxHeatMapComponent.prototype.setOptions = function (options) {
        this.host.jqxHeatMap('setOptions', options);
    };
    // jqxHeatMapComponent properties
    jqxHeatMapComponent.prototype.xAxis = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('xAxis', arg);
        }
        else {
            return this.host.jqxHeatMap('xAxis');
        }
    };
    jqxHeatMapComponent.prototype.yAxis = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('yAxis', arg);
        }
        else {
            return this.host.jqxHeatMap('yAxis');
        }
    };
    jqxHeatMapComponent.prototype.paletteSettings = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('paletteSettings', arg);
        }
        else {
            return this.host.jqxHeatMap('paletteSettings');
        }
    };
    jqxHeatMapComponent.prototype.legendSettings = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('legendSettings', arg);
        }
        else {
            return this.host.jqxHeatMap('legendSettings');
        }
    };
    jqxHeatMapComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('source', arg);
        }
        else {
            return this.host.jqxHeatMap('source');
        }
    };
    jqxHeatMapComponent.prototype.title = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('title', arg);
        }
        else {
            return this.host.jqxHeatMap('title');
        }
    };
    jqxHeatMapComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('width', arg);
        }
        else {
            return this.host.jqxHeatMap('width');
        }
    };
    jqxHeatMapComponent.prototype.tooltipRender = function (arg) {
        if (arg !== undefined) {
            this.host.jqxHeatMap('tooltipRender', arg);
        }
        else {
            return this.host.jqxHeatMap('tooltipRender');
        }
    };
    // jqxHeatMapComponent functions
    jqxHeatMapComponent.prototype.destroy = function () {
        this.host.jqxHeatMap('destroy');
    };
    jqxHeatMapComponent.prototype.setLegendPosition = function (position) {
        this.host.jqxHeatMap('setLegendPosition', position);
    };
    jqxHeatMapComponent.prototype.setOpposedXAxisPosition = function (opposedPosition) {
        this.host.jqxHeatMap('setOpposedXAxisPosition', opposedPosition);
    };
    jqxHeatMapComponent.prototype.setOpposedYAxisPosition = function (opposedPosition) {
        this.host.jqxHeatMap('setOpposedYAxisPosition', opposedPosition);
    };
    jqxHeatMapComponent.prototype.reverseXAxisPosition = function (isInversed) {
        this.host.jqxHeatMap('reverseXAxisPosition', isInversed);
    };
    jqxHeatMapComponent.prototype.reverseYAxisPosition = function (isInversed) {
        this.host.jqxHeatMap('reverseYAxisPosition', isInversed);
    };
    jqxHeatMapComponent.prototype.setPaletteType = function (type) {
        this.host.jqxHeatMap('setPaletteType', type);
    };
    // jqxHeatMapComponent events
    jqxHeatMapComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('xAxis')
    ], jqxHeatMapComponent.prototype, "attrXAxis", void 0);
    __decorate([
        core_1.Input('yAxis')
    ], jqxHeatMapComponent.prototype, "attrYAxis", void 0);
    __decorate([
        core_1.Input('paletteSettings')
    ], jqxHeatMapComponent.prototype, "attrPaletteSettings", void 0);
    __decorate([
        core_1.Input('legendSettings')
    ], jqxHeatMapComponent.prototype, "attrLegendSettings", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxHeatMapComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('title')
    ], jqxHeatMapComponent.prototype, "attrTitle", void 0);
    __decorate([
        core_1.Input('tooltipRender')
    ], jqxHeatMapComponent.prototype, "attrTooltipRender", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxHeatMapComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxHeatMapComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxHeatMapComponent.prototype, "autoCreate", void 0);
    jqxHeatMapComponent = __decorate([
        core_1.Component({
            selector: 'jqxHeatMap',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxHeatMapComponent);
    return jqxHeatMapComponent;
}()); //jqxHeatMapComponent
exports.jqxHeatMapComponent = jqxHeatMapComponent;
