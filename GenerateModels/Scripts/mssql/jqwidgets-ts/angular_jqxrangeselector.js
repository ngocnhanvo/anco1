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
require("../jqwidgets/jqxtooltip.js");
require("../jqwidgets/jqxrangeselector.js");
var core_1 = require("@angular/core");
var jqxRangeSelectorComponent = /** @class */ (function () {
    function jqxRangeSelectorComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['disabled', 'groupLabelsFormatFunction', 'height', 'labelsFormat', 'labelsFormatFunction', 'labelsOnTicks', 'markersFormat', 'markersFormatFunction', 'majorTicksInterval', 'minorTicksInterval', 'max', 'min', 'moveOnClick', 'padding', 'range', 'resizable', 'rtl', 'showGroupLabels', 'showMinorTicks', 'snapToTicks', 'showMajorLabels', 'showMarkers', 'theme', 'width'];
        // jqxRangeSelectorComponent events
        this.onChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxRangeSelectorComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxRangeSelectorComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxRangeSelector(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxRangeSelector(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxRangeSelector(this.properties[i])) {
                        this.host.jqxRangeSelector(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxRangeSelectorComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxRangeSelectorComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxRangeSelectorComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxRangeSelectorComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxRangeSelectorComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxRangeSelector', options);
    };
    jqxRangeSelectorComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxRangeSelectorComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxRangeSelectorComponent.prototype.setOptions = function (options) {
        this.host.jqxRangeSelector('setOptions', options);
    };
    // jqxRangeSelectorComponent properties
    jqxRangeSelectorComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('disabled', arg);
        }
        else {
            return this.host.jqxRangeSelector('disabled');
        }
    };
    jqxRangeSelectorComponent.prototype.groupLabelsFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('groupLabelsFormatFunction', arg);
        }
        else {
            return this.host.jqxRangeSelector('groupLabelsFormatFunction');
        }
    };
    jqxRangeSelectorComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('height', arg);
        }
        else {
            return this.host.jqxRangeSelector('height');
        }
    };
    jqxRangeSelectorComponent.prototype.labelsFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('labelsFormat', arg);
        }
        else {
            return this.host.jqxRangeSelector('labelsFormat');
        }
    };
    jqxRangeSelectorComponent.prototype.labelsFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('labelsFormatFunction', arg);
        }
        else {
            return this.host.jqxRangeSelector('labelsFormatFunction');
        }
    };
    jqxRangeSelectorComponent.prototype.labelsOnTicks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('labelsOnTicks', arg);
        }
        else {
            return this.host.jqxRangeSelector('labelsOnTicks');
        }
    };
    jqxRangeSelectorComponent.prototype.markersFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('markersFormat', arg);
        }
        else {
            return this.host.jqxRangeSelector('markersFormat');
        }
    };
    jqxRangeSelectorComponent.prototype.markersFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('markersFormatFunction', arg);
        }
        else {
            return this.host.jqxRangeSelector('markersFormatFunction');
        }
    };
    jqxRangeSelectorComponent.prototype.majorTicksInterval = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('majorTicksInterval', arg);
        }
        else {
            return this.host.jqxRangeSelector('majorTicksInterval');
        }
    };
    jqxRangeSelectorComponent.prototype.minorTicksInterval = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('minorTicksInterval', arg);
        }
        else {
            return this.host.jqxRangeSelector('minorTicksInterval');
        }
    };
    jqxRangeSelectorComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('max', arg);
        }
        else {
            return this.host.jqxRangeSelector('max');
        }
    };
    jqxRangeSelectorComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('min', arg);
        }
        else {
            return this.host.jqxRangeSelector('min');
        }
    };
    jqxRangeSelectorComponent.prototype.moveOnClick = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('moveOnClick', arg);
        }
        else {
            return this.host.jqxRangeSelector('moveOnClick');
        }
    };
    jqxRangeSelectorComponent.prototype.padding = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('padding', arg);
        }
        else {
            return this.host.jqxRangeSelector('padding');
        }
    };
    jqxRangeSelectorComponent.prototype.range = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('range', arg);
        }
        else {
            return this.host.jqxRangeSelector('range');
        }
    };
    jqxRangeSelectorComponent.prototype.resizable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('resizable', arg);
        }
        else {
            return this.host.jqxRangeSelector('resizable');
        }
    };
    jqxRangeSelectorComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('rtl', arg);
        }
        else {
            return this.host.jqxRangeSelector('rtl');
        }
    };
    jqxRangeSelectorComponent.prototype.showGroupLabels = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('showGroupLabels', arg);
        }
        else {
            return this.host.jqxRangeSelector('showGroupLabels');
        }
    };
    jqxRangeSelectorComponent.prototype.showMinorTicks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('showMinorTicks', arg);
        }
        else {
            return this.host.jqxRangeSelector('showMinorTicks');
        }
    };
    jqxRangeSelectorComponent.prototype.snapToTicks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('snapToTicks', arg);
        }
        else {
            return this.host.jqxRangeSelector('snapToTicks');
        }
    };
    jqxRangeSelectorComponent.prototype.showMajorLabels = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('showMajorLabels', arg);
        }
        else {
            return this.host.jqxRangeSelector('showMajorLabels');
        }
    };
    jqxRangeSelectorComponent.prototype.showMarkers = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('showMarkers', arg);
        }
        else {
            return this.host.jqxRangeSelector('showMarkers');
        }
    };
    jqxRangeSelectorComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('theme', arg);
        }
        else {
            return this.host.jqxRangeSelector('theme');
        }
    };
    jqxRangeSelectorComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxRangeSelector('width', arg);
        }
        else {
            return this.host.jqxRangeSelector('width');
        }
    };
    // jqxRangeSelectorComponent functions
    jqxRangeSelectorComponent.prototype.destroy = function () {
        this.host.jqxRangeSelector('destroy');
    };
    jqxRangeSelectorComponent.prototype.getRange = function () {
        return this.host.jqxRangeSelector('getRange');
    };
    jqxRangeSelectorComponent.prototype.render = function () {
        this.host.jqxRangeSelector('render');
    };
    jqxRangeSelectorComponent.prototype.refresh = function () {
        this.host.jqxRangeSelector('refresh');
    };
    jqxRangeSelectorComponent.prototype.setRange = function (from, to) {
        this.host.jqxRangeSelector('setRange', from, to);
    };
    jqxRangeSelectorComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
    };
    __decorate([
        core_1.Input('disabled')
    ], jqxRangeSelectorComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('groupLabelsFormatFunction')
    ], jqxRangeSelectorComponent.prototype, "attrGroupLabelsFormatFunction", void 0);
    __decorate([
        core_1.Input('labelsFormat')
    ], jqxRangeSelectorComponent.prototype, "attrLabelsFormat", void 0);
    __decorate([
        core_1.Input('labelsFormatFunction')
    ], jqxRangeSelectorComponent.prototype, "attrLabelsFormatFunction", void 0);
    __decorate([
        core_1.Input('labelsOnTicks')
    ], jqxRangeSelectorComponent.prototype, "attrLabelsOnTicks", void 0);
    __decorate([
        core_1.Input('markersFormat')
    ], jqxRangeSelectorComponent.prototype, "attrMarkersFormat", void 0);
    __decorate([
        core_1.Input('markersFormatFunction')
    ], jqxRangeSelectorComponent.prototype, "attrMarkersFormatFunction", void 0);
    __decorate([
        core_1.Input('majorTicksInterval')
    ], jqxRangeSelectorComponent.prototype, "attrMajorTicksInterval", void 0);
    __decorate([
        core_1.Input('minorTicksInterval')
    ], jqxRangeSelectorComponent.prototype, "attrMinorTicksInterval", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxRangeSelectorComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxRangeSelectorComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('moveOnClick')
    ], jqxRangeSelectorComponent.prototype, "attrMoveOnClick", void 0);
    __decorate([
        core_1.Input('padding')
    ], jqxRangeSelectorComponent.prototype, "attrPadding", void 0);
    __decorate([
        core_1.Input('range')
    ], jqxRangeSelectorComponent.prototype, "attrRange", void 0);
    __decorate([
        core_1.Input('resizable')
    ], jqxRangeSelectorComponent.prototype, "attrResizable", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxRangeSelectorComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('showGroupLabels')
    ], jqxRangeSelectorComponent.prototype, "attrShowGroupLabels", void 0);
    __decorate([
        core_1.Input('showMinorTicks')
    ], jqxRangeSelectorComponent.prototype, "attrShowMinorTicks", void 0);
    __decorate([
        core_1.Input('snapToTicks')
    ], jqxRangeSelectorComponent.prototype, "attrSnapToTicks", void 0);
    __decorate([
        core_1.Input('showMajorLabels')
    ], jqxRangeSelectorComponent.prototype, "attrShowMajorLabels", void 0);
    __decorate([
        core_1.Input('showMarkers')
    ], jqxRangeSelectorComponent.prototype, "attrShowMarkers", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxRangeSelectorComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxRangeSelectorComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxRangeSelectorComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxRangeSelectorComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxRangeSelectorComponent.prototype, "onChange", void 0);
    jqxRangeSelectorComponent = __decorate([
        core_1.Component({
            selector: 'jqxRangeSelector',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxRangeSelectorComponent);
    return jqxRangeSelectorComponent;
}()); //jqxRangeSelectorComponent
exports.jqxRangeSelectorComponent = jqxRangeSelectorComponent;
