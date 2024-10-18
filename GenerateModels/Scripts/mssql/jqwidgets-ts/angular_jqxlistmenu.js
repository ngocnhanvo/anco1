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
require("../jqwidgets/jqxbuttons.js");
require("../jqwidgets/jqxscrollbar.js");
require("../jqwidgets/jqxlistmenu.js");
var core_1 = require("@angular/core");
var jqxListMenuComponent = /** @class */ (function () {
    function jqxListMenuComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['alwaysShowNavigationArrows', 'animationType', 'animationDuration', 'autoSeparators', 'backLabel', 'disabled', 'enableScrolling', 'filterCallback', 'height', 'headerAnimationDuration', 'placeHolder', 'readOnly', 'rtl', 'roundedCorners', 'showNavigationArrows', 'showFilter', 'showHeader', 'showBackButton', 'theme', 'width'];
        this.elementRef = containerElement;
    }
    jqxListMenuComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxListMenuComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxListMenu(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxListMenu(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxListMenu(this.properties[i])) {
                        this.host.jqxListMenu(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxListMenuComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxListMenuComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxListMenuComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxListMenuComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxListMenuComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxListMenu', options);
    };
    jqxListMenuComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxListMenuComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxListMenuComponent.prototype.setOptions = function (options) {
        this.host.jqxListMenu('setOptions', options);
    };
    // jqxListMenuComponent properties
    jqxListMenuComponent.prototype.alwaysShowNavigationArrows = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('alwaysShowNavigationArrows', arg);
        }
        else {
            return this.host.jqxListMenu('alwaysShowNavigationArrows');
        }
    };
    jqxListMenuComponent.prototype.animationType = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('animationType', arg);
        }
        else {
            return this.host.jqxListMenu('animationType');
        }
    };
    jqxListMenuComponent.prototype.animationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('animationDuration', arg);
        }
        else {
            return this.host.jqxListMenu('animationDuration');
        }
    };
    jqxListMenuComponent.prototype.autoSeparators = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('autoSeparators', arg);
        }
        else {
            return this.host.jqxListMenu('autoSeparators');
        }
    };
    jqxListMenuComponent.prototype.backLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('backLabel', arg);
        }
        else {
            return this.host.jqxListMenu('backLabel');
        }
    };
    jqxListMenuComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('disabled', arg);
        }
        else {
            return this.host.jqxListMenu('disabled');
        }
    };
    jqxListMenuComponent.prototype.enableScrolling = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('enableScrolling', arg);
        }
        else {
            return this.host.jqxListMenu('enableScrolling');
        }
    };
    jqxListMenuComponent.prototype.filterCallback = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('filterCallback', arg);
        }
        else {
            return this.host.jqxListMenu('filterCallback');
        }
    };
    jqxListMenuComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('height', arg);
        }
        else {
            return this.host.jqxListMenu('height');
        }
    };
    jqxListMenuComponent.prototype.headerAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('headerAnimationDuration', arg);
        }
        else {
            return this.host.jqxListMenu('headerAnimationDuration');
        }
    };
    jqxListMenuComponent.prototype.placeHolder = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('placeHolder', arg);
        }
        else {
            return this.host.jqxListMenu('placeHolder');
        }
    };
    jqxListMenuComponent.prototype.readOnly = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('readOnly', arg);
        }
        else {
            return this.host.jqxListMenu('readOnly');
        }
    };
    jqxListMenuComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('rtl', arg);
        }
        else {
            return this.host.jqxListMenu('rtl');
        }
    };
    jqxListMenuComponent.prototype.roundedCorners = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('roundedCorners', arg);
        }
        else {
            return this.host.jqxListMenu('roundedCorners');
        }
    };
    jqxListMenuComponent.prototype.showNavigationArrows = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('showNavigationArrows', arg);
        }
        else {
            return this.host.jqxListMenu('showNavigationArrows');
        }
    };
    jqxListMenuComponent.prototype.showFilter = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('showFilter', arg);
        }
        else {
            return this.host.jqxListMenu('showFilter');
        }
    };
    jqxListMenuComponent.prototype.showHeader = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('showHeader', arg);
        }
        else {
            return this.host.jqxListMenu('showHeader');
        }
    };
    jqxListMenuComponent.prototype.showBackButton = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('showBackButton', arg);
        }
        else {
            return this.host.jqxListMenu('showBackButton');
        }
    };
    jqxListMenuComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('theme', arg);
        }
        else {
            return this.host.jqxListMenu('theme');
        }
    };
    jqxListMenuComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxListMenu('width', arg);
        }
        else {
            return this.host.jqxListMenu('width');
        }
    };
    // jqxListMenuComponent functions
    jqxListMenuComponent.prototype.back = function () {
        this.host.jqxListMenu('back');
    };
    jqxListMenuComponent.prototype.changePage = function (Item) {
        this.host.jqxListMenu('changePage', Item);
    };
    jqxListMenuComponent.prototype.destroy = function () {
        this.host.jqxListMenu('destroy');
    };
    jqxListMenuComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('alwaysShowNavigationArrows')
    ], jqxListMenuComponent.prototype, "attrAlwaysShowNavigationArrows", void 0);
    __decorate([
        core_1.Input('animationType')
    ], jqxListMenuComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('animationDuration')
    ], jqxListMenuComponent.prototype, "attrAnimationDuration", void 0);
    __decorate([
        core_1.Input('autoSeparators')
    ], jqxListMenuComponent.prototype, "attrAutoSeparators", void 0);
    __decorate([
        core_1.Input('backLabel')
    ], jqxListMenuComponent.prototype, "attrBackLabel", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxListMenuComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('enableScrolling')
    ], jqxListMenuComponent.prototype, "attrEnableScrolling", void 0);
    __decorate([
        core_1.Input('filterCallback')
    ], jqxListMenuComponent.prototype, "attrFilterCallback", void 0);
    __decorate([
        core_1.Input('headerAnimationDuration')
    ], jqxListMenuComponent.prototype, "attrHeaderAnimationDuration", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxListMenuComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('readOnly')
    ], jqxListMenuComponent.prototype, "attrReadOnly", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxListMenuComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('roundedCorners')
    ], jqxListMenuComponent.prototype, "attrRoundedCorners", void 0);
    __decorate([
        core_1.Input('showNavigationArrows')
    ], jqxListMenuComponent.prototype, "attrShowNavigationArrows", void 0);
    __decorate([
        core_1.Input('showFilter')
    ], jqxListMenuComponent.prototype, "attrShowFilter", void 0);
    __decorate([
        core_1.Input('showHeader')
    ], jqxListMenuComponent.prototype, "attrShowHeader", void 0);
    __decorate([
        core_1.Input('showBackButton')
    ], jqxListMenuComponent.prototype, "attrShowBackButton", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxListMenuComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxListMenuComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxListMenuComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxListMenuComponent.prototype, "autoCreate", void 0);
    jqxListMenuComponent = __decorate([
        core_1.Component({
            selector: 'jqxListMenu',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxListMenuComponent);
    return jqxListMenuComponent;
}()); //jqxListMenuComponent
exports.jqxListMenuComponent = jqxListMenuComponent;
