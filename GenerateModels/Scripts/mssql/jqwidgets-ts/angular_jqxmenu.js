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
require("../jqwidgets/jqxmenu.js");
var core_1 = require("@angular/core");
var jqxMenuComponent = /** @class */ (function () {
    function jqxMenuComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['animationShowDuration', 'animationHideDuration', 'animationHideDelay', 'animationShowDelay', 'autoCloseInterval', 'autoSizeMainItems', 'autoCloseOnClick', 'autoOpenPopup', 'autoOpen', 'autoCloseOnMouseLeave', 'clickToOpen', 'disabled', 'enableHover', 'easing', 'height', 'keyboardNavigation', 'minimizeWidth', 'mode', 'popupZIndex', 'rtl', 'showTopLevelArrows', 'source', 'theme', 'width'];
        // jqxMenuComponent events
        this.onClosed = new core_1.EventEmitter();
        this.onItemclick = new core_1.EventEmitter();
        this.onShown = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxMenuComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxMenuComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxMenu(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxMenu(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxMenu(this.properties[i])) {
                        this.host.jqxMenu(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxMenuComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxMenuComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxMenuComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxMenuComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxMenuComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxMenu', options);
    };
    jqxMenuComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxMenuComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxMenuComponent.prototype.setOptions = function (options) {
        this.host.jqxMenu('setOptions', options);
    };
    // jqxMenuComponent properties
    jqxMenuComponent.prototype.animationShowDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('animationShowDuration', arg);
        }
        else {
            return this.host.jqxMenu('animationShowDuration');
        }
    };
    jqxMenuComponent.prototype.animationHideDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('animationHideDuration', arg);
        }
        else {
            return this.host.jqxMenu('animationHideDuration');
        }
    };
    jqxMenuComponent.prototype.animationHideDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('animationHideDelay', arg);
        }
        else {
            return this.host.jqxMenu('animationHideDelay');
        }
    };
    jqxMenuComponent.prototype.animationShowDelay = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('animationShowDelay', arg);
        }
        else {
            return this.host.jqxMenu('animationShowDelay');
        }
    };
    jqxMenuComponent.prototype.autoCloseInterval = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('autoCloseInterval', arg);
        }
        else {
            return this.host.jqxMenu('autoCloseInterval');
        }
    };
    jqxMenuComponent.prototype.autoSizeMainItems = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('autoSizeMainItems', arg);
        }
        else {
            return this.host.jqxMenu('autoSizeMainItems');
        }
    };
    jqxMenuComponent.prototype.autoCloseOnClick = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('autoCloseOnClick', arg);
        }
        else {
            return this.host.jqxMenu('autoCloseOnClick');
        }
    };
    jqxMenuComponent.prototype.autoOpenPopup = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('autoOpenPopup', arg);
        }
        else {
            return this.host.jqxMenu('autoOpenPopup');
        }
    };
    jqxMenuComponent.prototype.autoOpen = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('autoOpen', arg);
        }
        else {
            return this.host.jqxMenu('autoOpen');
        }
    };
    jqxMenuComponent.prototype.autoCloseOnMouseLeave = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('autoCloseOnMouseLeave', arg);
        }
        else {
            return this.host.jqxMenu('autoCloseOnMouseLeave');
        }
    };
    jqxMenuComponent.prototype.clickToOpen = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('clickToOpen', arg);
        }
        else {
            return this.host.jqxMenu('clickToOpen');
        }
    };
    jqxMenuComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('disabled', arg);
        }
        else {
            return this.host.jqxMenu('disabled');
        }
    };
    jqxMenuComponent.prototype.enableHover = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('enableHover', arg);
        }
        else {
            return this.host.jqxMenu('enableHover');
        }
    };
    jqxMenuComponent.prototype.easing = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('easing', arg);
        }
        else {
            return this.host.jqxMenu('easing');
        }
    };
    jqxMenuComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('height', arg);
        }
        else {
            return this.host.jqxMenu('height');
        }
    };
    jqxMenuComponent.prototype.keyboardNavigation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('keyboardNavigation', arg);
        }
        else {
            return this.host.jqxMenu('keyboardNavigation');
        }
    };
    jqxMenuComponent.prototype.minimizeWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('minimizeWidth', arg);
        }
        else {
            return this.host.jqxMenu('minimizeWidth');
        }
    };
    jqxMenuComponent.prototype.mode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('mode', arg);
        }
        else {
            return this.host.jqxMenu('mode');
        }
    };
    jqxMenuComponent.prototype.popupZIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('popupZIndex', arg);
        }
        else {
            return this.host.jqxMenu('popupZIndex');
        }
    };
    jqxMenuComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('rtl', arg);
        }
        else {
            return this.host.jqxMenu('rtl');
        }
    };
    jqxMenuComponent.prototype.showTopLevelArrows = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('showTopLevelArrows', arg);
        }
        else {
            return this.host.jqxMenu('showTopLevelArrows');
        }
    };
    jqxMenuComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('source', arg);
        }
        else {
            return this.host.jqxMenu('source');
        }
    };
    jqxMenuComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('theme', arg);
        }
        else {
            return this.host.jqxMenu('theme');
        }
    };
    jqxMenuComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxMenu('width', arg);
        }
        else {
            return this.host.jqxMenu('width');
        }
    };
    // jqxMenuComponent functions
    jqxMenuComponent.prototype.closeItem = function (itemID) {
        this.host.jqxMenu('closeItem', itemID);
    };
    jqxMenuComponent.prototype.close = function () {
        this.host.jqxMenu('close');
    };
    jqxMenuComponent.prototype.disable = function (itemID, value) {
        this.host.jqxMenu('disable', itemID, value);
    };
    jqxMenuComponent.prototype.destroy = function () {
        this.host.jqxMenu('destroy');
    };
    jqxMenuComponent.prototype.focus = function () {
        this.host.jqxMenu('focus');
    };
    jqxMenuComponent.prototype.minimize = function () {
        this.host.jqxMenu('minimize');
    };
    jqxMenuComponent.prototype.open = function (left, top) {
        this.host.jqxMenu('open', left, top);
    };
    jqxMenuComponent.prototype.openItem = function (itemID) {
        this.host.jqxMenu('openItem', itemID);
    };
    jqxMenuComponent.prototype.restore = function () {
        this.host.jqxMenu('restore');
    };
    jqxMenuComponent.prototype.setItemOpenDirection = function (item, horizontaldirection, verticaldirection) {
        this.host.jqxMenu('setItemOpenDirection', item, horizontaldirection, verticaldirection);
    };
    jqxMenuComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('closed', function (eventData) { _this.onClosed.emit(eventData); });
        this.host.on('itemclick', function (eventData) { _this.onItemclick.emit(eventData); });
        this.host.on('shown', function (eventData) { _this.onShown.emit(eventData); });
    };
    __decorate([
        core_1.Input('animationShowDuration')
    ], jqxMenuComponent.prototype, "attrAnimationShowDuration", void 0);
    __decorate([
        core_1.Input('animationHideDuration')
    ], jqxMenuComponent.prototype, "attrAnimationHideDuration", void 0);
    __decorate([
        core_1.Input('animationHideDelay')
    ], jqxMenuComponent.prototype, "attrAnimationHideDelay", void 0);
    __decorate([
        core_1.Input('animationShowDelay')
    ], jqxMenuComponent.prototype, "attrAnimationShowDelay", void 0);
    __decorate([
        core_1.Input('autoCloseInterval')
    ], jqxMenuComponent.prototype, "attrAutoCloseInterval", void 0);
    __decorate([
        core_1.Input('autoSizeMainItems')
    ], jqxMenuComponent.prototype, "attrAutoSizeMainItems", void 0);
    __decorate([
        core_1.Input('autoCloseOnClick')
    ], jqxMenuComponent.prototype, "attrAutoCloseOnClick", void 0);
    __decorate([
        core_1.Input('autoOpenPopup')
    ], jqxMenuComponent.prototype, "attrAutoOpenPopup", void 0);
    __decorate([
        core_1.Input('autoOpen')
    ], jqxMenuComponent.prototype, "attrAutoOpen", void 0);
    __decorate([
        core_1.Input('autoCloseOnMouseLeave')
    ], jqxMenuComponent.prototype, "attrAutoCloseOnMouseLeave", void 0);
    __decorate([
        core_1.Input('clickToOpen')
    ], jqxMenuComponent.prototype, "attrClickToOpen", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxMenuComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('enableHover')
    ], jqxMenuComponent.prototype, "attrEnableHover", void 0);
    __decorate([
        core_1.Input('easing')
    ], jqxMenuComponent.prototype, "attrEasing", void 0);
    __decorate([
        core_1.Input('keyboardNavigation')
    ], jqxMenuComponent.prototype, "attrKeyboardNavigation", void 0);
    __decorate([
        core_1.Input('minimizeWidth')
    ], jqxMenuComponent.prototype, "attrMinimizeWidth", void 0);
    __decorate([
        core_1.Input('mode')
    ], jqxMenuComponent.prototype, "attrMode", void 0);
    __decorate([
        core_1.Input('popupZIndex')
    ], jqxMenuComponent.prototype, "attrPopupZIndex", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxMenuComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('showTopLevelArrows')
    ], jqxMenuComponent.prototype, "attrShowTopLevelArrows", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxMenuComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxMenuComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxMenuComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxMenuComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxMenuComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxMenuComponent.prototype, "onClosed", void 0);
    __decorate([
        core_1.Output()
    ], jqxMenuComponent.prototype, "onItemclick", void 0);
    __decorate([
        core_1.Output()
    ], jqxMenuComponent.prototype, "onShown", void 0);
    jqxMenuComponent = __decorate([
        core_1.Component({
            selector: 'jqxMenu',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxMenuComponent);
    return jqxMenuComponent;
}()); //jqxMenuComponent
exports.jqxMenuComponent = jqxMenuComponent;
