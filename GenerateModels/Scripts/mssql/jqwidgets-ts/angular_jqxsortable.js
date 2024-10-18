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
require("../jqwidgets/jqxsortable.js");
var core_1 = require("@angular/core");
var jqxSortableComponent = /** @class */ (function () {
    function jqxSortableComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['appendTo', 'axis', 'cancel', 'connectWith', 'containment', 'cursor', 'cursorAt', 'delay', 'disabled', 'distance', 'dropOnEmpty', 'forceHelperSize', 'forcePlaceholderSize', 'grid', 'handle', 'helper', 'items', 'opacity', 'placeholderShow', 'revert', 'scroll', 'scrollSensitivity', 'scrollSpeed', 'tolerance', 'zIndex'];
        // jqxSortableComponent events
        this.onActivate = new core_1.EventEmitter();
        this.onBeforeStop = new core_1.EventEmitter();
        this.onChange = new core_1.EventEmitter();
        this.onDeactivate = new core_1.EventEmitter();
        this.onOut = new core_1.EventEmitter();
        this.onOver = new core_1.EventEmitter();
        this.onReceive = new core_1.EventEmitter();
        this.onRemove = new core_1.EventEmitter();
        this.onSort = new core_1.EventEmitter();
        this.onStart = new core_1.EventEmitter();
        this.onStop = new core_1.EventEmitter();
        this.onUpdate = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxSortableComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxSortableComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxSortable(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxSortable(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxSortable(this.properties[i])) {
                        this.host.jqxSortable(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxSortableComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxSortableComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxSortableComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxSortableComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxSortableComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxSortable', options);
    };
    jqxSortableComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxSortableComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxSortableComponent.prototype.setOptions = function (options) {
        this.host.jqxSortable('setOptions', options);
    };
    // jqxSortableComponent properties
    jqxSortableComponent.prototype.appendTo = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('appendTo', arg);
        }
        else {
            return this.host.jqxSortable('appendTo');
        }
    };
    jqxSortableComponent.prototype.axis = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('axis', arg);
        }
        else {
            return this.host.jqxSortable('axis');
        }
    };
    jqxSortableComponent.prototype.cancel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('cancel', arg);
        }
        else {
            return this.host.jqxSortable('cancel');
        }
    };
    jqxSortableComponent.prototype.connectWith = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('connectWith', arg);
        }
        else {
            return this.host.jqxSortable('connectWith');
        }
    };
    jqxSortableComponent.prototype.containment = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('containment', arg);
        }
        else {
            return this.host.jqxSortable('containment');
        }
    };
    jqxSortableComponent.prototype.cursor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('cursor', arg);
        }
        else {
            return this.host.jqxSortable('cursor');
        }
    };
    jqxSortableComponent.prototype.cursorAt = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('cursorAt', arg);
        }
        else {
            return this.host.jqxSortable('cursorAt');
        }
    };
    jqxSortableComponent.prototype.delay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('delay', arg);
        }
        else {
            return this.host.jqxSortable('delay');
        }
    };
    jqxSortableComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('disabled', arg);
        }
        else {
            return this.host.jqxSortable('disabled');
        }
    };
    jqxSortableComponent.prototype.distance = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('distance', arg);
        }
        else {
            return this.host.jqxSortable('distance');
        }
    };
    jqxSortableComponent.prototype.dropOnEmpty = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('dropOnEmpty', arg);
        }
        else {
            return this.host.jqxSortable('dropOnEmpty');
        }
    };
    jqxSortableComponent.prototype.forceHelperSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('forceHelperSize', arg);
        }
        else {
            return this.host.jqxSortable('forceHelperSize');
        }
    };
    jqxSortableComponent.prototype.forcePlaceholderSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('forcePlaceholderSize', arg);
        }
        else {
            return this.host.jqxSortable('forcePlaceholderSize');
        }
    };
    jqxSortableComponent.prototype.grid = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('grid', arg);
        }
        else {
            return this.host.jqxSortable('grid');
        }
    };
    jqxSortableComponent.prototype.handle = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('handle', arg);
        }
        else {
            return this.host.jqxSortable('handle');
        }
    };
    jqxSortableComponent.prototype.helper = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('helper', arg);
        }
        else {
            return this.host.jqxSortable('helper');
        }
    };
    jqxSortableComponent.prototype.items = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('items', arg);
        }
        else {
            return this.host.jqxSortable('items');
        }
    };
    jqxSortableComponent.prototype.opacity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('opacity', arg);
        }
        else {
            return this.host.jqxSortable('opacity');
        }
    };
    jqxSortableComponent.prototype.placeholderShow = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('placeholderShow', arg);
        }
        else {
            return this.host.jqxSortable('placeholderShow');
        }
    };
    jqxSortableComponent.prototype.revert = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('revert', arg);
        }
        else {
            return this.host.jqxSortable('revert');
        }
    };
    jqxSortableComponent.prototype.scroll = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('scroll', arg);
        }
        else {
            return this.host.jqxSortable('scroll');
        }
    };
    jqxSortableComponent.prototype.scrollSensitivity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('scrollSensitivity', arg);
        }
        else {
            return this.host.jqxSortable('scrollSensitivity');
        }
    };
    jqxSortableComponent.prototype.scrollSpeed = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('scrollSpeed', arg);
        }
        else {
            return this.host.jqxSortable('scrollSpeed');
        }
    };
    jqxSortableComponent.prototype.tolerance = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('tolerance', arg);
        }
        else {
            return this.host.jqxSortable('tolerance');
        }
    };
    jqxSortableComponent.prototype.zIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxSortable('zIndex', arg);
        }
        else {
            return this.host.jqxSortable('zIndex');
        }
    };
    // jqxSortableComponent functions
    jqxSortableComponent.prototype.cancelMethod = function () {
        this.host.jqxSortable('cancelMethod');
    };
    jqxSortableComponent.prototype.destroy = function () {
        this.host.jqxSortable('destroy');
    };
    jqxSortableComponent.prototype.disable = function () {
        this.host.jqxSortable('disable');
    };
    jqxSortableComponent.prototype.enable = function () {
        this.host.jqxSortable('enable');
    };
    jqxSortableComponent.prototype.refresh = function () {
        this.host.jqxSortable('refresh');
    };
    jqxSortableComponent.prototype.refreshPositions = function () {
        this.host.jqxSortable('refreshPositions');
    };
    jqxSortableComponent.prototype.serialize = function (object) {
        return this.host.jqxSortable('serialize', object);
    };
    jqxSortableComponent.prototype.toArray = function () {
        return this.host.jqxSortable('toArray');
    };
    jqxSortableComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('activate', function (eventData) { _this.onActivate.emit(eventData); });
        this.host.on('beforeStop', function (eventData) { _this.onBeforeStop.emit(eventData); });
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
        this.host.on('deactivate', function (eventData) { _this.onDeactivate.emit(eventData); });
        this.host.on('out', function (eventData) { _this.onOut.emit(eventData); });
        this.host.on('over', function (eventData) { _this.onOver.emit(eventData); });
        this.host.on('receive', function (eventData) { _this.onReceive.emit(eventData); });
        this.host.on('remove', function (eventData) { _this.onRemove.emit(eventData); });
        this.host.on('sort', function (eventData) { _this.onSort.emit(eventData); });
        this.host.on('start', function (eventData) { _this.onStart.emit(eventData); });
        this.host.on('stop', function (eventData) { _this.onStop.emit(eventData); });
        this.host.on('update', function (eventData) { _this.onUpdate.emit(eventData); });
    };
    __decorate([
        core_1.Input('appendTo')
    ], jqxSortableComponent.prototype, "attrAppendTo", void 0);
    __decorate([
        core_1.Input('axis')
    ], jqxSortableComponent.prototype, "attrAxis", void 0);
    __decorate([
        core_1.Input('cancel')
    ], jqxSortableComponent.prototype, "attrCancel", void 0);
    __decorate([
        core_1.Input('connectWith')
    ], jqxSortableComponent.prototype, "attrConnectWith", void 0);
    __decorate([
        core_1.Input('containment')
    ], jqxSortableComponent.prototype, "attrContainment", void 0);
    __decorate([
        core_1.Input('cursor')
    ], jqxSortableComponent.prototype, "attrCursor", void 0);
    __decorate([
        core_1.Input('cursorAt')
    ], jqxSortableComponent.prototype, "attrCursorAt", void 0);
    __decorate([
        core_1.Input('delay')
    ], jqxSortableComponent.prototype, "attrDelay", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxSortableComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('distance')
    ], jqxSortableComponent.prototype, "attrDistance", void 0);
    __decorate([
        core_1.Input('dropOnEmpty')
    ], jqxSortableComponent.prototype, "attrDropOnEmpty", void 0);
    __decorate([
        core_1.Input('forceHelperSize')
    ], jqxSortableComponent.prototype, "attrForceHelperSize", void 0);
    __decorate([
        core_1.Input('forcePlaceholderSize')
    ], jqxSortableComponent.prototype, "attrForcePlaceholderSize", void 0);
    __decorate([
        core_1.Input('grid')
    ], jqxSortableComponent.prototype, "attrGrid", void 0);
    __decorate([
        core_1.Input('handle')
    ], jqxSortableComponent.prototype, "attrHandle", void 0);
    __decorate([
        core_1.Input('helper')
    ], jqxSortableComponent.prototype, "attrHelper", void 0);
    __decorate([
        core_1.Input('items')
    ], jqxSortableComponent.prototype, "attrItems", void 0);
    __decorate([
        core_1.Input('opacity')
    ], jqxSortableComponent.prototype, "attrOpacity", void 0);
    __decorate([
        core_1.Input('placeholderShow')
    ], jqxSortableComponent.prototype, "attrPlaceholderShow", void 0);
    __decorate([
        core_1.Input('revert')
    ], jqxSortableComponent.prototype, "attrRevert", void 0);
    __decorate([
        core_1.Input('scroll')
    ], jqxSortableComponent.prototype, "attrScroll", void 0);
    __decorate([
        core_1.Input('scrollSensitivity')
    ], jqxSortableComponent.prototype, "attrScrollSensitivity", void 0);
    __decorate([
        core_1.Input('scrollSpeed')
    ], jqxSortableComponent.prototype, "attrScrollSpeed", void 0);
    __decorate([
        core_1.Input('tolerance')
    ], jqxSortableComponent.prototype, "attrTolerance", void 0);
    __decorate([
        core_1.Input('zIndex')
    ], jqxSortableComponent.prototype, "attrZIndex", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxSortableComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxSortableComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxSortableComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onActivate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onBeforeStop", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onDeactivate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onOut", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onOver", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onReceive", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onRemove", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onSort", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onStop", void 0);
    __decorate([
        core_1.Output()
    ], jqxSortableComponent.prototype, "onUpdate", void 0);
    jqxSortableComponent = __decorate([
        core_1.Component({
            selector: 'jqxSortable',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxSortableComponent);
    return jqxSortableComponent;
}()); //jqxSortableComponent
exports.jqxSortableComponent = jqxSortableComponent;
