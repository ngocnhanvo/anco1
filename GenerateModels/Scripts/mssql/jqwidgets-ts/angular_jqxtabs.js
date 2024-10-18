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
require("../jqwidgets/jqxtabs.js");
var core_1 = require("@angular/core");
var jqxTabsComponent = /** @class */ (function () {
    function jqxTabsComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['animationType', 'autoHeight', 'closeButtonSize', 'collapsible', 'contentTransitionDuration', 'disabled', 'enabledHover', 'enableScrollAnimation', 'enableDropAnimation', 'height', 'initTabContent', 'keyboardNavigation', 'next', 'previous', 'position', 'reorder', 'rtl', 'scrollAnimationDuration', 'selectedItem', 'selectionTracker', 'scrollable', 'scrollPosition', 'scrollStep', 'showCloseButtons', 'toggleMode', 'theme', 'width'];
        // jqxTabsComponent events
        this.onAdd = new core_1.EventEmitter();
        this.onCollapsed = new core_1.EventEmitter();
        this.onDragStart = new core_1.EventEmitter();
        this.onDragEnd = new core_1.EventEmitter();
        this.onExpanded = new core_1.EventEmitter();
        this.onRemoved = new core_1.EventEmitter();
        this.onSelecting = new core_1.EventEmitter();
        this.onSelected = new core_1.EventEmitter();
        this.onTabclick = new core_1.EventEmitter();
        this.onUnselecting = new core_1.EventEmitter();
        this.onUnselected = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxTabsComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxTabsComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxTabs(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxTabs(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxTabs(this.properties[i])) {
                        this.host.jqxTabs(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxTabsComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxTabsComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxTabsComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxTabsComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxTabsComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxTabs', options);
    };
    jqxTabsComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxTabsComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxTabsComponent.prototype.setOptions = function (options) {
        this.host.jqxTabs('setOptions', options);
    };
    // jqxTabsComponent properties
    jqxTabsComponent.prototype.animationType = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('animationType', arg);
        }
        else {
            return this.host.jqxTabs('animationType');
        }
    };
    jqxTabsComponent.prototype.autoHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('autoHeight', arg);
        }
        else {
            return this.host.jqxTabs('autoHeight');
        }
    };
    jqxTabsComponent.prototype.closeButtonSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('closeButtonSize', arg);
        }
        else {
            return this.host.jqxTabs('closeButtonSize');
        }
    };
    jqxTabsComponent.prototype.collapsible = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('collapsible', arg);
        }
        else {
            return this.host.jqxTabs('collapsible');
        }
    };
    jqxTabsComponent.prototype.contentTransitionDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('contentTransitionDuration', arg);
        }
        else {
            return this.host.jqxTabs('contentTransitionDuration');
        }
    };
    jqxTabsComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('disabled', arg);
        }
        else {
            return this.host.jqxTabs('disabled');
        }
    };
    jqxTabsComponent.prototype.enabledHover = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('enabledHover', arg);
        }
        else {
            return this.host.jqxTabs('enabledHover');
        }
    };
    jqxTabsComponent.prototype.enableScrollAnimation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('enableScrollAnimation', arg);
        }
        else {
            return this.host.jqxTabs('enableScrollAnimation');
        }
    };
    jqxTabsComponent.prototype.enableDropAnimation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('enableDropAnimation', arg);
        }
        else {
            return this.host.jqxTabs('enableDropAnimation');
        }
    };
    jqxTabsComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('height', arg);
        }
        else {
            return this.host.jqxTabs('height');
        }
    };
    jqxTabsComponent.prototype.initTabContent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('initTabContent', arg);
        }
        else {
            return this.host.jqxTabs('initTabContent');
        }
    };
    jqxTabsComponent.prototype.keyboardNavigation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('keyboardNavigation', arg);
        }
        else {
            return this.host.jqxTabs('keyboardNavigation');
        }
    };
    jqxTabsComponent.prototype.next = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('next', arg);
        }
        else {
            return this.host.jqxTabs('next');
        }
    };
    jqxTabsComponent.prototype.previous = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('previous', arg);
        }
        else {
            return this.host.jqxTabs('previous');
        }
    };
    jqxTabsComponent.prototype.position = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('position', arg);
        }
        else {
            return this.host.jqxTabs('position');
        }
    };
    jqxTabsComponent.prototype.reorder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('reorder', arg);
        }
        else {
            return this.host.jqxTabs('reorder');
        }
    };
    jqxTabsComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('rtl', arg);
        }
        else {
            return this.host.jqxTabs('rtl');
        }
    };
    jqxTabsComponent.prototype.scrollAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('scrollAnimationDuration', arg);
        }
        else {
            return this.host.jqxTabs('scrollAnimationDuration');
        }
    };
    jqxTabsComponent.prototype.selectedItem = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('selectedItem', arg);
        }
        else {
            return this.host.jqxTabs('selectedItem');
        }
    };
    jqxTabsComponent.prototype.selectionTracker = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('selectionTracker', arg);
        }
        else {
            return this.host.jqxTabs('selectionTracker');
        }
    };
    jqxTabsComponent.prototype.scrollable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('scrollable', arg);
        }
        else {
            return this.host.jqxTabs('scrollable');
        }
    };
    jqxTabsComponent.prototype.scrollPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('scrollPosition', arg);
        }
        else {
            return this.host.jqxTabs('scrollPosition');
        }
    };
    jqxTabsComponent.prototype.scrollStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('scrollStep', arg);
        }
        else {
            return this.host.jqxTabs('scrollStep');
        }
    };
    jqxTabsComponent.prototype.showCloseButtons = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('showCloseButtons', arg);
        }
        else {
            return this.host.jqxTabs('showCloseButtons');
        }
    };
    jqxTabsComponent.prototype.toggleMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('toggleMode', arg);
        }
        else {
            return this.host.jqxTabs('toggleMode');
        }
    };
    jqxTabsComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('theme', arg);
        }
        else {
            return this.host.jqxTabs('theme');
        }
    };
    jqxTabsComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTabs('width', arg);
        }
        else {
            return this.host.jqxTabs('width');
        }
    };
    // jqxTabsComponent functions
    jqxTabsComponent.prototype.addAt = function (index, title, content) {
        this.host.jqxTabs('addAt', index, title, content);
    };
    jqxTabsComponent.prototype.addFirst = function (htmlElement1, htmlElement2) {
        this.host.jqxTabs('addFirst', htmlElement1, htmlElement2);
    };
    jqxTabsComponent.prototype.addLast = function (htmlElement1, htmlElement2) {
        this.host.jqxTabs('addLast', htmlElement1, htmlElement2);
    };
    jqxTabsComponent.prototype.collapse = function () {
        this.host.jqxTabs('collapse');
    };
    jqxTabsComponent.prototype.disable = function () {
        this.host.jqxTabs('disable');
    };
    jqxTabsComponent.prototype.disableAt = function (index) {
        this.host.jqxTabs('disableAt', index);
    };
    jqxTabsComponent.prototype.destroy = function () {
        this.host.jqxTabs('destroy');
    };
    jqxTabsComponent.prototype.ensureVisible = function (index) {
        this.host.jqxTabs('ensureVisible', index);
    };
    jqxTabsComponent.prototype.enableAt = function (index) {
        this.host.jqxTabs('enableAt', index);
    };
    jqxTabsComponent.prototype.expand = function () {
        this.host.jqxTabs('expand');
    };
    jqxTabsComponent.prototype.enable = function () {
        this.host.jqxTabs('enable');
    };
    jqxTabsComponent.prototype.focus = function () {
        this.host.jqxTabs('focus');
    };
    jqxTabsComponent.prototype.getTitleAt = function (index) {
        return this.host.jqxTabs('getTitleAt', index);
    };
    jqxTabsComponent.prototype.getContentAt = function (index) {
        return this.host.jqxTabs('getContentAt', index);
    };
    jqxTabsComponent.prototype.getDisabledTabsCount = function () {
        return this.host.jqxTabs('getDisabledTabsCount');
    };
    jqxTabsComponent.prototype.hideCloseButtonAt = function (index) {
        this.host.jqxTabs('hideCloseButtonAt', index);
    };
    jqxTabsComponent.prototype.hideAllCloseButtons = function () {
        this.host.jqxTabs('hideAllCloseButtons');
    };
    jqxTabsComponent.prototype.length = function () {
        return this.host.jqxTabs('length');
    };
    jqxTabsComponent.prototype.removeAt = function (index) {
        this.host.jqxTabs('removeAt', index);
    };
    jqxTabsComponent.prototype.removeFirst = function () {
        this.host.jqxTabs('removeFirst');
    };
    jqxTabsComponent.prototype.removeLast = function () {
        this.host.jqxTabs('removeLast');
    };
    jqxTabsComponent.prototype.select = function (index) {
        this.host.jqxTabs('select', index);
    };
    jqxTabsComponent.prototype.setContentAt = function (index, htmlElement) {
        this.host.jqxTabs('setContentAt', index, htmlElement);
    };
    jqxTabsComponent.prototype.setTitleAt = function (index, htmlElement) {
        this.host.jqxTabs('setTitleAt', index, htmlElement);
    };
    jqxTabsComponent.prototype.showCloseButtonAt = function (index) {
        this.host.jqxTabs('showCloseButtonAt', index);
    };
    jqxTabsComponent.prototype.showAllCloseButtons = function () {
        this.host.jqxTabs('showAllCloseButtons');
    };
    jqxTabsComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxTabs('val', value);
        }
        else {
            return this.host.jqxTabs('val');
        }
    };
    ;
    jqxTabsComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('add', function (eventData) { _this.onAdd.emit(eventData); });
        this.host.on('collapsed', function (eventData) { _this.onCollapsed.emit(eventData); });
        this.host.on('dragStart', function (eventData) { _this.onDragStart.emit(eventData); });
        this.host.on('dragEnd', function (eventData) { _this.onDragEnd.emit(eventData); });
        this.host.on('expanded', function (eventData) { _this.onExpanded.emit(eventData); });
        this.host.on('removed', function (eventData) { _this.onRemoved.emit(eventData); });
        this.host.on('selecting', function (eventData) { _this.onSelecting.emit(eventData); });
        this.host.on('selected', function (eventData) { _this.onSelected.emit(eventData); });
        this.host.on('tabclick', function (eventData) { _this.onTabclick.emit(eventData); });
        this.host.on('unselecting', function (eventData) { _this.onUnselecting.emit(eventData); });
        this.host.on('unselected', function (eventData) { _this.onUnselected.emit(eventData); });
    };
    __decorate([
        core_1.Input('animationType')
    ], jqxTabsComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('autoHeight')
    ], jqxTabsComponent.prototype, "attrAutoHeight", void 0);
    __decorate([
        core_1.Input('closeButtonSize')
    ], jqxTabsComponent.prototype, "attrCloseButtonSize", void 0);
    __decorate([
        core_1.Input('collapsible')
    ], jqxTabsComponent.prototype, "attrCollapsible", void 0);
    __decorate([
        core_1.Input('contentTransitionDuration')
    ], jqxTabsComponent.prototype, "attrContentTransitionDuration", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxTabsComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('enabledHover')
    ], jqxTabsComponent.prototype, "attrEnabledHover", void 0);
    __decorate([
        core_1.Input('enableScrollAnimation')
    ], jqxTabsComponent.prototype, "attrEnableScrollAnimation", void 0);
    __decorate([
        core_1.Input('enableDropAnimation')
    ], jqxTabsComponent.prototype, "attrEnableDropAnimation", void 0);
    __decorate([
        core_1.Input('initTabContent')
    ], jqxTabsComponent.prototype, "attrInitTabContent", void 0);
    __decorate([
        core_1.Input('keyboardNavigation')
    ], jqxTabsComponent.prototype, "attrKeyboardNavigation", void 0);
    __decorate([
        core_1.Input('next')
    ], jqxTabsComponent.prototype, "attrNext", void 0);
    __decorate([
        core_1.Input('previous')
    ], jqxTabsComponent.prototype, "attrPrevious", void 0);
    __decorate([
        core_1.Input('position')
    ], jqxTabsComponent.prototype, "attrPosition", void 0);
    __decorate([
        core_1.Input('reorder')
    ], jqxTabsComponent.prototype, "attrReorder", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxTabsComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('scrollAnimationDuration')
    ], jqxTabsComponent.prototype, "attrScrollAnimationDuration", void 0);
    __decorate([
        core_1.Input('selectedItem')
    ], jqxTabsComponent.prototype, "attrSelectedItem", void 0);
    __decorate([
        core_1.Input('selectionTracker')
    ], jqxTabsComponent.prototype, "attrSelectionTracker", void 0);
    __decorate([
        core_1.Input('scrollable')
    ], jqxTabsComponent.prototype, "attrScrollable", void 0);
    __decorate([
        core_1.Input('scrollPosition')
    ], jqxTabsComponent.prototype, "attrScrollPosition", void 0);
    __decorate([
        core_1.Input('scrollStep')
    ], jqxTabsComponent.prototype, "attrScrollStep", void 0);
    __decorate([
        core_1.Input('showCloseButtons')
    ], jqxTabsComponent.prototype, "attrShowCloseButtons", void 0);
    __decorate([
        core_1.Input('toggleMode')
    ], jqxTabsComponent.prototype, "attrToggleMode", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxTabsComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxTabsComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxTabsComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxTabsComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onAdd", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onCollapsed", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onDragStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onDragEnd", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onExpanded", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onRemoved", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onSelecting", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onSelected", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onTabclick", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onUnselecting", void 0);
    __decorate([
        core_1.Output()
    ], jqxTabsComponent.prototype, "onUnselected", void 0);
    jqxTabsComponent = __decorate([
        core_1.Component({
            selector: 'jqxTabs',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxTabsComponent);
    return jqxTabsComponent;
}()); //jqxTabsComponent
exports.jqxTabsComponent = jqxTabsComponent;
