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
require("../jqwidgets/jqxdragdrop.js");
var core_1 = require("@angular/core");
var jqxDragDropComponent = /** @class */ (function () {
    function jqxDragDropComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['appendTo', 'disabled', 'distance', 'data', 'dropAction', 'dropTarget', 'dragZIndex', 'feedback', 'initFeedback', 'opacity', 'onDragEnd', 'onDrag', 'onDragStart', 'onTargetDrop', 'onDropTargetEnter', 'onDropTargetLeave', 'restricter', 'revert', 'revertDuration', 'tolerance'];
        // jqxDragDropComponent functions
        // jqxDragDropComponent events
        this.ondragstart = new core_1.EventEmitter();
        this.ondragend = new core_1.EventEmitter();
        this.ondragging = new core_1.EventEmitter();
        this.ondroptargetenter = new core_1.EventEmitter();
        this.ondroptargetleave = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxDragDropComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxDragDropComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxDragDrop(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxDragDrop(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxDragDrop(this.properties[i])) {
                        this.host.jqxDragDrop(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxDragDropComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxDragDropComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxDragDropComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxDragDropComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxDragDropComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxDragDrop', options);
    };
    jqxDragDropComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxDragDropComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxDragDropComponent.prototype.setOptions = function (options) {
        this.host.jqxDragDrop('setOptions', options);
    };
    // jqxDragDropComponent properties
    jqxDragDropComponent.prototype.appendTo = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('appendTo', arg);
        }
        else {
            return this.host.jqxDragDrop('appendTo');
        }
    };
    jqxDragDropComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('disabled', arg);
        }
        else {
            return this.host.jqxDragDrop('disabled');
        }
    };
    jqxDragDropComponent.prototype.distance = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('distance', arg);
        }
        else {
            return this.host.jqxDragDrop('distance');
        }
    };
    jqxDragDropComponent.prototype.data = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('data', arg);
        }
        else {
            return this.host.jqxDragDrop('data');
        }
    };
    jqxDragDropComponent.prototype.dropAction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('dropAction', arg);
        }
        else {
            return this.host.jqxDragDrop('dropAction');
        }
    };
    jqxDragDropComponent.prototype.dropTarget = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('dropTarget', arg);
        }
        else {
            return this.host.jqxDragDrop('dropTarget');
        }
    };
    jqxDragDropComponent.prototype.dragZIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('dragZIndex', arg);
        }
        else {
            return this.host.jqxDragDrop('dragZIndex');
        }
    };
    jqxDragDropComponent.prototype.feedback = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('feedback', arg);
        }
        else {
            return this.host.jqxDragDrop('feedback');
        }
    };
    jqxDragDropComponent.prototype.initFeedback = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('initFeedback', arg);
        }
        else {
            return this.host.jqxDragDrop('initFeedback');
        }
    };
    jqxDragDropComponent.prototype.opacity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('opacity', arg);
        }
        else {
            return this.host.jqxDragDrop('opacity');
        }
    };
    jqxDragDropComponent.prototype.onDragEnd = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('onDragEnd', arg);
        }
        else {
            return this.host.jqxDragDrop('onDragEnd');
        }
    };
    jqxDragDropComponent.prototype.onDrag = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('onDrag', arg);
        }
        else {
            return this.host.jqxDragDrop('onDrag');
        }
    };
    jqxDragDropComponent.prototype.onDragStart = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('onDragStart', arg);
        }
        else {
            return this.host.jqxDragDrop('onDragStart');
        }
    };
    jqxDragDropComponent.prototype.onTargetDrop = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('onTargetDrop', arg);
        }
        else {
            return this.host.jqxDragDrop('onTargetDrop');
        }
    };
    jqxDragDropComponent.prototype.onDropTargetEnter = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('onDropTargetEnter', arg);
        }
        else {
            return this.host.jqxDragDrop('onDropTargetEnter');
        }
    };
    jqxDragDropComponent.prototype.onDropTargetLeave = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('onDropTargetLeave', arg);
        }
        else {
            return this.host.jqxDragDrop('onDropTargetLeave');
        }
    };
    jqxDragDropComponent.prototype.restricter = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('restricter', arg);
        }
        else {
            return this.host.jqxDragDrop('restricter');
        }
    };
    jqxDragDropComponent.prototype.revert = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('revert', arg);
        }
        else {
            return this.host.jqxDragDrop('revert');
        }
    };
    jqxDragDropComponent.prototype.revertDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('revertDuration', arg);
        }
        else {
            return this.host.jqxDragDrop('revertDuration');
        }
    };
    jqxDragDropComponent.prototype.tolerance = function (arg) {
        if (arg !== undefined) {
            this.host.jqxDragDrop('tolerance', arg);
        }
        else {
            return this.host.jqxDragDrop('tolerance');
        }
    };
    jqxDragDropComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('dragStart', function (eventData) { _this.ondragstart.emit(eventData); });
        this.host.on('dragEnd', function (eventData) { _this.ondragend.emit(eventData); });
        this.host.on('dragging', function (eventData) { _this.ondragging.emit(eventData); });
        this.host.on('dropTargetEnter', function (eventData) { _this.ondroptargetenter.emit(eventData); });
        this.host.on('dropTargetLeave', function (eventData) { _this.ondroptargetleave.emit(eventData); });
    };
    __decorate([
        core_1.Input('appendTo')
    ], jqxDragDropComponent.prototype, "attrAppendTo", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxDragDropComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('distance')
    ], jqxDragDropComponent.prototype, "attrDistance", void 0);
    __decorate([
        core_1.Input('data')
    ], jqxDragDropComponent.prototype, "attrData", void 0);
    __decorate([
        core_1.Input('dropAction')
    ], jqxDragDropComponent.prototype, "attrDropAction", void 0);
    __decorate([
        core_1.Input('dropTarget')
    ], jqxDragDropComponent.prototype, "attrDropTarget", void 0);
    __decorate([
        core_1.Input('dragZIndex')
    ], jqxDragDropComponent.prototype, "attrDragZIndex", void 0);
    __decorate([
        core_1.Input('feedback')
    ], jqxDragDropComponent.prototype, "attrFeedback", void 0);
    __decorate([
        core_1.Input('initFeedback')
    ], jqxDragDropComponent.prototype, "attrInitFeedback", void 0);
    __decorate([
        core_1.Input('opacity')
    ], jqxDragDropComponent.prototype, "attrOpacity", void 0);
    __decorate([
        core_1.Input('onDragEnd')
    ], jqxDragDropComponent.prototype, "attrOnDragEnd", void 0);
    __decorate([
        core_1.Input('onDrag')
    ], jqxDragDropComponent.prototype, "attrOnDrag", void 0);
    __decorate([
        core_1.Input('onDragStart')
    ], jqxDragDropComponent.prototype, "attrOnDragStart", void 0);
    __decorate([
        core_1.Input('onTargetDrop')
    ], jqxDragDropComponent.prototype, "attrOnTargetDrop", void 0);
    __decorate([
        core_1.Input('onDropTargetEnter')
    ], jqxDragDropComponent.prototype, "attrOnDropTargetEnter", void 0);
    __decorate([
        core_1.Input('onDropTargetLeave')
    ], jqxDragDropComponent.prototype, "attrOnDropTargetLeave", void 0);
    __decorate([
        core_1.Input('restricter')
    ], jqxDragDropComponent.prototype, "attrRestricter", void 0);
    __decorate([
        core_1.Input('revert')
    ], jqxDragDropComponent.prototype, "attrRevert", void 0);
    __decorate([
        core_1.Input('revertDuration')
    ], jqxDragDropComponent.prototype, "attrRevertDuration", void 0);
    __decorate([
        core_1.Input('tolerance')
    ], jqxDragDropComponent.prototype, "attrTolerance", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxDragDropComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxDragDropComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxDragDropComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxDragDropComponent.prototype, "ondragstart", void 0);
    __decorate([
        core_1.Output()
    ], jqxDragDropComponent.prototype, "ondragend", void 0);
    __decorate([
        core_1.Output()
    ], jqxDragDropComponent.prototype, "ondragging", void 0);
    __decorate([
        core_1.Output()
    ], jqxDragDropComponent.prototype, "ondroptargetenter", void 0);
    __decorate([
        core_1.Output()
    ], jqxDragDropComponent.prototype, "ondroptargetleave", void 0);
    jqxDragDropComponent = __decorate([
        core_1.Component({
            selector: 'jqxDragDrop',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxDragDropComponent);
    return jqxDragDropComponent;
}()); //jqxDragDropComponent
exports.jqxDragDropComponent = jqxDragDropComponent;
