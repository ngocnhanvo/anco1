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
require("../jqwidgets/jqxwindow.js");
var core_1 = require("@angular/core");
var jqxWindowComponent = /** @class */ (function () {
    function jqxWindowComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoOpen', 'animationType', 'collapsed', 'collapseAnimationDuration', 'content', 'closeAnimationDuration', 'closeButtonSize', 'closeButtonAction', 'cancelButton', 'dragArea', 'draggable', 'disabled', 'height', 'initContent', 'isModal', 'keyboardCloseKey', 'keyboardNavigation', 'minHeight', 'maxHeight', 'minWidth', 'maxWidth', 'modalOpacity', 'modalZIndex', 'modalBackgroundZIndex', 'okButton', 'position', 'rtl', 'resizable', 'showAnimationDuration', 'showCloseButton', 'showCollapseButton', 'theme', 'title', 'width', 'zIndex'];
        // jqxWindowComponent events
        this.onClose = new core_1.EventEmitter();
        this.onCollapse = new core_1.EventEmitter();
        this.onExpand = new core_1.EventEmitter();
        this.onMoving = new core_1.EventEmitter();
        this.onMoved = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.onResizing = new core_1.EventEmitter();
        this.onResized = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxWindowComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxWindowComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxWindow(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxWindow(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxWindow(this.properties[i])) {
                        this.host.jqxWindow(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxWindowComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxWindowComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxWindowComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxWindowComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxWindowComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxWindow', options);
    };
    jqxWindowComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxWindowComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxWindowComponent.prototype.setOptions = function (options) {
        this.host.jqxWindow('setOptions', options);
    };
    // jqxWindowComponent properties
    jqxWindowComponent.prototype.autoOpen = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('autoOpen', arg);
        }
        else {
            return this.host.jqxWindow('autoOpen');
        }
    };
    jqxWindowComponent.prototype.animationType = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('animationType', arg);
        }
        else {
            return this.host.jqxWindow('animationType');
        }
    };
    jqxWindowComponent.prototype.collapsed = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('collapsed', arg);
        }
        else {
            return this.host.jqxWindow('collapsed');
        }
    };
    jqxWindowComponent.prototype.collapseAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('collapseAnimationDuration', arg);
        }
        else {
            return this.host.jqxWindow('collapseAnimationDuration');
        }
    };
    jqxWindowComponent.prototype.content = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('content', arg);
        }
        else {
            return this.host.jqxWindow('content');
        }
    };
    jqxWindowComponent.prototype.closeAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('closeAnimationDuration', arg);
        }
        else {
            return this.host.jqxWindow('closeAnimationDuration');
        }
    };
    jqxWindowComponent.prototype.closeButtonSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('closeButtonSize', arg);
        }
        else {
            return this.host.jqxWindow('closeButtonSize');
        }
    };
    jqxWindowComponent.prototype.closeButtonAction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('closeButtonAction', arg);
        }
        else {
            return this.host.jqxWindow('closeButtonAction');
        }
    };
    jqxWindowComponent.prototype.cancelButton = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('cancelButton', arg);
        }
        else {
            return this.host.jqxWindow('cancelButton');
        }
    };
    jqxWindowComponent.prototype.dragArea = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('dragArea', arg);
        }
        else {
            return this.host.jqxWindow('dragArea');
        }
    };
    jqxWindowComponent.prototype.draggable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('draggable', arg);
        }
        else {
            return this.host.jqxWindow('draggable');
        }
    };
    jqxWindowComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('disabled', arg);
        }
        else {
            return this.host.jqxWindow('disabled');
        }
    };
    jqxWindowComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('height', arg);
        }
        else {
            return this.host.jqxWindow('height');
        }
    };
    jqxWindowComponent.prototype.initContent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('initContent', arg);
        }
        else {
            return this.host.jqxWindow('initContent');
        }
    };
    jqxWindowComponent.prototype.isModal = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('isModal', arg);
        }
        else {
            return this.host.jqxWindow('isModal');
        }
    };
    jqxWindowComponent.prototype.keyboardCloseKey = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('keyboardCloseKey', arg);
        }
        else {
            return this.host.jqxWindow('keyboardCloseKey');
        }
    };
    jqxWindowComponent.prototype.keyboardNavigation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('keyboardNavigation', arg);
        }
        else {
            return this.host.jqxWindow('keyboardNavigation');
        }
    };
    jqxWindowComponent.prototype.minHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('minHeight', arg);
        }
        else {
            return this.host.jqxWindow('minHeight');
        }
    };
    jqxWindowComponent.prototype.maxHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('maxHeight', arg);
        }
        else {
            return this.host.jqxWindow('maxHeight');
        }
    };
    jqxWindowComponent.prototype.minWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('minWidth', arg);
        }
        else {
            return this.host.jqxWindow('minWidth');
        }
    };
    jqxWindowComponent.prototype.maxWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('maxWidth', arg);
        }
        else {
            return this.host.jqxWindow('maxWidth');
        }
    };
    jqxWindowComponent.prototype.modalOpacity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('modalOpacity', arg);
        }
        else {
            return this.host.jqxWindow('modalOpacity');
        }
    };
    jqxWindowComponent.prototype.modalZIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('modalZIndex', arg);
        }
        else {
            return this.host.jqxWindow('modalZIndex');
        }
    };
    jqxWindowComponent.prototype.modalBackgroundZIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('modalBackgroundZIndex', arg);
        }
        else {
            return this.host.jqxWindow('modalBackgroundZIndex');
        }
    };
    jqxWindowComponent.prototype.okButton = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('okButton', arg);
        }
        else {
            return this.host.jqxWindow('okButton');
        }
    };
    jqxWindowComponent.prototype.position = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('position', arg);
        }
        else {
            return this.host.jqxWindow('position');
        }
    };
    jqxWindowComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('rtl', arg);
        }
        else {
            return this.host.jqxWindow('rtl');
        }
    };
    jqxWindowComponent.prototype.resizable = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('resizable', arg);
        }
        else {
            return this.host.jqxWindow('resizable');
        }
    };
    jqxWindowComponent.prototype.showAnimationDuration = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('showAnimationDuration', arg);
        }
        else {
            return this.host.jqxWindow('showAnimationDuration');
        }
    };
    jqxWindowComponent.prototype.showCloseButton = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('showCloseButton', arg);
        }
        else {
            return this.host.jqxWindow('showCloseButton');
        }
    };
    jqxWindowComponent.prototype.showCollapseButton = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('showCollapseButton', arg);
        }
        else {
            return this.host.jqxWindow('showCollapseButton');
        }
    };
    jqxWindowComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('theme', arg);
        }
        else {
            return this.host.jqxWindow('theme');
        }
    };
    jqxWindowComponent.prototype.title = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('title', arg);
        }
        else {
            return this.host.jqxWindow('title');
        }
    };
    jqxWindowComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('width', arg);
        }
        else {
            return this.host.jqxWindow('width');
        }
    };
    jqxWindowComponent.prototype.zIndex = function (arg) {
        if (arg !== undefined) {
            this.host.jqxWindow('zIndex', arg);
        }
        else {
            return this.host.jqxWindow('zIndex');
        }
    };
    // jqxWindowComponent functions
    jqxWindowComponent.prototype.bringToFront = function () {
        this.host.jqxWindow('bringToFront');
    };
    jqxWindowComponent.prototype.close = function () {
        this.host.jqxWindow('close');
    };
    jqxWindowComponent.prototype.collapse = function () {
        this.host.jqxWindow('collapse');
    };
    jqxWindowComponent.prototype.closeAll = function () {
        this.host.jqxWindow('closeAll');
    };
    jqxWindowComponent.prototype.disable = function () {
        this.host.jqxWindow('disable');
    };
    jqxWindowComponent.prototype.destroy = function () {
        this.host.jqxWindow('destroy');
    };
    jqxWindowComponent.prototype.enable = function () {
        this.host.jqxWindow('enable');
    };
    jqxWindowComponent.prototype.expand = function () {
        this.host.jqxWindow('expand');
    };
    jqxWindowComponent.prototype.focus = function () {
        this.host.jqxWindow('focus');
    };
    jqxWindowComponent.prototype.isOpen = function () {
        return this.host.jqxWindow('isOpen');
    };
    jqxWindowComponent.prototype.move = function (top, left) {
        this.host.jqxWindow('move', top, left);
    };
    jqxWindowComponent.prototype.open = function () {
        this.host.jqxWindow('open');
    };
    jqxWindowComponent.prototype.hide = function () {
        this.host.jqxWindow('hide');
    };
    jqxWindowComponent.prototype.resize = function (top, left) {
        this.host.jqxWindow('resize', top, left);
    };
    jqxWindowComponent.prototype.setTitle = function (title) {
        this.host.jqxWindow('setTitle', title);
    };
    jqxWindowComponent.prototype.setContent = function (content) {
        this.host.jqxWindow('setContent', content);
    };
    jqxWindowComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
        this.host.on('collapse', function (eventData) { _this.onCollapse.emit(eventData); });
        this.host.on('expand', function (eventData) { _this.onExpand.emit(eventData); });
        this.host.on('moving', function (eventData) { _this.onMoving.emit(eventData); });
        this.host.on('moved', function (eventData) { _this.onMoved.emit(eventData); });
        this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        this.host.on('resizing', function (eventData) { _this.onResizing.emit(eventData); });
        this.host.on('resized', function (eventData) { _this.onResized.emit(eventData); });
    };
    __decorate([
        core_1.Input('autoOpen')
    ], jqxWindowComponent.prototype, "attrAutoOpen", void 0);
    __decorate([
        core_1.Input('animationType')
    ], jqxWindowComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('collapsed')
    ], jqxWindowComponent.prototype, "attrCollapsed", void 0);
    __decorate([
        core_1.Input('collapseAnimationDuration')
    ], jqxWindowComponent.prototype, "attrCollapseAnimationDuration", void 0);
    __decorate([
        core_1.Input('content')
    ], jqxWindowComponent.prototype, "attrContent", void 0);
    __decorate([
        core_1.Input('closeAnimationDuration')
    ], jqxWindowComponent.prototype, "attrCloseAnimationDuration", void 0);
    __decorate([
        core_1.Input('closeButtonSize')
    ], jqxWindowComponent.prototype, "attrCloseButtonSize", void 0);
    __decorate([
        core_1.Input('closeButtonAction')
    ], jqxWindowComponent.prototype, "attrCloseButtonAction", void 0);
    __decorate([
        core_1.Input('cancelButton')
    ], jqxWindowComponent.prototype, "attrCancelButton", void 0);
    __decorate([
        core_1.Input('dragArea')
    ], jqxWindowComponent.prototype, "attrDragArea", void 0);
    __decorate([
        core_1.Input('draggable')
    ], jqxWindowComponent.prototype, "attrDraggable", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxWindowComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('initContent')
    ], jqxWindowComponent.prototype, "attrInitContent", void 0);
    __decorate([
        core_1.Input('isModal')
    ], jqxWindowComponent.prototype, "attrIsModal", void 0);
    __decorate([
        core_1.Input('keyboardCloseKey')
    ], jqxWindowComponent.prototype, "attrKeyboardCloseKey", void 0);
    __decorate([
        core_1.Input('keyboardNavigation')
    ], jqxWindowComponent.prototype, "attrKeyboardNavigation", void 0);
    __decorate([
        core_1.Input('minHeight')
    ], jqxWindowComponent.prototype, "attrMinHeight", void 0);
    __decorate([
        core_1.Input('maxHeight')
    ], jqxWindowComponent.prototype, "attrMaxHeight", void 0);
    __decorate([
        core_1.Input('minWidth')
    ], jqxWindowComponent.prototype, "attrMinWidth", void 0);
    __decorate([
        core_1.Input('maxWidth')
    ], jqxWindowComponent.prototype, "attrMaxWidth", void 0);
    __decorate([
        core_1.Input('modalOpacity')
    ], jqxWindowComponent.prototype, "attrModalOpacity", void 0);
    __decorate([
        core_1.Input('modalZIndex')
    ], jqxWindowComponent.prototype, "attrModalZIndex", void 0);
    __decorate([
        core_1.Input('modalBackgroundZIndex')
    ], jqxWindowComponent.prototype, "attrModalBackgroundZIndex", void 0);
    __decorate([
        core_1.Input('okButton')
    ], jqxWindowComponent.prototype, "attrOkButton", void 0);
    __decorate([
        core_1.Input('position')
    ], jqxWindowComponent.prototype, "attrPosition", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxWindowComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('resizable')
    ], jqxWindowComponent.prototype, "attrResizable", void 0);
    __decorate([
        core_1.Input('showAnimationDuration')
    ], jqxWindowComponent.prototype, "attrShowAnimationDuration", void 0);
    __decorate([
        core_1.Input('showCloseButton')
    ], jqxWindowComponent.prototype, "attrShowCloseButton", void 0);
    __decorate([
        core_1.Input('showCollapseButton')
    ], jqxWindowComponent.prototype, "attrShowCollapseButton", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxWindowComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('title')
    ], jqxWindowComponent.prototype, "attrTitle", void 0);
    __decorate([
        core_1.Input('zIndex')
    ], jqxWindowComponent.prototype, "attrZIndex", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxWindowComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxWindowComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxWindowComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onCollapse", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onExpand", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onMoving", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onMoved", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onResizing", void 0);
    __decorate([
        core_1.Output()
    ], jqxWindowComponent.prototype, "onResized", void 0);
    jqxWindowComponent = __decorate([
        core_1.Component({
            selector: 'jqxWindow',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxWindowComponent);
    return jqxWindowComponent;
}()); //jqxWindowComponent
exports.jqxWindowComponent = jqxWindowComponent;
