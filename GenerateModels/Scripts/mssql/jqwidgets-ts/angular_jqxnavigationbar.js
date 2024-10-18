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
require("../jqwidgets/jqxnavigationbar.js");
var core_1 = require("@angular/core");
var jqxNavigationBarComponent = /** @class */ (function () {
    function jqxNavigationBarComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['animationType', 'arrowPosition', 'collapseAnimationDuration', 'disabled', 'expandAnimationDuration', 'expandMode', 'expandedIndexes', 'height', 'initContent', 'rtl', 'showArrow', 'theme', 'toggleMode', 'width'];
        // jqxNavigationBarComponent events
        this.onCollapsingItem = new core_1.EventEmitter();
        this.onCollapsedItem = new core_1.EventEmitter();
        this.onExpandingItem = new core_1.EventEmitter();
        this.onExpandedItem = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxNavigationBarComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxNavigationBarComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxNavigationBar(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxNavigationBar(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxNavigationBar(this.properties[i])) {
                        this.host.jqxNavigationBar(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxNavigationBarComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxNavigationBarComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxNavigationBarComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxNavigationBarComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxNavigationBarComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxNavigationBar', options);
    };
    jqxNavigationBarComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxNavigationBarComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxNavigationBarComponent.prototype.setOptions = function (options) {
        this.host.jqxNavigationBar('setOptions', options);
    };
    // jqxNavigationBarComponent properties
    jqxNavigationBarComponent.prototype.animationType = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('animationType', arg);
        }
        else {
            return this.host.jqxNavigationBar('animationType');
        }
    };
    jqxNavigationBarComponent.prototype.arrowPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('arrowPosition', arg);
        }
        else {
            return this.host.jqxNavigationBar('arrowPosition');
        }
    };
    jqxNavigationBarComponent.prototype.collapseAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('collapseAnimationDuration', arg);
        }
        else {
            return this.host.jqxNavigationBar('collapseAnimationDuration');
        }
    };
    jqxNavigationBarComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('disabled', arg);
        }
        else {
            return this.host.jqxNavigationBar('disabled');
        }
    };
    jqxNavigationBarComponent.prototype.expandAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('expandAnimationDuration', arg);
        }
        else {
            return this.host.jqxNavigationBar('expandAnimationDuration');
        }
    };
    jqxNavigationBarComponent.prototype.expandMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('expandMode', arg);
        }
        else {
            return this.host.jqxNavigationBar('expandMode');
        }
    };
    jqxNavigationBarComponent.prototype.expandedIndexes = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('expandedIndexes', arg);
        }
        else {
            return this.host.jqxNavigationBar('expandedIndexes');
        }
    };
    jqxNavigationBarComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('height', arg);
        }
        else {
            return this.host.jqxNavigationBar('height');
        }
    };
    jqxNavigationBarComponent.prototype.initContent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('initContent', arg);
        }
        else {
            return this.host.jqxNavigationBar('initContent');
        }
    };
    jqxNavigationBarComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('rtl', arg);
        }
        else {
            return this.host.jqxNavigationBar('rtl');
        }
    };
    jqxNavigationBarComponent.prototype.showArrow = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('showArrow', arg);
        }
        else {
            return this.host.jqxNavigationBar('showArrow');
        }
    };
    jqxNavigationBarComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('theme', arg);
        }
        else {
            return this.host.jqxNavigationBar('theme');
        }
    };
    jqxNavigationBarComponent.prototype.toggleMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('toggleMode', arg);
        }
        else {
            return this.host.jqxNavigationBar('toggleMode');
        }
    };
    jqxNavigationBarComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxNavigationBar('width', arg);
        }
        else {
            return this.host.jqxNavigationBar('width');
        }
    };
    // jqxNavigationBarComponent functions
    jqxNavigationBarComponent.prototype.add = function (header, content) {
        this.host.jqxNavigationBar('add', header, content);
    };
    jqxNavigationBarComponent.prototype.collapseAt = function (index) {
        this.host.jqxNavigationBar('collapseAt', index);
    };
    jqxNavigationBarComponent.prototype.disableAt = function (index) {
        this.host.jqxNavigationBar('disableAt', index);
    };
    jqxNavigationBarComponent.prototype.disable = function () {
        this.host.jqxNavigationBar('disable');
    };
    jqxNavigationBarComponent.prototype.destroy = function () {
        this.host.jqxNavigationBar('destroy');
    };
    jqxNavigationBarComponent.prototype.expandAt = function (index) {
        this.host.jqxNavigationBar('expandAt', index);
    };
    jqxNavigationBarComponent.prototype.enableAt = function (index) {
        this.host.jqxNavigationBar('enableAt', index);
    };
    jqxNavigationBarComponent.prototype.enable = function () {
        this.host.jqxNavigationBar('enable');
    };
    jqxNavigationBarComponent.prototype.focus = function () {
        this.host.jqxNavigationBar('focus');
    };
    jqxNavigationBarComponent.prototype.getHeaderContentAt = function (index) {
        return this.host.jqxNavigationBar('getHeaderContentAt', index);
    };
    jqxNavigationBarComponent.prototype.getContentAt = function (index) {
        return this.host.jqxNavigationBar('getContentAt', index);
    };
    jqxNavigationBarComponent.prototype.hideArrowAt = function (index) {
        this.host.jqxNavigationBar('hideArrowAt', index);
    };
    jqxNavigationBarComponent.prototype.invalidate = function () {
        this.host.jqxNavigationBar('invalidate');
    };
    jqxNavigationBarComponent.prototype.insert = function (Index, header, content) {
        this.host.jqxNavigationBar('insert', Index, header, content);
    };
    jqxNavigationBarComponent.prototype.refresh = function () {
        this.host.jqxNavigationBar('refresh');
    };
    jqxNavigationBarComponent.prototype.render = function () {
        this.host.jqxNavigationBar('render');
    };
    jqxNavigationBarComponent.prototype.remove = function (index) {
        this.host.jqxNavigationBar('remove', index);
    };
    jqxNavigationBarComponent.prototype.setContentAt = function (index, item) {
        this.host.jqxNavigationBar('setContentAt', index, item);
    };
    jqxNavigationBarComponent.prototype.setHeaderContentAt = function (index, item) {
        this.host.jqxNavigationBar('setHeaderContentAt', index, item);
    };
    jqxNavigationBarComponent.prototype.showArrowAt = function (index) {
        this.host.jqxNavigationBar('showArrowAt', index);
    };
    jqxNavigationBarComponent.prototype.update = function (index, header, content) {
        this.host.jqxNavigationBar('update', index, header, content);
    };
    jqxNavigationBarComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxNavigationBar('val', value);
        }
        else {
            return this.host.jqxNavigationBar('val');
        }
    };
    ;
    jqxNavigationBarComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('collapsingItem', function (eventData) { _this.onCollapsingItem.emit(eventData); });
        this.host.on('collapsedItem', function (eventData) { _this.onCollapsedItem.emit(eventData); });
        this.host.on('expandingItem', function (eventData) { _this.onExpandingItem.emit(eventData); });
        this.host.on('expandedItem', function (eventData) { _this.onExpandedItem.emit(eventData); });
    };
    __decorate([
        core_1.Input('animationType')
    ], jqxNavigationBarComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('arrowPosition')
    ], jqxNavigationBarComponent.prototype, "attrArrowPosition", void 0);
    __decorate([
        core_1.Input('collapseAnimationDuration')
    ], jqxNavigationBarComponent.prototype, "attrCollapseAnimationDuration", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxNavigationBarComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('expandAnimationDuration')
    ], jqxNavigationBarComponent.prototype, "attrExpandAnimationDuration", void 0);
    __decorate([
        core_1.Input('expandMode')
    ], jqxNavigationBarComponent.prototype, "attrExpandMode", void 0);
    __decorate([
        core_1.Input('expandedIndexes')
    ], jqxNavigationBarComponent.prototype, "attrExpandedIndexes", void 0);
    __decorate([
        core_1.Input('initContent')
    ], jqxNavigationBarComponent.prototype, "attrInitContent", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxNavigationBarComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('showArrow')
    ], jqxNavigationBarComponent.prototype, "attrShowArrow", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxNavigationBarComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('toggleMode')
    ], jqxNavigationBarComponent.prototype, "attrToggleMode", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxNavigationBarComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxNavigationBarComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxNavigationBarComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxNavigationBarComponent.prototype, "onCollapsingItem", void 0);
    __decorate([
        core_1.Output()
    ], jqxNavigationBarComponent.prototype, "onCollapsedItem", void 0);
    __decorate([
        core_1.Output()
    ], jqxNavigationBarComponent.prototype, "onExpandingItem", void 0);
    __decorate([
        core_1.Output()
    ], jqxNavigationBarComponent.prototype, "onExpandedItem", void 0);
    jqxNavigationBarComponent = __decorate([
        core_1.Component({
            selector: 'jqxNavigationBar',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxNavigationBarComponent);
    return jqxNavigationBarComponent;
}()); //jqxNavigationBarComponent
exports.jqxNavigationBarComponent = jqxNavigationBarComponent;
